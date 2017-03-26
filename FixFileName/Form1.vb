Imports System.IO

Public Class Form1
    Private Declare Function SetProcessWorkingSetSize Lib "kernel32" (ByVal hProcess As Integer, ByVal dwMinimumWorkingSetSize As Integer, ByVal dwMaximumWorkingSetSize As Integer) As Integer
    Private Declare Function GetCurrentProcess Lib "kernel32" () As Integer

    Private Sub ShowMessageInfoAndLOG(ByVal info As String, Optional ByVal StrWriteToLog As String = "", Optional ByVal OmitInfo As Boolean = False, Optional ByVal CountTimesAndError As Integer = 0)
        If OmitInfo = False Then
            Label1.Visible = False
            browse_container.Enabled = False
            fixname_container.Enabled = False
            operate.Enabled = False
            btn_Msg.Visible = True
            lbl_Msg.Visible = True
            btn_Msg.Focus()
            lbl_Msg.Text = info & vbCrLf
        End If
        If StrWriteToLog <> "" Then
            If menuLog.Checked = True Then
                If CountTimesAndError > 0 Then
                    Dim tmpMyEXEName As String = Path.GetFileName(Application.ExecutablePath)
                    tmpMyEXEName = tmpMyEXEName.Remove(tmpMyEXEName.Length - 4) & ".log"

                    'If File.Exists(tmpMyEXEName) Then
                    '    Dim FFNlog_b4 As IO.StreamReader = New IO.StreamReader(tmpMyEXEName, System.Text.Encoding.Default)
                    '    '获取log之前所有记录 , 可用于?? 倒叙(时间)写入log?
                    '    MsgBox(FFNlog_b4.ReadToEnd())
                    'End If

                    Dim FFNlog As IO.StreamWriter = New IO.StreamWriter(tmpMyEXEName, True, System.Text.Encoding.Default)
                    FFNlog.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ") & StrWriteToLog)
                    FFNlog.Close()
                End If
            End If
        End If
    End Sub
    Private Sub btn_Msg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Msg.Click
        browse_container.Enabled = True
        fixname_container.Enabled = True
        browse_txtbox_TextChanged(Nothing, Nothing)
        btn_Msg.Visible = False
        lbl_Msg.Visible = False
    End Sub

    Private Sub operate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles operate.Click
        If Directory.Exists(browse_txtbox.Text) = False Then
            ShowMessageInfoAndLOG("没有找到文件夹，请重试。    ", "Target Folder not found: <" & browse_txtbox.Text & ">" & If(browse_includechild.Checked = True, "(Include SUB folder)", ""))
            Exit Sub
        End If

        SearchFiles(browse_txtbox.Text, browse_includechild.Checked)
        Dim oVar As Object = FileList
        If oVar Is Nothing Then
            ShowMessageInfoAndLOG("没有在该路径下找到任何文件。    ", "No files in target folder: <" & browse_txtbox.Text & ">" & If(browse_includechild.Checked = True, "(Include SUB folder)", ""))
        Else
            Dim i As Integer, errfire As Integer
            For Each FilePathFull As String In FileList

                If fixname_fixSEARCH.Text.Contains(fixname_fixTO.Text) Then
                    Dim FileName As String = FilePathFull.Remove(0, FilePathFull.LastIndexOf("\") + 1)
                    If FileName.Contains(fixname_fixSEARCH.Text) Then
                        Dim FileDirectory As String = FilePathFull.Remove(FilePathFull.LastIndexOf("\") + 1)
                        Try
                            Rename(FilePathFull, FileDirectory & FileName.Replace(fixname_fixSEARCH.Text, fixname_fixTO.Text))
                            i += 1
                        Catch ex As Exception
                            errfire += 1
                            ShowMessageInfoAndLOG("", "ERR:" & ex.ToString & "Target<" & FilePathFull & ">" & _
                                     "Searched<" & fixname_fixSEARCH.Text & "> | Replaced<" & fixname_fixTO.Text & ">" & If(browse_includechild.Checked = True, "(Include SUB folder)", ""), True)

                            If MsgBox(ex.ToString & vbCrLf & "AimPath: <" & FilePathFull & ">" & vbCrLf & _
                                     "Searched(String): <" & fixname_fixSEARCH.Text & "> | ReplaceWith(String): <" & fixname_fixTO.Text & ">" & vbCrLf & vbCrLf & _
                                     "Press 'Yes' to Ignore the error, 'No' to Abort the process.", _
                                      MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "ERROR MSG") = MsgBoxResult.No Then
                                Exit For
                            End If
                        End Try
                    End If
                Else
                    '如果 将要替换的字符串[fixTO] 中[包含] 要寻找的字符串[fixSEARCH]    例如 将"1"[fixSEARCH]替换为"12"[fixTO]
                    Dim FileName As String = FilePathFull.Remove(0, FilePathFull.LastIndexOf("\") + 1)
                    If FileName.Contains(fixname_fixTO.Text) Then
                        '并且文件名中已经有[fixTO]字符串 那么跳过
                    ElseIf FileName.Contains(fixname_fixSEARCH.Text) Then
                        Dim FileDirectory As String = FilePathFull.Remove(FilePathFull.LastIndexOf("\") + 1)
                        Try
                            Rename(FilePathFull, FileDirectory & FileName.Replace(fixname_fixSEARCH.Text, fixname_fixTO.Text))
                            i += 1
                        Catch ex As Exception
                            errfire += 1
                            ShowMessageInfoAndLOG("", "ERR:" & ex.ToString & "Target<" & FilePathFull & ">" & _
                                      "Searched<" & fixname_fixSEARCH.Text & "> | Replaced<" & fixname_fixTO.Text & ">" & If(browse_includechild.Checked = True, "(Include SUB folder)", ""), True)

                            If MsgBox(ex.ToString & vbCrLf & "AimPath: <" & FilePathFull & ">" & vbCrLf & _
                                     "Searched(String): <" & fixname_fixSEARCH.Text & "> | ReplaceWith(String): <" & fixname_fixTO.Text & ">" & vbCrLf & vbCrLf & _
                                     "Press 'Yes' to Ignore the error, 'No' to Abort the process.", _
                                      MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "ERROR MSG") = MsgBoxResult.No Then
                                Exit For
                            End If
                        End Try
                    End If
                End If
            Next
            ShowMessageInfoAndLOG("成功执行 " & i & " 次操作" & If(errfire > 0, "，遇到 " & errfire & " 次错误。", "。    "), _
                                   If(errfire > 0, "Error(" & errfire & "), ", "") & "Success(" & i & "). """ & browse_txtbox.Text & """" & If(browse_includechild.Checked = True, "(Include SUB folder)", "") & Chr(9) & "<" & fixname_fixSEARCH.Text & "> to <" & fixname_fixTO.Text & ">", _
                                  False, _
                                  errfire + i)
        End If
    End Sub


#Region "    枚举目标(子)文件夹中所有内容    "
    Dim FileList() As String
    Dim tmp_times As Integer
    ''' <summary>
    ''' 枚举目标(子)文件夹中所有文件的完整路径并赋值到 FileList()
    ''' </summary>
    ''' <param name="strDirectory">目标路径</param>
    ''' <param name="SearchChild">是否搜索子目录</param>
    ''' <remarks></remarks>
    Private Sub SearchFiles(ByVal strDirectory As String, ByVal SearchChild As Boolean)
        Erase FileList
        tmp_times = 0
        If SearchChild Then
            SearchFilesWith_Child(strDirectory)
        Else
            SearchFilesWith_OUT_Child(strDirectory)
        End If
    End Sub
    Private Sub SearchFilesWith_OUT_Child(ByVal strDirectory As String)
        Dim d As New DirectoryInfo(strDirectory) '这里是你的文件夹路径
        Dim f As FileInfo
        For Each f In d.GetFiles
            If f.FullName.ToLower <> Application.ExecutablePath.ToLower Then
                ReDim Preserve FileList(tmp_times)
                FileList(tmp_times) = f.FullName
                tmp_times += 1
            End If
        Next
    End Sub
    Private Sub SearchFilesWith_Child(ByVal strDirectory As String)
        Dim mFileInfo As FileInfo
        Dim mDir As DirectoryInfo
        Dim mDirInfo As New DirectoryInfo(strDirectory)
        For Each mFileInfo In mDirInfo.GetFiles()
            If mFileInfo.FullName.ToLower <> Application.ExecutablePath.ToLower Then
                ReDim Preserve FileList(tmp_times)
                FileList(tmp_times) = mFileInfo.FullName
                tmp_times += 1
            End If
        Next
        For Each mDir In mDirInfo.GetDirectories
            SearchFilesWith_Child(mDir.FullName)
        Next
    End Sub
#End Region

    Private Sub browse_txtbox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles browse_txtbox.DoubleClick, browse_container.DoubleClick
        FolderBrowserDialog1.SelectedPath = browse_txtbox.Text
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            browse_txtbox.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub browse_txtbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browse_txtbox.TextChanged
        If browse_txtbox.Text.Length > 4 Then
            If browse_txtbox.Text.StartsWith("""") And browse_txtbox.Text.EndsWith("""") Then
                browse_txtbox.Text = browse_txtbox.Text.Substring(1, browse_txtbox.Text.Length - 2)
                browse_txtbox.SelectionStart = browse_txtbox.Text.Length
            End If
        End If
        If Directory.Exists(browse_txtbox.Text) Then
            browse_txtbox.BackColor = Color.FromArgb(192, 255, 192)
            ToolTip1.Hide(browse_txtbox)
        Else
            browse_txtbox.BackColor = Color.FromArgb(255, 192, 192)
            If IsNothing(e) = False Then
                ToolTip1.ToolTipIcon = ToolTipIcon.Error
                ToolTip1.Show("当前路径无效  ", browse_txtbox, 0, browse_txtbox.Height)
            End If
        End If
        If Found_CantContain = False And Directory.Exists(browse_txtbox.Text) = True And fixname_fixSEARCH.Text <> "" Then
            operate.Enabled = True
        Else
            operate.Enabled = False
        End If
        SetProcessWorkingSetSize(GetCurrentProcess, -1, -1)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text &= Application.ProductVersion
        lbl_Msg.Size = New Size(272, 90)
        browse_txtbox.Text = Application.StartupPath
        Dim tmpMyEXEName As String = Path.GetFileName(Application.ExecutablePath)
        tmpMyEXEName = tmpMyEXEName.Remove(tmpMyEXEName.Length - 4)
        If File.Exists(tmpMyEXEName & ".log") Then
            menuLog.Checked = True
        End If
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        menuTopMost_Click(sender, Nothing)
    End Sub

#Region "    文本框首次获得焦点时，全选以及tooltip    "
    Dim txtGotFocus As Boolean
    Private Sub browse_txtbox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles browse_txtbox.Click
        If txtGotFocus = False Then
            browse_txtbox.SelectAll()
            txtGotFocus = True
        End If
    End Sub
    Private Sub browse_txtbox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles browse_txtbox.Leave
        txtGotFocus = False
    End Sub

    Private Sub fixname_fixSEARCH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles fixname_fixSEARCH.Click
        If txtGotFocus = False Then
            fixname_fixSEARCH.SelectAll()
            txtGotFocus = True
        End If
    End Sub
    Private Sub fixname_fixSEARCH_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles fixname_fixSEARCH.Enter
        fixname_fixSEARCH.SelectAll()
        ToolTip1.ToolTipIcon = ToolTipIcon.Info
        ToolTip1.Show("在这里输入需要搜索(被替换的)的字符串", fixname_fixSEARCH, 0, fixname_fixSEARCH.Height)
        operate.TabStop = True
    End Sub

    Private Sub fixname_fixSEARCH_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles fixname_fixSEARCH.Leave
        ToolTip1.Hide(fixname_fixSEARCH)
        txtGotFocus = False
    End Sub

    Private Sub fixname_fixTO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles fixname_fixTO.Click
        If txtGotFocus = False Then
            fixname_fixTO.SelectAll()
            txtGotFocus = True
        End If
    End Sub
    Private Sub fixname_fixTO_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles fixname_fixTO.Enter
        fixname_fixTO.SelectAll()
        ToolTip1.ToolTipIcon = ToolTipIcon.Info
        ToolTip1.Show("在这里输入需要替换为的字符串", fixname_fixTO, 0, fixname_fixTO.Height)
        fixname_fixTO_TextChanged(sender, Nothing)
    End Sub
    Private Sub fixname_fixTO_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles fixname_fixTO.Leave
        ToolTip1.Hide(fixname_fixTO)
        txtGotFocus = False
    End Sub    'tooltip的消失事件也在这里
#End Region

#Region "    拖拽，获取路径    "
    Private Sub Form1_FileDrag_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Link
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub Form1_FileDrag_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim DropItem As String() = DirectCast(e.Data.GetData(DataFormats.FileDrop), String())
        For Each Path As String In DropItem
            If Directory.Exists(Path) Then
                browse_txtbox.Text = Path
            ElseIf File.Exists(Path) Then
                Dim FileDirectory As String = Path.Remove(Path.LastIndexOf("\"))
                browse_txtbox.Text = FileDirectory
            End If
        Next
    End Sub
#End Region

#Region "    提示替换文本中包含非法字符    "
    Dim Found_CantContain As Boolean
    Private Sub fixname_fixTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fixname_fixTO.TextChanged
        Dim CantContain As String() = Split("\ / : * ? "" < > |")
        Found_CantContain = False
        For i = 0 To UBound(CantContain)
            If fixname_fixTO.Text.Contains(CantContain(i)) Then
                ToolTip1.ToolTipIcon = ToolTipIcon.Error
                ToolTip1.Show("文件名不能包含下列任何字符:  " & vbCrLf & "         \ / : * ? "" < > |", fixname_fixTO, 0, fixname_fixTO.Height)
                fixname_fixTO.BackColor = Color.FromArgb(255, 192, 192)
                operate.Enabled = False
                Found_CantContain = True
                Exit Sub
            Else
                fixname_fixTO.BackColor = SystemColors.Window
            End If
        Next
        If Found_CantContain = False Then
            ToolTip1.ToolTipIcon = ToolTipIcon.Info
            ToolTip1.Show("在这里输入需要替换为的字符串  ", fixname_fixTO, 0, fixname_fixTO.Height)
            browse_txtbox_TextChanged(sender, Nothing)
        End If
    End Sub
    Private Sub fixname_fixSEARCH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fixname_fixSEARCH.TextChanged, fixname_fixSEARCH.GotFocus
        If fixname_fixSEARCH.Text = "" Then
            operate.Enabled = False
            ToolTip1.ToolTipIcon = ToolTipIcon.Error
            ToolTip1.Show("被搜索的字符不能为空  ", fixname_fixSEARCH, 0, fixname_fixSEARCH.Height)
            fixname_fixSEARCH.BackColor = Color.FromArgb(255, 192, 192)
        Else
            fixname_fixSEARCH.BackColor = SystemColors.Window
            ToolTip1.ToolTipIcon = ToolTipIcon.Info
            ToolTip1.Show("在这里输入需要搜索(被替换的)的字符串  ", fixname_fixSEARCH, 0, fixname_fixSEARCH.Height)
        End If
    End Sub
#End Region

#Region "    右键菜单    "
    Private Sub menuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuAbout.Click
        ToolTip1.ToolTipIcon = ToolTipIcon.Info
        ToolTip1.Show("本程序由Jero设计编写，可自由免费发布。　　　" & vbCrLf & vbCrLf & "联系方式: weiguanqwe@gmail.com" & vbCrLf & " ", browse_container, -3, -3, 3333)
    End Sub
    Private Sub Form1_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        ToolTip1.Hide(Me)
    End Sub

    Private Sub menuTopMost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuTopMost.Click
        menuTopMost.Checked = Not menuTopMost.Checked
        Me.TopMost = menuTopMost.Checked
    End Sub
    Private Sub menuLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuLog.Click
        menuLog.Checked = Not menuLog.Checked
    End Sub
#End Region

    Private Sub Label1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        Label1.Visible = False
    End Sub

End Class
