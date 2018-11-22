<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Main))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbTo = New System.Windows.Forms.ComboBox()
        Me.CmbFrom = New System.Windows.Forms.ComboBox()
        Me.TxtBoxInputPath = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnBrowse = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.MsgLog = New System.Windows.Forms.RichTextBox()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.BW_Main = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CmbTo)
        Me.GroupBox1.Controls.Add(Me.CmbFrom)
        Me.GroupBox1.Controls.Add(Me.TxtBoxInputPath)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BtnBrowse)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(730, 97)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Folder"
        '
        'CmbTo
        '
        Me.CmbTo.FormattingEnabled = True
        Me.CmbTo.Items.AddRange(New Object() {"[SELECT]", "English", "Chinese", "Spanish", "Portugese", "Japanese", "French", "German"})
        Me.CmbTo.Location = New System.Drawing.Point(262, 21)
        Me.CmbTo.Name = "CmbTo"
        Me.CmbTo.Size = New System.Drawing.Size(121, 21)
        Me.CmbTo.TabIndex = 3
        '
        'CmbFrom
        '
        Me.CmbFrom.FormattingEnabled = True
        Me.CmbFrom.Items.AddRange(New Object() {"[SELECT]", "English", "Chinese", "Spanish", "Portugese", "Japanese", "French", "German"})
        Me.CmbFrom.Location = New System.Drawing.Point(79, 21)
        Me.CmbFrom.Name = "CmbFrom"
        Me.CmbFrom.Size = New System.Drawing.Size(121, 21)
        Me.CmbFrom.TabIndex = 3
        '
        'TxtBoxInputPath
        '
        Me.TxtBoxInputPath.Location = New System.Drawing.Point(79, 60)
        Me.TxtBoxInputPath.Name = "TxtBoxInputPath"
        Me.TxtBoxInputPath.Size = New System.Drawing.Size(551, 20)
        Me.TxtBoxInputPath.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(217, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "From"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Input Folder"
        '
        'BtnBrowse
        '
        Me.BtnBrowse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBrowse.Location = New System.Drawing.Point(638, 58)
        Me.BtnBrowse.Name = "BtnBrowse"
        Me.BtnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.BtnBrowse.TabIndex = 0
        Me.BtnBrowse.Text = "Browse"
        Me.BtnBrowse.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.MsgLog)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 121)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(730, 276)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Message Log"
        '
        'MsgLog
        '
        Me.MsgLog.BackColor = System.Drawing.SystemColors.Menu
        Me.MsgLog.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.MsgLog.Location = New System.Drawing.Point(15, 19)
        Me.MsgLog.Name = "MsgLog"
        Me.MsgLog.ReadOnly = True
        Me.MsgLog.Size = New System.Drawing.Size(698, 250)
        Me.MsgLog.TabIndex = 0
        Me.MsgLog.Text = ""
        '
        'BtnStart
        '
        Me.BtnStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStart.Enabled = False
        Me.BtnStart.Location = New System.Drawing.Point(555, 403)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(75, 23)
        Me.BtnStart.TabIndex = 0
        Me.BtnStart.Text = "Start"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'BtnStop
        '
        Me.BtnStop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStop.Enabled = False
        Me.BtnStop.Location = New System.Drawing.Point(650, 403)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(75, 23)
        Me.BtnStop.TabIndex = 0
        Me.BtnStop.Text = "Stop"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'BW_Main
        '
        Me.BW_Main.WorkerReportsProgress = True
        Me.BW_Main.WorkerSupportsCancellation = True
        '
        'Form_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 437)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnStart)
        Me.Controls.Add(Me.BtnStop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_Main"
        Me.Text = "Auto Systran"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbTo As System.Windows.Forms.ComboBox
    Friend WithEvents CmbFrom As System.Windows.Forms.ComboBox
    Friend WithEvents TxtBoxInputPath As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnBrowse As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents MsgLog As System.Windows.Forms.RichTextBox
    Friend WithEvents BtnStart As System.Windows.Forms.Button
    Friend WithEvents BtnStop As System.Windows.Forms.Button
    Friend WithEvents BW_Main As System.ComponentModel.BackgroundWorker

End Class
