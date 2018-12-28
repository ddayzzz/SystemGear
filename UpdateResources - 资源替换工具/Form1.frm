VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "系统齿轮 资源更新程序"
   ClientHeight    =   1665
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   11115
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
   ScaleHeight     =   1665
   ScaleWidth      =   11115
   StartUpPosition =   3  '窗口缺省
   Begin VB.Label Label1 
      Caption         =   $"Form1.frx":A9B9
      Height          =   1575
      Left            =   120
      TabIndex        =   0
      Top             =   240
      Width           =   11055
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
Private Declare Function BeginUpdateResource Lib "kernel32" Alias "BeginUpdateResourceA" (ByVal pFileName As String, ByVal bDeleteExistingResources As Boolean) As Long
Private Declare Function UpdateResource Lib "kernel32" Alias "UpdateResourceA" (ByVal hUpdate As Long, ByVal lpType As Any, ByVal lpName As Any, ByVal wLanguage As Long, lpData As Any, ByVal cbData As Long) As Long
Private Declare Function EndUpdateResource Lib "kernel32" Alias "EndUpdateResourceA" (ByVal hUpdate As Long, ByVal fDiscard As Boolean) As Long
Private Const RT_ICON = 3&
Private Const RT_BITMAP = 2& 'Bitmap
Private Const RT_RCDATA = 10& 'RCData

Public Function WriteRes(ByVal ResFileName As String, ByVal WriteFileName As String, ByVal ResType As String, ByVal ResID As Long, ByVal ResLang As Long) As Boolean
Dim VbArrayRes() As Byte '写入内容
Dim hUpdate As Long '被写入的目标文件路径
Dim Ret As Long '资源句柄
Dim ResTypeX As String

    ResTypeX = ResType
    hUpdate = BeginUpdateResource(WriteFileName, False) '打开要写入的目标文件

    ReDim VbArrayRes(FileLen(ResFileName) - 1) '计算资源文件大小

    Open ResFileName For Binary As #1 '获取资源文件内容
        Get #1, , VbArrayRes
    Close #1
    Select Case VBA.UCase(ResTypeX)
    
               Case "RCDATA"
                          Ret = UpdateResource(hUpdate, RT_RCDATA, ResID, ResLang, VbArrayRes(0), UBound(VbArrayRes) + 1) 'RCDATA RT_RCDATA 为10
                         If Ret <> 0 Then
                                   WriteRes = True
                         End If
               Case "BITMAP"
                        Ret = UpdateResource(hUpdate, RT_BITMAP, ResID, ResLang, VbArrayRes(0), UBound(VbArrayRes) + 1) 'RCDATA RT_RCDATA 为10
                        If Ret <> 0 Then
                                  WriteRes = True
                        End If
        
                Case Else
                        Ret = UpdateResource(hUpdate, ResTypeX, ResID, ResLang, VbArrayRes(0), UBound(VbArrayRes) + 1) 'Other
                        If Ret <> 0 Then
                                WriteRes = True
                        End If
    End Select
    '关闭资源更新
    Ret = EndUpdateResource(hUpdate, False)
    'MsgBox Ret
End Function

  
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

Private Sub Form_Load()
Form1.Hide
On Error GoTo haserror
Dim Argc As Long, Argv() As String
Dim CommandArgsItems() As String
Dim i As Integer, szCmd As String
Call SplitCmd(Argc, Argv())
CommandArgsItems = Argv
Dim respaht As String
Dim file As String
Dim resname As String
Dim ResID As String
Dim ResLang As String
'//////////////
respaht = Strings.Replace(Strings.Replace(CommandArgsItems(1), "/", ""), "-", "")
file = Strings.Replace(Strings.Replace(CommandArgsItems(2), "/", ""), "-", "")
resname = Strings.Replace(Strings.Replace(CommandArgsItems(3), "/", ""), "-", "")
ResID = Strings.Replace(Strings.Replace(CommandArgsItems(4), "/", ""), "-", "")
ResLang = Strings.Replace(Strings.Replace(CommandArgsItems(5), "/", ""), "-", "")
Dim id As Long
Dim lan As Long
id = CLng(ResID)
lan = CLng(ResLang)
Dim k As Boolean
k = WriteRes(respaht, file, resname, id, lan)
End
haserror:
Form1.Show
End Sub

