VERSION 5.00
Begin VB.Form Form_main 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "剪切板管理工具 1.0"
   ClientHeight    =   6765
   ClientLeft      =   45
   ClientTop       =   390
   ClientWidth     =   11490
   BeginProperty Font 
      Name            =   "微软雅黑"
      Size            =   9
      Charset         =   134
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "Form_main.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   451
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   766
   StartUpPosition =   2  '屏幕中心
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   495
      Left            =   3120
      TabIndex        =   6
      Top             =   6120
      Visible         =   0   'False
      Width           =   855
   End
   Begin VB.TextBox Text1 
      Height          =   5055
      Left            =   240
      Locked          =   -1  'True
      MultiLine       =   -1  'True
      ScrollBars      =   3  'Both
      TabIndex        =   5
      Text            =   "Form_main.frx":08CA
      Top             =   720
      Width           =   10815
   End
   Begin VB.CommandButton Command_setting 
      Caption         =   "设置"
      Height          =   495
      Left            =   240
      TabIndex        =   4
      Top             =   6000
      Width           =   1575
   End
   Begin VB.CommandButton Command_clear 
      Caption         =   "清空剪切板"
      Height          =   495
      Left            =   6120
      TabIndex        =   3
      Top             =   6000
      Width           =   1575
   End
   Begin VB.CommandButton Command_refash 
      Caption         =   "刷新"
      Height          =   495
      Left            =   7800
      TabIndex        =   2
      Top             =   6000
      Width           =   1575
   End
   Begin VB.CommandButton Command_save 
      Caption         =   "保存为文件"
      Height          =   495
      Left            =   9480
      TabIndex        =   0
      Top             =   6000
      Width           =   1575
   End
   Begin VB.Image Image1 
      Height          =   5055
      Left            =   240
      Stretch         =   -1  'True
      Top             =   720
      Width           =   10815
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      Caption         =   "您当前剪切板的内容："
      BeginProperty Font 
         Name            =   "微软雅黑"
         Size            =   14.25
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FF9400&
      Height          =   375
      Left            =   240
      TabIndex        =   1
      Top             =   240
      Width           =   3690
   End
End
Attribute VB_Name = "Form_main"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim startarg() As String
Dim after_showsetting As Boolean
Private Sub savefile()
Dim tim
tim = Format(Now, "yyyymmddhhmmss")

End Sub

Private Sub Command_clear_Click()
Dim chose
chose = MsgBox("您是否要清空剪切板吗？", vbYesNo + vbQuestion, "是否清空？")
If chose = 6 Then
Clipboard.Clear
Module1.GetClipboardData
End If
End Sub

Private Sub Command_refash_Click()
Module1.GetClipboardData
End Sub

Private Sub Command_save_Click()
Module1.GetClipboardData
Module1.SaveDataAsFile
End Sub

Private Sub Command_setting_Click()
Form_setting.Left = (Me.Width - Form_setting.Width) / 2 + Me.Left
Form_setting.Top = (Me.Height - Form_setting.Height) / 2 + Me.Top
                Form_setting.Show
                Form_setting.SetFocus
End Sub

Private Sub Form_Activate()
If after_showsetting = True Then
                Form_setting.Left = (Me.Width - Form_setting.Width) / 2 + Me.Left
                Form_setting.Top = (Me.Height - Form_setting.Height) / 2 + Me.Top
                Form_setting.Show
                Form_setting.SetFocus
                after_showsetting = False
Else

End If
End Sub

Private Sub Form_Load()
'检查命令行
Module1.GetClipboardData
checkarg

End Sub
Public Sub checkarg()
Dim fullarg As String
fullarg = Command$
If fullarg = "" Then
   '没有命令行
   Module1.GetClipboardData
Else
   '有命令行
   Dim Argc As Long, Argv() As String
   Dim i As Integer, szCmd As String
   Call CommandArg.SplitCmd(Argc, Argv())
   'MsgBox "有命令行"
   '数组的个数
   Dim argcount As Integer
   argcount = UBound(Argv)
   startarg = Argv
   '根据arg1来判断
   Dim firstarg As String
   firstarg = Argv(1)
   firstarg = UCase(firstarg)
   firstarg = Replace(firstarg, "/", "")
   firstarg = Replace(firstarg, "-", "")
   firstarg = Replace(firstarg, "\", "")
   If argcount >= 1 & rgcount <= 2 Then
       '检查个数
       If argcount = 1 Then
            Select Case firstarg
                   Case "SE"
                      SetProgram "SE"
                   Case "RE"
                   SetProgram "RE"
                   End
                   Case "UR"
                   SetProgram "UR"
                   End
                   Case "HE"
            End Select
        Else
            If argcount = 2 Then
               '保存
               Select Case firstarg
                       Case "SA"
                           Dim folder As String
                           folder = Argv(2)
                           If folder <> "" And Len(folder) >= 3 Then
                           '截取
                                 folder = Right(folder, Len(folder) - 3)
                                 folder = Left(folder, Len(folder) - 1)
                                 '检查文件夹
                                  If Dir(folder, vbDirectory) <> "" Then
                                     '存在
                                      Module1.SaveDataAsFile_CommandArg (folder & "\")
                                      End
                                   Else
                                       MsgBox "没有找到文件夹""" & folder & """", vbOKOnly + vbCritical, "错误"
                                       End
                                  End If
                           Else
                           'error MLH DLG
                           MsgBox "无效的命令行" & Command$, vbOKOnly + vbCritical, "错误"
                           End If
               End Select
            End If
       End If
   Else
   'error
   MsgBox "无效的命令行" & Command$, vbOKOnly + vbCritical, "错误"
   'MLH DLG
   End If
End If
End Sub

Private Sub Form_Unload(Cancel As Integer)
End
End Sub
Public Sub SetProgram(ByVal settype As String)
Dim isa As Boolean
isa = iSaDMIN.Getisadmin
Select Case settype
        Case "RE"
            If isa = False Then
               Module1.runasadmin ("/RE")
            Else
                Module1.RegSystem
            End If
        Case "UR"
            If isa = False Then
                Module1.runasadmin ("/UR")
               End
            Else
                Module1.UnRegSystem
            End If
        Case "SE"
                after_showsetting = True
End Select
End Sub

