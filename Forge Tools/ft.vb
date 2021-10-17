
Imports System.ComponentModel
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Timers
Imports ICSharpCode.SharpZipLib.Zip

Public Class ft
    Shared todas

    Public WithEvents downloader As WebClient
    Dim second As Integer

    Sub TimerElapsed(sender As Object, e As ElapsedEventArgs)
        ' Write the SignalTime.
        Dim time As DateTime = e.SignalTime
        Console.WriteLine("TIME: " + time)
    End Sub

    Private Sub Fl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' tal()
        TabControl1.TabPages.Remove(TabControl1.TabPages(1))
    End Sub

    Private Sub Fl_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fn.WriteUserLog("Loading data..." & vbCrLf)
        Timer1.Interval = 10
        Timer1.Start() 'Timer starts functioning
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

        Dim basico As Boolean = False

        'basico = True
        If basico = True Then
            SetComboboxes()
            Exit Sub

        End If

        fn.movefilestofldata()
        fn.CheckIfICSharpCodeExist()
        'fn.WriteUserLog("Checking Forge Version..." & vbCrLf)
        fn.RewriteLog()
        fn.CheckLog()



        fn.MaintainVersionInAdvancedLaunchMode()
        SetComboboxes()
        fn.CheckIfPreviousProfileProperties()
        'DisableStuffs()

        'fn.HitToLauncherUpdates()
        'fn.CheckLauncherUpdates()

        'fn.CheckForgeVersion(False, True)
        'Dim resulta = fn.ReadLogUser("enableprompt", False, False)
        'If resulta = "yes" Then

        '    fn.AlertAboutVersion(True)
        'End If

        'Dim result = fn.ReadLogUser("checklauncherupdates", False, False)
        'If result = "yes" Or result = Nothing Then
        'End If

        'fn.ShowingWhatsNew()
        'todas = ext.tenertodas()

        fn.SearchFolders(True)
        'Try
        'Catch
        'End Try
        'fn.checkunsupportedcards()
    End Sub

    Sub SetComboboxes()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add("8", "Top 8")
        comboSource.Add("12", "Top 12")
        comboSource.Add("16", "Top 16")
        comboSource.Add("25", "Top 25")
        comboSource.Add("50", "Top 50")

        Dim comboSource2 As New Dictionary(Of String, String)()
        comboSource2.Add("8", "Last 8")
        comboSource2.Add("12", "Last 12")
        comboSource2.Add("16", "Last 16")
        comboSource2.Add("25", "Last 25")
        comboSource2.Add("50", "Last 50")

        comboSource.Add("99", "Top 99")
        comboSource.Add("120", "Top 120")
            comboSource.Add("150", "Top 150")
            comboSource.Add("200", "Top 200")
            comboSource2.Add("99", "Last 99")
            comboSource2.Add("120", "Last 120")
            comboSource2.Add("200", "Last 200")

        howmuch2.DataSource = New BindingSource(comboSource2, Nothing)
        howmuch2.DisplayMember = "Value"
        howmuch2.ValueMember = "Key"

        howmuch.DataSource = New BindingSource(comboSource, Nothing)
        howmuch.DisplayMember = "Value"
        howmuch.ValueMember = "Key"

        metagame.SelectedIndex = 0
        metag2.SelectedIndex = 0
        'metag3.SelectedIndex = 0

        'ComboBox1.SelectedItem = ComboBox1.Items(0)
        ComboBox2.SelectedItem = ComboBox2.Items(0)
        'ComboBox3.SelectedItem = ComboBox3.Items(0)

        maxtournm.SelectedItem = maxtournm.Items(0)
        fromweb.SelectedItem = fromweb.Items(0)
        maxtournamentsdecks.SelectedItem = maxtournamentsdecks.Items(0)

    End Sub

    Sub DisableStuffs()
        If fn.CheckIfForgeExists() = False Then

            GroupExtras.Enabled = False
            'GroupBox3.Enabled = False
        Else

            GroupExtras.Enabled = True
            'GroupBox3.Enabled = True
        End If
        'GroupExtras.TabPages(46).Visible = False
        'quito lo de descargar gauntlets
        'GroupExtras.TabPages.Remove(GroupExtras.TabPages(1))
        'GroupExtras.TabPages.Remove(GroupExtras.TabPages(1))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            vars.UserDir = FolderBrowserDialog1.SelectedPath
            My.Settings.userdir = vars.UserDir
            My.Settings.Save()
            fn.SearchFolders(False)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        fn.getgauntlets()
    End Sub



    Private Sub update_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub fl_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        fn.DeleteDownloaded()
    End Sub


    Private Sub extract_Click(sender As Object, e As EventArgs) Handles extract1.Click
        fn.checkunsupportedcards()

        If InStr(metagame.SelectedItem.ToString, "-") = 0 Then
            ext.ExtractTopMtggoldfish(metagame.SelectedItem.ToString, howmuch.SelectedValue, chktopnumber.Checked,
                                      Nothing)
            Exit Sub
        End If

        If InStr(metagame.SelectedItem.ToString, "Download All") > 0 Then
            If _
                MsgBox("This action will take a long time, Are you sure?", MsgBoxStyle.YesNoCancel, "") =
                MsgBoxResult.Yes Then
                Dim formats = "Standard,Modern,Pauper,Legacy,Vintage,Commander 1v1,Commander, Arena Standard"
                Dim f() = Split(formats, ",")
                For i = 0 To f.Length - 1
                    ext.ExtractTopMtggoldfish(f(i), howmuch.SelectedValue, chktopnumber.Checked, Nothing)
                Next i
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        ext.ExtractTournamentMtgtop8()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs)
        fn.getgauntlets()
    End Sub

    Private Sub ForgeDiscordChannelToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Process.Start("https://discord.gg/3v9JCVr")
    End Sub

    Private Sub ForgeForumToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Process.Start("https://www.slightlymagic.net/forum/viewforum.php?f=26")
    End Sub

    Private Sub ForgeWikiToolStripMenuItem_Click(sender As Object, e As EventArgs)

        Process.Start("https://www.slightlymagic.net/wiki/Forge")
    End Sub

    Private Sub RestartForgeLauncherToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles RestartForgeLauncherToolStripMenuItem.Click
        Application.Restart()
    End Sub

    Private Sub GauntletContestFolderToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Process.Start(fn.ReadLogUser("gauntlet_dir", False))
        Catch
            fn.PrintError(Err.Description)
        End Try
    End Sub

    Private Sub PreferencesToolStripMenuItem_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub extract2_Click(sender As Object, e As EventArgs)
        ext.ExtractTournamentMtgtop8()
    End Sub

    Private Sub WhatsNewToolStripMenuItem_Click_2(sender As Object, e As EventArgs)


        Dim opened = False
        For Each frm As Form In Application.OpenForms
            If frm.Name.Equals("whatsnew") Then
                frm.Show()
                opened = True
            End If
        Next

        If Not opened Then
            Dim box = New whatsnew()
            box.Show()
        End If
    End Sub

    Private Sub PicsFolderToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Process.Start(fn.ReadLogUser("pics_dir", False))
        Catch
            fn.PrintError(Err.Description)
        End Try
    End Sub

    Private Sub ForzeUpdateForgeLauncherToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ForzeUpdateForgeLauncherToolStripMenuItem.Click
        fn.UpdateLog("launcher_version", "")
        fn.UpdateLog("lastupdate", "")
        Application.Restart()
    End Sub

    Private Sub CheckForLauncherUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        fn.CheckLauncherUpdates()
    End Sub

    Private Sub CancelButton1_Click(sender As Object, e As EventArgs)
        vars.continueLooping = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles extract3.Click
        fn.checkunsupportedcards()
        If InStr(metag2.SelectedItem.ToString, "-") = 0 Then
            ext.ExtractTopMtggoldfish(metag2.SelectedItem.ToString, howmuch2.SelectedValue, False, Nothing)
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

    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        fn.CheckLauncherUpdates()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim lafolder = fn.ReadLogUser("decks_dir", False)
            Process.Start(lafolder)
        Catch
            fn.PrintError(Err.Description)
        End Try
    End Sub

    Private Sub DecksFolderToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        Try
            Dim lafolder = fn.ReadLogUser("decks_dir", False)
            Process.Start(lafolder)
        Catch
            fn.PrintError(Err.Description)
        End Try
    End Sub

    Private Sub Button3_Click_2(sender As Object, e As EventArgs)
        fn.getgauntlets()
    End Sub

    Private Sub fl_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        'fn.DeleteDownloaded()
    End Sub

    Private Sub LogFileToolStripMenuItem_Click(sender As Object, e As EventArgs)
        fn.OpenLogFile()
    End Sub

    Private Sub CopyMyExternalIPToClipboardToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        fn.CopyIPtoClipboard()
    End Sub

    Private Sub RestoreForgePreferencesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles RestoreForgePreferencesToolStripMenuItem.Click
        fn.RestoreForgePreferences()
    End Sub

    Private Sub ReadForgeLogFileToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ReadForgeLogFileToolStripMenuItem.Click
        fn.OpenLogFile()
    End Sub

    Private Sub OpenDecksFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles OpenDecksFolderToolStripMenuItem.Click
        Try
            Dim lafolder = fn.ReadLogUser("decks_dir", False)
            Process.Start(lafolder)
        Catch
            fn.PrintError(Err.Description)
        End Try
    End Sub



    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs)

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

    Private Sub extract4_Click(sender As Object, e As EventArgs) Handles extract4.Click
        fn.checkunsupportedcards()
        Select Case fromweb.SelectedItem.ToString
            Case "mtgtop8"
                ext.ExtractFromMtgtop8(Replace(maxtournamentsdecks.SelectedItem.ToString, "Limit ", ""))
            Case "mtggoldfish"
                Dim w As String =
                        fn.ReadWeb(
                            "https://www.mtggoldfish.com/tournaments/" & ComboBox2.SelectedItem.ToString & "#paper")
                Dim links = ext.extlinks(w, "/tournament/")
                Dim laweb = ""
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

    'esta es la funcion buena
    Public Sub extracttournamentmtggoldfish(Optional ByVal tournament_url As String = "",
                                            Optional ByVal maxdecks As Integer = 100)

        'aqui saco el link del torneo OK, debería de crear la carpeta
        Dim eldir As String = fn.GetForgeDecksDir() & "\constructed\" & fn.ReadLogUser("tournamentsdecks_dir", False) &
                              "\"

        Dim tx1 As String
        'METEMOS EN UNA VARIABLE EL tx DEL TORNEO PARA SACAR LAS URLS DE LOS MAZOS
        tx1 = fn.ReadWeb(tournament_url)

        Dim tourname = ""

        ' Leer el contenido.
        Dim res As String = tx1
        'FORMATO DEL name
        tourname = fn.FindIt(tx1, "<title>", "</title>")
        tourname = Replace(tourname, " (" & ComboBox2.SelectedItem.ToString & ") Decks", "")


        If tourname Is Nothing Then tourname = ""
        tourname = tourname.Trim()
        tourname = Replace(tourname, ":", "")
        'CREAMOS UNA MyFolder CON EL name DEL TORNEO
        Dim MyFolder As String = eldir & tourname & "\"
        If Directory.Exists(MyFolder) Then
            If _
                MsgBox(
                    "Folder " & tourname & " exists, do you want to download decks again? " & vbCrLf & vbCrLf &
                    " (Decks inside the folder will be deleted)", MsgBoxStyle.YesNoCancel, "Warning!") = MsgBoxResult.No _
                Then 'Or (MsgBoxResult.Cancel)
                fn.WriteUserLog(tourname & " folder exists. Operation cancelled." & vbCrLf)
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

        'SACAMOS LAS URLS DE LOS MAZOS


        tx1 = ext.extlinks(tx1, "/deck/", "/deck/custom/standard") '"/visual/",


        'YA TENGO LAS URL, AHORA A EXTRAER UNA POR UNA
        Dim lasurls() As String = Split(tx1, vbCrLf)
        Dim mx = Replace(maxtournamentsdecks.SelectedItem.ToString, "Limit ", "")
        Dim contadorposicion = 0
        For a = 0 To lasurls.Length - 1


            If _
                lasurls(a).ToString <> "" And
                lasurls(a).ToString <> "/deck/custom/" & LCase(ComboBox2.SelectedItem.ToString) Then

                If a > mx Then Exit For


                Dim DeckPage = ""
                Dim UrlDeck = ""
                'pagina del mazo i
                DeckPage = fn.ReadWeb(vars.mtggf & lasurls(a))
                'url del mazo i

                UrlDeck = ext.extmtggoldfish(DeckPage, "/deck/download/")

                Dim Deck = ""
                Dim TitDeck = ""
                'titulo del mazo i

                'formato del titulo del mazo

                'sacamos el tx del 
                Deck = fn.ReadWeb(vars.mtggf & "/" & UrlDeck)

                'formato del mazo
                Deck = Replace(Deck, "sideboard", "[sideboard]")
                Deck = Replace(Deck, vbCrLf & vbCrLf, vbCrLf & "[sideboard]" & vbCrLf)

                Deck = Replace(Deck, "[[", "[")
                Deck = Replace(Deck, "]]", "]")
                TitDeck = fn.FindIt(DeckPage, "<title>", "</title>")
                TitDeck = Replace(TitDeck, "_", " ")
                TitDeck = Replace(TitDeck, """", "'")
                ' TitDeck = fn.Normalize(TitDeck)

                Dim num As String = (contadorposicion + 1).ToString
                If Len(num) <= 1 Then num = "0" & num

                TitDeck = "#" & num & " - " & TitDeck

                contadorposicion = (contadorposicion + 1).ToString
                Deck = fn.FormatDeck(Deck, TitDeck)
                fn.StringToDeck(MyFolder, Deck, TitDeck)
                fn.WriteUserLog("Saving " & TitDeck & vbCrLf)
            End If

        Next a
        extract1.Enabled = True
        fn.WriteUserLog("Completed")
        't = fn.ReadWeb(web)
        'y esto de abajo está bien?
        ' If i = 0 Then Exit For

        'fin del continua
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        'extracttournamentmtggoldfish("https://www.mtggoldfish.com/decks/budget/Modern#paper", 100)
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Process.Start("https://drive.google.com/file/d/18WT3KM7byQIkkcK-ow7FidYmBoZYHpxi/view?usp=sharing")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Process.Start("https://mega.nz/#F!nhUXAYiJ!ddZy_z7Aq6nF4hCnNNestg")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Process.Start("https://mega.nz/#F!sEgi1A6S!l8ye2iwWDrTPHlgDp36UCw")
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Process.Start("https://mega.nz/#F!8Mx1xaZZ!PATKOBXq0IaLNaGFsIAJ6g")
    End Sub


    Private Sub btnlaunchmode_Click(sender As Object, e As EventArgs)
        Dim opened = False

        For Each frm As Form In Application.OpenForms
            If frm.Name.Equals("lm") Then
                frm.Show()
                opened = True
            End If
        Next

        If opened = False Then
            Dim box = New lm()
            box.Show()
        End If


        'Dim box = New lm()
        'box.Show()
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

    Private Sub btnupdate_Click(sender As Object, e As EventArgs)
        'If typeofupdate.SelectedItem.ToString = "release" Then
        '    MsgBox("Please, consider using snapshots, releases have not been created for months.")
        '    Exit Sub
        'End If
    End Sub

    Private Sub txlog_TextChanged(sender As Object, e As EventArgs) Handles txlog.TextChanged
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs)
        'CreateCardsBySetFile()
    End Sub

    Sub CreateCardsBySetFile()

        Dim todaslascartas As String = File.ReadAllText(vars.UserDir & "\fldata\allsupportedcards.txt")
        Dim todaslasediciones As String = File.ReadAllText(vars.UserDir & "\fldata\allmysets.txt")
        Dim archivodestino As String = File.ReadAllText(vars.UserDir & "\fldata\allcardsandsets.txt")

        Dim resultado = ""

        Dim cartas = Split(todaslascartas, vbCrLf)
        Dim edici() = Split(todaslasediciones, vbCrLf)

        Dim ediciones() As String

        Dim edicionesmalas() As String
        Dim listbuenas As New List(Of String)()
        Dim listmalas As New List(Of String)()
        Dim listignorar As New List(Of String)()

        Dim cuentabuenas = 0
        Dim cuentamalas = 0

        For x = 0 To edici.Length - 1
            If edici(x) <> "" Then

                Dim setcode = Split(edici(x), "SetCode=")(1).Split("|")(0)
                Dim setfolder = Split(edici(x), "Folder=")(1).Split("|")(0)
                Dim SetType = Split(edici(x), "SetType=")(1).Split("|")(0)

                Dim pasar As Boolean = True
                'aqui pongo las que no quiero que tome
                Dim tipodeexpansion = Split(edici(x), "SetType=")(1).Split(vbLf)(0).ToString
                If setcode = "UNH" Then
                    listbuenas.Add(setcode)
                    pasar = False
                End If
                If setcode = "PLIST" Then
                    listmalas.Add(setcode)
                    pasar = False
                End If
                If setcode = "PSLD" Then
                    listmalas.Add(setcode)
                    pasar = False
                End If
                If pasar Then
                    Select Case tipodeexpansion
                        Case "Expansion", "Core", "Other", "Reprint"
                            listbuenas.Add(setcode)
                        Case Else
                            listmalas.Add(setcode)
                    End Select
                End If

            End If
        Next x



        For i = 0 To cartas.Length - 1
            Dim lacarta = Split(cartas(i), "|")(0)
            Dim laedicion = Split(cartas(i), "|")(1)
            If laedicion.Contains("|") Then laedicion = Split(laedicion, "|")(0)

            lacarta = lacarta
            laedicion = laedicion

            For b = 0 To listmalas.Count - 1
                Dim cartaconsalto = cartas(i) & vbCrLf
                If cartaconsalto.Contains("|" & listmalas(b) & vbCrLf) Then
                    archivodestino = Replace(archivodestino, vbCrLf & lacarta & "|" & listmalas(b) & vbCrLf, Nothing)
                    File.Delete(vars.UserDir & "\fldata\allcardsandsets.txt")
                    Dim fPath = vars.UserDir & "\fldata\allcardsandsets.txt"
                    archivodestino = Replace(archivodestino, vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf, vbCrLf)
                    archivodestino = Replace(archivodestino, vbCrLf & vbCrLf & vbCrLf & vbCrLf, vbCrLf)
                    archivodestino = Replace(archivodestino, vbCrLf & vbCrLf & vbCrLf, vbCrLf)
                    archivodestino = Replace(archivodestino, vbCrLf & vbCrLf, vbCrLf)

                    Dim afile As New StreamWriter(fPath, True)
                    afile.WriteLine(archivodestino)
                    afile.Close()
                End If
            Next b

        Next i

        archivodestino = ""
        Dim anterior As String = ""
        For i = 0 To cartas.Length - 1

            archivodestino = ""
            archivodestino = File.ReadAllText(vars.UserDir & "\fldata\allcardsandsets.txt")

            'formateo la carta
            Dim lacarta = Split(cartas(i), "|")(0)
            Dim laedicion = Split(cartas(i), "|")(1)

            If Environment.NewLine & lacarta & "|" <> anterior Then


                If laedicion.Contains("|") Then laedicion = Split(laedicion, "|")(0)
                lacarta = lacarta
                laedicion = laedicion
                Dim hapasado As Boolean

                fn.WriteUserLog("processing " & lacarta & vbCrLf)


                For e = 0 To listbuenas.Count - 1
                    hapasado = False

                    'patron para buscar en el listado de todas
                    Dim patron = lacarta & "|" & listbuenas(e)
                    If archivodestino.Contains(Environment.NewLine & lacarta & "|") Then
                        hapasado = True
                        Exit For
                    End If

                    If _
                        lacarta = "Forest" Or lacarta = "Plains" Or lacarta = "Swamp" Or lacarta = "Mountain" Or
                        lacarta = "Island" Then
                        hapasado = True
                        resultado = lacarta & "|KHM"
                        Exit For
                    End If

                    If lacarta = "Wastes" Then
                        hapasado = True
                        resultado = lacarta & "|OGW"
                        Exit For
                    End If

                    Dim contiene = False
                    Try
                        'AQUI ES DONDE MIRO SI LA EDICION X COINCIDE EN EL FICHERO DE TODAS DE CARTAS
                        'Dim controlar = Split(todaslascartas,Environment.NewLine & patron)(0).Split(vbCrLf)(0)
                        'If controlar = patron then
                        If todaslascartas.Contains(Environment.NewLine & patron) = True Then
                            resultado = patron
                            hapasado = True
                            Exit For
                        End If
                    Catch
                    End Try
                Next e

                If hapasado = False Then
                    resultado = lacarta & "|" & laedicion
                Else
                    resultado = resultado
                End If

                If resultado <> "" Then
                    Dim carpetaca = Directory.GetCurrentDirectory() & "\cache\pics\cards\" &
                                    Split(resultado, "|")(1)
                    If Directory.Exists(carpetaca) = False And hapasado = True Then
                        carpetaca = carpetaca
                    End If
                End If
                If resultado <> "" Then
                    Dim test = Environment.NewLine & Split(resultado, "|")(0) & "|"
                    If archivodestino.Contains(test) = True Then
                        resultado = ""
                    End If
                End If
                If resultado <> "" Then
                    If i > 0 Then '"ach ach run"
                        Dim file = My.Computer.FileSystem.OpenTextFileWriter(vars.UserDir & "\fldata\allcardsandsets.txt", True)
                        file.WriteLine(resultado)
                        file.Close()

                    End If
                Else
                    archivodestino = File.ReadAllText(vars.UserDir & "\fldata\allcardsandsets.txt")
                    If archivodestino.Contains(vbCrLf & lacarta & "|") = False Then
                        Dim file = My.Computer.FileSystem.OpenTextFileWriter(vars.UserDir & "\fldata\allcardsandsets.txt", True)
                        file.WriteLine(lacarta & "|" & laedicion)
                        file.Close()
                    End If
                    archivodestino = ""
                End If

                anterior = Environment.NewLine & lacarta & "|"
            End If

        Next i
    End Sub

    Private Sub CccToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Dim result = fn.ReadLogUser("checklauncherupdates", False, False)
        'If result = "yes" Or result = Nothing Then
        '    fn.HitToLauncherUpdates()
        '    fn.CheckLauncherUpdates()
        'End If

        fn.CheckLauncherUpdates()
    End Sub

    Private Sub CccToolStripMenuItem_Click_1(sender As Object, e As EventArgs)

        fn.CheckLauncherUpdates()
    End Sub

    'Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles Button1.Click

    '    Dim validoano = False
    '    Dim validoformat = False
    '    If lbgauntletyear.SelectedIndex <> -1 Then
    '        validoano = True
    '    End If
    '    If validoano = False Then
    '        MsgBox("Select Year")
    '        Exit Sub
    '    End If

    '    If lbgauntletformat.SelectedIndex <> -1 Then
    '        validoformat = True
    '    End If
    '    If validoformat = False Then
    '        MsgBox("Select Format")
    '        Exit Sub
    '    End If

    '    Dim ano = lbgauntletyear.SelectedItem.ToString
    '    Dim formato = lbgauntletformat.SelectedItem.ToString
    '    Button1.Enabled = False
    '    Try
    '        File.Delete("gauntlet.zip")
    '    Catch
    '    End Try
    '    Try
    '        fn.DownloadFile(vars.BaseUrl & "gauntlets/" & LCase(formato) & "/" & ano & ".zip", "gauntlet.zip", True)
    '    Catch
    '        fn.WriteUserLog("Unable to get from server temporarily, please try later." & vbCrLf)
    '        Exit Sub
    '    End Try
    '    'Try
    '    Dim mycount As Long = 0
    '    vars.UserDir = My.Settings.myuser_directory
    '    vars.UserDir = Replace(vars.UserDir, "/user", "")
    '    vars.UserDir = Replace(vars.UserDir, "\user", "")
    '    Dim rutausuario = fn.ReadLogUser("gauntlet_dir", False, False)

    '    Using archive As ZipArchive = ZipFile.OpenRead("gauntlet.zip")
    '        For Each entry As ZipArchiveEntry In archive.Entries
    '            entry.ExtractToFile(Path.Combine(rutausuario & "\", entry.FullName), True)
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

    Private Sub Button3_Click_3(sender As Object, e As EventArgs) Handles Button3.Click
        Dim rutausuario = fn.ReadLogUser("gauntlet_dir", False, False)
        Dim directoryName As String = rutausuario
        Try
            Dim cuenta = 0
            For Each deleteFile In Directory.GetFiles(directoryName, "LOCKED_*.*", SearchOption.TopDirectoryOnly)
                If deleteFile.Contains("LOCKED_DotP") = False Then
                    If deleteFile.Contains("LOCKED_Starting") = False Then
                        If deleteFile.Contains("LOCKED_Swimming") = False Then
                            File.Delete(deleteFile)
                            fn.WriteUserLog("Deleting " & deleteFile & vbCrLf)
                            cuenta = cuenta + 1
                        End If
                    End If
                End If

            Next
            fn.WriteUserLog(cuenta & " downloaded Gauntlet has been deleted." & vbCrLf)

        Catch
        End Try
    End Sub

    Private Sub CheckForForgeLauncherUpdatesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles CheckForForgeLauncherUpdatesToolStripMenuItem.Click
        fn.CheckLauncherUpdates()
    End Sub

    Private Sub chkenableprompt_CheckedChanged(sender As Object, e As EventArgs)
        Dim shit As Boolean
        If fn.ReadLogUser("enableprompt", False, False) = "yes" Then
            shit = True
        Else
            shit = False
        End If
    End Sub

    Private Sub fl_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        fn.DeleteDownloaded()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs)
        Dim opened = False

        For Each frm As Form In Application.OpenForms
            If frm.Name.Equals("lm") Then
                frm.Show()
                opened = True
            End If
        Next

        If opened = False Then
            Dim box = New lm()
            box.Show()
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs)
        CreateCardsBySetFile()
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


            Dim linea = "SetDate=" & SetDate & "|SetName=" & SetName & "|SetCode=" & SetCode & "|SetFolder=" & SetFolder & "|SetType=" & SetType
            linea = Replace(linea, vbCr, Nothing)
            myList.Add(linea)

            Console.WriteLine(fri.Name)

        Next fri


        '**************

        Dim myListSortedByDate As New List(Of String)()

        Dim startP As DateTime = New DateTime(1993, 8, 5)
        Dim endP As DateTime = New DateTime(DateTime.Now.Year, Date.Now.Month, Date.Now.Day)
        Dim currD As DateTime = startP



        While (currD <= endP)

            For i = 0 To myList.Count - 1
                Dim fecha = Split(myList(i), "SetDate=")(1).Split("|")(0)
                If CDate(fecha).ToShortDateString = CDate(currD).ToShortDateString Then
                    myListSortedByDate.Add(myList(i))
                End If
            Next i
            currD = currD.AddDays(1)

        End While


        myListSortedByDate.Reverse()

        'borro y lo creo
        File.Delete(vars.UserDir & "\fldata\allmysets.txt")
        'aqui lo creo   
        Dim fPath = vars.UserDir & "\fldata\allmysets.txt"

        Dim afile As New StreamWriter(vars.UserDir & "\fldata\allmysets.txt", True)
        For i = 0 To myListSortedByDate.Count - 1
            afile.WriteLine(myListSortedByDate(i))
        Next i
        afile.Close()
        MsgBox("\fldata\allmysets.tx created!")

    End Sub

    Private Sub Button5_Click_2(sender As Object, e As EventArgs) Handles Button5.Click
        Button5.Enabled = False

        CreateCardsBySetFile()
        Button5.Enabled = True

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        poneredicionesenmazos(metagame.SelectedItem.ToString())
    End Sub


    sub poneredicionesenmazos(metajuego)


        For Each f In Directory.GetFiles(Directory.GetCurrentDirectory() & "\user\decks\constructed\" & metajuego)
           Dim t =  File.ReadAllText(f)
            t = t
            if t <> "" then
            Dim tx = Split(t,"[Main]")(1).ToString()
            Dim name = Split(t,"Name = ")(1).Split(vbCrLf)(0)
            tx = tx

            name = name
                'tx = fn.PonerEdicion(tx, name)
                tx = tx
            File.Delete(f)
            Dim afile As New StreamWriter(f, True)
            afile.WriteLine(tx)
            afile.Close()
            fn.WriteUserLog(name & vbCrLf)

            end if

        Next

    End sub



    sub quitarediciones(metajuego)


        Dim carpeta =""
        
        if metajuego.contains("Commander") then 
            carpeta = Directory.GetCurrentDirectory() & "\user\decks\commander\" 
        End If

        if metajuego.contains("Brawl") then 
            carpeta = Directory.GetCurrentDirectory() & "\user\decks\brawl\"
        End If

        if carpeta = "" then carpeta = Directory.GetCurrentDirectory() & "\user\decks\constructed\" & metajuego

                        Dim result as string

        For Each f In Directory.GetFiles(carpeta)
            result= ""
            Dim t =  File.ReadAllText(f)
            t = t
            if t <> "" then
                Dim tx = Split(t,"[Main]")(1).ToString()
                Dim name = Split(t,"Name = ")(1).Split(vbCrLf)(0)
                tx = tx

                name = name


                'parto por los saltos
                Dim lines() = split(tx,vbCrLf)
                For i = 0 to lines.Count -1
                    if lines(i) <> "" then
                    if lines(i).Contains("|") then
                    result = result &  Split(lines(i),"|")(0) & vbCrLf
                    Else 
                        result = result & lines(i) & vbCrLf
                    end if
                        End If

                Next

                tx = "[metadata]" & vbCrLf & "Name = " & name & vbCrLf & "[Main]" & vbCrLf & result
                tx = replace(tx,environment.NewLine,vbCrLf)
               tx = replace(tx,vbCrLf & vbCrLf & vbCrLf,vbCrLf)
                tx = replace(tx,vbCrLf & vbCrLf,vbCrLf)

               
                tx = tx
                File.Delete(f)
                Dim afile As New StreamWriter(f, True)
                afile.WriteLine(tx)
                afile.Close()
                fn.WriteUserLog(name & vbCrLf)

            end if

        Next

    End sub

    sub findcard(cardname)
        Dim metajuego  = metagame.SelectedItem.ToString()
        Dim carpeta =""
        
        if metajuego.contains("Commander") then 
            carpeta = Directory.GetCurrentDirectory() & "\user\decks\commander\" 
        End If

        if metajuego.contains("Brawl") then 
            carpeta = Directory.GetCurrentDirectory() & "\user\decks\brawl\"
        End If

        if carpeta = "" then carpeta = Directory.GetCurrentDirectory() & "\user\decks\constructed\" & metajuego


        For Each f In Directory.GetFiles(carpeta)
            Dim t =  File.ReadAllText(f)
            if t.Contains(cardname) Then
                MsgBox("Find " & cardname & " in " & f)
                exit sub
            End If
            fn.WriteUserLog("Searching in " &  f & vbCrLf)
            next

    End sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        findcard(cardtofind.Text)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        quitarediciones(metagame.SelectedItem.ToString())
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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        Dim metajuego  = metagame.SelectedItem.ToString()
        Dim carpeta =""
        
        if metajuego.contains("Commander") then 
            carpeta = Directory.GetCurrentDirectory() & "\user\decks\commander\" 
        End If

        if metajuego.contains("Brawl") then 
            carpeta = Directory.GetCurrentDirectory() & "\user\decks\brawl\"
        End If

        if carpeta = "" then carpeta = Directory.GetCurrentDirectory() & "\user\decks\constructed\" & metajuego

        Dim elfichero = Directory.GetCurrentDirectory() & "\current" & LCase(fn.RemoveWhitespace(Replace(metajuego, " ", "")) & "metagame.zip")
        If File.Exists(elfichero) Then
            File.Delete(elfichero)
        End If

        compressDirectory(carpeta, elfichero)
        fn.WriteUserLog("Zipped " & elfichero & vbCrLf)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        If File.Exists(IO.Directory.GetCurrentDirectory() & "/fldata/allcardsandsets.txt") = False Then
            File.Create(IO.Directory.GetCurrentDirectory() & "/fldata/allcardsandsets.txt").Dispose()
        End If

        Dim actual As String = File.ReadAllText(IO.Directory.GetCurrentDirectory() & "/fldata/allcardsandsets.txt")
        Dim Listado As New List(Of String)()
        Dim listbuenas As New List(Of String)()
        Dim arr = Split(actual, vbCrLf)
        For Each i In arr
            If i <> "" Then
                Listado.Add(i.ToString)
            End If
        Next


        Dim Cards As New List(Of String)()

        'realmente tendría que recorrer los sets por fecha para tener las cartas actuales, PERO PRUEBO ASI

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
                    Dim carta = list(i)
                    If carta.Contains("+") Then carta = Split(carta, "+")(0).ToString()
                    If carta.Contains("|") Then carta = Split(carta, "|")(0).ToString()
                    If carta.Contains("[") Then carta = Split(carta, "[")(0).ToString()
                    carta = Trim(carta)
                    '"★"
                    'si no existe ya se añade
                    If actual.Contains(carta & vbCrLf) = False Then
                        Cards.Add(carta)
                    End If
                End If
            Next

        Next
        'ORDENO ALFABETICAMENTE
        Cards.Sort()
        Cards.Distinct()

        Dim t As String
        For Each a In Cards
            t = t & a & vbCrLf
        Next

        Dim afile As New StreamWriter(IO.Directory.GetCurrentDirectory() & "/fldata/allcardsandsets.txt", True)
        afile.WriteLine(t)
        afile.Close()


    End Sub
End Class