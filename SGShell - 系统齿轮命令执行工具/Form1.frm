VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "系统齿轮 命令运行工具(命令行选项)"
   ClientHeight    =   2655
   ClientLeft      =   45
   ClientTop       =   390
   ClientWidth     =   8835
   BeginProperty Font 
      Name            =   "微软雅黑"
      Size            =   9
      Charset         =   134
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "Form1.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2655
   ScaleWidth      =   8835
   StartUpPosition =   3  '窗口缺省
   Begin VB.Label Label1 
      Caption         =   $"Form1.frx":DC1C
      Height          =   2655
      Left            =   120
      TabIndex        =   0
      Top             =   240
      Width           =   8535
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
  
Private Declare Function GetCommandLineW Lib "kernel32" () As Long
Private Declare Function CommandLineToArgvW Lib "shell32" (ByVal lpCmdLine As Long, pnNumArgs As Long) As Long
Private Declare Function LocalFree Lib "kernel32" (ByVal hMem As Long) As Long
Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (Destination As Any, Source As Any, ByVal Length As Long)
Private Declare Function lstrlenW Lib "kernel32" (ByVal lpString As Long) As Long
Public Function SplitCmd(ByRef Argc As Long, ByRef Argv() As String)
   Dim nNumArgs As Long       '//命令行参数个数
   Dim lpszArglist As Long    '//命令行参数数组地址
   Dim lpszArg As Long        '//命令行各参数地址
   Dim nArgLength As Long     '//命令行各参数长度
   Dim szArg() As Byte        '//命令行各参数
   Dim i As Long
    
   lpszArglist = CommandLineToArgvW(GetCommandLineW(), nNumArgs)
   If lpszArglist Then
      Argc = nNumArgs   '//输出总个数
      ReDim Argv(nNumArgs - 1)
      CopyMemory ByVal VarPtr(lpszArg), ByVal lpszArglist, 4   '//得到argv(0)的地址
      
      For i = 0 To nNumArgs - 1
        nArgLength = lstrlenW(lpszArg)
        ReDim szArg(nArgLength * 2 - 1)
        CopyMemory ByVal VarPtr(szArg(0)), ByVal lpszArg, nArgLength * 2
        Argv(i) = CStr(szArg)
        lpszArg = lpszArg + nArgLength * 2 + 2
      Next
      
      Erase szArg
      Call LocalFree(lpszArglist)
   End If
End Function

Private Sub Command1_Click()
End Sub

Private Sub Form_Load()
On Error GoTo haserror
Dim Argc As Long, Argv() As String
Dim CommandArgsItems() As String
Dim i As Integer, szCmd As String
Call SplitCmd(Argc, Argv())
CommandArgsItems = Argv
Dim argcount As Integer
argcount = UBound(Argv) + 1
'计算参数的个数 如果<=1 则表示没有参数
If argcount > 1 Then
      If argcount = 2 Then
           '制定了一个参数 应该是-S
           Dim kaiguan As String
           kaiguan = Left(Argv(1), 3)
           kaiguan = Replace(kaiguan, "/", "")
           kaiguan = Replace(kaiguan, "-", "")
           kaiguan = Replace(kaiguan, "\", "")
           kaiguan = Replace(kaiguan, "=", "")
           Select Case UCase(kaiguan)
                  Case "S"
                       Dim cmd As String
                       If Len(Argv(1)) >= 4 Then
                             cmd = Right(Argv(1), Len(Argv(1)) - 3)
                             Module1.ShellCMD (cmd)
                       End If
           End Select
      Else
      
      End If
Else

End If
Exit Sub
haserror:
End
End Sub
