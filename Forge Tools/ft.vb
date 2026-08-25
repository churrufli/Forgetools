Imports ICSharpCode.SharpZipLib.Zip

Public Class ft
    Dim second As Integer

    Private Sub Fl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupExtras.TabPages.Remove(GroupExtras.TabPages(1))

    End Sub

    Private Sub Fl_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fn.WriteUserLog("Loading data..." & vbCrLf)
        Timer1.Interval = 10
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        second = second + 1
        If second >= 1 Then
            Timer1.Stop()
            If vars.InitAll Then
                InitProgram()
                vars.InitAll = True
            End If
        End If
    End Sub

    Sub InitProgram()
        fn.CheckLog()
        SetComboboxes()
        'fn.SearchFolders(True)
        fn.UnsupportedCards()


    End Sub

    Sub SetComboboxes()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add("8", "8")
        comboSource.Add("12", "12")
        comboSource.Add("16", "16")
        comboSource.Add("25", "25")
        comboSource.Add("50", "50")

        Dim comboSource2 As New Dictionary(Of String, String)()
        comboSource2.Add("8", "8")
        comboSource2.Add("12", "12")
        comboSource2.Add("16", "16")
        comboSource2.Add("25", "25")
        comboSource2.Add("50", "50")
        comboSource2.Add("75", "75")
        comboSource.Add("99", "99")
        comboSource.Add("125", "125")
        comboSource.Add("150", "150")
        comboSource.Add("175", "175")
        comboSource2.Add("200", "200")
        comboSource2.Add("999", "999")

        howmuch2.DataSource = New BindingSource(comboSource2, Nothing)
        howmuch2.DisplayMember = "Value"
        howmuch2.ValueMember = "Key"

        howmuch.DataSource = New BindingSource(comboSource, Nothing)
        howmuch.DisplayMember = "Value"
        howmuch.ValueMember = "Key"

        howmuch3.DataSource = New BindingSource(comboSource, Nothing)
        howmuch3.DisplayMember = "Value"
        howmuch3.ValueMember = "Key"

        metagame.SelectedIndex = 0
        metag2.SelectedIndex = 0

        ComboBox1.SelectedItem = ComboBox1.Items(0)
        ComboBox2.SelectedItem = ComboBox2.Items(0)

        maxtournm.SelectedItem = maxtournm.Items(0)
        fromweb.SelectedItem = fromweb.Items(0)
        maxtournamentsdecks.SelectedItem = maxtournamentsdecks.Items(0)

    End Sub

    Sub DisableStuffs()
        If fn.CheckIfForgeExists() = False Then
            GroupExtras.Enabled = False
        Else
            GroupExtras.Enabled = True
        End If
    End Sub

    Private Sub extract_Click(sender As Object, e As EventArgs) Handles extract1.Click

        If InStr(metagame.SelectedItem.ToString, "-") = 0 Then
            Ext.ExtractTopMtggoldfish(metagame.SelectedItem.ToString, howmuch.Text, chktopnumber.Checked,
                                      Nothing, "", False)
            Exit Sub
        End If

        If InStr(metagame.SelectedItem.ToString, "Download All") > 0 Then
            If _
                MsgBox("This action will take a long time, Are you sure?", MsgBoxStyle.YesNoCancel, "") =
                MsgBoxResult.Yes Then
                Dim formats = "Standard,Modern,Pauper,Legacy,Vintage,Commander 1v1,Commander, Arena Standard"
                Dim f() = Split(formats, ",")
                For i = 0 To f.Length - 1
                    Ext.ExtractTopMtggoldfish(f(i), howmuch.SelectedValue, chktopnumber.Checked, Nothing)
                Next i
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles extract3.Click
        If InStr(metag2.SelectedItem.ToString, "-") = 0 Then
            Ext.ExtractTopMtggoldfish(metag2.SelectedItem.ToString, howmuch2.SelectedValue, False, "", "", True)
        End If
    End Sub

    Function RemoveNumbers(t) As String
        t = Replace(t, "0", "")
        t = Replace(t, "1", "")
        t = Replace(t, "2", "")
        t = Replace(t, "3", "")
        t = Replace(t, "4", "")
        t = Replace(t, "5", "")
        t = Replace(t, "6", "")
        t = Replace(t, "7", "")
        t = Replace(t, "8", "")
        t = Replace(t, "9", "")
        Return t
    End Function

    Private Sub OpenDecksFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles OpenDecksFolderToolStripMenuItem.Click
        Try
            Dim folder = fn.ReadLogUser("decks_dir", False)
            Process.Start(folder)
        Catch
            fn.PrintError(Err.Description)
        End Try
    End Sub

    Private Sub extract4_Click(sender As Object, e As EventArgs) Handles extract4.Click
        Select Case fromweb.SelectedItem.ToString
            Case "mtgtop8"
                Ext.ExtractFromMtgtop8(Replace(maxtournamentsdecks.SelectedItem.ToString, "Limit ", ""))
            Case "mtggoldfish"
                Dim w As String =
                        fn.ReadWeb(LCase(
                            "https://www.mtggoldfish.com/tournaments/" & ComboBox2.SelectedItem.ToString & "#paper"))
                Dim links = Ext.extlinks(w, "/tournament/")
                Dim pageUrl = ""
                Dim t = ""

                Dim urls() As String = Split(links, vbCrLf)
                For i = 0 To urls.Length - 1
                    If urls(i) <> "" Then

                        Dim tournament_url = ("https://www.mtggoldfish.com" & urls(i))
                        extracttournamentmtggoldfish(tournament_url,
                                                     Replace(maxtournamentsdecks.SelectedItem.ToString, "Limit ", ""))
                        Dim max = 5
                        Select Case maxtournm.SelectedItem.ToString
                            Case "Last One"
                                max = 1
                            Case "Last 2"
                                max = 2
                            Case "Last 5"
                                max = 5
                            Case "Last 10"
                                max = 10
                            Case Else
                                max = 100
                        End Select
                        If (i + 1) >= max Then
                            Exit For
                        End If

                    End If

                Next i

        End Select
    End Sub

    'this is the good function
    Public Sub extracttournamentmtggoldfish(Optional ByVal tournament_url As String = "",
                                            Optional ByVal maxdecks As Integer = 100)

        'get the tournament link here, OK, should create the folder
        Dim baseDir As String = "netdecks\mtggoldfish\" & fn.ReadLogUser("tournamentsdecks_dir", False) &
                              "\"

        Dim tx1 As String
        'PUT THE TOURNAMENT'S TEXT IN A VARIABLE TO GET THE DECK URLS
        tx1 = fn.ReadWeb(tournament_url)

        Dim tournamentName = ""

        ' Read the content.
        Dim res As String = tx1
        'FORMAT THE name
        tournamentName = fn.FindIt(tx1, "<title>", "</title>")
        tournamentName = Replace(tournamentName, " (" & ComboBox2.SelectedItem.ToString & ") Decks", "")
        While tournamentName = Nothing
            If _
        MsgBox(
            "Throtted in page, PLEASE WAIT!!! 1 OR 2 MINUTE TO CONTINUE, THEN PRESS YES", MsgBoxStyle.YesNo, "Warning!") = MsgBoxResult.Yes Then
                tx1 = fn.ReadWeb(tournament_url)
                'retry
                tournamentName = ""
                ' Read the content.
                res = tx1
                'FORMAT THE name
                tournamentName = fn.FindIt(tx1, "<title>", "</title>")
                'retry ends here
            Else
                Exit Sub
            End If
        End While

        If tournamentName Is Nothing Then tournamentName = ""
        tournamentName = fn.Normalize(tournamentName)
        tournamentName = tournamentName.Trim()
        tournamentName = Replace(tournamentName, ":", "")
        'BUILD A MyFolder USING THE TOURNAMENT name
        Dim MyFolder As String = baseDir & tournamentName & "\"

        If Directory.Exists(MyFolder) Then
            If _
                MsgBox(
                    "Folder " & tournamentName & " exists, do you want to download decks again? " & vbCrLf & vbCrLf &
                    " (Decks inside the folder will be deleted)", MsgBoxStyle.YesNoCancel, "Warning!") = MsgBoxResult.No _
                Then 'Or (MsgBoxResult.Cancel)
                fn.WriteUserLog(tournamentName & " folder exists. Operation cancelled." & vbCrLf)
                Exit Sub
            End If
        End If
        Try
            Directory.Delete(MyFolder, True)
        Catch

        End Try
        fn.CheckFolder(MyFolder)
        txlog.Text = ""
        fn.WriteUserLog("Creating " & MyFolder & vbCrLf)

        'GET THE DECK URLS

        tx1 = Ext.extlinks(tx1, "/deck/", "/deck/custom/standard") '"/visual/",

        'WE NOW HAVE THE URLS, TIME TO EXTRACT THEM ONE BY ONE
        Dim deckUrls() As String = Split(tx1, vbCrLf)
        Dim maxDecksLimit = Replace(maxtournamentsdecks.SelectedItem.ToString, "Limit ", "")
        Dim positionCounter = 0
        For a = 0 To deckUrls.Length - 1

            If _
                deckUrls(a).ToString <> "" And
                deckUrls(a).ToString <> "/deck/custom/" & LCase(ComboBox2.SelectedItem.ToString) Then

                If a > maxDecksLimit Then Exit For

                Dim DeckPage = ""
                Dim UrlDeck = ""
                'page for deck i
                DeckPage = fn.ReadWeb(vars.mtggf & deckUrls(a))
                'url for deck i

                UrlDeck = Ext.extmtggoldfish(DeckPage, "/deck/download/")
                If UrlDeck.Contains(vbCrLf) Then UrlDeck = UrlDeck.Split(vbCrLf)(0).ToString
                Dim Deck = ""
                Dim TitDeck = ""
                'title for deck i

                'format the deck title

                'get the deck's text
                Deck = fn.ReadWeb(vars.mtggf & "/" & UrlDeck)

                'format the deck
                Deck = Replace(Deck, "sideboard", "[sideboard]")
                Deck = Replace(Deck, vbCrLf & vbCrLf, vbCrLf & "[sideboard]" & vbCrLf)

                Deck = Replace(Deck, "[[", "[")
                Deck = Replace(Deck, "]]", "]")
                TitDeck = Ext.GetTitDeck(DeckPage)
                If TitDeck = "Untitled" Then
                    Dim asssssa As String = ""
                End If
                TitDeck = fn.Normalize(TitDeck)
                TitDeck = Replace(TitDeck, "_", " ")
                TitDeck = Replace(TitDeck, """", "'")

                Dim num As String = (positionCounter + 1).ToString
                If Len(num) <= 1 Then num = "0" & num

                TitDeck = "#" & num & " - " & TitDeck

                positionCounter = (positionCounter + 1).ToString
                Deck = fn.FormatDeck(Deck, TitDeck)
                fn.StringToDeck(MyFolder, Deck, TitDeck)
                fn.WriteUserLog("Saving " & TitDeck & vbCrLf)
            End If

        Next a
        extract1.Enabled = True
        fn.WriteUserLog("Completed")
        't = fn.ReadWeb(web)
        'is the below ok?
        ' If i = 0 Then Exit For

        'end of the loop
    End Sub

    Public Shared Function IsFormOpen(FormType As Type) As Boolean
        For Each OpenForm In Application.OpenForms
            If OpenForm.GetType() = FormType Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub SettingsToolStripMenuItem1_Click(sender As Object, e As EventArgs) _
        Handles SettingsToolStripMenuItem1.Click
        Dim opened = False

        For Each frm As Form In Application.OpenForms
            If frm.Name.Equals("preferences") Then
                frm.Show()
                opened = True
            End If
        Next

        If opened = False Then
            Dim box = New preferences()
            box.Show()
        End If
    End Sub

    Private Sub txlog_TextChanged(sender As Object, e As EventArgs) Handles txlog.TextChanged
    End Sub

    Sub CreateCardsBySetFile()

        Dim allCards As String = File.ReadAllText(vars.UserDir & "\fldata\allsupportedcards.txt")
        Dim allEditions As String = File.ReadAllText(vars.UserDir & "\fldata\allmysets.txt")
        Dim destinationContent As String = File.ReadAllText(vars.UserDir & "\fldata\allcardsandsets.txt")

        Dim result = ""

        Dim cardLines = Split(allCards, vbCrLf)
        Dim editionLines() = Split(allEditions, vbCrLf)

        Dim editionsArray() As String

        Dim badEditionsArray() As String
        Dim goodEditionsList As New List(Of String)()
        Dim badEditionsList As New List(Of String)()
        Dim ignoreList As New List(Of String)()

        Dim goodCount = 0
        Dim badCount = 0

        For x = 0 To editionLines.Length - 1
            If editionLines(x) <> "" Then

                Dim setCode = Split(editionLines(x), "SetCode=")(1).Split("|")(0)
                Dim setFolder = Split(editionLines(x), "Folder=")(1).Split("|")(0)
                Dim SetType = Split(editionLines(x), "SetType=")(1).Split("|")(0)

                Dim shouldInclude As Boolean = True
                'this is where I list the ones I don't want to include
                Dim expansionType = Split(editionLines(x), "SetType=")(1).Split(vbLf)(0).ToString
                If setCode = "UNH" Then
                    goodEditionsList.Add(setCode)
                    shouldInclude = False
                End If
                If setCode = "PLIST" Then
                    badEditionsList.Add(setCode)
                    shouldInclude = False
                End If
                If setCode = "PSLD" Then
                    badEditionsList.Add(setCode)
                    shouldInclude = False
                End If
                If shouldInclude Then
                    Select Case expansionType
                        Case "Expansion", "Core", "Other", "Reprint"
                            goodEditionsList.Add(setCode)
                        Case Else
                            badEditionsList.Add(setCode)
                    End Select
                End If

            End If
        Next x

        For i = 0 To cardLines.Length - 1
            Dim cardName = Split(cardLines(i), "|")(0)
            Dim cardEdition = Split(cardLines(i), "|")(1)
            If cardEdition.Contains("|") Then cardEdition = Split(cardEdition, "|")(0)

            cardName = cardName
            cardEdition = cardEdition

            For b = 0 To badEditionsList.Count - 1
                Dim cardLineWithBreak = cardLines(i) & vbCrLf
                If cardLineWithBreak.Contains("|" & badEditionsList(b) & vbCrLf) Then
                    destinationContent = Replace(destinationContent, vbCrLf & cardName & "|" & badEditionsList(b) & vbCrLf, Nothing)
                    File.Delete(vars.UserDir & "\fldata\allcardsandsets.txt")
                    Dim fPath = vars.UserDir & "\fldata\allcardsandsets.txt"
                    destinationContent = Replace(destinationContent, vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf, vbCrLf)
                    destinationContent = Replace(destinationContent, vbCrLf & vbCrLf & vbCrLf & vbCrLf, vbCrLf)
                    destinationContent = Replace(destinationContent, vbCrLf & vbCrLf & vbCrLf, vbCrLf)
                    destinationContent = Replace(destinationContent, vbCrLf & vbCrLf, vbCrLf)

                    Using afile As New StreamWriter(fPath, True)
                        afile.WriteLine(destinationContent)
                    End Using
                End If
            Next b

        Next i

        destinationContent = ""
        Dim previousCard As String = ""
        For i = 0 To cardLines.Length - 1

            destinationContent = ""
            destinationContent = File.ReadAllText(vars.UserDir & "\fldata\allcardsandsets.txt")

            'format the card
            Dim cardName = Split(cardLines(i), "|")(0)
            Dim cardEdition = Split(cardLines(i), "|")(1)

            If Environment.NewLine & cardName & "|" <> previousCard Then

                If cardEdition.Contains("|") Then cardEdition = Split(cardEdition, "|")(0)
                cardName = cardName
                cardEdition = cardEdition
                Dim found As Boolean

                fn.WriteUserLog("processing " & cardName & vbCrLf)

                For e = 0 To goodEditionsList.Count - 1
                    found = False

                    'pattern used to search through the full list
                    Dim pattern = cardName & "|" & goodEditionsList(e)
                    If destinationContent.Contains(Environment.NewLine & cardName & "|") Then
                        found = True
                        Exit For
                    End If

                    If _
                        cardName = "Forest" Or cardName = "Plains" Or cardName = "Swamp" Or cardName = "Mountain" Or
                        cardName = "Island" Then
                        found = True
                        result = cardName & "|KHM"
                        Exit For
                    End If

                    If cardName = "Wastes" Then
                        found = True
                        result = cardName & "|OGW"
                        Exit For
                    End If

                    Dim hasMatch = False
                    Try
                        'THIS IS WHERE I CHECK IF EDITION X MATCHES IN THE FILE OF ALL CARDS
                        'Dim check = Split(allCards,Environment.NewLine & pattern)(0).Split(vbCrLf)(0)
                        'If check = pattern then
                        If allCards.Contains(Environment.NewLine & pattern) = True Then
                            result = pattern
                            found = True
                            Exit For
                        End If
                    Catch
                    End Try
                Next e

                If found = False Then
                    result = cardName & "|" & cardEdition
                Else
                    result = result
                End If

                If result <> "" Then
                    Dim cacheFolder = Directory.GetCurrentDirectory() & "\cache\pics\cards\" &
                                    Split(result, "|")(1)
                    If Directory.Exists(cacheFolder) = False And found = True Then
                        cacheFolder = cacheFolder
                    End If
                End If
                If result <> "" Then
                    Dim test = Environment.NewLine & Split(result, "|")(0) & "|"
                    If destinationContent.Contains(test) = True Then
                        result = ""
                    End If
                End If
                If result <> "" Then
                    If i > 0 Then '"ach ach run"
                        Using file = My.Computer.FileSystem.OpenTextFileWriter(vars.UserDir & "\fldata\allcardsandsets.txt", True)
                            file.WriteLine(result)
                        End Using
                    End If
                Else
                    destinationContent = File.ReadAllText(vars.UserDir & "\fldata\allcardsandsets.txt")
                    If destinationContent.Contains(vbCrLf & cardName & "|") = False Then
                        Using file = My.Computer.FileSystem.OpenTextFileWriter(vars.UserDir & "\fldata\allcardsandsets.txt", True)
                            file.WriteLine(cardName & "|" & cardEdition)
                        End Using
                    End If
                    destinationContent = ""
                End If

                previousCard = Environment.NewLine & cardName & "|"
            End If

        Next i
    End Sub

    'Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles Button1.Click

    '    Dim yearValid = False
    '    Dim formatValid = False
    '    If lbgauntletyear.SelectedIndex <> -1 Then
    '        yearValid = True
    '    End If
    '    If yearValid = False Then
    '        MsgBox("Select Year")
    '        Exit Sub
    '    End If

    '    If lbgauntletformat.SelectedIndex <> -1 Then
    '        formatValid = True
    '    End If
    '    If formatValid = False Then
    '        MsgBox("Select Format")
    '        Exit Sub
    '    End If

    '    Dim year = lbgauntletyear.SelectedItem.ToString
    '    Dim tournamentFormat = lbgauntletformat.SelectedItem.ToString
    '    Button1.Enabled = False
    '    Try
    '        File.Delete("gauntlet.zip")
    '    Catch
    '    End Try
    '    Try
    '        fn.DownloadFile(vars.BaseUrl & "gauntlets/" & LCase(tournamentFormat) & "/" & year & ".zip", "gauntlet.zip", True)
    '    Catch
    '        fn.WriteUserLog("Unable to get from server temporarily, please try later." & vbCrLf)
    '        Exit Sub
    '    End Try
    '    'Try
    '    Dim mycount As Long = 0
    '    vars.UserDir = My.Settings.myuser_directory
    '    vars.UserDir = Replace(vars.UserDir, "/user", "")
    '    vars.UserDir = Replace(vars.UserDir, "\user", "")
    '    Dim userPath = fn.ReadLogUser("gauntlet_dir", False, False)

    '    Using archive As ZipArchive = ZipFile.OpenRead("gauntlet.zip")
    '        For Each entry As ZipArchiveEntry In archive.Entries
    '            entry.ExtractToFile(Path.Combine(userPath & "\", entry.FullName), True)
    '            fn.WriteUserLog("Extracting Gauntlet " & entry.Name & vbCrLf)
    '            mycount += 1
    '        Next
    '    End Using

    '    Try
    '        File.Delete("gauntlet.zip")
    '    Catch
    '    End Try
    '    Button1.Enabled = True
    'End Sub

    Private Sub GroupExtras_TabIndexChanged(sender As Object, e As EventArgs) Handles GroupExtras.TabIndexChanged
    End Sub

    Public Sub GroupExtras_Selected(sender As Object, e As TabControlEventArgs) Handles GroupExtras.Selected
        'If GroupExtras.SelectedTab.Text.Contains("Gauntlet") Then
        '    Dim mensakje = "Download Gauntlets and play through Forge > Gauntlets > Gauntlets Conquest. Choose your deck and overcome each challenge, defeating all opponents, from the last deck to the first deck of the tournament, from 2014 onwards. Select year and format and download. " & vbCrLf & vbCrLf & "Warning! Forge may slow down loading if there are too many Gauntlets files."
        '    txlog.Text = ""
        '    fn.WriteUserLog(mensakje)
        'End If
    End Sub

    Private Sub CheckForForgeLauncherUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CheckForForgeLauncherUpdatesToolStripMenuItem.Click
        CheckLauncherUpdates()
    End Sub

    Public Shared Sub CheckLauncherUpdates()
        Try
            fn.WriteUserLog("Checking for updates..." & vbCrLf)
            'Dim x As String = fn.ReadWeb("https://github.com/churrufli/myforgetools/releases/")

            If _
                     MsgBox("Update Forge Tools auto-getting last version from GitHub?", MsgBoxStyle.YesNo, "") =
                    MsgBoxResult.Yes Then
                Try
                    fn.WriteUserLog("Downloading new version from GitHub..." & vbCrLf)
                    Dim myUrl = "https://github.com/churrufli/myforgetools/releases/download/0.2/Forge.Tools.zip"
                    fn.DownloadFile(myUrl, "Forge Tools New Version.zip", True)
                    fn.WriteUserLog("Unpacking new version in " & Directory.GetCurrentDirectory() & "..." & vbCrLf)
                    fn.UnzipFile(Directory.GetCurrentDirectory() & "/" & "Forge Tools New Version.zip",
                                  Directory.GetCurrentDirectory() & "/fltmp")
                    File.Delete("Forge Tools New Version.zip")
                    File.Move("Forge Tools.exe", "fltmp/Forge Tools.bak")
                    File.Copy("fltmp/Forge Tools.exe", "Forge Tools.exe")
                Catch
                End Try
                Try
                    Directory.Delete("fltmp", True)
                Catch
                End Try
                Application.Restart()
            End If
        Catch

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button4.Enabled = False
        CreateSetsFile()
        Button4.Enabled = True
    End Sub

    Sub CreateSetsFile()
        Dim di As New DirectoryInfo(Directory.GetCurrentDirectory() & "\res\editions\")
        'Dim di As New DirectoryInfo(IO.Directory.GetCurrentDirectory() & "/res/editions/")
        ' Get a reference to each file in that directory.
        Dim fiArr As FileInfo() = di.GetFiles()
        ' Display the names of the files.
        Dim fri As FileInfo
        Dim myList As New List(Of String)()
        For Each fri In fiArr
            Dim readText As String = File.ReadAllText(IO.Directory.GetCurrentDirectory() & "/res/editions/" & fri.Name)

            Dim SetCode = Split(readText, "Code=")(1).Split(vbLf)(0)

            Dim SetFolder = SetCode
            Dim SetType = ""
            Dim SetDate = Split(readText, "Date=")(1).Split(vbLf)(0)
            Dim SetName = Split(readText, "Name=")(1).Split(vbLf)(0)
            Try
                SetType = Split(readText, "Type=")(1).Split(vbLf)(0)
            Catch
                SetType = "?"
            End Try

            Try
                SetFolder = Split(readText, "Code2=")(1).Split(vbLf)(0)
            Catch
            End Try

            Dim lineText = "SetDate=" & SetDate & "|SetName=" & SetName & "|SetCode=" & SetCode & "|SetFolder=" & SetFolder & "|SetType=" & SetType
            lineText = Replace(lineText, vbCr, Nothing)
            myList.Add(lineText)

            Console.WriteLine(fri.Name)

        Next fri

        '**************

        Dim myListSortedByDate As New List(Of String)()

        Dim startDate As DateTime = New DateTime(1993, 8, 5)
        Dim endDate As DateTime = New DateTime(DateTime.Now.Year, Date.Now.Month, Date.Now.Day)
        Dim currentDate As DateTime = startDate

        While (currentDate <= endDate)

            For i = 0 To myList.Count - 1
                Dim entryDate = Split(myList(i), "SetDate=")(1).Split("|")(0)
                If CDate(entryDate).ToShortDateString = CDate(currentDate).ToShortDateString Then
                    myListSortedByDate.Add(myList(i))
                End If
            Next i
            currentDate = currentDate.AddDays(1)

        End While

        myListSortedByDate.Reverse()

        'delete it and create it
        File.Delete(vars.UserDir & "\fldata\allmysets.txt")
        'create it here
        Dim fPath = vars.UserDir & "\fldata\allmysets.txt"

        Using afile As New StreamWriter(vars.UserDir & "\fldata\allmysets.txt", True)
            For i = 0 To myListSortedByDate.Count - 1
                afile.WriteLine(myListSortedByDate(i))
            Next i
        End Using
        MsgBox("\fldata\allmysets.tx created!")

    End Sub

    Private Sub Button5_Click_2(sender As Object, e As EventArgs) Handles Button5.Click
        Button5.Enabled = False

        CreateCardsBySetFile()
        Button5.Enabled = True

    End Sub

    Sub PutEditionsInDecks(gameFormat)

        For Each f In Directory.GetFiles(Directory.GetCurrentDirectory() & "\user\decks\constructed\" & gameFormat)
            Dim t = File.ReadAllText(f)
            t = t
            If t <> "" Then
                Dim tx = Split(t, "[Main]")(1).ToString()
                Dim name = Split(t, "Name = ")(1).Split(vbCrLf)(0)
                tx = tx

                name = name
                'tx = fn.PutEdition(tx, name)
                tx = tx
                File.Delete(f)
                Using afile As New StreamWriter(f, True)
                    afile.WriteLine(tx)
                End Using
                fn.WriteUserLog(name & vbCrLf)

            End If

        Next

    End Sub

    Function GetMetagameFolder(gameFormat As String) As String
        If gameFormat.Contains("Commander") Then
            Return Directory.GetCurrentDirectory() & "\user\decks\commander\"
        End If

        If gameFormat.Contains("Brawl") Then
            Return Directory.GetCurrentDirectory() & "\user\decks\brawl\"
        End If

        Return Directory.GetCurrentDirectory() & "\user\decks\constructed\" & gameFormat
    End Function

    Sub RemoveEditionsFromDecks(gameFormat)

        Dim folder = GetMetagameFolder(gameFormat)

        Dim result As String

        For Each f In Directory.GetFiles(folder)
            result = ""
            Dim t = File.ReadAllText(f)
            t = t
            If t <> "" Then
                Dim tx = Split(t, "[Main]")(1).ToString()
                Dim name = Split(t, "Name = ")(1).Split(vbCrLf)(0)
                tx = tx

                name = name

                'split it by newlines
                Dim lines() = Split(tx, vbCrLf)
                For i = 0 To lines.Count - 1
                    If lines(i) <> "" Then
                        If lines(i).Contains("|") Then
                            result = result & Split(lines(i), "|")(0) & vbCrLf
                        Else
                            result = result & lines(i) & vbCrLf
                        End If
                    End If

                Next

                tx = "[metadata]" & vbCrLf & "Name = " & name & vbCrLf & "[Main]" & vbCrLf & result
                tx = Replace(tx, Environment.NewLine, vbCrLf)
                tx = Replace(tx, vbCrLf & vbCrLf & vbCrLf, vbCrLf)
                tx = Replace(tx, vbCrLf & vbCrLf, vbCrLf)

                tx = tx
                File.Delete(f)
                Using afile As New StreamWriter(f, True)
                    afile.WriteLine(tx)
                End Using
                fn.WriteUserLog(name & vbCrLf)

            End If

        Next

    End Sub

    Sub findcard(cardname)
        Dim gameFormat = metagame.SelectedItem.ToString()
        Dim folder = GetMetagameFolder(gameFormat)

        For Each f In Directory.GetFiles(folder)
            Dim t = File.ReadAllText(f)
            If t.Contains(cardname) Then
                MsgBox("Find " & cardname & " in " & f)
                Exit Sub
            End If
            fn.WriteUserLog("Searching in " & f & vbCrLf)
        Next

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        findcard(cardtofind.Text)
    End Sub

    Public Shared Sub compressDirectory(DirectoryPath As String, OutputFilePath As String,
                                        ByVal Optional CompressionLevel As Integer = 9)
        Try
            Dim filenames As String() = Directory.GetFiles(DirectoryPath)

            Using OutputStream = New ZipOutputStream(File.Create(OutputFilePath))
                OutputStream.SetLevel(CompressionLevel)
                Dim buffer = New Byte(4095) {}

                For Each file As String In filenames
                    Dim entry = New ZipEntry(Path.GetFileName(file))
                    entry.DateTime = DateTime.Now
                    OutputStream.PutNextEntry(entry)

                    Using fs As FileStream = IO.File.OpenRead(file)
                        Dim sourceBytes As Integer

                        Do
                            sourceBytes = fs.Read(buffer, 0, buffer.Length)
                            OutputStream.Write(buffer, 0, sourceBytes)
                        Loop While sourceBytes > 0
                    End Using
                Next

                OutputStream.Finish()
                OutputStream.Close()
                Console.WriteLine("Files successfully compressed")
            End Using
        Catch ex As Exception
            Console.WriteLine("Exception during processing {0}", ex)
        End Try
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        If File.Exists(IO.Directory.GetCurrentDirectory() & "/fldata/allcardsandsets.txt") = False Then
            File.Create(IO.Directory.GetCurrentDirectory() & "/fldata/allcardsandsets.txt").Dispose()
        End If

        Dim actual As String = File.ReadAllText(IO.Directory.GetCurrentDirectory() & "/fldata/allcardsandsets.txt")
        Dim Listado As New List(Of String)()
        Dim goodEditionsList As New List(Of String)()
        Dim arr = Split(actual, vbCrLf)
        For Each i In arr
            If i <> "" Then
                Listado.Add(i.ToString)
            End If
        Next

        Dim Cards As New List(Of String)()

        'I should really go through the sets by date to get the current cards, BUT TRYING IT THIS WAY FOR NOW

        Dim di As New DirectoryInfo(Directory.GetCurrentDirectory() & "\res\editions\")

        Dim fiArr As FileInfo() = di.GetFiles()
        ' Display the names of the files.
        Dim fri As FileInfo
        Dim myList As New List(Of String)()
        For Each fri In fiArr
            Dim readText As String = File.ReadAllText(IO.Directory.GetCurrentDirectory() & "/res/editions/" & fri.Name)
            If readText.Contains(vbLf) Then readText.Replace(vbLf, vbCrLf)
            If readText.Contains(vbCr) Then readText.Replace(vbCr, vbCrLf)
            Dim Listcards
            Try
                Listcards = Split(readText, "[cards]" & vbCrLf)(1)
            Catch
            End Try
            If Listcards = Nothing Then
                Listcards = Split(readText, "[cards]" & vbLf)(1)

            End If

            If Listcards.Contains("[tokens]") Then Listcards = Split(Listcards, "[tokens]" & vbCrLf)(0)
            Listcards = Replace(Listcards, vbCrLf & vbCrLf, Nothing)
            Listcards = RemoveNumbers(Listcards)
            Listcards = Replace(Listcards, " R ", "")
            Listcards = Replace(Listcards, " M ", "")
            Listcards = Replace(Listcards, " U ", "")
            Listcards = Replace(Listcards, " S ", "")
            Listcards = Replace(Listcards, " C ", "")
            Listcards = Replace(Listcards, " L ", "")
            Dim list = Split(Listcards, vbCrLf)
            For i = 0 To list.Count - 1
                If list(i) <> "" Then
                    Dim card = list(i)
                    If card.Contains("+") Then card = Split(card, "+")(0).ToString()
                    If card.Contains("|") Then card = Split(card, "|")(0).ToString()
                    If card.Contains("[") Then card = Split(card, "[")(0).ToString()
                    card = Trim(card)
                    '"★"
                    'add it if it doesn't already exist
                    If actual.Contains(card & vbCrLf) = False Then
                        Cards.Add(card)
                    End If
                End If
            Next

        Next
        'SORT ALPHABETICALLY AND REMOVE DUPLICATES
        Cards = Cards.Distinct().ToList()
        Cards.Sort()

        Dim t As String
        For Each a In Cards
            t = t & a & vbCrLf
        Next

        Using afile As New StreamWriter(IO.Directory.GetCurrentDirectory() & "/fldata/allcardsandsets.txt", True)
            afile.WriteLine(t)
        End Using

    End Sub

    Private Sub by_metagame_Click(sender As Object, e As EventArgs) Handles by_metagame.Click

    End Sub

    Public Sub Button3_Click_4(sender As Object, e As EventArgs) Handles Button3.Click
        Ext.ExtractfromAetherhub(TextBox1.Text.ToString, False, "", "100", True)
    End Sub

    Private Sub Button1_Click_4(sender As Object, e As EventArgs) Handles Button1.Click
        Dim metag = Replace(ComboBox1.Text, " ", "-")
        Ext.ExtractfromAetherhub("https://aetherhub.com/Metagame/" & metag & "/", IIf(puttopaetherhub.Checked, True, False), metag, howmuch3.Text, False)
    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        Dim gameFormat = metagame.SelectedItem.ToString()
        Dim folder = ""

        If gameFormat.Contains("Commander") Then
            folder = Directory.GetCurrentDirectory() & "\user\decks\commander\"
        End If

        If gameFormat.Contains("Brawl") Then
            folder = Directory.GetCurrentDirectory() & "\user\decks\brawl\"
        End If

        If folder = "" Then folder = Directory.GetCurrentDirectory() & "\user\decks\constructed\mtggoldfish\" & gameFormat

        Dim outputFile = folder & "\current" & LCase(fn.RemoveWhitespace(Replace(gameFormat, " ", "")) & "metagame.zip")
        If File.Exists(outputFile) Then
            File.Delete(outputFile)
        End If

        compressDirectory(folder, outputFile)
        fn.WriteUserLog("Zipped " & outputFile & vbCrLf)

    End Sub

    Private Sub Button6_Click_2(sender As Object, e As EventArgs) Handles Button6.Click
        fn.UnsupportedCards()
    End Sub

End Class