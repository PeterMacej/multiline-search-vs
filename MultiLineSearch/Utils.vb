Imports System
Imports EnvDTE
Imports EnvDTE80
Imports System.Diagnostics
Imports Microsoft.VisualStudio
Imports System.Xml
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.Shell.Interop
Imports Microsoft.VisualStudio.Shell
Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Reflection


Friend Class Utils


    Public Shared Sub WriteToGeneralOutputPane(ByVal message As String)
        'System.Windows.Forms.MessageBox.Show(message)
        'Return

        Dim output As IVsOutputWindow = TryCast(Package.GetGlobalService(GetType(SVsOutputWindow)), IVsOutputWindow)
        If output IsNot Nothing Then
            ' can't write to the output window - just a pane
            ' see References.Services HelperMethodsClass SDK Sample
            Dim generalPaneGuid As Guid = VSConstants.GUID_OutWindowGeneralPane
            Dim pane As IVsOutputWindowPane = Nothing

            ' fetch the pane wrapped in error handling:
            If ErrorHandler.Failed(output.GetPane(generalPaneGuid, pane)) OrElse pane Is Nothing Then
                ' not created yet
                output.CreatePane(generalPaneGuid, "General", 1, 0)
                If ErrorHandler.Failed(output.GetPane(generalPaneGuid, pane)) OrElse pane Is Nothing Then
                    ' ideally, throw an exception or trace/output...
                    Return
                End If
            End If

            ' wrap attempts to write in an error handler:
            message &= Environment.NewLine
            pane.Activate()
            If (ErrorHandler.Failed(pane.OutputString(message))) Then
                ' throw an exception/etc.
                Return
            End If
        End If
    End Sub



#Region "COM interfaces diagnostics"

    ''' <summary>
    ''' Get all implemented types in a COM object. Code based on work at
    ''' http://fernandof.wordpress.com/2008/02/05/how-to-check-
    '''          the-type-of-a-com-object-system__comobject-with-visual-c-net/
    ''' </summary>
    ''' <param name="comObject">The object we want all types of.</param>
    ''' <param name="assType">Any type in the COM assembly (the interface we expect that is implemented by the object).</param>
    ''' <returns>All implemented classes/interfaces.</returns>
    Private Shared Function GetAllImplementedTypes(ByVal comObject As Object, ByVal assType As Type) As List(Of Type)
        'get all available assemblies
        Dim allAssemblies As List(Of Assembly)
        allAssemblies = New List(Of Assembly)(AppDomain.CurrentDomain.GetAssemblies())

        ' add assembly of the specified helper type (it is probably already loaded in AppDomain, but just for sure)
        Dim interopAss As Assembly = Assembly.GetAssembly(assType)
        If Not allAssemblies.Contains(interopAss) Then
            allAssemblies.Add(interopAss)
        End If

        ' search in all assemblies
        Dim res As New List(Of Type)
        For Each ass As Assembly In allAssemblies
            res.AddRange(GetAllImplementedTypes(comObject, ass))
        Next

        Return res
    End Function


    ''' <summary>
    ''' Gets all types from an assembly that are implemented by a COM object.
    ''' </summary>
    ''' <param name="comObject">The object we want all types of.</param>
    ''' <param name="interopAss">COM interop assembly to search.</param>
    ''' <returns>All implemented classes/interfaces.</returns>
    Private Shared Function GetAllImplementedTypes(ByVal comObject As Object, ByVal interopAss As Assembly) As List(Of Type)
        Dim implTypes As New List(Of Type)
        Try
            ' get the com object and fetch its IUnknown
            Dim iunkwn As IntPtr = Marshal.GetIUnknownForObject(comObject)

            ' enum all the types defined in the interop assembly
            Dim allTypes As Type() = interopAss.GetTypes()

            ' find all types it implements
            For Each currType As Type In allTypes
                ' com interop type must be an interface with valid iid
                Dim iid As Guid = currType.GUID
                If Not currType.IsInterface OrElse iid = Guid.Empty Then
                    Continue For
                End If

                ' query supportability of current interface on object
                Dim ipointer As IntPtr
                Marshal.QueryInterface(iunkwn, iid, ipointer)

                If ipointer <> IntPtr.Zero Then
                    implTypes.Add(currType)

                End If
            Next
        Catch ex As ReflectionTypeLoadException
            For Each subEx As Exception In ex.LoaderExceptions
                'WriteToGeneralOutputPane("   Error loading: " & interopAss.FullName)
                'WriteToGeneralOutputPane("   EXCEPTION:" & ex.ToString)
                'WriteToGeneralOutputPane("     SUBEXCEPTION:" & subEx.ToString)
            Next
        End Try
        Return implTypes
    End Function


    ''' <summary>
    ''' Prints all implemented types in a COM object.
    ''' </summary>
    ''' <param name="comObject">The object we want all types of.</param>
    ''' <param name="assType">Any type in the COM assembly (the interface we expect that is implemented by the object).</param>
    Private Sub PrintAllTypes(ByVal comObject As Object, ByVal assType As Type)
        For Each t As Type In GetAllImplementedTypes(comObject, assType)
            WriteToGeneralOutputPane("  " & t.FullName & " " & t.Assembly.FullName)
        Next
    End Sub

#End Region


End Class
