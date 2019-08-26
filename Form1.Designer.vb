<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SelectFileBtn = New System.Windows.Forms.Button()
        Me.FilePathTxtBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LocationChckBox = New System.Windows.Forms.CheckBox()
        Me.TopologyChckBox = New System.Windows.Forms.CheckBox()
        Me.MolProcChckBox = New System.Windows.Forms.CheckBox()
        Me.StartBtn = New System.Windows.Forms.Button()
        Me.StopBtn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LogTxtBox = New System.Windows.Forms.TextBox()
        Me.version_lbl = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ErrorLogTxtBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SelectFileBtn
        '
        Me.SelectFileBtn.Location = New System.Drawing.Point(114, 84)
        Me.SelectFileBtn.Name = "SelectFileBtn"
        Me.SelectFileBtn.Size = New System.Drawing.Size(127, 30)
        Me.SelectFileBtn.TabIndex = 0
        Me.SelectFileBtn.Text = "Select File"
        Me.SelectFileBtn.UseVisualStyleBackColor = True
        '
        'FilePathTxtBox
        '
        Me.FilePathTxtBox.Location = New System.Drawing.Point(7, 58)
        Me.FilePathTxtBox.Name = "FilePathTxtBox"
        Me.FilePathTxtBox.Size = New System.Drawing.Size(334, 20)
        Me.FilePathTxtBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(111, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select a list of UniProt IDs"
        '
        'LocationChckBox
        '
        Me.LocationChckBox.AutoSize = True
        Me.LocationChckBox.Checked = True
        Me.LocationChckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LocationChckBox.Location = New System.Drawing.Point(7, 142)
        Me.LocationChckBox.Name = "LocationChckBox"
        Me.LocationChckBox.Size = New System.Drawing.Size(67, 17)
        Me.LocationChckBox.TabIndex = 3
        Me.LocationChckBox.Text = "Location"
        Me.LocationChckBox.UseVisualStyleBackColor = True
        '
        'TopologyChckBox
        '
        Me.TopologyChckBox.AutoSize = True
        Me.TopologyChckBox.Checked = True
        Me.TopologyChckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TopologyChckBox.Location = New System.Drawing.Point(7, 168)
        Me.TopologyChckBox.Name = "TopologyChckBox"
        Me.TopologyChckBox.Size = New System.Drawing.Size(70, 17)
        Me.TopologyChckBox.TabIndex = 4
        Me.TopologyChckBox.Text = "Topology"
        Me.TopologyChckBox.UseVisualStyleBackColor = True
        '
        'MolProcChckBox
        '
        Me.MolProcChckBox.AutoSize = True
        Me.MolProcChckBox.Checked = True
        Me.MolProcChckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MolProcChckBox.Location = New System.Drawing.Point(7, 191)
        Me.MolProcChckBox.Name = "MolProcChckBox"
        Me.MolProcChckBox.Size = New System.Drawing.Size(124, 17)
        Me.MolProcChckBox.TabIndex = 5
        Me.MolProcChckBox.Text = "Molecule Processing"
        Me.MolProcChckBox.UseVisualStyleBackColor = True
        '
        'StartBtn
        '
        Me.StartBtn.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.StartBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.StartBtn.Location = New System.Drawing.Point(63, 296)
        Me.StartBtn.Name = "StartBtn"
        Me.StartBtn.Size = New System.Drawing.Size(210, 23)
        Me.StartBtn.TabIndex = 6
        Me.StartBtn.Text = "Start"
        Me.StartBtn.UseVisualStyleBackColor = False
        '
        'StopBtn
        '
        Me.StopBtn.BackColor = System.Drawing.Color.SeaShell
        Me.StopBtn.Location = New System.Drawing.Point(63, 325)
        Me.StopBtn.Name = "StopBtn"
        Me.StopBtn.Size = New System.Drawing.Size(210, 23)
        Me.StopBtn.TabIndex = 7
        Me.StopBtn.Text = "Stop"
        Me.StopBtn.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.StartBtn)
        Me.GroupBox1.Controls.Add(Me.StopBtn)
        Me.GroupBox1.Controls.Add(Me.SelectFileBtn)
        Me.GroupBox1.Controls.Add(Me.FilePathTxtBox)
        Me.GroupBox1.Controls.Add(Me.MolProcChckBox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TopologyChckBox)
        Me.GroupBox1.Controls.Add(Me.LocationChckBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(364, 365)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Application parameters"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LogTxtBox)
        Me.GroupBox2.Location = New System.Drawing.Point(382, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(459, 218)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Application logs"
        '
        'LogTxtBox
        '
        Me.LogTxtBox.Location = New System.Drawing.Point(6, 19)
        Me.LogTxtBox.Multiline = True
        Me.LogTxtBox.Name = "LogTxtBox"
        Me.LogTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.LogTxtBox.Size = New System.Drawing.Size(447, 189)
        Me.LogTxtBox.TabIndex = 0
        '
        'version_lbl
        '
        Me.version_lbl.AutoSize = True
        Me.version_lbl.Location = New System.Drawing.Point(746, 413)
        Me.version_lbl.Name = "version_lbl"
        Me.version_lbl.Size = New System.Drawing.Size(104, 13)
        Me.version_lbl.TabIndex = 10
        Me.version_lbl.Text = "version 1.02.190619"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ErrorLogTxtBox)
        Me.GroupBox3.Location = New System.Drawing.Point(382, 257)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(459, 141)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Error logs"
        '
        'ErrorLogTxtBox
        '
        Me.ErrorLogTxtBox.ForeColor = System.Drawing.Color.Firebrick
        Me.ErrorLogTxtBox.Location = New System.Drawing.Point(6, 19)
        Me.ErrorLogTxtBox.Multiline = True
        Me.ErrorLogTxtBox.Name = "ErrorLogTxtBox"
        Me.ErrorLogTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ErrorLogTxtBox.Size = New System.Drawing.Size(447, 116)
        Me.ErrorLogTxtBox.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 435)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.version_lbl)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UniProt annotation downloader"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SelectFileBtn As Button
    Friend WithEvents FilePathTxtBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LocationChckBox As CheckBox
    Friend WithEvents TopologyChckBox As CheckBox
    Friend WithEvents MolProcChckBox As CheckBox
    Friend WithEvents StartBtn As Button
    Friend WithEvents StopBtn As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LogTxtBox As TextBox
    Friend WithEvents version_lbl As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ErrorLogTxtBox As TextBox
End Class
