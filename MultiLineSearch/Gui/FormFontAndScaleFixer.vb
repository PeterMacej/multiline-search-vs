Option Explicit On
Option Strict On

Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Drawing


Namespace Gui

    ''' <summary>
    ''' Fixed the font typeface and scales the form according to DPI on current OS. 
    ''' </summary>
    ''' <remarks>
    ''' Original idea and code (3 lines :-) by Benjamin Hollis: 
    ''' http://brh.numbera.com/blog/index.php/2007/04/11/setting-the-correct-default-font-in-net-windows-forms-apps/
    ''' Modified from TeX HeX of Xteq Systems: http://texhex.blogspot.com/ and http://www.texhex.info/
    ''' </remarks>
    Public NotInheritable Class FormFontAndScaleFixer

        Private Sub New()
        End Sub

        'This list contains the fonts we want to replace.
        Private Shared ReadOnly fontReplaceList As New List(Of String)(New String() {"Microsoft Sans Serif", "Tahoma"})


        Private Shared ReadOnly defaultFont As Font

        Private Shared ReadOnly canFixFonts As Boolean


        Shared Sub New()
            'Basically the font name we want to use should be easy to choose by using the SystemFonts class. However, this class
            'is hard-coded (!!) and doesn't seem to work right. On XP, it will mostly return "Microsoft Sans Serif" except
            'for the DialogFont property (=Tahoma) but on Vista, this class will return "Tahoma" instead of "SegoiUI" for this property!

            'Therefore we will do the following: If we are running on a OS below XP, we will exit because the only font available
            'will be MS Sans Serif. On XP, we gonna use "Tahoma", and any other OS we will use the value of the MessageBoxFont
            'property because this seems to be set correctly on Vista an above.

            If Environment.OSVersion.Platform = PlatformID.Win32Windows Then
                '95, 98 and other crap
                canFixFonts = False
                Return
            End If

            If Environment.OSVersion.Version.Major < 5 Then
                'Windows NT
                canFixFonts = False
                Return
            End If

            If Environment.OSVersion.Version.Major < 6 Then
                'Windows 2000 (5.0), Windows XP (5.1), Windows Server 2003 and XP Pro x64 Edtion v2003 (5.2)
                canFixFonts = True
                'Tahoma hopefully
                defaultFont = SystemFonts.DialogFont
            Else
                'Vista and above
                canFixFonts = True
                'should be SegoiUI
                defaultFont = SystemFonts.MessageBoxFont
            End If
        End Sub


        ''' <summary>
        ''' Fixes the font of control and all it's children controls.
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <remarks>Fixes the font so that it match with OS settings.</remarks>
        Public Shared Sub FixFont(ByVal ctrl As Control)
            'If we can't fix the font, exit
            If canFixFonts = False Then
                Return
            End If

            'only replace fonts that use one the "system fonts" we have declared
            If fontReplaceList.IndexOf(ctrl.Font.Name) > -1 Then
                'Now check the size, when the size is 9 or below it's the default font size and we do not keep the size since
                'SegoiUI has a complete different spacing (and thus size) than MS SansS or Tahoma.

                'Also check if there are any styles applied on the font (e.g. Italic) which we need to apply to the new
                'font as well.

                Dim useDefaultSize As Boolean = True
                Dim useDefaultStyle As Boolean = True

                'is this a special size?
                If (ctrl.Font.Size <= 8) OrElse (ctrl.Font.Size >= 9) Then
                    useDefaultSize = False
                End If

                'are any special styles (bold, italic etc.) applied to this font?
                If (ctrl.Font.Italic = True) OrElse (ctrl.Font.Strikeout = True) OrElse (ctrl.Font.Underline = True) OrElse (ctrl.Font.Bold = True) Then
                    useDefaultStyle = False
                End If

                'if everything is set to defaults, we can use our prepared font right away
                If useDefaultSize AndAlso useDefaultStyle Then
                    ctrl.Font = defaultFont
                Else
                    'There are non default properties set so
                    'there is some work we need to do...

                    'Retrieve custom font style
                    Dim style As FontStyle = FontStyle.Regular
                    If useDefaultStyle = False Then
                        If ctrl.Font.Italic Then
                            style = style Or FontStyle.Italic
                        End If
                        If ctrl.Font.Strikeout Then
                            style = style Or FontStyle.Strikeout
                        End If
                        If ctrl.Font.Underline Then
                            style = style Or FontStyle.Underline
                        End If
                        If ctrl.Font.Bold Then
                            style = style Or FontStyle.Bold
                        End If
                    End If

                    'Retrieve custom size
                    Dim fontSize As Single = defaultFont.SizeInPoints
                    If Not useDefaultSize Then
                        fontSize = ctrl.Font.SizeInPoints
                    End If

                    'Finally apply this font...
                    Dim font As New Font(defaultFont.Name, fontSize, style, GraphicsUnit.Point)
                    ctrl.Font = font
                End If
            End If

            'recursively traverse all children
            For Each childCtrl As Control In ctrl.Controls
                FixFont(childCtrl)
            Next
        End Sub


        ''' <summary>
        ''' Fixes the scale of control and all it's children controls relative to the display resolution..
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <remarks>This method sets AutoScaleMode property of the control to ScaleMode.Dpi.
        ''' And it sets AutoScaleMode property of nested controls to ScaleMode.Inherit.</remarks>
        Public Shared Sub FixDpiScale(ByVal ctrl As Control)
            If TypeOf ctrl Is ContainerControl Then
                Dim contCtrl As ContainerControl = DirectCast(ctrl, ContainerControl)
                contCtrl.AutoScaleDimensions = New SizeF(96.0F, 96.0F)
                contCtrl.AutoScaleMode = AutoScaleMode.Dpi
            End If

            'recursively traverse all children
            For Each childCtrl As Control In ctrl.Controls
                FixNestedControlDpiScale(childCtrl)
            Next
        End Sub


        ''' <summary>
        ''' Fixes the scale of nested control and all it's children controls relative to the display resolution..
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <remarks>This method sets AutoScaleMode property of the controls to ScaleMode.Inherit.
        ''' It's because some parent control has already set AutoScaleMode property to ScaleMode.Dpi.</remarks>
        Private Shared Sub FixNestedControlDpiScale(ByVal ctrl As Control)
            If TypeOf ctrl Is ContainerControl Then
                Dim contCtrl As ContainerControl = DirectCast(ctrl, ContainerControl)
                contCtrl.AutoScaleDimensions = New SizeF(96.0F, 96.0F)
                contCtrl.AutoScaleMode = AutoScaleMode.Inherit
            End If

            'recursively traverse all children
            For Each childCtrl As Control In ctrl.Controls
                FixNestedControlDpiScale(childCtrl)
            Next
        End Sub


    End Class

End Namespace
