Imports System.Globalization
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports ICSharpCode.SharpZipLib.BZip2
Imports ICSharpCode.SharpZipLib.Tar
Imports ICSharpCode.SharpZipLib.Zip

Public Class fn
    Shared WithEvents downloader As WebClient

    Shared Sub WriteLogFL(s As String)
        Try
            Dim sFileName As String = Environment.CurrentDirectory & "\fllog.txt"
            If File.Exists(sFileName) Then
                File.Delete(sFileName)
            End If
        Catch
        End Try
    End Sub

    Shared Function IsValidFileNameOrPath(name As String) As Boolean
        ' Determines if the name is Nothing.
        If name Is Nothing Then
            Return False
        End If

        ' Determines if there are bad characters in the name.
        For Each badChar As Char In Path.GetInvalidPathChars
            If InStr(name, badChar) > 0 Then
                Return False
            End If
        Next

        ' The name passes basic validation.
        Return True
    End Function

    Public Shared Function Normalize(name As String) As String
        'name = "" & name
        'Try
        '    name = Replace(name, "\", " ")
        '    name = Replace(name, "/", " ")
        '    name = Replace(name, """", "'")
        '    Dim reg As New Regex("[^a-zA-Z0-9' ]")
        '    name = reg.Replace(name, "")
        '    name = Replace(name, "    ", " ")
        '    name = Replace(name, "   ", " ")
        '    name = Replace(name, "  ", " ")
        '    name = Replace(name, "--", "-")
        '    name = Replace(name, "---", "-")
        '    name = Replace(name, "á", "a")
        '    name = Replace(name, "é", "e")
        '    name = Replace(name, "í", "i")
        '    name = Replace(name, "ó", "o")
        '    name = Replace(name, "ú", "u")
        '    name = Replace(name, "ú", "u")
        '    name = Replace(name, "ü", "u")
        '    name = Replace(name, "ñ", "n")
        '    name = LTrim(RTrim(name))
        '    Normalize = name
        '    reg = Nothing
        'Catch
        '    Normalize = name
        'End Try
        Return name
    End Function

    Public Shared Function NormalizeUrl(name As String) As String
        name = Replace(name, " ", "_")
        Return name
    End Function

    Public Shared Function RemoveDiacritics(s As String) As String
        Dim normalizedString As String = s.Normalize(NormalizationForm.FormD)
        Dim stringBuilder As New StringBuilder()

        For Each c As Char In normalizedString
            If CharUnicodeInfo.GetUnicodeCategory(c) <> UnicodeCategory.NonSpacingMark Then
                stringBuilder.Append(c)
            End If
        Next

        Return stringBuilder.ToString()
    End Function

    Public Shared Function RemoveWhitespace(fs As String) As String
        fs = Regex.Replace(fs, "[ ]{2,}", " ")
        fs = Regex.Replace(fs, "\s+", " ")
        fs = Replace(fs, " ", " ")
        Return fs
    End Function

    Public Shared Function removeshit(s As String) As String
        s = Replace(s, "?", "")
        s = Replace(s, ")", "-")
        s = Replace(s, "(", "-")
        removeshit = s
    End Function

    Public Shared Sub checkunsupportedcards()
    End Sub

    Public Shared Sub UnsupportedCards()
        Try
            fn.DownloadFile(vars.BaseUrlUnsupportedCards, "fldata\unsupportedcards.txt", True)
            fn.WriteUserLog("unsupportedcards.txt downloaded." & vbCrLf)
            'ok = True
        Catch
            fn.WriteUserLog("Can't fetch unsupportedcards.txt from server, please try later." & vbCrLf)
        End Try
    End Sub

    Public Shared Sub DownloadFile(address As String, fileName As String, Optional forceDownload As Boolean = False)
        If Not forceDownload AndAlso File.Exists(fileName) Then
            Exit Sub
        End If

        Dim backupFileName As String = $"{Path.GetFileNameWithoutExtension(fileName)}.bak"

        Try
            If File.Exists(fileName) Then
                File.Move(fileName, backupFileName)
            End If

            Using client As New WebClient()
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                client.DownloadFile(address, fileName)
            End Using

            ' If the download is successful, delete the backup file
            If File.Exists(fileName) Then
                File.Delete(backupFileName)
            End If
        Catch ex As Exception
            ' Handle exceptions or log errors here
        End Try
    End Sub

    Function ReadWebAlt(myurl As String)
        Dim client As WebClient = New WebClient()
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Dim reply As String = client.DownloadString(myurl)
        Return reply
    End Function

    Public Shared Function ReadLogUser(idlog As String, Optional ShowMsg As Boolean = False, Optional ByVal CompareWithServer As Boolean = True) As String
        If idlog = "profileproperties" Then CompareWithServer = False
        If CompareWithServer Then
            If File.Exists("\fldata\" & vars.ServerLogName) = False Then
                Try
                    DownloadFile(vars.BaseUrl & vars.ServerLogName, vars.UserDir & "/fldata/" & vars.ServerLogName)
                Catch
                    PrintError(Err.Description)
                End Try
            End If
        End If

        Dim LogServer = ""
        Try
            LogServer = vars.MyLogServer
            LogServer = FindIt(LogServer, "<" & idlog & ">", "</" & idlog & ">")
        Catch
            PrintError(Err.Description)
        End Try

        If File.Exists(vars.LogName) = False Then
            File.Create(vars.LogName).Dispose()
        End If
        Dim ladire = vars.UserDir & "\" & vars.LogName
        ladire = Replace(ladire, "/", "\")
        ladire = Replace(ladire, "\", "/")
        'If ladire.Contains() Then
        Dim LogUser = ""
        Try
            LogUser = File.ReadAllText(ladire).ToString
        Catch
        End Try
        If LogUser = "" Then
            Try
                LogUser = File.ReadAllText(vars.UserDir & ladire).ToString
            Catch
            End Try
        End If
        If LogUser = "" Then
            Try
                LogUser = File.ReadAllText(Directory.GetCurrentDirectory & ladire).ToString
            Catch
            End Try
        End If

        Dim log_user As String = FindIt(LogUser, "<" & idlog & ">", "</" & idlog & ">")

        idlog = Replace(idlog, "_", " ")
        idlog = StrConv(idlog, VbStrConv.ProperCase)
        If ShowMsg Then
            If LogServer = "" Then
                Return ""
                Exit Function
            End If
            If LogServer <> log_user Then
                WriteUserLog("New " & idlog & " available! " & LogServer & "." & vbCrLf)
            Else
                WriteUserLog("Your " & idlog & " is up to date: " & log_user & "." & vbCrLf)
            End If
        End If
        ReadLogUser = log_user
    End Function

    Public Shared Function OpenLogFile()
        Dim logfile As String = Directory.GetCurrentDirectory & "\user\forge.log"
        Dim logfile2 As String = Directory.GetCurrentDirectory & "\UserDir\forge.log"

        If File.Exists(logfile) = True Then
            Shell("c:\windows\notepad.exe " & logfile)
            Exit Function
        End If

        If File.Exists(logfile2) = True Then
            Shell("c:\windows\notepad.exe " & logfile2)
            Exit Function
        End If

        MsgBox("Cant'f find forge.log file.")
    End Function

    Public Shared Sub UpdateLog(idlog, myvalue)
        Dim mylog As String = My.Computer.FileSystem.ReadAllText(vars.LogName)
        Dim previousmyvalue = FindIt(mylog, "<" & idlog & ">", "</" & idlog & ">")
        Dim newlog = Replace(mylog, "<" & idlog & ">" & previousmyvalue & "</" & idlog & ">",
                             "<" & idlog & ">" & myvalue & "</" & idlog & ">")
        Try
            File.Delete(vars.UserDir & "/" & vars.LogName)
        Catch
        End Try
        Try
            File.WriteAllText(vars.UserDir & "/" & vars.LogName, newlog)
        Catch
        End Try
    End Sub

    Public Shared Sub PrintError(tx)
        Try
            If InStr(vars.TxtError.ToString & "", tx, CompareMethod.Text) = 0 Then
                vars.TxtError = vars.TxtError & tx & vbCrLf
                WriteUserLog(vars.TxtError)
            End If
        Catch
        End Try
    End Sub

    Public Shared Function ReadLogServer(idlog As String, Optional ShowMsg As Boolean = True)
        'lo comento que dice Snoops que no le checkea bien
        'If IO.File.Exists("fldata/" & vars.ServerLogName) = False Then
        Try
            DownloadFile(vars.BaseUrl & vars.ServerLogName, "fldata/" & vars.ServerLogName)
        Catch
            PrintError(Err.Description)
            Exit Function
        End Try
        'End If

        Dim LogServer_data = ""

        Try
            LogServer_data = File.ReadAllText("fldata\" & vars.ServerLogName).ToString
        Catch
            PrintError(Err.Description)
            Exit Function
        End Try

        Try
            LogServer_data = FindIt(LogServer_data, "<" & idlog & ">", "</" & idlog & ">")
        Catch
            PrintError(Err.Description)
            Exit Function
        End Try
        ReadLogServer = LogServer_data
    End Function

    Public Shared Sub ExtractToDirectory(archive As ZipArchive, destinationDirectoryName As String,
                                         overwrite As Boolean)
        Dim mycount As Integer
        If Not overwrite Then
            archive.ExtractToDirectory(destinationDirectoryName)
            Return
        End If

        For Each file As ZipArchiveEntry In archive.Entries
            Dim completeFileName As String = Path.Combine(destinationDirectoryName, file.FullName)
            If file.Name = "" Then
                Try
                    If Directory.Exists(Path.GetDirectoryName(completeFileName)) = False Then
                        Directory.CreateDirectory(Path.GetDirectoryName(completeFileName))
                    End If
                Catch
                End Try
                Continue For
            End If

            file.ExtractToFile(completeFileName, True)
            WriteUserLog("Extracting " & file.FullName & vbCrLf)
            mycount = mycount + 1
        Next
        WriteUserLog("Done!." & vbCrLf)
    End Sub

    Public Shared Function ReadWeb(MyUrl As String)
        MyUrl = Replace(MyUrl, "'", "")
        MyUrl = Replace(MyUrl, """", "")
        Dim res As String
        If MyUrl = "" Then Exit Function
        'Dim request As WebRequest
        'Try
        '    request = WebRequest.Create(MyUrl)
        'Catch
        '    ReadWeb = ""
        '    Exit Function
        'End Try
        'Dim response As WebResponse
        'Try
        '    response = request.GetResponse()
        'Catch
        '    ReadWeb = ""
        '    Exit Function
        'End Try
        'Dim reader As New StreamReader(response.GetResponseStream())
        'Try
        '    res = reader.ReadToEnd()
        'Catch
        '    Exit Function
        'End Try
        'reader.Close()
        'response.Close()

        Try

            Dim client As WebClient = New WebClient()
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim reply As String = client.DownloadString(MyUrl)
            Return reply
            Exit Function
        Catch ex As Exception

        End Try

        ReadWeb = res
    End Function

    Public Shared Sub DownloadStart(dwl, fn)
        downloader = New WebClient
        downloader.DownloadFileAsync(New Uri(dwl), fn)
    End Sub

    Public Shared Function FindIt(total As String, first As String, last As String) As String
        If total = Nothing Then total = ""

        If first.Length > 0 AndAlso last.Length > 0 Then
            Dim startIndex As Integer = total.IndexOf(first)
            Dim endIndex As Integer = total.IndexOf(last, startIndex + first.Length)

            If startIndex >= 0 AndAlso endIndex >= 0 Then
                Return total.Substring(startIndex + first.Length, endIndex - startIndex - first.Length)
            End If
        ElseIf first.Length > 0 Then
            Dim startIndex As Integer = total.IndexOf(first)
            If startIndex >= 0 Then
                Return total.Substring(startIndex + first.Length)
            End If
        ElseIf last.Length > 0 Then
            Dim endIndex As Integer = total.IndexOf(last)
            If endIndex >= 0 Then
                Return total.Substring(0, endIndex)
            End If
        End If

        Return ""
    End Function

    Public Shared Function GetForgeDecksDir()
        If vars.ForgeDecksDir = "" Then
            Return SearchFolders(False)
        Else
            Return vars.ForgeDecksDir
        End If
    End Function

    Public Shared Function SearchFolders(Optional ShowMsg As Boolean = True, Optional idlog As String = "decks_dir")

        Dim lafolder As String = ReadLogUser(idlog, False, False)

        If lafolder <> "" Then
            If ShowMsg Then
                WriteUserLog(
                    lafolder & " -> user decks directory (You may change the directories in Settings)." & vbCrLf)
            End If
            Return lafolder
            Exit Function
        End If

        Dim MyFolder = ""
        Dim files() As String = Directory.GetFiles(vars.UserDir)
        Dim lines As String() = {}
        For Each file As String In files
            If file = vars.UserDir & "\forge.profile.properties" Then
                'CUSTOM FOLDERS!
                Dim text As String = IO.File.ReadAllText(vars.UserDir & "\forge.profile.properties")
                lines = IO.File.ReadAllLines(vars.UserDir & "\forge.profile.properties")
                For Each line As String In lines
                    If InStr(LCase(line.ToString), "UserDir") > 0 Then
                        Try
                            Dim posibledir = Split(line, "=")(1).ToString
                            If posibledir <> "" And Directory.Exists(posibledir) Then
                                If posibledir <> "" Then
                                    posibledir = posibledir & "\decks"
                                    If CheckIfForgeExists() Then
                                        If ShowMsg Then
                                            WriteUserLog(
                                                "Detected " & posibledir &
                                                " As Custom User Directory (You can change the directories In Settings)." &
                                                vbCrLf)
                                        End If
                                    End If
                                    MyFolder = posibledir
                                    SearchFolders = posibledir
                                    Exit Function
                                End If
                            End If
                        Catch
                        End Try
                    End If
                Next
            End If
            'normal FOLDERS!
        Next

        MyFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Forge\decks"

        If CheckIfForgeExists() Then
            If ShowMsg Then
                WriteUserLog("Detected " & MyFolder & " As Content Directory." & vbCrLf)
            End If
        End If

        SearchFolders = MyFolder

        If MyFolder <> "" Then
            UpdateLog("decks_dir", MyFolder)
        End If
    End Function

    Public Shared Function CheckIfForgeExists()
        Return IIf(File.Exists("forge.exe"), True, False)
    End Function

    Public Shared Function HTMLToText(HTMLCode As String) As String
        If IsNothing(HTMLCode) Then HTMLCode = ""
        ' Remove new lines since they are not visible in HTML
        HTMLCode = HTMLCode.Replace("\n", " ")

        ' Remove tab spaces
        HTMLCode = HTMLCode.Replace("\t", " ")

        ' Remove multiple white spaces from HTML
        HTMLCode = Regex.Replace(HTMLCode, "\\s+", "  ")

        ' Remove HEAD tag
        HTMLCode = Regex.Replace(HTMLCode, "<head.*?</head>", "" _
                                 , RegexOptions.IgnoreCase Or RegexOptions.Singleline)

        ' Remove any JavaScript
        HTMLCode = Regex.Replace(HTMLCode, "<script.*?</script>", "" _
                                 , RegexOptions.IgnoreCase Or RegexOptions.Singleline)

        ' Replace special characters like &, <, >, " etc.
        Dim sbHTML = New StringBuilder(HTMLCode)
        ' Note: There are many more special characters, these are just
        ' most common. You can add new characters in this arrays if needed
        Dim OldWords() As String = {"&nbsp;", "&amp;", "&quot;", "&lt;",
                                    "&gt;", "&reg;", "&copy;", "&bull;", "&trade;"}
        Dim NewWords() As String = {" ", "&", """", "<", ">", "Â®", "Â©", "â€¢", "â„¢"}
        For i As Integer = 0 To i < OldWords.Length
            sbHTML.Replace(OldWords(i), NewWords(i))
        Next i

        ' Check if there are line breaks (<br>) or paragraph (<p>)
        sbHTML.Replace("<br>", "\n<br>")
        sbHTML.Replace("<br ", "\n<br ")
        sbHTML.Replace("<p ", "\n<p ")

        ' Finally, remove all HTML tags and return plain text
        Return Regex.Replace(
            sbHTML.ToString(), "<[^>]*>", "")
    End Function

    Public Shared Sub DeleteDecks(path As String, Optional ByVal condition As String = "")
        Try
            If condition = "" Then condition = "#*"
            Dim txtList As String() = Directory.GetFiles(path, condition)
            For Each f As String In txtList
                File.Delete(f)
            Next
        Catch
        End Try
    End Sub

    Public Shared Function StringToDeck(mypath, tx, FinalName)
        mypath = Replace(mypath, "|", "-")
        If InStr(tx, ">", CompareMethod.Text) > 0 Then
            StringToDeck = "error converting to .dck file" & vbCrLf
            Exit Function
        End If

        If InStr(FinalName, "Deck for") > 0 Then FinalName = Split(FinalName, "Deck for")(0).ToString
        If FinalName.Contains(" Deck for Magic the") Then FinalName = Split(FinalName, "Deck for")(0).ToString
        If FinalName.Contains(" by ") Then FinalName = Split(FinalName, " by ")(0).ToString
        FinalName = Trim(FinalName)
        FinalName = RemoveWhitespace(FinalName)

        If vars.continueLooping = False Then
            Exit Function
        End If

        If InStr(tx, "Throttled", CompareMethod.Text) > 0 Then
            StringToDeck = "Error getting data (Throttled)" & vbCrLf
            Exit Function
        End If

        tx = Replace(tx, "  //  ", " // ")
        tx = Replace(tx, vbCrLf & vbCrLf, vbCrLf)

        Try
            If Not IsValidFileNameOrPath(FinalName) Then FinalName = Normalize(FinalName)
            FinalName = Replace(FinalName, "/", "")
            FinalName = Replace(FinalName, "\", "")
            FinalName = Replace(FinalName, "*", "")
            FinalName = Replace(FinalName, ":", " ")
            FinalName = Replace(FinalName, "&#39;", "'")
            FinalName = Replace(FinalName, "&#x27;", "'")

            Normalize(FinalName)

            If (Not Directory.Exists(mypath)) Then
                Directory.CreateDirectory(mypath)
            End If

            FinalName = Trim(FinalName)
            Dim path As String = mypath & FinalName & ".dck"

            Dim x = 1
            If File.Exists(path) Then
                'comparo y si es igual paso de guardar
                Do
                    x = x + 1
                    path = mypath & FinalName & "(" & CStr(x) & ").dck"
                Loop While File.Exists(path)
            End If
            tx = Replace(tx, vbCrLf & vbCrLf, vbCrLf)
            tx = Replace(tx, vbLf & vbLf, vbLf)

            Dim delcardordeck = ""
            Dim msg As String = validatecards(tx, FinalName, delcardordeck)
            If msg <> "" Then
                Return (msg)
                Exit Function
            End If

            ' Create the file.
            Using fs As FileStream = File.Create(path)
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(tx)
                ' Add some information to the file.
                fs.Write(info, 0, info.Length)
            End Using

            ' Open the stream and read it back.
            Using sr As StreamReader = File.OpenText(path)
                Do While sr.Peek() >= 0
                    Console.WriteLine(sr.ReadLine())
                Loop
            End Using
            StringToDeck = "saving " & FinalName & vbCrLf
        Catch e As Exception
            StringToDeck = e.Message.ToString & vbCrLf
        End Try
    End Function

    Public Shared Sub RewriteLog()
        Try
            CompatibleOldVersions()
            Dim hoy As String = DateTime.Now.ToString("dd'/'MM'/'yyyy")
            Dim existpp As String = IIf(File.Exists("forge.profile.properties"), "yes", "no")

            Dim readText As String = File.ReadAllText(vars.UserDir & "/" & vars.LogName)
            Dim WriteLog = False
            WriteLog = True
            If WriteLog Then
                Try
                    File.Delete(vars.LogName)
                Catch
                End Try
                File.WriteAllText(vars.LogName, readText)
            End If
        Catch
        End Try
    End Sub

    Public Shared Sub CheckLog()
        Try
            CompatibleOldVersions()
            Dim hoy As String = DateTime.Now.ToString("dd'/'MM'/'yyyy")
            Dim existpp As String = IIf(File.Exists("forge.profile.properties"), "yes", "no")
            If File.Exists(vars.LogName) = False Then
                Dim t As String
                t = t & "<decks_dir>" & GetForgeDecksDir() & "</decks_dir>" & vbCrLf
                t = t & "<preserve_decks>no</preserve_decks>" & vbCrLf
                t = t & "<preserve_decks_number>1</preserve_decks_number>" & vbCrLf
                t = t & "<tournamentsdecks_dir>Tournaments</tournamentsdecks_dir>" & vbCrLf
                t = t & "<profileproperties>" & existpp & "</profileproperties>" & vbCrLf
                File.WriteAllText(vars.LogName, t)
            Else

                Dim readText As String = File.ReadAllText(vars.UserDir & "\" & vars.LogName)
                Dim WriteLog = False

                If InStr(readText, "<profileproperties>", CompareMethod.Text) = 0 Then
                    readText = readText & "<profileproperties>" & existpp & "</profileproperties>" & Environment.NewLine
                    WriteLog = True
                End If

                If InStr(readText, "<decks_dir>", CompareMethod.Text) = 0 Then
                    readText = readText & "<decks_dir>" & GetForgeDecksDir() & "</decks_dir>" & Environment.NewLine
                    WriteLog = True
                End If
                If InStr(readText, "<preserve_decks>", CompareMethod.Text) = 0 Then
                    readText = readText & "<preserve_decks>no</preserve_decks>" & Environment.NewLine
                    WriteLog = True
                End If

                If InStr(readText, "<preserve_decks_number>", CompareMethod.Text) = 0 Then
                    readText = readText & "<preserve_decks_number>1</preserve_decks_number>" & Environment.NewLine
                    WriteLog = True
                End If

                If InStr(readText, "<tournamentsdecks_dir>", CompareMethod.Text) = 0 Then
                    readText = readText & "<tournamentsdecks_dir>Tournaments</tournamentsdecks_dir>" &
                               Environment.NewLine
                    WriteLog = True
                End If

                If InStr(readText, Environment.NewLine & Environment.NewLine, CompareMethod.Text) > 0 Then
                    readText = Replace(readText, Environment.NewLine & Environment.NewLine, Environment.NewLine)
                    WriteLog = True
                End If

                If WriteLog Then
                    Try
                        File.Delete(vars.LogName)
                    Catch
                    End Try
                    File.WriteAllText(vars.LogName, readText)
                End If
            End If
        Catch
        End Try
    End Sub

    Public Shared Sub CompatibleOldVersions()
        If File.Exists("fl_log.txt") = True Then
            Try
                My.Computer.FileSystem.RenameFile("fl_log.txt", "version.txt")
            Catch
            End Try
            Try
                My.Computer.FileSystem.DeleteFile("fl_log.txt")
            Catch
            End Try
        End If
    End Sub

    Public Shared Sub CheckIfPreviousProfileProperties()
        Try
            Dim aa As String = ReadLogUser("profileproperties", False).ToString
            If aa.ToString <> (IIf(File.Exists("forge.profile.properties"), "yes", "no")).ToString Then
                UpdateLog("profileproperties", IIf(File.Exists("forge.profile.properties"), "yes", "no"))
                UpdateLog("decks_dir", Directory.GetCurrentDirectory() & "\user\decks")
            End If
        Catch
        End Try
    End Sub

    Public Shared Function UnzipFile(sZipFile As String, sDestPath As String) As Boolean

        Dim bResult = False

        On Error GoTo Problem

        'Determine the archive type
        Select Case Path.GetExtension(sZipFile)
            Case ".zip"
                'If it's a zip, then simply extract the contents
                Dim fZ = New FastZip()
                fZ.ExtractZip(sZipFile, sDestPath, "") '//use "" for File Filter if you want all files
            Case ".bz2"
                'If it's a tarball, then first decompress the tar, then extract the tar's contents

                'Get the filename of the resulting tar file
                Dim sTarFileName As String = Path.GetDirectoryName(sZipFile) & "\" &
                                             Path.GetFileNameWithoutExtension(sZipFile)
                'Create a new file stream for the tar ball
                Dim fsIn As FileStream = File.OpenRead(sZipFile)

                'If the resulting tar file exists alreay, delete it before creating it
                If File.Exists(sTarFileName) Then
                    File.Delete(sTarFileName)
                End If

                'Create a file stream to receive the decompressed tar file
                Dim fsOut As FileStream = File.Create(sTarFileName)

                'Perform the decompression of the tar file
                BZip2.Decompress(fsIn, fsOut)

                'Open a new file stream for the tar file
                Dim fsTar As FileStream = File.OpenRead(sTarFileName)
                'Create a TarArchive object for the tar file
                Dim tArch As TarArchive = TarArchive.CreateInputTarArchive(fsTar)

                'Extract the tar's contents
                tArch.ExtractContents(sDestPath)

                'Get a list of the files that were extracted within the tar folder
                Dim sExtractedFiles() As String =
                        Directory.GetFiles(sDestPath & "\" & Path.GetFileNameWithoutExtension(sTarFileName))

                'Move all the files to the requested destination directory
                Dim sFile As String
                For Each sFile In sExtractedFiles
                    File.Move(sFile, sDestPath & "\" & Path.GetFileName(sFile))
                Next

                'Delete the tar folder
                Directory.Delete(sDestPath & "\" & Path.GetFileNameWithoutExtension(sTarFileName))

                'Close the open file streams
                tArch.Close()
                fsIn.Close()

                'Delete the decompressed tar file

                File.Delete(sTarFileName)

        End Select

        bResult = True

Problem:
        Return bResult
    End Function

    Public Shared Function CheckFolder(DestinationFolder As String) As String

        If InStr(DestinationFolder, "Commander") > 0 Then Exit Function
        If InStr(DestinationFolder, "Tiny") > 0 Then Exit Function
        If InStr(DestinationFolder, "Brawl") > 0 Then Exit Function

        If IsValidFileNameOrPath(DestinationFolder) = False Then
            DestinationFolder = DestinationFolder
        End If
        DestinationFolder = Replace(DestinationFolder, "|", "-")
        Dim mydir As New DirectoryInfo(DestinationFolder)
        If mydir.Exists = False Then
            mydir.Create()
        End If
        Return DestinationFolder
    End Function

    Public Shared Function FormatDeck(tx As String, Optional name As String = "", Optional commander As String = "")
        If tx = "" Then
            FormatDeck = ""
            Exit Function
        End If
        tx = Replace(tx, vbCr, "")
        tx = Replace(tx, "&#39;", "'")
        tx = Replace(tx, "&#27;", "'")

        tx = Replace(tx, "  ", " ")
        'igual esta aqui el problema de las /////// comento el if commander
        'If commander = "" Then
        If InStr(tx, "/", CompareMethod.Text) > 0 Then
            tx = Replace(tx, "/", " // ")
        End If
        ' End If
        'Dim mytest = Split("1" & commander, "1")
        'Try
        '    If mytest(2).ToString <> "" Then
        '        Dim hola = "vale"
        '        commander = RemoveWhitespace("1 " & Split(commander, "1")(1).ToString) & vbCrLf & "1" & RemoveWhitespace(mytest(2).ToString)

        '    End If
        'Catch
        'End Try

        If InStr(name, "Deck for") > 0 Then name = Split(name, "Deck for")(0).ToString
        If name.Contains(" Deck for Magic the") Then name = Split(name, "Deck for")(0).ToString

        name = Trim(name)
        name = RemoveWhitespace(name)
        If name.Contains(" by ") Then name = Split(name, " by ")(0).ToString

        If commander <> "" Then
            If InStr(commander, "<title>") > 0 Then
                commander = Split(commander, "<title>")(0).ToString
            End If
            If InStr(commander, vbCrLf) > 0 Then
                Dim com1 = Trim(Split(commander, vbCrLf)(0))
                Dim com2 = Trim(Split(commander, vbCrLf)(1))
                tx = Replace(tx, com1, "")
                tx = Replace(tx, com2, "")
            Else
                tx = Replace(tx, commander, "")
            End If

            commander = Replace(commander, "1 1 ", "1 ")

            If ft.insertedition.Checked = True Then
                'tx = PonerEdicion(tx, name)
            Else
                tx = "[metadata]" & vbCrLf & "Name = " & name & vbCrLf & "[Main]" & vbCrLf & tx
            End If
            tx = Replace(tx, "[sideboard]", "")

            tx = tx & "[commander]" & vbCrLf & commander
        Else

            If ft.insertedition.Checked = True Then
                'tx = PonerEdicion(tx, name)
            Else
                tx = "[metadata]" & vbCrLf & "Name = " & name & vbCrLf & "[Main]" & vbCrLf & tx
            End If
        End If

        tx = Replace(tx, vbCrLf & vbCrLf, vbCrLf)
        tx = Replace(tx, "1 1 ", "1 ")
        tx = Replace(tx, "Planeswalkers () ", "")
        tx = Replace(tx, "Planeswalkers () ", "")

        FormatDeck = tx
    End Function

    Public Shared Sub WriteUserLog(msg)
        ft.txlog.SelectedText = msg
        ft.txlog.SelectionStart = ft.txlog.Text.Length
        ft.txlog.ScrollToCaret()
    End Sub

    Public Shared Function validatecards(tx, titdeck, delcardordeck) As String
        'Return ""
        Try

            'leo las cartas no soportadas y la meto en un array
            Dim readText As String = File.ReadAllText(vars.UserDir & "\fldata\unsupportedcards.txt")
            Dim tx1 As String = readText
            tx1 = Replace(tx1, vbLf, vbCrLf)
            Dim a As Array = Split(tx1, vbCrLf)

            'leo las cartas del mazo y la meto en un array
            readText = tx
            Dim t As String = Split(readText, "[Main]" & vbCrLf)(1).ToString
            t = Replace((t), vbCrLf & "[sideboard]", "")
            t = Replace(t, vbLf, vbCrLf)
            Dim b As Array = Split(t, vbCrLf)

            Dim contador = 0
            'recorro cada carta del mazo

            While contador < b.Length
                'doy formato a la carta

                Dim nombrecarta = b(contador) & ""
                If nombrecarta.contains("|") Then nombrecarta = Split(nombrecarta, "|")(0)
                If InStr(nombrecarta, "|") Then nombrecarta = Split(nombrecarta, "|")(0)

                'nombre de la carta que viene en el mazo
                nombrecarta = nombrecarta

                Dim contador2 = 0
                Dim lineacarta = ""
                While contador2 < a.Length
                    lineacarta = nombrecarta
                    For x = 0 To 20
                        nombrecarta = Replace(nombrecarta, x + 1 & " ", "")
                    Next x
                    nombrecarta = nombrecarta
                    nombrecarta = Replace(nombrecarta, vbCr, Nothing)
                    nombrecarta = Replace(nombrecarta, vbCrLf, Nothing)

                    Dim cartaprohibida As String = a(contador2)
                    If nombrecarta = "Gemrazer" Or nombrecarta = "Dirge Bat" Or nombrecarta = "Auspicious Starrix" Then
                        nombrecarta = nombrecarta
                    End If

                    If LCase(nombrecarta) = LCase(cartaprohibida) Then

                        Return _
                            ("Forge unsupported card '" & cartaprohibida & "' in " & titdeck & ". Deck not saved." &
                             vbCrLf)
                        Exit Function
                    End If

                    contador2 = contador2 + 1
                End While

                contador = contador + 1
            End While
        Catch ex As Exception

        End Try
        Return ""
    End Function

    Public Shared Function movefilestofldata()
        'muevo todo a la carpeta fldata LO DEJO AQUÍ
        ' SI NO EXISTE LA CREO
        'SI NO EXISTE ESE FICHERO DENTRO LO BUSCO FUERA Y LO METO DENTRO
        Try
            If My.Computer.FileSystem.DirectoryExists(Directory.GetCurrentDirectory & "\fldata") = False Then
                Directory.CreateDirectory(Directory.GetCurrentDirectory & "\fldata")
            End If

            If File.Exists("version.txt") = True Then
                Try
                    File.Move(vars.UserDir & "\version.txt", vars.UserDir & "\fldata\version.txt")
                Catch
                End Try
                Try
                    File.Delete(vars.UserDir & "\version.txt")
                Catch
                End Try
            End If

            If File.Exists("fl_whatsnew.txt") = True Then
                Try
                    File.Move(vars.UserDir & "\fl_whatsnew.txt", vars.UserDir & "\fldata\fl_whatsnew.txt")
                Catch
                End Try
                Try
                    File.Delete(vars.UserDir & "\fl_whatsnew.txt")
                Catch
                End Try
            End If

            If File.Exists("unsupportedcards.txt") = True Then
                Try
                    File.Move(vars.UserDir & "\unsupportedcards.txt", vars.UserDir & "\fldata\unsupportedcards.txt")
                Catch
                End Try
                Try
                    File.Delete(vars.UserDir & "\unsupportedcards.txt")
                Catch
                End Try
            End If

            If File.Exists("updates.txt") = True Then
                Try
                    File.Move(vars.UserDir & "\updates.txt", vars.UserDir & "\fldata\updates.txt")
                Catch
                End Try
                Try
                    File.Delete(vars.UserDir & "\updates.txt")
                Catch
                End Try
            End If
        Catch
        End Try
    End Function

    Public Shared Function GetDelimitedText(Text As String, OpenDelimiter As String,
  CloseDelimiter As String, index As Long) As String
        Dim i As Long, j As Long

        If index = 0 Then index = 1

        ' search the opening mark
        i = InStr(index, Text, OpenDelimiter, vbTextCompare)
        If i = 0 Then
            index = 0
            Exit Function
        End If
        i = i + Len(OpenDelimiter)

        ' search the closing mark
        j = InStr(i + 1, Text, CloseDelimiter, vbTextCompare)
        If j = 0 Then
            index = 0
            Exit Function
        End If

        ' get the text between the two Delimiters
        GetDelimitedText = Mid$(Text, i, j - i)

        ' advanced the index after the closing Delimiter
        index = j + Len(CloseDelimiter)

    End Function

End Class