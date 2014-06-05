Imports System
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio


Namespace Settings

    ''' <summary>
    ''' Writes the package settings into memory.
    ''' </summary>
    ''' <remarks>The settings are stored in <see cref="PackageMemorySettingsStore"/>.</remarks>
    Friend Class PackageMemorySettingsWriter
    Implements IVsSettingsWriter


        Private ReadOnly mSettingsStore As PackageMemorySettingsStore = New PackageMemorySettingsStore

        Public ReadOnly Property SettingsStore() As PackageMemorySettingsStore
            Get
                Return mSettingsStore
            End Get
        End Property


        Public Function ReportError(ByVal pszError As String, ByVal dwErrorType As UInteger) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsWriter.ReportError

        End Function

        Public Function WriteCategoryVersion(ByVal nMajor As Integer, ByVal nMinor As Integer, ByVal nBuild As Integer, ByVal nRevision As Integer) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsWriter.WriteCategoryVersion

        End Function


        Public Function WriteSettingAttribute(ByVal pszSettingName As String, ByVal pszAttributeName As String, ByVal pszSettingValue As String) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsWriter.WriteSettingAttribute
            SettingsStore.SetSettingAttribute(pszSettingName, pszAttributeName, pszSettingValue)
            Return VSConstants.S_OK
        End Function


        Public Function WriteSettingBoolean(ByVal pszSettingName As String, ByVal fSettingValue As Integer) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsWriter.WriteSettingBoolean
            SettingsStore.SetSetting(pszSettingName, fSettingValue)
            Return VSConstants.S_OK
        End Function


        Public Function WriteSettingBytes(ByVal pszSettingName As String, ByVal pSettingValue() As Byte, ByVal lDataLength As Integer) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsWriter.WriteSettingBytes
            Dim newValue As Byte()
            If pSettingValue.Length > lDataLength Then
                newValue = New Byte(lDataLength) {}
                Array.Copy(pSettingValue, 0, newValue, 0, lDataLength)
            Else
                newValue = pSettingValue
            End If
            SettingsStore.SetSetting(pszSettingName, newValue)

            Return VSConstants.S_OK
        End Function


        Public Function WriteSettingLong(ByVal pszSettingName As String, ByVal lSettingValue As Integer) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsWriter.WriteSettingLong
            SettingsStore.SetSetting(pszSettingName, lSettingValue)
            Return VSConstants.S_OK
        End Function


        Public Function WriteSettingString(ByVal pszSettingName As String, ByVal pszSettingValue As String) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsWriter.WriteSettingString
            SettingsStore.SetSetting(pszSettingName, pszSettingValue)
            Return VSConstants.S_OK
        End Function


        Public Function WriteSettingXml(ByVal pIXMLDOMNode As Object) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsWriter.WriteSettingXml

        End Function

        Public Function WriteSettingXmlFromString(ByVal szXML As String) As Integer Implements Microsoft.VisualStudio.Shell.Interop.IVsSettingsWriter.WriteSettingXmlFromString

        End Function


    End Class

End Namespace
