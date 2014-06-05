Imports System.Collections.Generic
Imports System.Text


Namespace Settings

    ''' <summary>
    ''' Stores a package settings. This is an in-memory alternative of
    ''' vssettings XML file.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class PackageMemorySettingsStore

        Private ReadOnly mSettings As Dictionary(Of String, Setting) = New Dictionary(Of String, Setting)

        Public ReadOnly Property Settings() As Dictionary(Of String, Setting)
            Get
                Return mSettings
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
                mName = name
            End Sub


            Private ReadOnly mName As String

            ''' <summary>
            ''' Gets or sets the setting name.
            ''' </summary>
            ''' <value></value>
            ''' <remarks></remarks>
            Public ReadOnly Property Name() As String
                Get
                    Return mName
                End Get
            End Property


            Private mValue As Object = Nothing

            ''' <summary>
            ''' Gets or sets the setting value.
            ''' </summary>
            ''' <value></value>
            ''' <remarks></remarks>
            Public Property Value() As Object
                Get
                    Return mValue
                End Get
                Set(ByVal value As Object)
                    mValue = value
                End Set
            End Property


            Private ReadOnly mAttributes As Dictionary(Of String, String) = New Dictionary(Of String, String)

            Public ReadOnly Property Attributes() As Dictionary(Of String, String)
                Get
                    Return mAttributes
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

End Namespace
