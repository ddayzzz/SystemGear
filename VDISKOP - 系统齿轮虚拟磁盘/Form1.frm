VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "系统齿轮 虚拟磁盘创建工具"
   ClientHeight    =   7425
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   8865
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
   ScaleHeight     =   7425
   ScaleWidth      =   8865
   StartUpPosition =   3  '窗口缺省
   Begin VB.CommandButton Command1 
      Caption         =   "确定"
      Height          =   495
      Left            =   7080
      TabIndex        =   1
      Top             =   6720
      Width           =   1695
   End
   Begin VB.Label Label1 
      Caption         =   $"Form1.frx":A9B9
      Height          =   6495
      Left            =   120
      TabIndex        =   0
      Top             =   120
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
Private Declare Function lstrlenW Lib "kernel32" (ByVal lpString As Long) As Long
Private Declare Function CommandLineToArgvW Lib "shell32" (ByVal lpCmdLine As Long, pnNumArgs As Long) As Long
Private Declare Function LocalFree Lib "kernel32" (ByVal hMem As Long) As Long
Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (Destination As Any, Source As Any, ByVal Length As Long)
  
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
End
End Sub

Private Sub Form_Load()
Call Module1.CheckFileAndOs
'检查命令行
On Error GoTo haserror
Dim errortext As String
errortext = "错误，无法完成您的操作"
Dim Argc As Long, Argv() As String
Dim wshShell, omyShortcut
Set wshShell = CreateObject("Wscript.shell")
Dim CommandArgsItems() As String
Dim i As Integer, szCmd As String
Call SplitCmd(Argc, Argv())
CommandArgsItems = Argv
Dim OperateType As String
'检查操作的模式
OperateType = Strings.UCase(Strings.Replace(Strings.Replace(CommandArgsItems(1), "/", ""), "-", ""))
If Strings.Len(OperateType) = 2 Then
Select Case OperateType
Case "OC" 'Only Create vd
If UBound(CommandArgsItems) - LBound(CommandArgsItems) + 1 = 5 Then
Dim vdfile As String
Dim vdsize As String
Dim vdtype As String
vdfile = Strings.UCase(Strings.Replace(Strings.Replace(CommandArgsItems(2), "/", ""), "-", ""))
vdsize = Strings.UCase(Strings.Replace(Strings.Replace(CommandArgsItems(3), "/", ""), "-", ""))
vdtype = Strings.UCase(Strings.Replace(Strings.Replace(CommandArgsItems(4), "/", ""), "-", ""))
Call Module1.OnlyCreateVdisk(vdfile, vdsize, vdtype, False, "")
End
Else
errortext = "没有为创建虚拟磁盘指定另外的3个有效的参数"
GoTo haserror
End If
Case "UL" 'uninstall
If UBound(CommandArgsItems) - LBound(CommandArgsItems) = 2 Then
Dim vdfile1 As String
vdfile1 = Strings.UCase(Strings.Replace(Strings.Replace(CommandArgsItems(2), "/", ""), "-", ""))
Call Module1.OnlyUninstallVdisk(vdfile1, False)
End
Else
errortext = "没有为卸载虚拟磁盘指定另外的1个有效的参数"
GoTo haserror
End If
Case "UD" 'uninstall and delete
If UBound(CommandArgsItems) - LBound(CommandArgsItems) = 2 Then
Dim vdfile2 As String
vdfile2 = Strings.UCase(Strings.Replace(Strings.Replace(CommandArgsItems(2), "/", ""), "-", ""))
Call Module1.OnlyUninstallVdisk(vdfile2, True)
End
Else
errortext = "没有为卸载并删除虚拟磁盘指定另外的1个有效的参数"
GoTo haserror
End If
Case "CL" 'create vdisk and load in os
If UBound(CommandArgsItems) - LBound(CommandArgsItems) = 5 Then
Dim vdfile3 As String
Dim vdsize3 As String
Dim vdtype3 As String
vdfile3 = Strings.UCase(Strings.Replace(Strings.Replace(CommandArgsItems(2), "/", ""), "-", ""))
vdsize3 = Strings.UCase(Strings.Replace(Strings.Replace(CommandArgsItems(3), "/", ""), "-", ""))
vdtype3 = Strings.UCase(Strings.Replace(Strings.Replace(CommandArgsItems(4), "/", ""), "-", ""))
Call Module1.OnlyCreateVdisk(vdfile3, vdsize3, vdtype3, True, Strings.UCase(Strings.Replace(Strings.Replace(CommandArgsItems(5), "/", ""), "-", "")))
End
Else
errortext = "没有为创建并加载虚拟磁盘指定另外的4个有效的参数"
GoTo haserror
End If
Case Else
errortext = "没有指定正确的命令行"
GoTo haserror
End Select
Else
errortext = "没有指定正确的命令行"
GoTo haserror
End If
Exit Sub
haserror:
Dim l
l = MsgBox(errortext, vbCritical, "系统齿轮 虚拟磁盘管理工具")
End Sub

