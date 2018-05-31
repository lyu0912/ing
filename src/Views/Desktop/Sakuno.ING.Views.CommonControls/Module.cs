﻿using Sakuno.ING.Composition;
using Sakuno.ING.Localization;

namespace Sakuno.ING.Views
{
    internal class Module : IModule
    {
        public void Initialize(IResolver resolver)
        {
            LocalizeExtension.Service = resolver.Resolve<ILocalizationService>();
            ResolveExtension.Resolver = resolver;
        }
    }
}
