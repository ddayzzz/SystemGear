VERSION 5.00
Begin VB.Form Form_setting 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "����"
   ClientHeight    =   3975
   ClientLeft      =   4965
   ClientTop       =   3240
   ClientWidth     =   7020
   BeginProperty Font 
      Name            =   "΢���ź�"
      Size            =   9
      Charset         =   134
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "Form_setting.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   265
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   468
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  '����ȱʡ
   Begin VB.CommandButton Command1 
      Caption         =   "ȡ������"
      Height          =   495
      Left            =   3240
      TabIndex        =   3
      Top             =   600
      Width           =   1575
   End
   Begin VB.CommandButton Command_regrm 
      Caption         =   "�������Ҽ��˵�"
      Height          =   495
      Left            =   1560
      TabIndex        =   1
      Top             =   600
      Width           =   1575
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      Caption         =   "�Ҽ��˵�������"
      BeginProperty Font 
         Name            =   "΢���ź�"
         Size            =   9
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   255
      Left            =   120
      TabIndex        =   2
      Top             =   720
      Width           =   1260
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      Caption         =   "���ã�"
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
      Left            =   120
      TabIndex        =   0
      Top             =   240
      Width           =   855
   End
End
Attribute VB_Name = "Form_setting"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command_regrm_Click()
Module1.ShellExecute Me.hwnd, "runas", App.Path & "\" & App.EXEName & ".exe", "/RE", App.Path, 1
MsgBox "�ɹ����������Ҽ��˵�", vbOKOnly + vbInformation, "�ɹ�"
End Sub

Private Sub Command1_Click()
Module1.ShellExecute Me.hwnd, "runas", App.Path & "\" & App.EXEName & ".exe", "/UR", App.Path, 1
MsgBox "�ɹ�ȡ������", vbOKOnly + vbInformation, "�ɹ�"
End Sub

