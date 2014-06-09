Option Explicit On
Option Strict On


Namespace Update

    ''' <summary>
    ''' Holds info about update.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class UpdateInfo

#Region "Properties"

        Private mCurrentVersion As Version
        ''' <summary>
        ''' Current installed version.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Property CurrentVersion() As Version
            Get
                Return mCurrentVersion
            End Get
            Set(ByVal value As Version)
                mCurrentVersion = value
            End Set
        End Property


        Private mLatestVersion As Version
        ''' <summary>
        ''' latest available version.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Property LatestVersion() As Version
            Get
                Return mLatestVersion
            End Get
            Set(ByVal value As Version)
                mLatestVersion = value
            End Set
        End Property


        Private mWhatsNew As String
        ''' <summary>
        ''' What's new in the latest version.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Property WhatsNew() As String
            Get
                Return mWhatsNew
            End Get
            Set(ByVal value As String)
                mWhatsNew = value
            End Set
        End Property


        Private mDownloadUrl As String
        ''' <summary>
        ''' Gets or sets download url for the latest version.
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Friend Property DownloadUrl() As String
            Get
                Return mDownloadUrl
            End Get
            Set(ByVal value As String)
                mDownloadUrl = value
            End Set
        End Property


        Private mHomeUrl As String
        ''' <summary>
        ''' Gets or sets home url for the latest version.
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Friend Property HomeUrl() As String
            Get
                Return mHomeUrl
            End Get
            Set(ByVal value As String)
                mHomeUrl = value
            End Set
        End Property


        Private mBuyUrl As String
        ''' <summary>
        ''' Gets or sets buy url for the latest version.
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Friend Property BuyUrl() As String
            Get
                Return mBuyUrl
            End Get
            Set(ByVal value As String)
                mBuyUrl = value
            End Set
        End Property


        Private mReleaseNotesUrl As String
        ''' <summary>
        ''' Gets or sets release notes url.
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Friend Property ReleaseNotesUrl() As String
            Get
                Return mReleaseNotesUrl
            End Get
            Set(ByVal value As String)
                mReleaseNotesUrl = Value
            End Set
        End Property


        Private mUpdateInfoUrl As String
        ''' <summary>
        ''' Gets or sets url of XML file with update info.
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Friend Property UpdateInfoUrl() As String
            Get
                Return mUpdateInfoUrl
            End Get
            Set(ByVal value As String)
                mUpdateInfoUrl = value
            End Set
        End Property


        Private mReleaseDate As Date
        ''' <summary>
        ''' Gets or sets the release date of the latest version.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Friend Property ReleaseDate() As Date
            Get
                Return mReleaseDate
            End Get
            Set(ByVal value As Date)
                mReleaseDate = value
            End Set
        End Property

#End Region


        Friend Function IsLatestNewer() As Boolean
            Return Me.CurrentVersion.CompareTo(Me.LatestVersion) < 0
        End Function

    End Class

End Namespace
