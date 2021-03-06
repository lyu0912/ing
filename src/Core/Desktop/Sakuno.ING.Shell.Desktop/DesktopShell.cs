﻿using System;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using Sakuno.ING.Composition;
using Sakuno.ING.Localization;
using Sakuno.ING.Settings;
using Sakuno.ING.Shell.Layout;
using Sakuno.UserInterface;
using Sakuno.UserInterface.Controls;

namespace Sakuno.ING.Shell.Desktop
{
    [Export(typeof(IShell))]
    internal class DesktopShell : FlexibleShell, IShell
    {
        private readonly LayoutSetting layoutSetting;
        private readonly ILocalizationService localization;
        private readonly string localeName;
        private readonly FontFamily userFont;
        private LayoutRoot layout;

        public DesktopShell(LayoutSetting layoutSetting, ILocalizationService localization, LocaleSetting locale)
            : base(localization)
        {
            this.layoutSetting = layoutSetting;
            this.localization = localization;
            localeName = locale.Language.Value;
            var userFontName = locale.UserLanguageFont.Value;
            if (!string.IsNullOrEmpty(userFontName))
                userFont = new FontFamily(userFontName);
        }

        public event Action Exited;

        public void Run()
        {
            var app = new ThemedApp
            {
                ShutdownMode = ShutdownMode.OnMainWindowClose
            };

            app.Startup += (s, e) =>
            {
                Window window;
                try
                {
                    if (layoutSetting.XamlString.Value.IsNullOrEmpty())
                        LayoutFallback();
                    else
                        layout = (LayoutRoot)XamlReader.Parse(layoutSetting.XamlString.Value);
                }
                catch
                {
                    LayoutFallback();
                }

                layoutSetting.LayoutScale.ValueChanged += UpdateScale;
                UpdateScale(layoutSetting.LayoutScale.Value);

                window = new MainWindow { MainContent = layout.MainWindow.LoadContent() };
                InitializeAndShow(window);
                Application.Current.MainWindow = window;

                void LayoutFallback()
                    => layout = (LayoutRoot)Application.LoadComponent(new Uri("/Sakuno.ING.Shell.Desktop;component/Layout/Default.xaml", UriKind.Relative));
            };

            app.Exit += (s, e) => Exited?.Invoke();
            app.Run();
        }

        private void UpdateScale(float scale)
        {
            if (scale < 0.25f) scale = 0.25f;
            if (scale > 4) scale = 4;
            var transform = new ScaleTransform(scale, scale);
            transform.Freeze();
            Application.Current.Resources["LayoutScale"] = transform;
        }

        private void InitializeAndShow(Window window)
        {
            if (!string.IsNullOrEmpty(localeName))
                window.Language = XmlLanguage.GetLanguage(localeName);
            if (userFont != null)
                window.FontFamily = userFont;
            window.Show();
            window.Activate();
        }

        public void SwitchWindow(string windowId)
        {
            var windows = Application.Current.Windows;
            for (int i = 0; i < windows.Count; i++)
            {
                var w = windows[i];
                if (windowId.Equals(w.Tag))
                {
                    w.Activate();
                    return;
                }
            }

            if (windowId == "Settings")
            {
                var w = new SettingsWindow { DataContext = CreateSettingViews() };
                InitializeAndShow(w);
                w.Show();
                w.Activate();
            }

            var windowContent = layout[windowId]?.LoadContent()
                ?? Compositor.Default.TryResolveView(windowId);

            if (windowContent != null)
            {
                var w = new ModernWindow
                {
                    Tag = windowId,
                    Title = localization.GetLocalized("ViewTitle", windowId) ?? windowId,
                    Content = windowContent
                };
                InitializeAndShow(w);
            }
        }

        public void ShowViewWithParameter<T>(string viewId, T parameter)
        {
            if (Compositor.Default.ViewTypes.TryGetValue(viewId, out var type))
                InitializeAndShow(new ModernWindow
                {
                    Title = localization.GetLocalized("ViewTitle", viewId) ?? viewId,
                    Content = Compositor.Default.ResolveWithParameter(type, parameter)
                });
        }
    }
}
