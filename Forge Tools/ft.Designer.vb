<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ft
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ft))
        Me.txlog = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderBrowserDialog2 = New System.Windows.Forms.FolderBrowserDialog()
        Me.MenuGeneral = New System.Windows.Forms.MenuStrip()
        Me.OpenDecksFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestartForgeLauncherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckForForgeLauncherUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForzeUpdateForgeLauncherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReadForgeLogFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreForgePreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupExtras = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.by_metagame = New System.Windows.Forms.TabPage()
        Me.insertedition = New System.Windows.Forms.CheckBox()
        Me.extract1 = New System.Windows.Forms.Button()
        Me.chktopnumber = New System.Windows.Forms.CheckBox()
        Me.howmuch = New System.Windows.Forms.ComboBox()
        Me.metagame = New System.Windows.Forms.ComboBox()
        Me.By_Tournament = New System.Windows.Forms.TabPage()
        Me.maxtournamentsdecks = New System.Windows.Forms.ComboBox()
        Me.fromweb = New System.Windows.Forms.ComboBox()
        Me.maxtournm = New System.Windows.Forms.ComboBox()
        Me.extract4 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Other_Formats = New System.Windows.Forms.TabPage()
        Me.extract3 = New System.Windows.Forms.Button()
        Me.howmuch2 = New System.Windows.Forms.ComboBox()
        Me.metag2 = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbgauntletformat = New System.Windows.Forms.ListBox()
        Me.lbgauntletyear = New System.Windows.Forms.ListBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.cardtofind = New System.Windows.Forms.TextBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.MenuGeneral.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupExtras.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.by_metagame.SuspendLayout()
        Me.By_Tournament.SuspendLayout()
        Me.Other_Formats.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txlog
        '
        Me.txlog.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlog.Location = New System.Drawing.Point(16, 200)
        Me.txlog.Multiline = True
        Me.txlog.Name = "txlog"
        Me.txlog.ReadOnly = True
        Me.txlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txlog.Size = New System.Drawing.Size(698, 301)
        Me.txlog.TabIndex = 24
        '
        'MenuGeneral
        '
        Me.MenuGeneral.BackColor = System.Drawing.Color.Silver
        Me.MenuGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MenuGeneral.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuGeneral.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenDecksFolderToolStripMenuItem, Me.SettingsToolStripMenuItem1, Me.ToolsToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuGeneral.Location = New System.Drawing.Point(0, 0)
        Me.MenuGeneral.Name = "MenuGeneral"
        Me.MenuGeneral.Size = New System.Drawing.Size(729, 28)
        Me.MenuGeneral.TabIndex = 41
        Me.MenuGeneral.Text = "MenuStrip1"
        '
        'OpenDecksFolderToolStripMenuItem
        '
        Me.OpenDecksFolderToolStripMenuItem.Name = "OpenDecksFolderToolStripMenuItem"
        Me.OpenDecksFolderToolStripMenuItem.Size = New System.Drawing.Size(142, 24)
        Me.OpenDecksFolderToolStripMenuItem.Text = "Open Decks Folder"
        '
        'SettingsToolStripMenuItem1
        '
        Me.SettingsToolStripMenuItem1.Name = "SettingsToolStripMenuItem1"
        Me.SettingsToolStripMenuItem1.Size = New System.Drawing.Size(71, 24)
        Me.SettingsToolStripMenuItem1.Text = "Settings"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestartForgeLauncherToolStripMenuItem, Me.CheckForForgeLauncherUpdatesToolStripMenuItem, Me.ForzeUpdateForgeLauncherToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(119, 24)
        Me.ToolsToolStripMenuItem.Text = "Launcher Tools"
        '
        'RestartForgeLauncherToolStripMenuItem
        '
        Me.RestartForgeLauncherToolStripMenuItem.Name = "RestartForgeLauncherToolStripMenuItem"
        Me.RestartForgeLauncherToolStripMenuItem.Size = New System.Drawing.Size(438, 26)
        Me.RestartForgeLauncherToolStripMenuItem.Text = "Restart Forge Launcher"
        '
        'CheckForForgeLauncherUpdatesToolStripMenuItem
        '
        Me.CheckForForgeLauncherUpdatesToolStripMenuItem.Name = "CheckForForgeLauncherUpdatesToolStripMenuItem"
        Me.CheckForForgeLauncherUpdatesToolStripMenuItem.Size = New System.Drawing.Size(438, 26)
        Me.CheckForForgeLauncherUpdatesToolStripMenuItem.Text = "Check for Forge Launcher Updates"
        '
        'ForzeUpdateForgeLauncherToolStripMenuItem
        '
        Me.ForzeUpdateForgeLauncherToolStripMenuItem.Name = "ForzeUpdateForgeLauncherToolStripMenuItem"
        Me.ForzeUpdateForgeLauncherToolStripMenuItem.Size = New System.Drawing.Size(438, 26)
        Me.ForzeUpdateForgeLauncherToolStripMenuItem.Text = "Force to Install Last Forge Launcher Version from server"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReadForgeLogFileToolStripMenuItem, Me.RestoreForgePreferencesToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(96, 24)
        Me.ToolStripMenuItem1.Text = "Forge Tools"
        '
        'ReadForgeLogFileToolStripMenuItem
        '
        Me.ReadForgeLogFileToolStripMenuItem.Name = "ReadForgeLogFileToolStripMenuItem"
        Me.ReadForgeLogFileToolStripMenuItem.Size = New System.Drawing.Size(254, 26)
        Me.ReadForgeLogFileToolStripMenuItem.Text = "Read Forge Log File"
        '
        'RestoreForgePreferencesToolStripMenuItem
        '
        Me.RestoreForgePreferencesToolStripMenuItem.Name = "RestoreForgePreferencesToolStripMenuItem"
        Me.RestoreForgePreferencesToolStripMenuItem.Size = New System.Drawing.Size(254, 26)
        Me.RestoreForgePreferencesToolStripMenuItem.Text = "Restore Forge Preferences"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 200
        Me.ToolTip1.ReshowDelay = 100
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(16, 21)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(25, 24)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 57
        Me.PictureBox5.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox5, "Autoextract last tournament decks by format.")
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(16, 23)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(25, 24)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 52
        Me.PictureBox6.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox6, "Other formats. User submmited decks. No top available.")
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "Select metagame and number of decks to download. Put #top number (by default) for" &
        " get the number in the top in the deck file.")
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(641, 88)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(35, 27)
        Me.Button3.TabIndex = 56
        Me.ToolTip1.SetToolTip(Me.Button3, "Delete all downloaded Gauntlets")
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 455)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 15)
        Me.Label1.TabIndex = 45
        '
        'GroupExtras
        '
        Me.GroupExtras.Controls.Add(Me.TabPage1)
        Me.GroupExtras.Controls.Add(Me.TabPage2)
        Me.GroupExtras.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupExtras.Location = New System.Drawing.Point(11, 37)
        Me.GroupExtras.Name = "GroupExtras"
        Me.GroupExtras.SelectedIndex = 0
        Me.GroupExtras.Size = New System.Drawing.Size(702, 157)
        Me.GroupExtras.TabIndex = 46
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPage1.Controls.Add(Me.TabControl1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(694, 129)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Decks Extractor"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.by_metagame)
        Me.TabControl1.Controls.Add(Me.By_Tournament)
        Me.TabControl1.Controls.Add(Me.Other_Formats)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!)
        Me.TabControl1.Location = New System.Drawing.Point(9, 10)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(679, 103)
        Me.TabControl1.TabIndex = 42
        Me.TabControl1.Tag = ""
        '
        'by_metagame
        '
        Me.by_metagame.BackColor = System.Drawing.Color.Transparent
        Me.by_metagame.Controls.Add(Me.insertedition)
        Me.by_metagame.Controls.Add(Me.PictureBox1)
        Me.by_metagame.Controls.Add(Me.extract1)
        Me.by_metagame.Controls.Add(Me.chktopnumber)
        Me.by_metagame.Controls.Add(Me.howmuch)
        Me.by_metagame.Controls.Add(Me.metagame)
        Me.by_metagame.Location = New System.Drawing.Point(4, 24)
        Me.by_metagame.Name = "by_metagame"
        Me.by_metagame.Padding = New System.Windows.Forms.Padding(3)
        Me.by_metagame.Size = New System.Drawing.Size(671, 75)
        Me.by_metagame.TabIndex = 2
        Me.by_metagame.Text = "Top Formats"
        '
        'insertedition
        '
        Me.insertedition.AutoSize = True
        Me.insertedition.Checked = True
        Me.insertedition.CheckState = System.Windows.Forms.CheckState.Checked
        Me.insertedition.Location = New System.Drawing.Point(249, 50)
        Me.insertedition.Name = "insertedition"
        Me.insertedition.Size = New System.Drawing.Size(159, 19)
        Me.insertedition.TabIndex = 49
        Me.insertedition.Text = "insert |EDITION in cards"
        Me.insertedition.UseVisualStyleBackColor = True
        Me.insertedition.Visible = False
        '
        'extract1
        '
        Me.extract1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.extract1.ForeColor = System.Drawing.Color.Black
        Me.extract1.Location = New System.Drawing.Point(373, 21)
        Me.extract1.Name = "extract1"
        Me.extract1.Size = New System.Drawing.Size(278, 26)
        Me.extract1.TabIndex = 45
        Me.extract1.Text = "Extract Decks"
        Me.extract1.UseVisualStyleBackColor = True
        '
        'chktopnumber
        '
        Me.chktopnumber.AutoSize = True
        Me.chktopnumber.Checked = True
        Me.chktopnumber.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chktopnumber.Location = New System.Drawing.Point(249, 25)
        Me.chktopnumber.Name = "chktopnumber"
        Me.chktopnumber.Size = New System.Drawing.Size(99, 19)
        Me.chktopnumber.TabIndex = 44
        Me.chktopnumber.Text = "#top number"
        Me.chktopnumber.UseVisualStyleBackColor = True
        '
        'howmuch
        '
        Me.howmuch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.howmuch.FormattingEnabled = True
        Me.howmuch.Location = New System.Drawing.Point(178, 23)
        Me.howmuch.Name = "howmuch"
        Me.howmuch.Size = New System.Drawing.Size(65, 23)
        Me.howmuch.TabIndex = 43
        '
        'metagame
        '
        Me.metagame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.metagame.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.metagame.FormattingEnabled = True
        Me.metagame.Items.AddRange(New Object() {"Standard", "Modern", "Pioneer", "Pauper", "Legacy", "Vintage", "Historic", "Penny Dreadful", "Commander 1v1", "Commander", "Brawl"})
        Me.metagame.Location = New System.Drawing.Point(47, 23)
        Me.metagame.Name = "metagame"
        Me.metagame.Size = New System.Drawing.Size(123, 24)
        Me.metagame.TabIndex = 41
        '
        'By_Tournament
        '
        Me.By_Tournament.BackColor = System.Drawing.Color.Transparent
        Me.By_Tournament.Controls.Add(Me.maxtournamentsdecks)
        Me.By_Tournament.Controls.Add(Me.fromweb)
        Me.By_Tournament.Controls.Add(Me.PictureBox5)
        Me.By_Tournament.Controls.Add(Me.maxtournm)
        Me.By_Tournament.Controls.Add(Me.extract4)
        Me.By_Tournament.Controls.Add(Me.ComboBox2)
        Me.By_Tournament.Controls.Add(Me.LinkLabel1)
        Me.By_Tournament.Controls.Add(Me.Label5)
        Me.By_Tournament.Location = New System.Drawing.Point(4, 24)
        Me.By_Tournament.Name = "By_Tournament"
        Me.By_Tournament.Padding = New System.Windows.Forms.Padding(3)
        Me.By_Tournament.Size = New System.Drawing.Size(671, 75)
        Me.By_Tournament.TabIndex = 1
        Me.By_Tournament.Text = "By Tournament"
        '
        'maxtournamentsdecks
        '
        Me.maxtournamentsdecks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.maxtournamentsdecks.FormattingEnabled = True
        Me.maxtournamentsdecks.Items.AddRange(New Object() {"Limit 8", "Limit 12", "Limit 16", "Limit 25", "Limit 50"})
        Me.maxtournamentsdecks.Location = New System.Drawing.Point(367, 23)
        Me.maxtournamentsdecks.Name = "maxtournamentsdecks"
        Me.maxtournamentsdecks.Size = New System.Drawing.Size(69, 23)
        Me.maxtournamentsdecks.TabIndex = 59
        '
        'fromweb
        '
        Me.fromweb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fromweb.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.fromweb.FormattingEnabled = True
        Me.fromweb.Items.AddRange(New Object() {"mtgtop8", "mtggoldfish"})
        Me.fromweb.Location = New System.Drawing.Point(47, 22)
        Me.fromweb.Name = "fromweb"
        Me.fromweb.Size = New System.Drawing.Size(80, 24)
        Me.fromweb.TabIndex = 58
        '
        'maxtournm
        '
        Me.maxtournm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.maxtournm.FormattingEnabled = True
        Me.maxtournm.Items.AddRange(New Object() {"Last One", "Last 2", "Last 3 ", "Last 4", "Last 5", "Last 6", "Last 7", "Last 8", "Last 9", "Last 10"})
        Me.maxtournm.Location = New System.Drawing.Point(281, 22)
        Me.maxtournm.Name = "maxtournm"
        Me.maxtournm.Size = New System.Drawing.Size(80, 23)
        Me.maxtournm.TabIndex = 56
        '
        'extract4
        '
        Me.extract4.Location = New System.Drawing.Point(442, 21)
        Me.extract4.Name = "extract4"
        Me.extract4.Size = New System.Drawing.Size(211, 26)
        Me.extract4.TabIndex = 55
        Me.extract4.Text = "Extract Decks"
        Me.extract4.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Standard", "Modern", "Pioneer", "Pauper", "Legacy", "Vintage"})
        Me.ComboBox2.Location = New System.Drawing.Point(133, 22)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(142, 24)
        Me.ComboBox2.TabIndex = 54
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(795, 249)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(0, 15)
        Me.LinkLabel1.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 15)
        Me.Label5.TabIndex = 12
        '
        'Other_Formats
        '
        Me.Other_Formats.BackColor = System.Drawing.Color.Transparent
        Me.Other_Formats.Controls.Add(Me.PictureBox6)
        Me.Other_Formats.Controls.Add(Me.extract3)
        Me.Other_Formats.Controls.Add(Me.howmuch2)
        Me.Other_Formats.Controls.Add(Me.metag2)
        Me.Other_Formats.Location = New System.Drawing.Point(4, 24)
        Me.Other_Formats.Name = "Other_Formats"
        Me.Other_Formats.Padding = New System.Windows.Forms.Padding(3)
        Me.Other_Formats.Size = New System.Drawing.Size(671, 75)
        Me.Other_Formats.TabIndex = 5
        Me.Other_Formats.Text = "Other Formats"
        '
        'extract3
        '
        Me.extract3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.extract3.ForeColor = System.Drawing.Color.Black
        Me.extract3.Location = New System.Drawing.Point(387, 21)
        Me.extract3.Name = "extract3"
        Me.extract3.Size = New System.Drawing.Size(268, 26)
        Me.extract3.TabIndex = 51
        Me.extract3.Text = "Extract Decks"
        Me.extract3.UseVisualStyleBackColor = True
        '
        'howmuch2
        '
        Me.howmuch2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.howmuch2.FormattingEnabled = True
        Me.howmuch2.Items.AddRange(New Object() {"last 8", "last 16", "last 25", "last 50", "all"})
        Me.howmuch2.Location = New System.Drawing.Point(288, 23)
        Me.howmuch2.Name = "howmuch2"
        Me.howmuch2.Size = New System.Drawing.Size(71, 23)
        Me.howmuch2.TabIndex = 50
        '
        'metag2
        '
        Me.metag2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.metag2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.metag2.FormattingEnabled = True
        Me.metag2.Items.AddRange(New Object() {"Budget Standard", "Budget Modern", "Budget Commander", "Duel Commander", "Arena Singleton", "Historic Brawl", "Artisan Historic", "Cascade", "Oathbreaker", "Canadian Highlander", "Old School", "No Banned List Modern", "Frontier", "Tiny Leaders", "Limited", "Block", "Free Form"})
        Me.metag2.Location = New System.Drawing.Point(47, 23)
        Me.metag2.Name = "metag2"
        Me.metag2.Size = New System.Drawing.Size(231, 24)
        Me.metag2.TabIndex = 49
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.TextBox2)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.lbgauntletformat)
        Me.TabPage2.Controls.Add(Me.lbgauntletyear)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(694, 129)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Gauntlets Extractor"
        '
        'TextBox2
        '
        Me.TextBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.TextBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.TextBox2.Location = New System.Drawing.Point(6, 16)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(414, 105)
        Me.TextBox2.TabIndex = 55
        Me.TextBox2.TabStop = False
        Me.TextBox2.Text = resources.GetString("TextBox2.Text")
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(448, 89)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(187, 26)
        Me.Button1.TabIndex = 52
        Me.Button1.Text = "Extract Gauntlets"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lbgauntletformat
        '
        Me.lbgauntletformat.FormattingEnabled = True
        Me.lbgauntletformat.ItemHeight = 15
        Me.lbgauntletformat.Items.AddRange(New Object() {"Standard", "Modern", "Legacy", "Vintage"})
        Me.lbgauntletformat.Location = New System.Drawing.Point(574, 16)
        Me.lbgauntletformat.Name = "lbgauntletformat"
        Me.lbgauntletformat.Size = New System.Drawing.Size(102, 49)
        Me.lbgauntletformat.TabIndex = 3
        '
        'lbgauntletyear
        '
        Me.lbgauntletyear.FormattingEnabled = True
        Me.lbgauntletyear.ItemHeight = 15
        Me.lbgauntletyear.Items.AddRange(New Object() {"2020", "2019", "2018", "2017", "2016", "2015", "2014"})
        Me.lbgauntletyear.Location = New System.Drawing.Point(448, 16)
        Me.lbgauntletyear.Name = "lbgauntletyear"
        Me.lbgauntletyear.Size = New System.Drawing.Size(120, 49)
        Me.lbgauntletyear.TabIndex = 2
        '
        'Timer1
        '
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(540, 447)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(143, 23)
        Me.Button4.TabIndex = 47
        Me.Button4.Text = "Sets"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(556, 410)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(127, 23)
        Me.Button5.TabIndex = 48
        Me.Button5.Text = "Cards"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(394, 284)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(289, 23)
        Me.Button6.TabIndex = 49
        Me.Button6.Text = "poner ediciones"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'cardtofind
        '
        Me.cardtofind.Location = New System.Drawing.Point(48, 455)
        Me.cardtofind.Name = "cardtofind"
        Me.cardtofind.Size = New System.Drawing.Size(100, 21)
        Me.cardtofind.TabIndex = 50
        Me.cardtofind.Visible = False
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(169, 455)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 51
        Me.Button7.Text = "find card"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(394, 323)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(289, 23)
        Me.Button8.TabIndex = 52
        Me.Button8.Text = "quitar ediciones"
        Me.Button8.UseVisualStyleBackColor = True
        Me.Button8.Visible = False
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(394, 369)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(289, 23)
        Me.Button9.TabIndex = 53
        Me.Button9.Text = "comprimir directorios"
        Me.Button9.UseVisualStyleBackColor = True
        Me.Button9.Visible = False
        '
        'ft
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(729, 509)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.cardtofind)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupExtras)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuGeneral)
        Me.Controls.Add(Me.txlog)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuGeneral
        Me.MaximizeBox = False
        Me.Name = "ft"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Forge Tools for Devs"
        Me.MenuGeneral.ResumeLayout(False)
        Me.MenuGeneral.PerformLayout
        CType(Me.PictureBox5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox6,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupExtras.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabControl1.ResumeLayout(false)
        Me.by_metagame.ResumeLayout(false)
        Me.by_metagame.PerformLayout
        Me.By_Tournament.ResumeLayout(false)
        Me.By_Tournament.PerformLayout
        Me.Other_Formats.ResumeLayout(false)
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents txlog As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents FolderBrowserDialog2 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents MenuGeneral As MenuStrip
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RestartForgeLauncherToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ForzeUpdateForgeLauncherToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupExtras As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RestoreForgePreferencesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReadForgeLogFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenDecksFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents by_metagame As TabPage
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents extract1 As Button
    Friend WithEvents chktopnumber As CheckBox
    Friend WithEvents howmuch As ComboBox
    Friend WithEvents metagame As ComboBox
    Friend WithEvents By_Tournament As TabPage
    Friend WithEvents maxtournamentsdecks As ComboBox
    Friend WithEvents fromweb As ComboBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents maxtournm As ComboBox
    Friend WithEvents extract4 As Button
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label5 As Label
    Friend WithEvents Other_Formats As TabPage
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents extract3 As Button
    Friend WithEvents howmuch2 As ComboBox
    Friend WithEvents metag2 As ComboBox
    Friend WithEvents SettingsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Button1 As Button
    Friend WithEvents lbgauntletformat As ListBox
    Friend WithEvents lbgauntletyear As ListBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private WithEvents TextBox2 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents CheckForForgeLauncherUpdatesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents cardtofind As TextBox
    Friend WithEvents Button7 As Button
    Friend WithEvents insertedition As CheckBox
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
End Class
