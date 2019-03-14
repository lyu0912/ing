﻿Imports Windows.UI.Xaml.Markup

<ContentProperty(Name:=NameOf(TypeTemplateSelector.Selections))>
Public Class TypeTemplateSelector
    Inherits DataTemplateSelector

    Public ReadOnly Property Selections As New List(Of TypeTemplateSelection)
    Public Property Fallback As DataTemplate
    Protected Overrides Function SelectTemplateCore(item As Object, container As DependencyObject) As DataTemplate
        Return SelectTemplateCore(item)
    End Function
    Protected Overrides Function SelectTemplateCore(item As Object) As DataTemplate
        If item Is Nothing Then Return Nothing
        Dim type = item.GetType()
        For Each s In Selections
            If s.Type = type Then Return s.Template
        Next
        Return Fallback
    End Function
End Class

<ContentProperty(Name:=NameOf(TypeTemplateSelection.Template))>
Public Class TypeTemplateSelection
    Public Property Type As Type
    Public Property Template As DataTemplate
End Class