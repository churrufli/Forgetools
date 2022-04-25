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
        Me.CheckForForgeLauncherUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.mtggoldfishfrom = New System.Windows.Forms.TextBox()
        Me.aetherhubfrom = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupExtras = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.by_metagame = New System.Windows.Forms.TabPage()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.insertedition = New System.Windows.Forms.CheckBox()
        Me.extract1 = New System.Windows.Forms.Button()
        Me.chktopnumber = New System.Windows.Forms.CheckBox()
        Me.howmuch = New System.Windows.Forms.ComboBox()
        Me.metagame = New System.Windows.Forms.ComboBox()
        Me.AetherHub_Top2 = New System.Windows.Forms.TabPage()
        Me.howmuch3 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.puttopaetherhub = New System.Windows.Forms.CheckBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.By_Tournament = New System.Windows.Forms.TabPage()
        Me.maxtournamentsdecks = New System.Windows.Forms.ComboBox()
        Me.fromweb = New System.Windows.Forms.ComboBox()
        Me.maxtournm = New System.Windows.Forms.ComboBox()
        Me.extract4 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.AetherHub_User = New System.Windows.Forms.TabPage()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Other_Formats = New System.Windows.Forms.TabPage()
        Me.extract3 = New System.Windows.Forms.Button()
        Me.howmuch2 = New System.Windows.Forms.ComboBox()
        Me.metag2 = New System.Windows.Forms.ComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cardtofind = New System.Windows.Forms.TextBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.MenuGeneral.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupExtras.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.by_metagame.SuspendLayout()
        Me.AetherHub_Top2.SuspendLayout()
        Me.By_Tournament.SuspendLayout()
        Me.AetherHub_User.SuspendLayout()
        Me.Other_Formats.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txlog
        '
        Me.txlog.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlog.Location = New System.Drawing.Point(11, 181)
        Me.txlog.Multiline = True
        Me.txlog.Name = "txlog"
        Me.txlog.ReadOnly = True
        Me.txlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txlog.Size = New System.Drawing.Size(698, 424)
        Me.txlog.TabIndex = 24
        '
        'MenuGeneral
        '
        Me.MenuGeneral.BackColor = System.Drawing.Color.Silver
        Me.MenuGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.MenuGeneral.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuGeneral.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenDecksFolderToolStripMenuItem, Me.SettingsToolStripMenuItem1, Me.ToolsToolStripMenuItem})
        Me.MenuGeneral.Location = New System.Drawing.Point(0, 0)
        Me.MenuGeneral.Name = "MenuGeneral"
        Me.MenuGeneral.Size = New System.Drawing.Size(721, 24)
        Me.MenuGeneral.TabIndex = 41
        Me.MenuGeneral.Text = "MenuStrip1"
        '
        'OpenDecksFolderToolStripMenuItem
        '
        Me.OpenDecksFolderToolStripMenuItem.Name = "OpenDecksFolderToolStripMenuItem"
        Me.OpenDecksFolderToolStripMenuItem.Size = New System.Drawing.Size(111, 20)
        Me.OpenDecksFolderToolStripMenuItem.Text = "Open Decks Folder"
        '
        'SettingsToolStripMenuItem1
        '
        Me.SettingsToolStripMenuItem1.Name = "SettingsToolStripMenuItem1"
        Me.SettingsToolStripMenuItem1.Size = New System.Drawing.Size(57, 20)
        Me.SettingsToolStripMenuItem1.Text = "Settings"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckForForgeLauncherUpdatesToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.ToolsToolStripMenuItem.Text = "Program Tools"
        '
        'CheckForForgeLauncherUpdatesToolStripMenuItem
        '
        Me.CheckForForgeLauncherUpdatesToolStripMenuItem.Name = "CheckForForgeLauncherUpdatesToolStripMenuItem"
        Me.CheckForForgeLauncherUpdatesToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.CheckForForgeLauncherUpdatesToolStripMenuItem.Text = "Check for Forge Tools Updates"
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
        Me.PictureBox1.Location = New System.Drawing.Point(9, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "Select metagame and number of decks to download. Put #top number (by default) for" &
        " get the number in the top in the deck file.")
        '
        'mtggoldfishfrom
        '
        Me.mtggoldfishfrom.Location = New System.Drawing.Point(169, 25)
        Me.mtggoldfishfrom.Name = "mtggoldfishfrom"
        Me.mtggoldfishfrom.Size = New System.Drawing.Size(20, 18)
        Me.mtggoldfishfrom.TabIndex = 50
        Me.mtggoldfishfrom.Text = "1"
        Me.ToolTip1.SetToolTip(Me.mtggoldfishfrom, "From number")
        '
        'aetherhubfrom
        '
        Me.aetherhubfrom.Location = New System.Drawing.Point(169, 25)
        Me.aetherhubfrom.Name = "aetherhubfrom"
        Me.aetherhubfrom.Size = New System.Drawing.Size(20, 18)
        Me.aetherhubfrom.TabIndex = 51
        Me.aetherhubfrom.Text = "1"
        Me.ToolTip1.SetToolTip(Me.aetherhubfrom, "From number")
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(9, 21)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 24)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 52
        Me.PictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox2, "Select metagame and number of decks to download. Put #top number (by default) for" &
        " get the number in the top in the deck file.")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 455)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 45
        '
        'GroupExtras
        '
        Me.GroupExtras.Controls.Add(Me.TabPage1)
        Me.GroupExtras.Controls.Add(Me.TabPage3)
        Me.GroupExtras.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!)
        Me.GroupExtras.Location = New System.Drawing.Point(11, 37)
        Me.GroupExtras.Name = "GroupExtras"
        Me.GroupExtras.SelectedIndex = 0
        Me.GroupExtras.Size = New System.Drawing.Size(702, 142)
        Me.GroupExtras.TabIndex = 46
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPage1.Controls.Add(Me.TabControl1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(694, 116)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Decks Extractor"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.by_metagame)
        Me.TabControl1.Controls.Add(Me.AetherHub_Top2)
        Me.TabControl1.Controls.Add(Me.By_Tournament)
        Me.TabControl1.Controls.Add(Me.AetherHub_User)
        Me.TabControl1.Controls.Add(Me.Other_Formats)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!)
        Me.TabControl1.Location = New System.Drawing.Point(7, 6)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(679, 103)
        Me.TabControl1.TabIndex = 42
        Me.TabControl1.Tag = ""
        '
        'by_metagame
        '
        Me.by_metagame.BackColor = System.Drawing.Color.WhiteSmoke
        Me.by_metagame.Controls.Add(Me.Button9)
        Me.by_metagame.Controls.Add(Me.mtggoldfishfrom)
        Me.by_metagame.Controls.Add(Me.insertedition)
        Me.by_metagame.Controls.Add(Me.PictureBox1)
        Me.by_metagame.Controls.Add(Me.extract1)
        Me.by_metagame.Controls.Add(Me.chktopnumber)
        Me.by_metagame.Controls.Add(Me.howmuch)
        Me.by_metagame.Controls.Add(Me.metagame)
        Me.by_metagame.Location = New System.Drawing.Point(4, 22)
        Me.by_metagame.Name = "by_metagame"
        Me.by_metagame.Padding = New System.Windows.Forms.Padding(3)
        Me.by_metagame.Size = New System.Drawing.Size(671, 77)
        Me.by_metagame.TabIndex = 2
        Me.by_metagame.Text = "MTGGoldfish Top"
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.Button9.Location = New System.Drawing.Point(447, 53)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(204, 18)
        Me.Button9.TabIndex = 54
        Me.Button9.Text = "Zip Selected Metagame Decks"
        Me.Button9.UseVisualStyleBackColor = True
        Me.Button9.Visible = False
        '
        'insertedition
        '
        Me.insertedition.AutoSize = True
        Me.insertedition.Location = New System.Drawing.Point(354, 25)
        Me.insertedition.Name = "insertedition"
        Me.insertedition.Size = New System.Drawing.Size(97, 17)
        Me.insertedition.TabIndex = 49
        Me.insertedition.Text = "insert |EDITION"
        Me.insertedition.UseVisualStyleBackColor = True
        Me.insertedition.Visible = False
        '
        'extract1
        '
        Me.extract1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.extract1.ForeColor = System.Drawing.Color.Black
        Me.extract1.Location = New System.Drawing.Point(447, 21)
        Me.extract1.Name = "extract1"
        Me.extract1.Size = New System.Drawing.Size(204, 26)
        Me.extract1.TabIndex = 45
        Me.extract1.Text = "Extract Decks"
        Me.extract1.UseVisualStyleBackColor = True
        '
        'chktopnumber
        '
        Me.chktopnumber.AutoSize = True
        Me.chktopnumber.Checked = True
        Me.chktopnumber.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chktopnumber.Location = New System.Drawing.Point(268, 25)
        Me.chktopnumber.Name = "chktopnumber"
        Me.chktopnumber.Size = New System.Drawing.Size(85, 17)
        Me.chktopnumber.TabIndex = 44
        Me.chktopnumber.Text = "#top number"
        Me.chktopnumber.UseVisualStyleBackColor = True
        '
        'howmuch
        '
        Me.howmuch.FormattingEnabled = True
        Me.howmuch.Location = New System.Drawing.Point(195, 23)
        Me.howmuch.Name = "howmuch"
        Me.howmuch.Size = New System.Drawing.Size(65, 21)
        Me.howmuch.TabIndex = 43
        '
        'metagame
        '
        Me.metagame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.metagame.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.metagame.FormattingEnabled = True
        Me.metagame.Items.AddRange(New Object() {"Standard", "Modern", "Pioneer", "Pauper", "Legacy", "Vintage", "Historic", "Alchemy", "Penny Dreadful", "Commander 1v1", "Commander", "Brawl", "Historic Brawl", "Explorer"})
        Me.metagame.Location = New System.Drawing.Point(40, 23)
        Me.metagame.Name = "metagame"
        Me.metagame.Size = New System.Drawing.Size(123, 21)
        Me.metagame.TabIndex = 41
        '
        'AetherHub_Top2
        '
        Me.AetherHub_Top2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.AetherHub_Top2.Controls.Add(Me.PictureBox2)
        Me.AetherHub_Top2.Controls.Add(Me.aetherhubfrom)
        Me.AetherHub_Top2.Controls.Add(Me.howmuch3)
        Me.AetherHub_Top2.Controls.Add(Me.Button1)
        Me.AetherHub_Top2.Controls.Add(Me.puttopaetherhub)
        Me.AetherHub_Top2.Controls.Add(Me.ComboBox1)
        Me.AetherHub_Top2.Location = New System.Drawing.Point(4, 22)
        Me.AetherHub_Top2.Name = "AetherHub_Top2"
        Me.AetherHub_Top2.Padding = New System.Windows.Forms.Padding(3)
        Me.AetherHub_Top2.Size = New System.Drawing.Size(671, 77)
        Me.AetherHub_Top2.TabIndex = 7
        Me.AetherHub_Top2.Text = "AetherHub Top"
        '
        'howmuch3
        '
        Me.howmuch3.FormattingEnabled = True
        Me.howmuch3.Location = New System.Drawing.Point(195, 23)
        Me.howmuch3.Name = "howmuch3"
        Me.howmuch3.Size = New System.Drawing.Size(65, 21)
        Me.howmuch3.TabIndex = 49
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(447, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(204, 26)
        Me.Button1.TabIndex = 48
        Me.Button1.Text = "Extract Decks"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'puttopaetherhub
        '
        Me.puttopaetherhub.AutoSize = True
        Me.puttopaetherhub.Checked = True
        Me.puttopaetherhub.CheckState = System.Windows.Forms.CheckState.Checked
        Me.puttopaetherhub.Location = New System.Drawing.Point(268, 25)
        Me.puttopaetherhub.Name = "puttopaetherhub"
        Me.puttopaetherhub.Size = New System.Drawing.Size(85, 17)
        Me.puttopaetherhub.TabIndex = 47
        Me.puttopaetherhub.Text = "#top number"
        Me.puttopaetherhub.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Standard BO1", "Traditional Standard", "Alchemy BO1", "Traditional Alchemy", "Historic BO1", "Traditional Historic", "Brawl", "Historic Brawl", "Pioneer", "Modern", "Legacy", "Vintage", "Traditional Explorer", "Explorer BO1"})
        Me.ComboBox1.Location = New System.Drawing.Point(40, 23)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(123, 21)
        Me.ComboBox1.TabIndex = 46
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
        Me.By_Tournament.Location = New System.Drawing.Point(4, 22)
        Me.By_Tournament.Name = "By_Tournament"
        Me.By_Tournament.Padding = New System.Windows.Forms.Padding(3)
        Me.By_Tournament.Size = New System.Drawing.Size(671, 77)
        Me.By_Tournament.TabIndex = 1
        Me.By_Tournament.Text = "MTGGoldfish By Tournament"
        '
        'maxtournamentsdecks
        '
        Me.maxtournamentsdecks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.maxtournamentsdecks.FormattingEnabled = True
        Me.maxtournamentsdecks.Items.AddRange(New Object() {"Limit 8", "Limit 12", "Limit 16", "Limit 25", "Limit 50", "Limit 99"})
        Me.maxtournamentsdecks.Location = New System.Drawing.Point(367, 23)
        Me.maxtournamentsdecks.Name = "maxtournamentsdecks"
        Me.maxtournamentsdecks.Size = New System.Drawing.Size(69, 21)
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
        Me.fromweb.Size = New System.Drawing.Size(80, 21)
        Me.fromweb.TabIndex = 58
        '
        'maxtournm
        '
        Me.maxtournm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.maxtournm.FormattingEnabled = True
        Me.maxtournm.Items.AddRange(New Object() {"Last One", "Last 2", "Last 3 ", "Last 4", "Last 5", "Last 6", "Last 7", "Last 8", "Last 9", "Last 10"})
        Me.maxtournm.Location = New System.Drawing.Point(281, 22)
        Me.maxtournm.Name = "maxtournm"
        Me.maxtournm.Size = New System.Drawing.Size(80, 21)
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
        Me.ComboBox2.Size = New System.Drawing.Size(142, 21)
        Me.ComboBox2.TabIndex = 54
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(795, 249)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(0, 13)
        Me.LinkLabel1.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 12
        '
        'AetherHub_User
        '
        Me.AetherHub_User.BackColor = System.Drawing.Color.WhiteSmoke
        Me.AetherHub_User.Controls.Add(Me.Button3)
        Me.AetherHub_User.Controls.Add(Me.TextBox1)
        Me.AetherHub_User.Location = New System.Drawing.Point(4, 22)
        Me.AetherHub_User.Name = "AetherHub_User"
        Me.AetherHub_User.Padding = New System.Windows.Forms.Padding(3)
        Me.AetherHub_User.Size = New System.Drawing.Size(671, 77)
        Me.AetherHub_User.TabIndex = 6
        Me.AetherHub_User.Text = "AetherHub User"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(557, 24)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(94, 23)
        Me.Button3.TabIndex = 55
        Me.Button3.Text = "Extract from URL"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(9, 26)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(542, 18)
        Me.TextBox1.TabIndex = 51
        '
        'Other_Formats
        '
        Me.Other_Formats.BackColor = System.Drawing.Color.Transparent
        Me.Other_Formats.Controls.Add(Me.PictureBox6)
        Me.Other_Formats.Controls.Add(Me.extract3)
        Me.Other_Formats.Controls.Add(Me.howmuch2)
        Me.Other_Formats.Controls.Add(Me.metag2)
        Me.Other_Formats.Location = New System.Drawing.Point(4, 22)
        Me.Other_Formats.Name = "Other_Formats"
        Me.Other_Formats.Padding = New System.Windows.Forms.Padding(3)
        Me.Other_Formats.Size = New System.Drawing.Size(671, 77)
        Me.Other_Formats.TabIndex = 5
        Me.Other_Formats.Text = "MTGGoldfish Users Formats"
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
        Me.howmuch2.FormattingEnabled = True
        Me.howmuch2.Items.AddRange(New Object() {"last 8", "last 16", "last 25", "last 50", "last 99", "all"})
        Me.howmuch2.Location = New System.Drawing.Point(288, 23)
        Me.howmuch2.Name = "howmuch2"
        Me.howmuch2.Size = New System.Drawing.Size(71, 21)
        Me.howmuch2.TabIndex = 50
        '
        'metag2
        '
        Me.metag2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.metag2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.metag2.FormattingEnabled = True
        Me.metag2.Items.AddRange(New Object() {"Standard", "Modern", "Pioneer", "Historic", "Alchemy", "Pauper", "Legacy", "Vintage", "Penny Dreadful", "Commander", "Brawl", "Duel Commander", "Alchemy", "Arena Singleton", "Historic Brawl", "Gladiator", "Artisan Historic", "Cascade", "Oathbreaker", "Canadian Highlander", "Old School", "Premodern", "No Banned List Modern", "Frontier", "Tiny Leaders", "Limited", "Block", "Free Form"})
        Me.metag2.Location = New System.Drawing.Point(47, 23)
        Me.metag2.Name = "metag2"
        Me.metag2.Size = New System.Drawing.Size(231, 21)
        Me.metag2.TabIndex = 49
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(694, 116)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Decks Tools"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(675, 53)
        Me.GroupBox2.TabIndex = 55
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "File Generation"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(187, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(219, 23)
        Me.Button2.TabIndex = 49
        Me.Button2.Text = "Generate Cards File Without Edition"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(20, 20)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(143, 23)
        Me.Button4.TabIndex = 47
        Me.Button4.Text = "Generate Sets File"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(436, 20)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(219, 23)
        Me.Button5.TabIndex = 48
        Me.Button5.Text = "Generate Cards File With Last Edition"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cardtofind)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Location = New System.Drawing.Point(73, 235)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(675, 102)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Decks Tools for Top Formats Selected Metagame"
        Me.GroupBox1.Visible = False
        '
        'cardtofind
        '
        Me.cardtofind.Location = New System.Drawing.Point(13, 18)
        Me.cardtofind.Name = "cardtofind"
        Me.cardtofind.Size = New System.Drawing.Size(338, 18)
        Me.cardtofind.TabIndex = 50
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.Button7.Location = New System.Drawing.Point(357, 17)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(298, 19)
        Me.Button7.TabIndex = 51
        Me.Button7.Text = "Find Card in Selected Metagame Decks"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'ft
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(721, 617)
        Me.Controls.Add(Me.GroupBox1)
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
        Me.Text = "Forge Tools - Deck Extractor for Devs - 16 March"
        Me.MenuGeneral.ResumeLayout(False)
        Me.MenuGeneral.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupExtras.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.by_metagame.ResumeLayout(False)
        Me.by_metagame.PerformLayout()
        Me.AetherHub_Top2.ResumeLayout(False)
        Me.AetherHub_Top2.PerformLayout()
        Me.By_Tournament.ResumeLayout(False)
        Me.By_Tournament.PerformLayout()
        Me.AetherHub_User.ResumeLayout(False)
        Me.AetherHub_User.PerformLayout()
        Me.Other_Formats.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txlog As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents FolderBrowserDialog2 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents MenuGeneral As MenuStrip
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupExtras As TabControl
    Friend WithEvents TabPage1 As TabPage
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
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents CheckForForgeLauncherUpdatesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents insertedition As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TabPage3 As TabPage
    Public WithEvents cardtofind As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents AetherHub_User As TabPage
    Public WithEvents TextBox1 As TextBox
    Friend WithEvents AetherHub_Top2 As TabPage
    Friend WithEvents Button1 As Button
    Friend WithEvents puttopaetherhub As CheckBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents howmuch3 As ComboBox
    Friend WithEvents mtggoldfishfrom As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents aetherhubfrom As TextBox
    Friend WithEvents Button9 As Button
End Class
