Imports System
Imports System.Runtime.InteropServices
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio


''' <summary>
''' Reads the package settings from memory.
''' </summary>
''' <remarks>The settings are stored in <see cref="PackageMemorySettingsStore"/>.</remarks>
Friend Class PackageMemorySettingsReader
    Implements IVsSettingsReader


    Private ReadOnly mSettingsStore As PackageMemorySettingsStore = New PackageMemorySettingsStore

    Public ReadOnly Property SettingsStore() As PackageMemorySettingsStore
        Get
            Return mSettingsStore
        End Get
    End Property


    Public Sub New(ByVal settingsStore As PackageMemorySettingsStore)
        If settingsStore Is Nothing Then
            Throw New ArgumentNullException("settingsStore")
        End If
        Me.mSettingsStore = settingsStore
    End Sub


    Public Function ReadCategoryVersion(ByRef pnMajor As Integer, ByRef pnMinor As Integer, ByRef pnBuild As Integer, ByRef pnRevision As Integer) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsReader.ReadCategoryVersion

    End Function


    Public Function ReadFileVersion(ByRef pnMajor As Integer, ByRef pnMinor As Integer, ByRef pnBuild As Integer, ByRef pnRevision As Integer) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsReader.ReadFileVersion

    End Function


    Public Function ReadSettingAttribute(ByVal pszSettingName As String, ByVal pszAttributeName As String, ByRef pbstrSettingValue As String) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsReader.ReadSettingAttribute
        Try
            If SettingsStore.Settings.ContainsKey(pszSettingName) Then
                Dim setting As PackageMemorySettingsStore.Setting = SettingsStore.Settings.Item(pszSettingName)
                If setting.Attributes.ContainsKey(pszAttributeName) Then
                    pbstrSettingValue = setting.Attributes.Item(pszAttributeName)
                    Return VSConstants.S_OK
                End If
            End If
        Catch ex As Exception
        End Try

        Return VSConstants.S_FALSE
    End Function


    Public Function ReadSettingBoolean(ByVal pszSettingName As String, ByRef pfSettingValue As Integer) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsReader.ReadSettingBoolean
        Try
            If SettingsStore.Settings.ContainsKey(pszSettingName) Then
                Dim setting As PackageMemorySettingsStore.Setting = SettingsStore.Settings.Item(pszSettingName)
                pfSettingValue = DirectCast(setting.Value, Integer)
                Return VSConstants.S_OK
            End If
        Catch ex As Exception
        End Try

        Return VSConstants.S_FALSE
    End Function


    Public Function ReadSettingBytes(ByVal pszSettingName As String, ByRef pSettingValue As Byte, ByRef plDataLength As Integer, ByVal lDataMax As Integer) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsReader.ReadSettingBytes
        ' since I couldn't test this method, just do nothing
        Return VSConstants.S_FALSE

        Try
            If SettingsStore.Settings.ContainsKey(pszSettingName) Then
                Dim setting As PackageMemorySettingsStore.Setting = SettingsStore.Settings.Item(pszSettingName)
                Dim bytes As Byte() = DirectCast(setting.Value, Byte())
                If bytes.Length <= lDataMax Then
                    Dim bufferPtr As IntPtr
                    ' byte and byte() are blittable so the pointer to the first array element is a pointer to the array itself
                    Dim pinnedBufferBytes As GCHandle = GCHandle.Alloc(pSettingValue, GCHandleType.Pinned)
                    bufferPtr = pinnedBufferBytes.AddrOfPinnedObject

                    Marshal.Copy(bytes, 0, bufferPtr, bytes.Length)
                    plDataLength = bytes.Length

                    ' probably not needed because the byte array was allocated by the caller
                    pinnedBufferBytes.Free()

                    Return VSConstants.S_OK
                End If
            End If
        Catch ex As Exception
        End Try

        Return VSConstants.S_FALSE
    End Function


    Public Function ReadSettingLong(ByVal pszSettingName As String, ByRef plSettingValue As Integer) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsReader.ReadSettingLong
        Try
            If SettingsStore.Settings.ContainsKey(pszSettingName) Then
                Dim setting As PackageMemorySettingsStore.Setting = SettingsStore.Settings.Item(pszSettingName)
                plSettingValue = DirectCast(setting.Value, Integer)
                Return VSConstants.S_OK
            End If
        Catch ex As Exception
        End Try

        Return VSConstants.S_FALSE
    End Function


    Public Function ReadSettingString(ByVal pszSettingName As String, ByRef pbstrSettingValue As String) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsReader.ReadSettingString
        Try
            If SettingsStore.Settings.ContainsKey(pszSettingName) Then
                Dim setting As PackageMemorySettingsStore.Setting = SettingsStore.Settings.Item(pszSettingName)
                pbstrSettingValue = DirectCast(setting.Value, String)
                Return VSConstants.S_OK
            End If
        Catch ex As Exception
        End Try

        Return VSConstants.S_FALSE
    End Function


    Public Function ReadSettingXml(ByVal pszSettingName As String, ByRef ppIXMLDOMNode As Object) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsReader.ReadSettingXml
        Return VSConstants.S_FALSE
    End Function

    Public Function ReadSettingXmlAsString(ByVal pszSettingName As String, ByRef pbstrXML As String) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsReader.ReadSettingXmlAsString
        Return VSConstants.S_FALSE
    End Function

    Public Function ReportError(ByVal pszError As String, ByVal dwErrorType As UInteger) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsReader.ReportError

    End Function
End Class
