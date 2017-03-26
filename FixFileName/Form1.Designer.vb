<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.operate = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.fixname_container = New System.Windows.Forms.GroupBox()
        Me.fixname_fixSEARCH = New System.Windows.Forms.TextBox()
        Me.fixname_fixTO = New System.Windows.Forms.TextBox()
        Me.fixname_lb_let = New System.Windows.Forms.Label()
        Me.fixname_lb_to = New System.Windows.Forms.Label()
        Me.browse_container = New System.Windows.Forms.GroupBox()
        Me.browse_txtbox = New System.Windows.Forms.TextBox()
        Me.browse_includechild = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuTopMost = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_Msg = New System.Windows.Forms.Button()
        Me.lbl_Msg = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fixname_container.SuspendLayout()
        Me.browse_container.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'operate
        '
        Me.operate.Enabled = False
        Me.operate.Location = New System.Drawing.Point(221, 50)
        Me.operate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.operate.Name = "operate"
        Me.operate.Size = New System.Drawing.Size(50, 38)
        Me.operate.TabIndex = 2
        Me.operate.TabStop = False
        Me.operate.Text = "执行"
        Me.operate.UseVisualStyleBackColor = True
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "选择目标文件夹:"
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'fixname_container
        '
        Me.fixname_container.Controls.Add(Me.fixname_fixSEARCH)
        Me.fixname_container.Controls.Add(Me.fixname_fixTO)
        Me.fixname_container.Controls.Add(Me.fixname_lb_let)
        Me.fixname_container.Controls.Add(Me.fixname_lb_to)
        Me.fixname_container.Location = New System.Drawing.Point(2, 43)
        Me.fixname_container.Name = "fixname_container"
        Me.fixname_container.Size = New System.Drawing.Size(216, 45)
        Me.fixname_container.TabIndex = 7
        Me.fixname_container.TabStop = False
        Me.fixname_container.Text = "替换文本"
        '
        'fixname_fixSEARCH
        '
        Me.fixname_fixSEARCH.Location = New System.Drawing.Point(26, 16)
        Me.fixname_fixSEARCH.Name = "fixname_fixSEARCH"
        Me.fixname_fixSEARCH.Size = New System.Drawing.Size(66, 23)
        Me.fixname_fixSEARCH.TabIndex = 0
        Me.fixname_fixSEARCH.Text = "-"
        '
        'fixname_fixTO
        '
        Me.fixname_fixTO.BackColor = System.Drawing.SystemColors.Window
        Me.fixname_fixTO.Location = New System.Drawing.Point(142, 16)
        Me.fixname_fixTO.Name = "fixname_fixTO"
        Me.fixname_fixTO.Size = New System.Drawing.Size(66, 23)
        Me.fixname_fixTO.TabIndex = 1
        Me.fixname_fixTO.Text = " - "
        '
        'fixname_lb_let
        '
        Me.fixname_lb_let.AutoSize = True
        Me.fixname_lb_let.Location = New System.Drawing.Point(6, 19)
        Me.fixname_lb_let.Name = "fixname_lb_let"
        Me.fixname_lb_let.Size = New System.Drawing.Size(20, 17)
        Me.fixname_lb_let.TabIndex = 2
        Me.fixname_lb_let.Text = "将"
        '
        'fixname_lb_to
        '
        Me.fixname_lb_to.AutoSize = True
        Me.fixname_lb_to.Location = New System.Drawing.Point(95, 19)
        Me.fixname_lb_to.Name = "fixname_lb_to"
        Me.fixname_lb_to.Size = New System.Drawing.Size(44, 17)
        Me.fixname_lb_to.TabIndex = 1
        Me.fixname_lb_to.Text = "替换为"
        '
        'browse_container
        '
        Me.browse_container.Controls.Add(Me.browse_txtbox)
        Me.browse_container.Controls.Add(Me.browse_includechild)
        Me.browse_container.Location = New System.Drawing.Point(2, 1)
        Me.browse_container.Name = "browse_container"
        Me.browse_container.Size = New System.Drawing.Size(269, 45)
        Me.browse_container.TabIndex = 6
        Me.browse_container.TabStop = False
        Me.browse_container.Text = "目标文件夹路径 (双击文本框浏览，支持拖拽)"
        '
        'browse_txtbox
        '
        Me.browse_txtbox.BackColor = System.Drawing.SystemColors.Window
        Me.browse_txtbox.Location = New System.Drawing.Point(6, 16)
        Me.browse_txtbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.browse_txtbox.Name = "browse_txtbox"
        Me.browse_txtbox.Size = New System.Drawing.Size(171, 23)
        Me.browse_txtbox.TabIndex = 4
        Me.browse_txtbox.TabStop = False
        '
        'browse_includechild
        '
        Me.browse_includechild.AutoSize = True
        Me.browse_includechild.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.browse_includechild.Location = New System.Drawing.Point(181, 18)
        Me.browse_includechild.Name = "browse_includechild"
        Me.browse_includechild.Size = New System.Drawing.Size(87, 21)
        Me.browse_includechild.TabIndex = 5
        Me.browse_includechild.TabStop = False
        Me.browse_includechild.Text = "含子文件夹"
        Me.browse_includechild.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuTopMost, Me.menuAbout, Me.menuLog})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 70)
        '
        'menuTopMost
        '
        Me.menuTopMost.Name = "menuTopMost"
        Me.menuTopMost.ShortcutKeyDisplayString = ""
        Me.menuTopMost.Size = New System.Drawing.Size(152, 22)
        Me.menuTopMost.Text = "窗口置顶 (&T)"
        '
        'menuAbout
        '
        Me.menuAbout.Name = "menuAbout"
        Me.menuAbout.Size = New System.Drawing.Size(152, 22)
        Me.menuAbout.Text = "关于 (&A)"
        '
        'menuLog
        '
        Me.menuLog.Name = "menuLog"
        Me.menuLog.Size = New System.Drawing.Size(152, 22)
        Me.menuLog.Text = "记录到.log (&L)"
        '
        'btn_Msg
        '
        Me.btn_Msg.Font = New System.Drawing.Font("微软雅黑", 8.5!)
        Me.btn_Msg.Location = New System.Drawing.Point(184, 60)
        Me.btn_Msg.Name = "btn_Msg"
        Me.btn_Msg.Size = New System.Drawing.Size(77, 23)
        Me.btn_Msg.TabIndex = 3
        Me.btn_Msg.Text = "确定"
        Me.btn_Msg.UseVisualStyleBackColor = True
        Me.btn_Msg.Visible = False
        '
        'lbl_Msg
        '
        Me.lbl_Msg.Image = CType(resources.GetObject("lbl_Msg.Image"), System.Drawing.Image)
        Me.lbl_Msg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_Msg.Location = New System.Drawing.Point(0, 0)
        Me.lbl_Msg.Name = "lbl_Msg"
        Me.lbl_Msg.Size = New System.Drawing.Size(28, 22)
        Me.lbl_Msg.TabIndex = 6
        Me.lbl_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_Msg.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(180, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "右键窗体显示菜单"
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(273, 90)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.btn_Msg)
        Me.Controls.Add(Me.lbl_Msg)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.browse_container)
        Me.Controls.Add(Me.operate)
        Me.Controls.Add(Me.fixname_container)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "批量修改文件名  "
        Me.fixname_container.ResumeLayout(False)
        Me.fixname_container.PerformLayout()
        Me.browse_container.ResumeLayout(False)
        Me.browse_container.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Private WithEvents fixname_container As System.Windows.Forms.GroupBox
    Private WithEvents fixname_lb_let As System.Windows.Forms.Label
    Private WithEvents fixname_lb_to As System.Windows.Forms.Label
    Private WithEvents browse_container As System.Windows.Forms.GroupBox
    Friend WithEvents operate As System.Windows.Forms.Button
    Friend WithEvents fixname_fixTO As System.Windows.Forms.TextBox
    Friend WithEvents fixname_fixSEARCH As System.Windows.Forms.TextBox
    Friend WithEvents browse_txtbox As System.Windows.Forms.TextBox
    Friend WithEvents browse_includechild As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuTopMost As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbl_Msg As System.Windows.Forms.Label
    Friend WithEvents btn_Msg As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents menuLog As System.Windows.Forms.ToolStripMenuItem

End Class
