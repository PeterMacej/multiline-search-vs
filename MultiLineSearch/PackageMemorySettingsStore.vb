Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.ComponentModel.Design
Imports Microsoft.Win32
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio.OLE.Interop
Imports Microsoft.VisualStudio.Shell
Imports EnvDTE80
Imports System.Collections.Generic
Imports System.Text


''' <summary>
''' Stores a package settings. This is an in-memory alternative of
''' vssettings XML file.
''' </summary>
''' <remarks></remarks>
Friend Class PackageMemorySettingsStore

    Private m_Settings As New Dictionary(Of String, Setting)
    Public ReadOnly Property Settings() As Dictionary(Of String, Setting)
        Get
            Return m_Settings
        End Get
    End Property


    Public Sub SetSetting(ByVal name As String, ByVal value As Object)
        If name Is Nothing Then
            Return
        End If

        Dim setting As Setting = GetOrCreateSetting(name)
        setting.Value = value
        Settings.Item(name) = setting
    End Sub


    Public Sub SetSettingAttribute(ByVal setName As String, ByVal attrName As String, ByVal attrValue As String)
        If setName Is Nothing Then
            Return
        End If

        Dim setting As Setting = GetOrCreateSetting(setName)
        setting.SetAttribute(attrName, attrValue)
        Settings.Item(setName) = setting
    End Sub


    ''' <summary>
    ''' Gets specified setting if it already exists or creates a new one with
    ''' null value.
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetOrCreateSetting(ByVal name As String) As Setting
        Dim res As Setting
        If Settings.ContainsKey(name) Then
            res = Settings.Item(name)
        Else
            res = New Setting(name)
        End If

        Return res
    End Function


    Public Overrides Function ToString() As String
        Dim res As New StringBuilder

        For Each s As Setting In Me.Settings.Values
            res.AppendLine(s.ToString)
        Next

        Return res.ToString()
    End Function


    ''' <summary>
    ''' Represents one IDE setting.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class Setting

        Public Sub New(ByVal name As String)
            m_Name = name
        End Sub


        Private m_Name As String
        ''' <summary>
        ''' Gets or sets the setting name.
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Public ReadOnly Property Name() As String
            Get
                Return m_Name
            End Get
        End Property


        Private m_Value As Object = Nothing
        ''' <summary>
        ''' Gets or sets the setting value.
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Public Property Value() As Object
            Get
                Return m_Value
            End Get
            Set(ByVal value As Object)
                m_Value = value
            End Set
        End Property



        Private m_attributes As New Dictionary(Of String, String)
        Public ReadOnly Property Attributes() As Dictionary(Of String, String)
            Get
                Return m_attributes
            End Get
        End Property


        Public Sub SetAttribute(ByVal attrName As String, ByVal attrValue As String)
            Attributes.Item(attrName) = attrValue
        End Sub


        Public Overrides Function ToString() As String
            Return Me.Name & " = " & CStr(Me.Value)
        End Function
    End Class
End Class
