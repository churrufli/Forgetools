Imports System.Globalization
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Ext

    Public Shared Function GetTitDeck(tx) As String
        Dim TitDeck = ""
        Try
            If TitDeck = Nothing Then
                TitDeck = fn.GetDelimitedText(tx, "class=""w-100 pb-2"">", "</div>", 1)
                TitDeck = Split(TitDeck, "</h3>")(0).ToString
                TitDeck = fn.HTMLToText(TitDeck)
                TitDeck = fn.RemoveWhitespace(TitDeck)
            End If
        Catch
        End Try

        If TitDeck = Nothing Then
            fn.GetDelimitedText(tx, "<title>", "</title>", 1)
        End If

        If TitDeck = Nothing Then
            TitDeck = fn.FindIt(tx, "<title>", "Deck for Magic: the Gathering")
        End If
        If TitDeck = Nothing Then
            TitDeck = fn.FindIt(tx, "<title>", "</title>")
        End If

        If TitDeck = Nothing Then
            Return "Untitled"
        End If
        TitDeck = Replace(TitDeck, "&#39;", "'")
        If TitDeck = "" Then TitDeck = fn.FindIt(tx, "<title>", " Deck")
        TitDeck = Trim(TitDeck)
        TitDeck = Replace(TitDeck, """", "'")
        TitDeck = Replace(TitDeck, "&amp;", "and")
        TitDeck = Replace(TitDeck, ":", " ")

        Dim startString As String = TitDeck
        Dim tempParts As String()
        Dim testValue As String
        Dim tempDate As Date

        If TitDeck <> Nothing Then
            If TitDeck.Contains(" by ") Then TitDeck = Split(TitDeck, " by ")(0).ToString
            If TitDeck.Contains(" Deck") Then TitDeck = Split(TitDeck, " Deck")(0).ToString
        Else
            Return Nothing
            Exit Function
        End If

        tempParts = startString.Split(" ")

        For Each testValue In tempParts
            Try
                testValue = Replace(testValue, "-", "/")
                testValue = Replace(testValue, """", "")
                Try
                    Dim result = DateTime.ParseExact(Convert.ToString(testValue), "d/MMM/yyyy", CultureInfo.CreateSpecificCulture("es-US"))
                Catch
                End Try

                TitDeck.Replace(testValue, Nothing)
            Catch ex As Exception
            End Try
            testValue = Replace(testValue, "/", "-")
        Next

        TitDeck = Replace(TitDeck, "   ", " ")
        TitDeck = Replace(TitDeck, "  ", " ")
        TitDeck = Trim(TitDeck)
        TitDeck = Replace(TitDeck, "  ", " ")

        TitDeck = fn.RemoveWhitespace(TitDeck)
        TitDeck = Trim(TitDeck)
        TitDeck = fn.removeshit(TitDeck)
        If TitDeck.EndsWith("-") Then
            TitDeck = TitDeck.Substring(0, TitDeck.Length - 1)
        End If
        If TitDeck.EndsWith("|") Then
            TitDeck = TitDeck.Substring(0, TitDeck.Length - 1)
        End If
        TitDeck = Trim(TitDeck)

        GetTitDeck = TitDeck
    End Function

    Public Shared Function IsaDate(input As String) As Boolean
        Dim result As DateTime
        IsaDate = DateTime.TryParse(input, result)
        IsaDate = IsaDate
    End Function

    Public Shared Sub ExtractTopMtggoldfish(metag As String, hm As Object, puttop As Object, customurl As String, Optional customfolder As String = "", Optional fromuser As Boolean = False)
        'used for the top decks and for custom decks
        ft.txlog.Text = ""

        'set the URL
        Dim url = ""
        If Not IsNothing(customurl) Then url = customurl
        If url = "" Then
            Select Case (metag)
                ', "Pioneer"
                Case "Budget Modern", "Budget Standard"
                    url = vars.mtggf & "/decks/budget/" & LCase(Replace(Replace(metag, "Budget ", ""), " ", "/")) &
                          "#paper"
                Case "Budget Commander"
                    url = vars.mtggf & "/decks/budget/commander/" & "#paper"
                Case "Standard", "Modern", "Pioneer", "Historic", "Alchemy", "Pauper", "Legacy", "Vintage", "Penny Dreadful", "Commander 1v1", "Commander", "Historic Brawl", "Brawl", "Explorer"
                    url = vars.mtggf & "/metagame/" & LCase(fn.NormalizeUrl(metag)) & "/full#paper"
                Case Else
                    url = vars.mtggf & "/deck/custom/" & fn.NormalizeUrl(metag) & "#paper"
            End Select
        End If

        ft.extract1.Enabled = False
        Dim tx1 As String

        'put that url's content into a variable
        tx1 = fn.ReadWeb(url)
        Dim MyDir
        If url.Contains("/custom/") Then
            MyDir = "netdecks\mtggoldfish\usersdecks\" & metag & "\"
        Else
            MyDir = "netdecks\mtggoldfish\" & metag & "\"
        End If

        fn.CheckFolder(MyDir)
        Dim MyFolder = MyDir

        'create the folder
        MyFolder = Replace(MyFolder, "\\", "\")

        If ft.mtggoldfishfrom.Text = "1" Then
            'DELETE PREVIOUS DECKS
            fn.DeleteDecks(MyFolder, "[" & metag & "] *")
        End If

        fn.CheckFolder(MyFolder)

        fn.WriteUserLog("Extracting " & metag & " Decks In " & MyFolder & vbCrLf)

        Select Case metag
            'official formats
            Case "Standard", "Modern", "Pioneer", "Pauper", "Legacy", "Vintage", "Historic", "Penny Dreadful"
                tx1 = extmtggoldfish(tx1, "/archetype/", "#paper")
            Case "Budget Modern", "Budget Standard"
                tx1 = extmtggoldfish(tx1, "/deck/", "#paper", "/deck/custom")
            Case "Duel Commander", "Arena Singleton", "Historic Brawl", "Artisan Historic", "Cascade", "Oathbreaker",
                "Canadian Highlander", "Old School", "No Banned List Modern", "Frontier", "Tiny Leaders", "Limited",
                "Block", "Free Form"
                ', "-->removed from here
                tx1 = extmtggoldfish(tx1, "/deck/", "#paper", "/deck/custom")
            Case "Arena Standard"
                tx1 = extmtggoldfish(tx1, "/archetype/", "#paper")
            Case "Commander 1v1", "Commander", "Brawl"
                tx1 = extmtggoldfish(tx1, "/archetype/", "#paper")
            Case Else
                tx1 = extmtggoldfish(tx1, "/deck/", "#paper", "/deck/custom")
        End Select

        Dim num As String
        Dim checkedUrls() As String
        checkedUrls = Split(tx1, vbCrLf)
        Dim deckUrls As String = tx1

        Try

            Dim pageCounter As Long = 2
            Dim itemCount = CInt(checkedUrls.Length - (ft.mtggoldfishfrom.Text))
            'If itemCount < hm Then
            'it used to be like this:
            If checkedUrls.Length < hm Then
                'if it's less than the total for the page, go to the next one and add links
                ' While hm > checkedUrls.Length
                Dim tx2
                While checkedUrls.Length < hm

                    If _
                        LCase(metag) = "standard" Or LCase(metag) = "legacy" Or LCase(metag) = "vintage" Or
                        LCase(metag) = "pauper" Or LCase(metag) = "pioneer" Or LCase(metag) = "historic" Or LCase(metag) = "penny dreadful" Or LCase(metag) = "brawl" Then
                        If pageCounter = 2 Then
                            tx2 = ""
                            'first time through
                            'go to this url and get results
                            Dim val = LCase(metag)
                            Select Case val
                                Case "legacy"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/other-315fcdf4-70d6-41b8-bd39-699032073591#paper")
                                Case "vintage"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/other-4b59bfe3-e589-45f1-bf1b-5312d945f2d3#paper")
                                Case "pauper"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/other-e2f79915-5636-44cc-9c6f-7a74834fd316#paper")
                                Case "pioneer"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/other-2309ea0a-91b7-44c4-b0cd-945fdc82dd90#paper")
                                Case "historic"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/other-061deb94-cf17-4926-a252-571799137b88#paper")
                                Case "penny dreadful"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/penny_dreadful-other-s22#paper")

                                Case Else
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/" & LCase(metag) & "-other-znr#paper")

                            End Select
                            tx2 = extmtggoldfish(tx2, "/deck/", "", "custom")
                        Else
                            Dim val = LCase(metag)
                            Select Case val

                                Case "legacy"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/other-315fcdf4-70d6-41b8-bd39-699032073591/decks?page=" &
                                            pageCounter)
                                Case "vintage"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/other-4b59bfe3-e589-45f1-bf1b-5312d945f2d3/decks?page=" &
                                            pageCounter)
                                Case "pauper"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/other-e2f79915-5636-44cc-9c6f-7a74834fd316/decks?page=" &
                                            pageCounter)
                                Case "pioneer"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/other-2309ea0a-91b7-44c4-b0cd-945fdc82dd90/decks?page=" &
                                            pageCounter)
                                Case "historic"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/other-061deb94-cf17-4926-a252-571799137b88/decks?page=" &
                                            pageCounter)

                                Case ("penny dreadful")
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/penny_dreadful-other-s22/decks#paper")
                                Case Else
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/" & LCase(metag) & "-other-znr#paper")
                            End Select

                            tx2 = extmtggoldfish(tx2, "/deck/", "", "custom")
                        End If
                    Else
                        url = vars.mtggf & "/metagame/" & Replace(LCase(metag), " ", "_") & "/full?page=" & pageCounter &
                              "#paper"
                        If LCase(metag) = "oathbreaker" Then
                            url = Replace(url, "/metagame/", "/deck/custom/")
                            url = Replace(url, "/full", "/")
                        End If
                        tx2 = fn.ReadWeb(url)
                        If LCase(metag) = "oathbreaker" Then
                            tx2 = extmtggoldfish(tx2, "/deck/", "#paper", "custom")
                        Else
                            tx2 = extmtggoldfish(tx2, "/archetype/", "#paper", "custom")

                        End If

                    End If

                    deckUrls = deckUrls & tx2
                    checkedUrls = Split(deckUrls, vbCrLf)
                    pageCounter = pageCounter + 1
                    If tx2 = "" Then Exit While
                End While
            End If
        Catch
        End Try
        Dim urls()
        urls = Split(deckUrls, vbCrLf)
        Dim startFrom As Integer
        If ft.mtggoldfishfrom.Text = "1" Then
            startFrom = 0
        Else
            startFrom = CInt(ft.mtggoldfishfrom.Text) - 1
        End If

        Dim secondaryCounter = 0

        For i = startFrom To urls.Length - 1

            If urls(i).ToString <> "" Then

                If i >= CInt(hm) Then Exit For
                If CInt(ft.mtggoldfishfrom.Text) <> 1 Then
                    secondaryCounter = secondaryCounter + 1
                End If
                If CInt(ft.mtggoldfishfrom.Text) <> 1 Then
                    Dim remaining = CInt(secondaryCounter + CInt(ft.mtggoldfishfrom.Text)) - 1
                    If remaining > hm Then Exit Sub
                End If

                Dim DeckPage = ""
                Dim UrlDeck = ""
                Dim Deck = ""
                Dim commanderText = ""
                Dim TitDeck = ""

                Dim pageUrl As String = vars.mtggf & urls(i)
                DeckPage = fn.ReadWeb(pageUrl)
                'COMMENT HERE TO TRY TO GET COMMANDER LIST NOT FROM USERS
                'If _
                '    (InStr(metag, "Commander") > 0 Or InStr(metag, "Tiny") > 0) And
                '    InStr(DeckPage, "<h3>Similar Decks</h3>", CompareMethod.Text) > 0 Then
                '    'it might not have similar decks
                '    Dim t2 As String = Split(DeckPage, "<h3>Similar Decks</h3>")(1).ToString
                '    TitDeck = GetTitDeck(DeckPage)
                '    Dim links = extlinks(t2, "/deck/")
                '    Dim aurls() As String = Split(links, vbCrLf)
                '    For a = 0 To urls.Length - 1
                '        Dim web = ("https//www.mtggoldfish.com" & aurls(0))
                '        DeckPage = fn.ReadWeb(web)
                '        If a = 0 Then Exit For
                '    Next a
                'End If

                UrlDeck = extmtggoldfish(DeckPage, "/deck/download/")

                'SET THE DECK TITLE
                If TitDeck = "" Then
                    TitDeck = GetTitDeck(DeckPage)
                    If TitDeck = Nothing Then
                        fn.WriteUserLog("Can't get more decks, not exists or try again between range of numbers." & vbCrLf)
                        ft.extract1.Enabled = True
                        Exit Sub

                    End If
                    If TitDeck.Contains(metag) = True Then
                        TitDeck = Replace(TitDeck, metag, "")
                    End If
                    TitDeck = fn.RemoveWhitespace(TitDeck)
                    TitDeck = Trim(TitDeck)
                    TitDeck = fn.removeshit(TitDeck)
                    If TitDeck.EndsWith("-") Then
                        TitDeck = TitDeck.Substring(0, TitDeck.Length - 1)
                    End If
                    If TitDeck.EndsWith("|") Then
                        TitDeck = TitDeck.Substring(0, TitDeck.Length - 1)
                    End If
                    TitDeck = Trim(TitDeck)
                    'TitDeck = Regex.Replace(TitDeck, "(?:(?![a-zA-Z0-9])(?:[\0-\t\x0B\f\x0E-\u2027\u202A-\uD7FF\uE000-\uFFFF]|[\uD800-\uDBFF][\uDC00-\uDFFF]|[\uD800-\uDBFF](?![\uDC00-\uDFFF])|(?:[^\uD800-\uDBFF]|^)[\uDC00-\uDFFF]))+", "")
                    TitDeck = Regex.Replace(TitDeck, "[^\u0000-\u007F]", String.Empty)
                    'TitDeck = Trim(TitDeck)

                End If

                Dim shouldInclude = False
                If InStr(metag, "Commander") > 0 Or InStr(metag, "Tiny") > 0 Or InStr(metag, "Brawl") > 0 Then
                    shouldInclude = True
                End If

                If UrlDeck <> "" Then
                    shouldInclude = True
                End If

                If shouldInclude Then
                    If InStr(UrlDeck, vbCrLf) > 0 Then
                        UrlDeck = Split(UrlDeck, vbCrLf)(0)
                    End If

                    If Deck = "" Then Deck = fn.ReadWeb(vars.mtggf & "" & UrlDeck)
                    If Deck <> "" And Deck <> "Throttled" Then
                        Deck = Replace(Deck, vbLf, vbCrLf)
                        'format the deck
                        If InStr(Deck, "container-fluid layout-container-fluid", CompareMethod.Text) > 0 Then
                            Deck = mtggoldfishnewformat(Deck)
                            Deck = extmtggoldfish(Deck, "/deck/download/")
                            Deck = fn.ReadWeb(Deck)
                        End If

                        'ZERO-PADDING FOR DECK NUMBERS
                        num = (i + 1)
                        Select Case Len(hm)
                            Case 3 '100 or more
                                'how many digits does the number have?
                                Select Case Len(num)
                                    Case 1 ' up to 9
                                        num = "00" & num
                                    Case 2 'from 10 to 99
                                        num = "0" & num
                                End Select
                            Case Else
                                If Len(num) <= 1 Then
                                    num = "0" & num
                                End If
                        End Select

                        If puttop Then
                            TitDeck = "#" & num & " - " & TitDeck
                        End If
                        'FORMATTING
                        Deck = Replace(Deck, vbCr, "")
                        Deck = Replace(Deck, vbLf, vbCrLf)
                        Deck = Replace(Deck, "'" & vbCrLf & "<div id='error'" & vbCrLf & "</div" & vbCrLf, "")
                        Deck = Replace(Deck, "sideboard", "sideboard")
                        Deck = Replace(Deck, vbCrLf & vbCrLf, vbCrLf & "[sideboard]" & vbCrLf)

                        Dim isCommander = False

                        If InStr(metag, "Commander") > 0 Or InStr(metag, "Tiny") > 0 Or InStr(metag, "Brawl") > 0 Then

                            isCommander = True

                            Dim searchText As String
                            searchText = fn.HTMLToText(DeckPage)
                            searchText = fn.RemoveWhitespace(searchText)
                            commanderText = fn.FindIt(searchText, "Tabletop Arena MTGO Commander", "Creatures")
                            If commanderText = "" Then _
                                commanderText = fn.FindIt(searchText, "Tabletop Arena MTGO Commander", "Planeswalkers")
                            If commanderText = "" Then commanderText = fn.FindIt(searchText, "Tabletop Arena MTGO Commander", "Spells")

                            If Len(commanderText) > 100 Then
                                commanderText = fn.FindIt(searchText, "Tabletop Arena MTGO Commander", "Spells")
                            End If

                            If Len(commanderText) > 100 Then
                                commanderText = fn.FindIt(searchText, "Tabletop Arena MTGO Commander", "Planeswalkerss")
                            End If

                            If InStr(commanderText, " Companion ") > 0 Then
                                commanderText = Split(commanderText, " Companion ")(0).ToString
                            End If
                            commanderText = Replace(commanderText, "$", "")
                            commanderText = Replace(commanderText, " Â", "")

                            'check whether there are multiple commanders
                            Dim commanderCount As Long = 1
                            Try
                                Dim splitLine() = Split(commanderText, " 1 ")
                                If splitLine(2) <> "" Then
                                    commanderCount = 2
                                End If
                                If splitLine(4) <> "" Then
                                    commanderCount = 3
                                End If
                                If splitLine(6) <> "" Then
                                    commanderCount = 4
                                End If
                                If splitLine(8) <> "" Then
                                    commanderCount = 5
                                End If
                            Catch

                            End Try

                            Dim sb As New StringBuilder
                            If Not IsNothing(commanderText) Then
                                For Each c As Char In commanderText
                                    If Not Char.IsNumber(c) Then
                                        sb.Append(c)
                                    End If
                                Next
                            End If

                            commanderText = sb.ToString
                            commanderText = Replace(commanderText, "&#;", "'")
                            commanderText = Replace(commanderText, "$", "")
                            If InStr(commanderText, "<title>") > 0 Then
                                commanderText = Split(commanderText, "<title>")(0).ToString
                            End If
                            commanderText = Trim(commanderText)
                            Dim commanderParts = Split(commanderText, ".")
                            Dim combinedCommander = ""

                            For xy = 0 To commanderParts.Length - 1
                                If Len(commanderParts(xy).ToString) > 3 Then
                                    combinedCommander += "1 " & commanderParts(xy).ToString & vbCrLf
                                End If

                            Next xy

                            commanderText = combinedCommander

                            If InStr(combinedCommander, vbCrLf) > 0 Then
                                'commanderText = Split(combinedCommander, vbCrLf)(0).ToString

                            End If

                            commanderText = fn.RemoveWhitespace(commanderText)
                            commanderText = Trim(commanderText)
                            commanderText = Replace(commanderText, " Â", "")

                            Dim firstToken As String = commanderText
                            If commanderText <> "" Then

                                'firstToken = firstToken.Substring(firstToken.Length - 1, 1)
                                firstToken = Trim(Split(firstToken, " ")(0))

                                If firstToken = "1" Then
                                    'commanderText = commanderText.Substring(0, (commanderText.Length - 1))
                                    'commanderText = (Split(commanderText, "1 ")(1))

                                    commanderText = Replace(commanderText, " 1 ", vbCrLf & "1 ")
                                    commanderText = LTrim((RTrim(commanderText)))

                                    If commanderText.Contains("Thrasios, Triton Hero") Then
                                        Dim debugMarker = ""
                                    End If

                                    '****NEW TEST

                                    'Deck = Replace(Deck, "1 " & commanderLine & vbCrLf, "")

                                    '****NEW TEST

                                    'split it, find the commanders in the text and remove them
                                    Dim commanderLines = Split(commanderText, "1 ")
                                    Dim lines = ""
                                    For ab = 0 To commanderLines.Length - 1
                                        If commanderLines(ab) <> "" Then
                                            Dim commanderLine As String = Trim(fn.RemoveWhitespace(Trim(commanderLines(ab))))
                                            If InStr(Deck, commanderLine) > 0 Then
                                                lines = lines & commanderLines(ab)
                                                Deck = Replace(Deck, "1 " & commanderLine & vbCrLf, "")
                                                'Deck = Replace(Deck, "[sideboard]", "[commander]")
                                            End If
                                        End If
                                    Next ab
                                End If
                            End If
                        End If

                        If Deck <> "" And InStr(Deck, "fb-root") = 0 Then
                            TitDeck = "[" & metag & "] " & TitDeck
                            TitDeck = Replace(TitDeck, "'", "'")
                            If InStr(TitDeck, "</title>") > 0 Then
                                Try
                                    TitDeck = Split(TitDeck, "</title>")(0).ToString
                                Catch

                                End Try
                            End If

                            If Deck.Contains("Godzilla") Then
                                Dim debugMarker = ""
                            End If

                            TitDeck = fn.removeshit(TitDeck)
                            Deck = Replace(Deck, "King Caesar, Ancient Guardian", "Huntmaster Liger")
                            Deck = Replace(Deck, "Godzilla, Doom Inevitable", "Yidaro, Wandering Monster")
                            Deck = Replace(Deck, "Gigan, Cyberclaw Terror", "Gyruda, Doom of Depths")
                            Deck = Replace(Deck, "Godzilla, King of the Monsters", "Zilortha, Strength Incarnate")
                            Deck = Replace(Deck, "Ghidorah, King of the Cosmos", "Illuna, Apex of Wishes")
                            Deck = Replace(Deck, "Bio-Quartz Spacegozilla", "Brokkos, Apex of Forever")
                            Deck = Replace(Deck, "Biollante, Plant Beast Form", "Nethroi, Apex of Death")
                            Deck = Replace(Deck, "Mothra, Supersonic Queen", "Luminous Broodmoth")
                            Deck = Replace(Deck, "King Caesar, Awoken Titan", "Snapdax, Apex of the Hunt")
                            Deck = Replace(Deck, "Godzilla, Primeval Champion", "Titanoth Rex")
                            Deck = Replace(Deck, "Destoroyah, Perfect Lifeform", "Everquill Phoenix")
                            Deck = Replace(Deck, "Battra, the Destruction Beast", "Dirge Bat")
                            Deck = Replace(Deck, "Anguirus, Armored Killer", "Gemrazer")
                            Deck = Replace(Deck, "Rodan, Titan of Winged Fury", "Vadrok, Apex of Thunderimage")
                            Deck = Replace(Deck, "Mechagodzilla, Decisive Battle", "Crystalline Giant")
                            Deck = Replace(Deck, "Dorat, the Perfect Pet", "Sprite Dragon")
                            Deck = Replace(Deck, "Babygodzilla, Ruin Reborn", "Pollywog Symbiote")
                            Deck = Replace(Deck, "Mothra's Giant Cocoon", "Mysterious Egg")
                            Deck = Replace(Deck, "Spacegodzilla, Void Invader", "Void Beckoner")

                            If InStr(Deck, "1 Companion") > 0 Then
                                Dim debugMarker = ""
                            End If

                            fn.WriteUserLog(fn.StringToDeck(MyFolder, fn.FormatDeck(Deck, TitDeck, commanderText), TitDeck))
                            num = num + 1
                        End If

                    End If
                End If
            End If
        Next i

        ft.extract1.Enabled = True
        ft.txlog.Text += CInt(num - 1) & " Decks extracted." & vbCrLf
    End Sub

    Public Shared Function isdevmode()
        If File.Exists("iamthefuckingdev.txt") Then
            Return True
        Else
            Return False
        End If
    End Function

    'Shared Function GetAllCards()
    '    'this works but I'm going to remove it, 2021
    '    'Return Nothing
    '    'Exit Function
    '    If allCards = "" Or IsNothing(allCards) Then
    '        If isdevmode() Then
    '            Try
    '                allCards = My.Computer.FileSystem.ReadAllText("fldata/allcardsandsets.txt")
    '                'not sure this is broken - cards = Split(allCards, vbCrLf)
    '            Catch
    '            End Try
    '        End If

    '        Dim allCardsList As New List(Of String)
    '        Dim arr As Array = Split(allCards, vbCrLf)
    '        Dim x
    '        For x = 0 To arr.Length - 1
    '            allCardsList.Add(arr(x))
    '        Next x
    '        allCardsList.Reverse()

    '        x = 0
    '        allCards = String.Join(vbCrLf, allCardsList)
    '    End If

    '    Return allCards
    'End Function

    Public Shared Function RemoveDigits(S As String) As String
        Return Regex.Replace(S, "\d", "")
    End Function

    Public Shared Function searchforedition(card, allCardsParam, allEditionsParam)
        'Return ""

        If InStr(card, "tun Grunt") > 0 Then
            card = ""
        End If
        If card.contains("[sideboard]") Then Return ""

        If InStr(card, "|") = True Then
            card = ""
        End If
        If InStr(card, "[") = True Then
            card = ""
        End If

        If _
            card = "Forest" Or card = "Plains" Or card = "Swamp" Or card = "Mountain" Or
            card = "Island" Then
            Return "KHM"
        End If

        If card = "Wastes" Then
            Return "OGW"
        End If

        Dim myChars() As Char = card.ToCharArray()
        Dim quantity = ""
        For Each ch As Char In myChars
            If Char.IsDigit(ch) Then
                quantity = quantity & ch
            End If
        Next

        card = RemoveDigits(card)
        card = Replace(card, "&apos;", "'")
        card = Replace(card, "ä", "a")
        card = Replace(card, "ë", "e")
        card = Replace(card, "ï", "i")
        card = Replace(card, "ö", "o")
        card = Replace(card, "ü", "u")
        card = Trim(card)

        Dim a

        'Try
        '    Dim searchCard = vbCrLf & card & "|"
        '    a = Split(allCards, searchCard)
        '    a = a(1)
        'Catch e As Exception
        '    Return ""
        'End Try

        a = Split(a, vbCrLf)(0)
        If InStr(a, "|") > 0 Then
            a = Split(a, "|")(0)
        End If

        If InStr(a, "|") > 0 Then
            a = Split(a, "|")(0)
        End If

        a = a
        If IsNothing(a) Then a = ""
        Return a
        Exit Function
    End Function

    Public Shared Function extlinks(str As String, condition As String, Optional ByVal negate As String = "") _
        As String
        If str = Nothing Then
            str = ""
            Exit Function
        End If

        Dim RegexPattern = "href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>\S+))"

        ' Find matches.
        Dim matches As MatchCollection = Regex.Matches(str,
                                                       RegexPattern,
                                                       RegexOptions _
                                                          .
                                                          IgnoreCase)

        Dim MatchList(matches.Count - 1) As String

        ' Report on each match.
        Dim c = 0
        Dim r = ""
        For Each match As Match In matches

            MatchList(c) = match.Groups("url").Value

            'validamos
            Dim link As String = match.ToString
            If condition = "" Then condition = "?e="
            Dim anadir = True
            If InStr(link, condition, CompareMethod.Text) > 0 Then

                link = Replace(link, "href=", "")
                link = Split(link, ">")(0).ToString
                link = Replace(link, """", "")

                If InStr(r, link, CompareMethod.Text) = 0 Then

                    If negate <> "" Then
                        If InStr(link, negate, CompareMethod.Text) > 0 Then
                            anadir = False
                        End If
                    End If

                    If anadir Then
                        r = r + link & vbCrLf
                    End If
                    c += 1

                End If

            End If

        Next match
        extlinks = r
    End Function

    Public Shared Function commanderformat(t) As String
        Dim t2 As String = Split(t, "<h3>Similar Decks</h3>")(1).ToString

        Dim links = extlinks(t2, "/deck/")
        Dim pageUrl = ""
        'MsgBox(tx1)
        Dim urls() As String = Split(links, vbCrLf)
        For i = 0 To urls.Length - 1
            Dim web = ("https://www.mtggoldfish.com" & urls(0))
            t = fn.ReadWeb(web)
            If i = 0 Then Exit For
        Next i

        't = FindIt(t, "<td class='deck-header' colspan='4'>" & vbLf & "Commander", "<div class='deck-view-compact-purchase-buttons'>")
        t = fn.FindIt(t, "<td class='deck-header' colspan='4'>" & vbLf & "Commander", "100 Cards Total")

        'replace using regular expressions
        t = Regex.Replace(t, "<td class='deck-col-price'>.*?</td>", "" _
                          , RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        t = Replace(t, "<td class='deck-col-qty'>", "")
        t = Regex.Replace(t, "<td class='deck-col-qty'>.*?</td>", "" _
                          , RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        t = Regex.Replace(t, "<a data-full-image=.*?>", "" _
                          , RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        t = Regex.Replace(t, "<td class='deck-col-mana'.*?</td>", "" _
                          , RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        t = Regex.Replace(t, "<td class='deck-header'.*?</td>", "" _
                          , RegexOptions.IgnoreCase Or RegexOptions.Singleline)

        t = Replace(t, vbLf & "</td>" & vbLf & "<td class='deck-col-card'>" & vbLf, " ")
        t = fn.HTMLToText(t)
        t = Replace(t, vbLf & vbLf & vbLf & vbLf & vbLf & vbLf & vbLf, vbLf)
        t = Replace(t, vbLf & vbLf & vbLf & vbLf & vbLf & vbLf, vbLf)
        t = Replace(t, vbLf & vbLf & vbLf & vbLf & vbLf, vbLf)
        t = Replace(t, vbLf & vbLf & vbLf & vbLf, vbLf)
        t = Replace(t, vbLf & vbLf & vbLf, vbLf)
        t = Replace(t, vbLf & vbLf, vbLf)
        Return t
    End Function

    Public Shared Function mtggoldfishnewformat(tx)
        tx = fn.FindIt(tx, "container-fluid layout-container-fluid", "<div class='hidden")
        tx = Replace(tx, vbCrLf & vbCrLf, vbCrLf)
        tx = Replace(tx, vbLf & "<div id='error'>" & vbLf & vbLf & "</div>" & vbLf, "")
        tx = Replace(tx, ">", "")
        tx = fn.HTMLToText(tx)
        mtggoldfishnewformat = tx
    End Function

    Public Shared Function extmtggoldfish(str As String, condition As String, Optional condition2 As String = "",
                                          Optional excludelinks As String = "") As String
        'extract a list of links with the decks
        If str = Nothing Then
            str = ""
            Exit Function
        End If

        Dim RegexPattern = "href\s*=\s*(?:    [""'](?<1>[^""']*)[""']|(?<1>\S+))"

        ' Find matches.
        Dim matches As MatchCollection = Regex.Matches(str,
                                                       RegexPattern,
                                                       RegexOptions _
                                                          .
                                                          IgnoreCase)

        Dim MatchList(matches.Count - 1) As String

        ' Report on each match.
        Dim c = 0
        Dim r = ""
        For Each match As Match In matches
            MatchList(c) = match.Groups("url").Value
            'validamos
            Dim link As String = match.ToString
            If condition = "" Then condition = "/archetype/"
            Dim SkipThis = False
            If InStr(link, condition) = 0 Then SkipThis = True
            If condition2 <> "" Then
                If InStr(link, condition2) = 0 Then SkipThis = True
            End If

            If excludelinks <> "" Then
                If InStr(link, excludelinks) > 0 Then
                    SkipThis = True
                End If
            End If

            If SkipThis = False Then
                link = Replace(link, "href=", "")
                link = Split(link, ">")(0).ToString
                link = Replace(link, """", "")
                r = r + link & vbCrLf
            End If
            c += 1

        Next match
        extmtggoldfish = r
        'MsgBox(r)
    End Function

    Public Shared Sub ExtractTournamentMtgtop8(Optional ByVal tournament_url As String = "")

        ft.txlog.Clear()

        fn.WriteUserLog("Connecting..." & vbCrLf)

        'Dim baseDir As String = GetForgeDecksDir() & "\constructed\" & fn.ReadLogUser("downloadeddecks_dir", False) & "\" & fn.ReadLogUser("tournamentsdecks_dir", False) & "\"
        Dim baseDir As String = "netdecks\mtgtop8\" & fn.ReadLogUser("tournamentsdecks_dir", False) &
                              "\"

        ft.extract1.Enabled = False
        Dim tx1 As String
        'PUT THE TOURNAMENT'S TEXT IN A VARIABLE TO GET THE DECK URLS
        tx1 = fn.ReadWeb(tournament_url)

        Dim tournamentName = ""

        ''GET THE TOURNAMENT'S NAME

        ''Try
        'Dim request As WebRequest = WebRequest.Create(tournament_url)

        '' Get the response.
        'Dim response As WebResponse = request.GetResponse()

        '' Open the received response stream.
        'Dim reader As New StreamReader(response.GetResponseStream())

        ' Read the content.
        Dim res As String = tx1
        'FORMAT THE name
        tournamentName = fn.FindIt(res, "<title>", "</title>")
        tournamentName = Replace(tournamentName, " @ mtgtop8.com", "")
        ' players and the DATE
        Dim playerCount As String = fn.FindIt(res, "star.png></div>", "<div class=S10")
        If playerCount = "" Then
            playerCount = fn.FindIt(res, "bigstar.png height=16></div>", "<div class=S10")
        End If
        If playerCount <> "" Then
            tournamentName = tournamentName & " - " & playerCount
        End If
        If tournamentName Is Nothing Then tournamentName = ""

        tournamentName = tournamentName.Replace("/", "")
        tournamentName = Replace(tournamentName, vbCrLf, "")

        tournamentName = Replace(tournamentName, ":", "")
        If tournamentName.Contains("@") Then tournamentName = Split(tournamentName, "@")(0)
        tournamentName = Trim(tournamentName)
        'BUILD A MyFolder USING THE TOURNAMENT NAME
        Dim MyFolder As String = baseDir & tournamentName & "\"

        If Directory.Exists(MyFolder) Then
            If _
                MsgBox(
                    "Folder " & tournamentName & " exists, do you want to download decks again? " & vbCrLf & vbCrLf &
                    " (Decks inside the folder will be deleted)", MsgBoxStyle.YesNoCancel, "Warning!") = MsgBoxResult.No _
                Then
                fn.WriteUserLog(tournamentName & " folder exists. Operation cancelled." & vbCrLf)
                Exit Sub
            End If
        End If

        Try
            Directory.Delete(MyFolder, True)
        Catch

        End Try
        fn.CheckFolder(MyFolder)
        fn.WriteUserLog("Creating " & MyFolder & vbCrLf)
        '//////////////END OF THE TOURNAMENT name

        'GET THE DECK URLS

        If InStr(tournament_url, "mtggoldfish", CompareMethod.Text) = 0 Then
            tx1 = extlinks(tx1, "?e=")
        Else
            tx1 = extlinks(tx1, "/deck/")
        End If

        'MsgBox(tx1)

        'WE NOW HAVE THE URLS, TIME TO EXTRACT THEM ONE BY ONE
        Dim urls() As String = Split(tx1, vbCrLf)
        For i = 0 To urls.Length - 1

            If urls(i).ToString <> "" And urls(i).ToString <> "/deck/custom/standard" Then
                Dim DeckPage = ""
                Dim UrlDeck = ""
                'page for deck i
                DeckPage = fn.ReadWeb(vars.mtgtop8 & "/event" & urls(i))
                'url for deck i

                UrlDeck = extlinks(DeckPage, "mtgo?d=")
                Dim Deck = ""
                Dim TitDeck = ""
                'title for deck i

                'format the deck title

                'get the deck's text
                Deck = fn.ReadWeb(vars.mtgtop8 & "/" & UrlDeck)

                'format the deck
                Deck = Replace(Deck, "sideboard", "[sideboard]")
                Deck = Replace(Deck, "[[", "[")
                Deck = Replace(Deck, "]]", "]")
                TitDeck = fn.FindIt(DeckPage, "<title>", "@")
                TitDeck = Replace(TitDeck, "_", " ")
                TitDeck = Replace(TitDeck, """", "'")
                TitDeck = fn.Normalize(TitDeck)
                Dim num As String = (i + 1).ToString
                If Len(num) <= 1 Then num = "0" & num

                TitDeck = "#" & num & " - " & TitDeck

                Deck = fn.FormatDeck(Deck, TitDeck)
                fn.StringToDeck(MyFolder, Deck, TitDeck)
                fn.WriteUserLog("Saving " & TitDeck & vbCrLf)
            End If

        Next i
        ft.extract1.Enabled = True
        fn.WriteUserLog("Completed")
    End Sub

    Public Shared Sub ExtractFromMtgtop8(Optional ByVal maxdecks As Integer = 100)

        Dim tournamentFormat = ""
        Select Case ft.ComboBox2.SelectedItem.ToString
            Case "Vintage"
                tournamentFormat = "VI"
            Case "Legacy"
                tournamentFormat = "LE"
            Case "Modern"
                tournamentFormat = "MO"
            Case "Standard"
                tournamentFormat = "ST"
            Case "Pauper"
                tournamentFormat = "PAU"
            Case "Commander"
                tournamentFormat = "EDH"
        End Select

        Dim tx1 = fn.ReadWeb(vars.mtgtop8 & "/format?f=" & tournamentFormat)
        Dim tx2 = extlinks(tx1, "event?e=")

        Dim urls() As String = Split(tx2, vbCrLf)

        Dim max = 0
        Select Case ft.maxtournm.SelectedItem.ToString
            Case "Last One"
                max = 1
            Case Else
                max = Replace(ft.maxtournm.SelectedItem.ToString, "Last ", "")
        End Select
        For i = 0 To urls.Length - 1
            If i > (max - 1) Then Exit For
            Dim MyUrl As String = vars.mtgtop8 & "/" & urls(i)
            ExtractTournamentMtgtop8(MyUrl)
        Next
    End Sub

    Public Shared Function ExtractfromAetherhub(myUrl As String, puttop As Boolean, metag As String, hm As Object, fromuser As Boolean)
        'ExtractfromAetherhub(Trim(TextBox1.Text.ToString)
        '    Exit Sub
        'If myUrl = "" Then myUrl = "https://aetherhub.com/Metagame/Standard-BO1/"
        Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
        If String.IsNullOrWhiteSpace(myUrl) Then
            Throw New ArgumentException("URL cannot be null or empty.")
        End If

        Dim htmlContent = fn.ReadWeb(Trim(myUrl))
        If String.IsNullOrEmpty(htmlContent) Then
            Throw New InvalidOperationException("Failed to retrieve content from the URL.")
        End If

        doc.LoadHtml(htmlContent)
        'Dim MyFolderName = doc.DocumentNode.SelectSingleNode("//head/title").InnerText
        Dim MyDir = "netdecks\aetherhub\" & metag & "\"
        If fromuser = True Then
            MyDir = "netdecks\aetherhub\" & doc.DocumentNode.SelectSingleNode("//head/title").InnerText & "\"
        End If
        MyDir = Regex.Replace(MyDir, "[^\u0000-\u007F]", String.Empty)
        MyDir = Replace(MyDir, "&#x27;s", "'s")

        Dim div = doc.DocumentNode.SelectSingleNode("//div[@class='inner-content']")

        Dim links
        If div IsNot Nothing Then
            links = div.Descendants("a").[Select](Function(a) a.GetAttributeValue("href", "")).ToList()
        End If
        If ft.aetherhubfrom.Text = "1" Then
            Try
                fn.DeleteDecks(MyDir, "[*] *")
            Catch
            End Try
        End If

        Dim filteredLinks As New List(Of String)
        Dim counter As Integer = 0
        For Each li2 In links
            If li2.contains("/Deck/") And Not li2.contains("comment") Then
                If Not filteredLinks.Contains(li2) Then
                    filteredLinks.Add(li2)
                    counter = counter + 1
                End If
            End If
        Next li2

        Dim pagination = doc.DocumentNode.SelectSingleNode("//ul[@class='pagination']")
        If pagination IsNot Nothing Then
            links = pagination.Descendants("a").[Select](Function(a) a.GetAttributeValue("href", "")).ToList()
        End If

        Dim i = 0
        Dim resultCounter = 0
        Dim secondaryCounter = 0
        Dim startFrom As Integer

        If ft.aetherhubfrom.Text = "1" Then
            startFrom = 1
        Else
            startFrom = CInt(ft.aetherhubfrom.Text)
        End If

        For i = startFrom To filteredLinks.Count - 1

            resultCounter = resultCounter + 1
            If resultCounter > hm Then Exit Function

            If CInt(ft.aetherhubfrom.Text) <> 1 Then
                secondaryCounter = secondaryCounter + 1
            End If

            If CInt(ft.aetherhubfrom.Text) <> 1 Then
                Dim remaining = CInt(secondaryCounter + CInt(ft.aetherhubfrom.Text)) - 1
                If remaining > hm Then Exit Function
            End If

            'read the page
            Dim doc2 As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
            Dim mypagetxt = fn.ReadWeb("https://aetherhub.com" & filteredLinks(i).ToString)
            doc2.LoadHtml(mypagetxt)
            Dim TitDeck = GetTitDeck(mypagetxt)
            If System.Text.RegularExpressions.Regex.IsMatch(TitDeck, "\d") Then
                ' Find the position of the first digit in the TitDeck string
                Dim firstDigitIndex As Integer = System.Text.RegularExpressions.Regex.Match(TitDeck, "\d").Index
                ' Get the part of the string before the number
                TitDeck = TitDeck.Substring(0, firstDigitIndex)
                ' Use the part of the string before the number as needed
            End If
            Dim div2 = doc2.DocumentNode.SelectSingleNode("//div[@class='row pt-2']")
            Dim links2
            If div2 IsNot Nothing Then
                links2 = div2.Descendants("a").[Select](Function(b) b.GetAttributeValue("href", "")).ToList()
            End If
            links2 = links2
            Dim mylink
            For Each li2 In links2
                If li2.Contains("/Deck/MtgoDeckExport/") Then
                    mylink = li2
                    Exit For
                End If
            Next li2

            If puttop Then
                Dim num As String = i
                If Len(num) <= 1 Then
                    num = "0" & num
                End If
                TitDeck = "#" & num & " - " & TitDeck
            End If
            Dim metag2 = Replace(metag, "-", " ")
            If TitDeck.Contains("MTG " & metag2 & " Metagame") Then TitDeck = Replace(TitDeck, "MTG " & metag2 & " Metagame", "")
            If TitDeck.Contains(metag2 & " Metagame") Then TitDeck = Replace(TitDeck, metag2 & " Metagame", "")
            If TitDeck.Contains("Arena Standard Metagame") Then TitDeck = Replace(TitDeck, "Arena Standard Metagame", "")
            If TitDeck.Contains("Arena Standard") Then TitDeck = Replace(TitDeck, "Arena Standard", "")
            If TitDeck.Contains("Standard Metagame") Then TitDeck = Replace(TitDeck, "Standard Metagame", "")
            If TitDeck.Contains(metag) = True Then TitDeck = Replace(TitDeck, metag, "")

            TitDeck = Replace(TitDeck, "  ", " ")
            TitDeck = Replace(TitDeck, " -  - ", " - ")
            If TitDeck.Contains(metag) = True Then
                TitDeck = Replace(TitDeck, metag, "")
            End If
            TitDeck = Replace(TitDeck, Replace(metag, " ", "-"), "")
            Dim metag3 = Replace(metag, " ", "-")
            TitDeck = Replace(TitDeck, metag3, "")
            Dim metag4 = Replace(metag, "-", " ")
            TitDeck = Replace(TitDeck, metag4, "")

            TitDeck = fn.RemoveWhitespace(TitDeck)
            TitDeck = Trim(TitDeck)
            TitDeck = fn.removeshit(TitDeck)
            TitDeck = Replace(TitDeck, "   ", " ")
            TitDeck = Replace(TitDeck, "  ", " ")
            TitDeck = Replace(TitDeck, " - - ", " - ")
            TitDeck = Trim(TitDeck)
            If TitDeck.StartsWith("-") Then
                TitDeck = TitDeck.Substring(1)
            End If
            If TitDeck.EndsWith("-") Then
                TitDeck = TitDeck.Substring(0, TitDeck.Length - 1)
            End If
            If TitDeck.EndsWith("|") Then
                TitDeck = TitDeck.Substring(0, TitDeck.Length - 1)
            End If
            TitDeck = Regex.Replace(TitDeck, "[^\u0000-\u007F]", String.Empty)
            TitDeck = Replace(TitDeck, "Historic Metagame", "")
            TitDeck = Replace(TitDeck, "Alchemy Metagame", "")
            TitDeck = Replace(TitDeck, " - Traditional", "")
            TitDeck = Replace(TitDeck, " - Standard", "")
            TitDeck = Replace(TitDeck, " - Historic", "")
            TitDeck = Replace(TitDeck, " - Alchemy ", "")
            TitDeck = Replace(TitDeck, " - Explorer ", "")

            TitDeck = Trim(TitDeck)
            TitDeck = fn.RemoveWhitespace(TitDeck)

            metag = Replace(metag, "Traditional-", "")

            If puttop Then
                TitDeck = "[" & metag & "] " & TitDeck
            End If

            Dim Deck As String = "[metadata]" & vbCrLf & "Name=" & TitDeck & vbCrLf & "[Main]" & vbCrLf & fn.ReadWeb("https://aetherhub.com" & mylink)
            Deck = Replace(Deck, vbCrLf & vbCrLf, vbCrLf & "[sideboard]" & vbCrLf)
            Deck = Replace(Deck, vbLf & vbLf, vbLf & "[sideboard]" & vbCrLf)
            Deck = Replace(Deck, vbCrLf & "Commander" & vbCrLf, vbCrLf & "[Commander]" & vbCrLf)
            If metag.Contains("Brawl") = True Then
                Deck = Replace(Deck, "[sideboard]", "[Commander]")
            End If

            fn.WriteUserLog(fn.StringToDeck(MyDir & "/", Deck, TitDeck))
        Next
    End Function

End Class