VERSION 5.00
Begin VB.Form Form_main 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "���а������ 1.0"
   ClientHeight    =   6765
   ClientLeft      =   45
   ClientTop       =   390
   ClientWidth     =   11490
   BeginProperty Font 
      Name            =   "΢���ź�"
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
   StartUpPosition =   2  '��Ļ����
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
      Caption         =   "����"
      Height          =   495
      Left            =   240
      TabIndex        =   4
      Top             =   6000
      Width           =   1575
   End
   Begin VB.CommandButton Command_clear 
      Caption         =   "��ռ��а�"
      Height          =   495
      Left            =   6120
      TabIndex        =   3
      Top             =   6000
      Width           =   1575
   End
   Begin VB.CommandButton Command_refash 
      Caption         =   "ˢ��"
      Height          =   495
      Left            =   7800
      TabIndex        =   2
      Top             =   6000
      Width           =   1575
   End
   Begin VB.CommandButton Command_save 
      Caption         =   "����Ϊ�ļ�"
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
      Caption         =   "����ǰ���а�����ݣ�"
      BeginProperty Font 
         Name            =   "΢���ź�"
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
chose = MsgBox("���Ƿ�Ҫ��ռ��а���", vbYesNo + vbQuestion, "�Ƿ���գ�")
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
'���������
Module1.GetClipboardData
checkarg

End Sub
Public Sub checkarg()
Dim fullarg As String
fullarg = Command$
If fullarg = "" Then
   'û��������
   Module1.GetClipboardData
Else
   '��������
   Dim Argc As Long, Argv() As String
   Dim i As Integer, szCmd As String
   Call CommandArg.SplitCmd(Argc, Argv())
   'MsgBox "��������"
   '����ĸ���
   Dim argcount As Integer
   argcount = UBound(Argv)
   startarg = Argv
   '����arg1���ж�
   Dim firstarg As String
   firstarg = Argv(1)
   firstarg = UCase(firstarg)
   firstarg = Replace(firstarg, "/", "")
   firstarg = Replace(firstarg, "-", "")
   firstarg = Replace(firstarg, "\", "")
   If argcount >= 1 & rgcount <= 2 Then
       '������
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
               '����
               Select Case firstarg
                       Case "SA"
                           Dim folder As String
                           folder = Argv(2)
                           If folder <> "" And Len(folder) >= 3 Then
                           '��ȡ
                                 folder = Right(folder, Len(folder) - 3)
                                 folder = Left(folder, Len(folder) - 1)
                                 '����ļ���
                                  If Dir(folder, vbDirectory) <> "" Then
                                     '����
                                      Module1.SaveDataAsFile_CommandArg (folder & "\")
                                      End
                                   Else
                                       MsgBox "û���ҵ��ļ���""" & folder & """", vbOKOnly + vbCritical, "����"
                                       End
                                  End If
                           Else
                           'error MLH DLG
                           MsgBox "��Ч��������" & Command$, vbOKOnly + vbCritical, "����"
                           End If
               End Select
            End If
       End If
   Else
   'error
   MsgBox "��Ч��������" & Command$, vbOKOnly + vbCritical, "����"
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

