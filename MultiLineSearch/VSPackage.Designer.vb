﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.8000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System


'This class was auto-generated by the StronglyTypedResourceBuilder
'class via a tool like ResGen or Visual Studio.
'To add or remove a member, edit your .ResX file then rerun ResGen
'with the /str option, or rebuild your VS project.
'''<summary>
'''  A strongly-typed resource class, for looking up localized strings, etc.
'''</summary>
<Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"),  _
 Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
 Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
Friend Class VSPackage
    
    Private Shared resourceMan As Global.System.Resources.ResourceManager
    
    Private Shared resourceCulture As Global.System.Globalization.CultureInfo
    
    <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
    Friend Sub New()
        MyBase.New
    End Sub
    
    '''<summary>
    '''  Returns the cached ResourceManager instance used by this class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
        Get
            If Object.ReferenceEquals(resourceMan, Nothing) Then
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Helixoft.MultiLineSearch.VSPackage", GetType(VSPackage).Assembly)
                resourceMan = temp
            End If
            Return resourceMan
        End Get
    End Property
    
    '''<summary>
    '''  Overrides the current thread's CurrentUICulture property for all
    '''  resource lookups using this strongly typed resource class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
        Get
            Return resourceCulture
        End Get
        Set
            resourceCulture = value
        End Set
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to HIK1KID0MEEQHRJRPQCTKHQ0RAADCPP8PZRTJMDRHDDIPECIIZZZCTCREDQ0RIEEZCMJDJZ9RRERA2PIZRCRPAQHPRARKDQZE3QJI3MACIMZD3QEEQEZRAC3J0QDCMEC.
    '''</summary>
    Friend Shared ReadOnly Property _1() As String
        Get
            Return ResourceManager.GetString("1", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Multiline Search and Replace.
    '''</summary>
    Friend Shared ReadOnly Property _110() As String
        Get
            Return ResourceManager.GetString("110", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Adds multiline search and replace functionality to Visual Studio..
    '''</summary>
    Friend Shared ReadOnly Property _112() As String
        Get
            Return ResourceManager.GetString("112", resourceCulture)
        End Get
    End Property
    
    Friend Shared ReadOnly Property _301() As System.Drawing.Bitmap
        Get
            Dim obj As Object = ResourceManager.GetObject("301", resourceCulture)
            Return CType(obj,System.Drawing.Bitmap)
        End Get
    End Property
    
    Friend Shared ReadOnly Property _400() As System.Drawing.Icon
        Get
            Dim obj As Object = ResourceManager.GetObject("400", resourceCulture)
            Return CType(obj,System.Drawing.Icon)
        End Get
    End Property
End Class
