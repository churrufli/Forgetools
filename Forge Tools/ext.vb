Imports System.Diagnostics.Contracts
Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Ext

    Public Shared Sub Cardsdata()
        Dim todaslascartas As String = IO.File.ReadAllText(Directory.GetCurrentDirectory() & "/fldata/allcardsandsets.txt")
        Dim todoslossets As String = IO.File.ReadAllText(Directory.GetCurrentDirectory() & "/fldata/allsets.txt")
    End Sub
    Public Shared Function GetTitDeck(tx) As String
        Dim TitDeck = ""
        TitDeck = fn.FindIt(tx, "<title>", "Deck for Magic: the Gathering")
        If TitDeck = Nothing Then
            TitDeck = fn.FindIt(tx, "<title>", "</title>")
        End If
        TitDeck = Replace(TitDeck, " &#39;", "'")
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
            TitDeck = TitDeck
        End If


        tempParts = startString.Split(" ")

        For Each testValue In tempParts
            Try
                testValue = Replace(testValue, "-", "/")
                testValue = Replace(testValue, """", "")
                'DateTime.Parse(testValue)
                Dim resultado = DateTime.ParseExact(Convert.ToString(testValue), "d/MMM/yyyy", CultureInfo.CreateSpecificCulture("es-US"))
                TitDeck.Replace(testValue, Nothing)
            Catch ex As Exception
            End Try
            testValue = Replace(testValue, "/", "-")


            'If DateTime.TryParse(testValue, tempDate) = True Then
            '    MessageBox.Show(String.Format("Date in string: {0}", tempDate))

            'End If
            'If DateTime.TryParse(testValue, tempDate) = True Then
            '    MessageBox.Show(String.Format("Date in string: {0}", tempDate))
            'End If
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

    Public Shared Sub ExtractTopMtggoldfish(metag As String, hm As Object, puttop As Object, customurl As String, Optional customfolder As String = "")
        'se usa para el top de los decks y para los custom decks 
        ft.txlog.Text = ""

        'establezco la URL
        Dim url = ""
        If Not IsNothing(customurl) Then url = customurl
        If url = "" Then
            Select Case (metag)
                ', "Pioneer"
                Case "Duel Commander", "Arena Singleton", "Historic Brawl", "Artisan Historic", "Cascade", "Oathbreaker",
                    "Canadian Highlander", "Old School", "No Banned List Modern", "Frontier", "Tiny Leaders", "Limited",
                    "Block", "Free Form"
                    url = vars.mtggf & "/deck/custom/" & LCase(Replace(metag, " ", "_")) & "#paper"
                Case "Budget Modern", "Budget Standard"
                    url = vars.mtggf & "/decks/budget/" & LCase(Replace(Replace(metag, "Budget ", ""), " ", "/")) &
                          "#paper"
                Case "Budget Commander"
                    url = vars.mtggf & "/decks/budget/commander/" & "#paper"
                Case "Standard", "Modern", "Pioneer", "Pauper", "Legacy", "Vintage", "Historic", "Penny Dreadful"
                    url = vars.mtggf & "/metagame/" & LCase(fn.Normalize(metag)) & "/full#paper"
                Case Else
                    url = vars.mtggf & "/metagame/" & LCase(fn.Normalize(metag)) & "/full#paper"
            End Select
        End If

        ft.extract1.Enabled = False
        Dim tx1 As String

        'meto el contenido de esa url en una variable
        tx1 = fn.ReadWeb(url)
        Dim MyDir = ""
        Dim MyFolder = ""

        'creo la carpeta 
        Select Case metag
            Case "Standard", "Modern", "Pioneer", "Pauper", "Legacy", "Vintage", "Historic", "Penny Dreadful",
                "Budget Modern", "Budget Standard"
                MyDir = fn.GetForgeDecksDir() & "\constructed\mtggoldfish\"
                If fn.ReadLogUser("preserve_decks", False) = "yes" Then
                    MyFolder = MyDir & "\" & metag & "\" & (Replace(DateTime.Today.ToShortDateString, "/", "-")) &
                               "\"
                    Dim ruta As String = MyDir & "\" & metag & "\"
                    Try

                        Dim counter =
                                New DirectoryInfo(ruta).GetDirectories().OrderBy(Function(x) x.CreationTime)

                        Dim s = ""
                        For Each f As DirectoryInfo In counter
                            s = s & f.Name & ","
                        Next

                        Dim s1() As String = Split(s, ",")

                        Dim mycount As Integer = CStr(counter.Count)
                        Dim x1 = 0
                        Dim total As Integer = fn.ReadLogUser("preserve_decks_number")
                        While mycount > CStr(total)
                            Try
                                Directory.Delete(ruta & s1(x1), True)
                            Catch
                            End Try
                            x1 = x1 + 1
                            counter =
                                New DirectoryInfo(ruta).GetDirectories().OrderBy(Function(x) x.CreationTime)
                            mycount = CStr(counter.Count)
                        End While
                    Catch
                    End Try
                Else
                    MyFolder = MyDir & "\" & metag & "\"
                End If
                MyFolder = Replace(MyFolder, "//", "/")
            Case "Commander", "Commander 1v1", "Budget Commander"
                MyDir = fn.GetForgeDecksDir() & "\commander\"
                MyFolder = MyDir
            Case "Tiny Leaders"
                MyDir = fn.GetForgeDecksDir() & "\tiny_leaders\"
                MyFolder = MyDir
            Case "Brawl", "Historic Brawl"
                MyDir = fn.GetForgeDecksDir() & "\brawl\"
                MyFolder = MyDir
            Case Else
                MyDir = fn.GetForgeDecksDir() & "\constructed\mtggoldfish\"
                MyFolder = MyDir
        End Select
        MyFolder = Replace(MyFolder, "\\", "\")


        If ft.mtggoldfishfrom.Text = "1" Then
            'BORRO MAZOS ANTERIORES
            fn.DeleteDecks(MyFolder, "[" & metag & "] *")
        End If

        fn.CheckFolder(MyFolder)

        fn.WriteUserLog("Extracting " & metag & " Decks in " & MyFolder & vbCrLf)

        Select Case metag
            'oficiales
            Case "Standard", "Modern", "Pioneer", "Pauper", "Legacy", "Vintage", "Historic", "Penny Dreadful"
                tx1 = extmtggoldfish(tx1, "/archetype/", "#paper")
            Case "Budget Modern", "Budget Standard"
                tx1 = extmtggoldfish(tx1, "/deck/", "#paper", "/deck/custom")
            Case "Duel Commander", "Arena Singleton", "Historic Brawl", "Artisan Historic", "Cascade", "Oathbreaker",
                "Canadian Highlander", "Old School", "No Banned List Modern", "Frontier", "Tiny Leaders", "Limited",
                "Block", "Free Form"
                ', "-->lo quito de aquí
                tx1 = extmtggoldfish(tx1, "/deck/", "#paper", "/deck/custom")
            Case "Arena Standard"
                tx1 = extmtggoldfish(tx1, "/archetype/", "#paper")
            Case "Commander 1v1", "Commander", "Brawl"
                tx1 = extmtggoldfish(tx1, "/archetype/", "#paper")
            Case Else
                tx1 = extmtggoldfish(tx1, "/deck/", "#paper")
        End Select

        Dim num As String
        Dim checkurls() As String
        checkurls = Split(tx1, vbCrLf)
        Dim lasurls As String = tx1

        Try

            Dim cuentaveces As Long = 2
            If checkurls.Length < hm Then
                'si es menor que el total de la pagina voy a la otra y añado links
                ' While hm > checkurls.Length
                Dim tx2
                While checkurls.Length < hm

                    If _
                        LCase(metag) = "standard" Or LCase(metag) = "legacy" Or LCase(metag) = "vintage" Or
                        LCase(metag) = "pauper" Or LCase(metag) = "pioneer" Or LCase(metag) = "historic" Or LCase(metag) = "penny dreadful" Or LCase(metag) = "brawl" Then
                        If cuentaveces = 2 Then
                            tx2 = ""
                            'entra por primera vez
                            'entro a esta url y saco resultados
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
                                            cuentaveces)
                                Case "vintage"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/other-4b59bfe3-e589-45f1-bf1b-5312d945f2d3/decks?page=" &
                                            cuentaveces)
                                Case "pauper"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/other-e2f79915-5636-44cc-9c6f-7a74834fd316/decks?page=" &
                                            cuentaveces)
                                Case "pioneer"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/other-2309ea0a-91b7-44c4-b0cd-945fdc82dd90/decks?page=" &
                                            cuentaveces)
                                Case "historic"
                                    tx2 =
                                        fn.ReadWeb(
                                            "https://www.mtggoldfish.com/archetype/other-061deb94-cf17-4926-a252-571799137b88/decks?page=" &
                                            cuentaveces)

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
                        url = vars.mtggf & "/metagame/" & Replace(LCase(metag), " ", "_") & "/full?page=" & cuentaveces &
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

                    lasurls = lasurls & tx2
                    checkurls = Split(lasurls, vbCrLf)
                    cuentaveces = cuentaveces + 1
                    If tx2 = "" Then Exit While
                End While
            End If
        Catch
        End Try
        Dim urls()
        urls = Split(lasurls, vbCrLf)
        Dim desdecual As Integer
        If ft.mtggoldfishfrom.Text = "1" Then
            desdecual = 0
        Else
            desdecual = CInt(ft.mtggoldfishfrom.Text) - 1
        End If


        Dim my2counter = 0

        For i = desdecual To urls.Length - 1

            If urls(i).ToString <> "" Then

                If i >= CInt(hm) Then Exit For
                If CInt(ft.mtggoldfishfrom.Text) <> 1 Then
                    my2counter = my2counter + 1
                End If
                If CInt(ft.mtggoldfishfrom.Text) <> 1 Then
                    Dim quedan = CInt(my2counter + CInt(ft.mtggoldfishfrom.Text)) - 1
                    If quedan > hm Then Exit Sub
                End If

                Dim DeckPage = ""
                Dim UrlDeck = ""
                Dim Deck = ""
                Dim mycmnd = ""
                Dim TitDeck = ""

                Dim laweb As String = vars.mtggf & urls(i)
                DeckPage = fn.ReadWeb(laweb)

                If _
                    (InStr(metag, "Commander") > 0 Or InStr(metag, "Tiny") > 0) And
                    InStr(DeckPage, "<h3>Similar Decks</h3>", CompareMethod.Text) > 0 Then
                    'puede que no tenga similar decks 
                    Dim t2 As String = Split(DeckPage, "<h3>Similar Decks</h3>")(1).ToString
                    TitDeck = GetTitDeck(DeckPage)
                    Dim links = extlinks(t2, "/deck/")
                    Dim aurls() As String = Split(links, vbCrLf)
                    For a = 0 To urls.Length - 1
                        Dim web = ("https//www.mtggoldfish.com" & aurls(0))
                        DeckPage = fn.ReadWeb(web)
                        If a = 0 Then Exit For
                    Next a
                End If

                UrlDeck = extmtggoldfish(DeckPage, "/deck/download/")

                'ESTABLEZCO EL TÍTULO DEL MAZO
                If TitDeck = "" Then
                    TitDeck = GetTitDeck(DeckPage)
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

                Dim pasar = False
                If InStr(metag, "Commander") > 0 Or InStr(metag, "Tiny") > 0 Or InStr(metag, "Brawl") > 0 Then
                    pasar = True
                End If

                If UrlDeck <> "" Then
                    pasar = True
                End If

                If pasar Then
                    If InStr(UrlDeck, vbCrLf) > 0 Then
                        UrlDeck = Split(UrlDeck, vbCrLf)(0)
                    End If

                    If Deck = "" Then Deck = fn.ReadWeb(vars.mtggf & "" & UrlDeck)
                    If Deck <> "" And Deck <> "Throttled" Then
                        Deck = Replace(Deck, vbLf, vbCrLf)
                        'formato del mazo
                        If InStr(Deck, "container-fluid layout-container-fluid", CompareMethod.Text) > 0 Then
                            Deck = mtggoldfishnewformat(Deck)
                            Deck = extmtggoldfish(Deck, "/deck/download/")
                            Deck = fn.ReadWeb(Deck)
                        End If

                        'EL TEMA DE LOS CEROS EN LOS MAZOS
                        num = (i + 1)
                        Select Case Len(hm)
                            Case 3 '100 o mas
                                'cuanto mide el numero?
                                Select Case Len(num)
                                    Case 1 ' hasta el 9
                                        num = "00" & num
                                    Case 2 'desde el 10 al 99
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
                        'DANDO FORMATO
                        Deck = Replace(Deck, vbCr, "")
                        Deck = Replace(Deck, vbLf, vbCrLf)
                        Deck = Replace(Deck, "'" & vbCrLf & "<div id='error'" & vbCrLf & "</div" & vbCrLf, "")
                        Deck = Replace(Deck, "sideboard", "sideboard")
                        Deck = Replace(Deck, vbCrLf & vbCrLf, vbCrLf & "[sideboard]" & vbCrLf)

                        Dim isacommander = False

                        If InStr(metag, "Commander") > 0 Or InStr(metag, "Tiny") > 0 Or InStr(metag, "Brawl") > 0 Then

                            isacommander = True

                            Dim searchfor As String
                            searchfor = fn.HTMLToText(DeckPage)
                            searchfor = fn.RemoveWhitespace(searchfor)
                            mycmnd = fn.FindIt(searchfor, "Tabletop Arena MTGO Commander", "Creatures")
                            If mycmnd = "" Then _
                                mycmnd = fn.FindIt(searchfor, "Tabletop Arena MTGO Commander", "Planeswalkers")
                            If mycmnd = "" Then mycmnd = fn.FindIt(searchfor, "Tabletop Arena MTGO Commander", "Spells")

                            If Len(mycmnd) > 100 Then
                                mycmnd = fn.FindIt(searchfor, "Tabletop Arena MTGO Commander", "Spells")
                            End If

                            If Len(mycmnd) > 100 Then
                                mycmnd = fn.FindIt(searchfor, "Tabletop Arena MTGO Commander", "Planeswalkerss")
                            End If


                            If InStr(mycmnd, " Companion ") > 0 Then
                                mycmnd = Split(mycmnd, " Companion ")(0).ToString
                            End If
                            mycmnd = Replace(mycmnd, "$", "")
                            mycmnd = Replace(mycmnd, " Â", "")


                            'voy a ver si tiene varios comandantes
                            Dim cuentacomandantes As Long = 1
                            Try
                                Dim partirlinea() = Split(mycmnd, " 1 ")
                                If partirlinea(2) <> "" Then
                                    cuentacomandantes = 2
                                End If
                                If partirlinea(4) <> "" Then
                                    cuentacomandantes = 3
                                End If
                                If partirlinea(6) <> "" Then
                                    cuentacomandantes = 4
                                End If
                                If partirlinea(8) <> "" Then
                                    cuentacomandantes = 5
                                End If
                            Catch

                            End Try

                            Dim sb As New StringBuilder
                            If Not IsNothing(mycmnd) Then
                                For Each c As Char In mycmnd
                                    If Not Char.IsNumber(c) Then
                                        sb.Append(c)
                                    End If
                                Next
                            End If

                            mycmnd = sb.ToString
                            mycmnd = Replace(mycmnd, "&#;", "'")
                            mycmnd = Replace(mycmnd, "$", "")
                            If InStr(mycmnd, "<title>") > 0 Then
                                mycmnd = Split(mycmnd, "<title>")(0).ToString
                            End If
                            mycmnd = Trim(mycmnd)
                            Dim spcomm = Split(mycmnd, ".")
                            Dim concatcomm = ""

                            For xy = 0 To spcomm.Length - 1
                                If Len(spcomm(xy).ToString) > 3 Then
                                    concatcomm += "1 " & spcomm(xy).ToString & vbCrLf
                                End If

                            Next xy

                            mycmnd = concatcomm

                            If InStr(concatcomm, vbCrLf) > 0 Then
                                'mycmnd = Split(concatcomm, vbCrLf)(0).ToString

                            End If

                            mycmnd = fn.RemoveWhitespace(mycmnd)
                            mycmnd = Trim(mycmnd)
                            mycmnd = Replace(mycmnd, " Â", "")

                            Dim substr As String = mycmnd
                            If mycmnd <> "" Then

                                'substr = substr.Substring(substr.Length - 1, 1)
                                substr = Trim(Split(substr, " ")(0))

                                If substr = "1" Then
                                    'mycmnd = mycmnd.Substring(0, (mycmnd.Length - 1))
                                    'mycmnd = (Split(mycmnd, "1 ")(1))

                                    mycmnd = Replace(mycmnd, " 1 ", vbCrLf & "1 ")
                                    mycmnd = LTrim((RTrim(mycmnd)))

                                    If mycmnd.Contains("Thrasios, Triton Hero") Then
                                        Dim hola = ""
                                    End If

                                    '****NUEVA PRUEBA

                                    'Deck = Replace(Deck, "1 " & uno & vbCrLf, "")

                                    '****NUEVA PRUEBA

                                    'parto, busco en el texto los comandantes y los elimino
                                    Dim spcmndlines = Split(mycmnd, "1 ")
                                    Dim lines = ""
                                    For ab = 0 To spcmndlines.Length - 1
                                        If spcmndlines(ab) <> "" Then
                                            Dim uno As String = Trim(fn.RemoveWhitespace(Trim(spcmndlines(ab))))
                                            If InStr(Deck, uno) > 0 Then
                                                lines = lines & spcmndlines(ab)
                                                Deck = Replace(Deck, "1 " & uno & vbCrLf, "")
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
                                Dim hola = ""
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
                                Dim hola = ""
                            End If

                            fn.WriteUserLog(fn.StringToDeck(MyFolder, fn.FormatDeck(Deck, TitDeck, mycmnd), TitDeck))
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

    'Shared Function tenertodas()
    '    'esto funciona pero lo voy a quitar, 2021
    '    'Return Nothing
    '    'Exit Function
    '    If todaslascartas = "" Or IsNothing(todaslascartas) Then
    '        If isdevmode() Then
    '            Try
    '                todaslascartas = My.Computer.FileSystem.ReadAllText("fldata/allcardsandsets.txt")
    '                'no se si está chungo cards = Split(todas, vbCrLf)
    '            Catch
    '            End Try
    '        End If


    '        Dim todicas As New List(Of String)
    '        Dim arr As Array = Split(todaslascartas, vbCrLf)
    '        Dim x
    '        For x = 0 To arr.Length - 1
    '            todicas.Add(arr(x))
    '        Next x
    '        todicas.Reverse()

    '        x = 0
    '        todaslascartas = String.Join(vbCrLf, todicas)
    '    End If

    '    Return todaslascartas
    'End Function

    Public Shared Function RemoveDigits(S As String) As String
        Return Regex.Replace(S, "\d", "")
    End Function

    Public Shared Function searchforedition(carta, tcartas, tediciones)
        'Return ""


        If InStr(carta, "tun Grunt") > 0 Then
            carta = ""
        End If
        If carta.contains("[sideboard]") Then Return ""

        If InStr(carta, "|") = True Then
            carta = ""
        End If
        If InStr(carta, "[") = True Then
            carta = ""
        End If

        If _
            carta = "Forest" Or carta = "Plains" Or carta = "Swamp" Or carta = "Mountain" Or
            carta = "Island" Then
            Return "KHM"
        End If

        If carta = "Wastes" Then
            Return "OGW"
        End If



        Dim myChars() As Char = carta.ToCharArray()
        Dim cantidad = ""
        For Each ch As Char In myChars
            If Char.IsDigit(ch) Then
                cantidad = cantidad & ch
            End If
        Next

        carta = RemoveDigits(carta)
        carta = Replace(carta, "&apos;", "'")
        carta = Replace(carta, "ä", "a")
        carta = Replace(carta, "ë", "e")
        carta = Replace(carta, "ï", "i")
        carta = Replace(carta, "ö", "o")
        carta = Replace(carta, "ü", "u")
        carta = Trim(carta)

        Dim a

        'Try
        '    Dim buscacaarta = vbCrLf & carta & "|"
        '    a = Split(todaslascartas, buscacaarta)
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
        Dim laweb = ""
        'MsgBox(tx1)
        Dim urls() As String = Split(links, vbCrLf)
        For i = 0 To urls.Length - 1
            Dim web = ("https://www.mtggoldfish.com" & urls(0))
            t = fn.ReadWeb(web)
            If i = 0 Then Exit For
        Next i

        't = FindIt(t, "<td class='deck-header' colspan='4'>" & vbLf & "Commander", "<div class='deck-view-compact-purchase-buttons'>")
        t = fn.FindIt(t, "<td class='deck-header' colspan='4'>" & vbLf & "Commander", "100 Cards Total")

        'reemplazamos con expresión regular
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
        'extrae un listado de links con los mazos
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


        'Dim eldir As String = GetForgeDecksDir() & "\constructed\" & fn.ReadLogUser("downloadeddecks_dir", False) & "\" & fn.ReadLogUser("tournamentsdecks_dir", False) & "\"
        Dim eldir As String = fn.GetForgeDecksDir() & "\constructed\" & fn.ReadLogUser("tournamentsdecks_dir", False) &
                              "\"

        ft.extract1.Enabled = False
        Dim tx1 As String
        'METEMOS EN UNA VARIABLE EL tx DEL TORNEO PARA SACAR LAS URLS DE LOS MAZOS
        tx1 = fn.ReadWeb(tournament_url)

        Dim tourname = ""

        ''SACAMOS EL name DEL TORNEO

        ''Try
        'Dim request As WebRequest = WebRequest.Create(tournament_url)

        '' Obtener la respuesta.
        'Dim response As WebResponse = request.GetResponse()

        '' Abrir el stream de la respuesta recibida.
        'Dim reader As New StreamReader(response.GetResponseStream())

        ' Leer el contenido.
        Dim res As String = tx1
        'FORMATO DEL name
        tourname = fn.FindIt(res, "<title>", "</title>")
        tourname = Replace(tourname, " @ mtgtop8.com", "")
        ' jugadores y LA FECHA
        Dim numju As String = fn.FindIt(res, "star.png></div>", "<div class=S10")
        If numju = "" Then
            numju = fn.FindIt(res, "bigstar.png height=16></div>", "<div class=S10")
        End If
        If numju <> "" Then
            tourname = tourname & " - " & numju
        End If
        If tourname Is Nothing Then tourname = ""

        tourname = tourname.Replace("/", "")
        tourname = Replace(tourname, vbCrLf, "")

        tourname = Replace(tourname, ":", "")
        If tourname.Contains("@") Then tourname = Split(tourname, "@")(0)
        tourname = Trim(tourname)
        'CREAMOS UNA MyFolder CON EL name DEL TORNEO
        Dim MyFolder As String = eldir & tourname & "\"

        If Directory.Exists(MyFolder) Then
            If _
                MsgBox(
                    "Folder " & tourname & " exists, do you want to download decks again? " & vbCrLf & vbCrLf &
                    " (Decks inside the folder will be deleted)", MsgBoxStyle.YesNoCancel, "Warning!") = MsgBoxResult.No _
                Then
                fn.WriteUserLog(tourname & " folder exists. Operation cancelled." & vbCrLf)
                Exit Sub
            End If
        End If

        Try
            Directory.Delete(MyFolder, True)
        Catch

        End Try
        fn.CheckFolder(MyFolder)
        fn.WriteUserLog("Creating " & MyFolder & vbCrLf)
        '//////////////FIN DEL name DEL TORNEO

        'SACAMOS LAS URLS DE LOS MAZOS

        If InStr(tournament_url, "mtggoldfish", CompareMethod.Text) = 0 Then
            tx1 = extlinks(tx1, "?e=")
        Else
            tx1 = extlinks(tx1, "/deck/")
        End If

        'MsgBox(tx1)

        'YA TENGO LAS URL, AHORA A EXTRAER UNA POR UNA
        Dim urls() As String = Split(tx1, vbCrLf)
        For i = 0 To urls.Length - 1

            If urls(i).ToString <> "" And urls(i).ToString <> "/deck/custom/standard" Then
                Dim DeckPage = ""
                Dim UrlDeck = ""
                'pagina del mazo i
                DeckPage = fn.ReadWeb(vars.mtgtop8 & "/event" & urls(i))
                'url del mazo i


                UrlDeck = extlinks(DeckPage, "mtgo?d=")
                Dim Deck = ""
                Dim TitDeck = ""
                'titulo del mazo i

                'formato del titulo del mazo

                'sacamos el tx del 
                Deck = fn.ReadWeb(vars.mtgtop8 & "/" & UrlDeck)

                'formato del mazo
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

        Dim formato = ""
        Select Case ft.ComboBox2.SelectedItem.ToString
            Case "Vintage"
                formato = "VI"
            Case "Legacy"
                formato = "LE"
            Case "Modern"
                formato = "MO"
            Case "Standard"
                formato = "ST"
            Case "Pauper"
                formato = "PAU"
            Case "Commander"
                formato = "EDH"
        End Select

        Dim tx1 = fn.ReadWeb(vars.mtgtop8 & "/format?f=" & formato)
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
    Public Shared Function ExtractfromAetherhub(myUrl As String, puttop As Boolean, metag As String, hm As Object)
        'ExtractfromAetherhub(Trim(TextBox1.Text.ToString)
        '    Exit Sub
        'If myUrl = "" Then myUrl = "https://aetherhub.com/Metagame/Standard-BO1/"
        Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
        doc.LoadHtml(fn.ReadWeb(Trim(myUrl)))
        'Dim MyFolderName = doc.DocumentNode.SelectSingleNode("//head/title").InnerText
        Dim MyDir = fn.GetForgeDecksDir() & "\constructed\aetherhub\" & metag & "\"

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

        Dim i = 0
        Dim mycounter = 0
        Dim my2counter = 0
        Dim desdecual As Integer

        If ft.aetherhubfrom.Text = "1" Then
            desdecual = 1
        Else
            desdecual = CInt(ft.aetherhubfrom.Text)
        End If

        For i = desdecual To filteredLinks.Count - 1

            mycounter = mycounter + 1
            If mycounter > hm Then Exit Function

            If CInt(ft.aetherhubfrom.Text) <> 1 Then
                my2counter = my2counter + 1
            End If

            If CInt(ft.aetherhubfrom.Text) <> 1 Then
                Dim quedan = CInt(my2counter + CInt(ft.aetherhubfrom.Text)) - 1
                If quedan > hm Then Exit Function
            End If

            'leo la web
            Dim doc2 As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
            Dim mypagetxt = fn.ReadWeb("https://aetherhub.com" & filteredLinks(i).ToString)
            doc2.LoadHtml(mypagetxt)
            Dim TitDeck = GetTitDeck(mypagetxt)
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
            If TitDeck.Contains(metag) = True Then
                TitDeck = Replace(TitDeck, metag, "")
            End If
            TitDeck = Replace(TitDeck, "   ", " ")
            TitDeck = Replace(TitDeck, "  ", " ")
            TitDeck = Trim(TitDeck)
            TitDeck = Replace(TitDeck, "  ", " ")
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
            TitDeck = Regex.Replace(TitDeck, "[^\u0000-\u007F]", String.Empty)
            TitDeck = "[" & metag & "] " & TitDeck

            Dim Deck As String = "[metadata]" & vbCrLf & "Name=" & TitDeck & vbCrLf & "[Main]" & vbCrLf & fn.ReadWeb("https://aetherhub.com" & mylink)
            Deck = Replace(Deck, vbCrLf & vbCrLf, vbCrLf & "[sideboard]" & vbCrLf)
            Deck = Replace(Deck, vbLf & vbLf, vbLf & "[sideboard]" & vbCrLf)
            Deck = Replace(Deck, "Commander" & vbCrLf, "[Commander]" & vbCrLf)
            fn.WriteUserLog(fn.StringToDeck(MyDir & "/", Deck, TitDeck))
        Next
    End Function
End Class
