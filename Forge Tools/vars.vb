Public Class vars
    Public Shared MyDll As String = "ICSharpCode.SharpZipLib.dll"
    Public Shared ServerLogName As String = "updates.txt"
    Public Shared BaseUrl As String = "https://github.com/churrufli/Forgetools/releases/tag/0.2/"
    Public Shared BaseUrlUnsupportedCards = "https://downloads.cardforge.org/decks/archive/unsupportedcards.txt"
    Public Shared MyLogServer As String = ""
    Public Shared LogName As String = "fldata/version.txt"
    Public Shared UserDir As String = Directory.GetCurrentDirectory()
    Public Shared mtggf As String = "https://www.mtggoldfish.com"
    Public Shared mtgtop8 As String = "http://mtgtop8.com"
    Public Shared LinkLine As String = ""
    Public Shared TxtError As String = ""
    Public Shared txlogserver As String
    Public Shared InitAll As Boolean = True
    Public Shared ForgeDecksDir, ForgePicsDir As String
    Public Shared continueLooping As Boolean = True
    'Public Shared unsupportedcards As String = setunsupportedcards()
End Class