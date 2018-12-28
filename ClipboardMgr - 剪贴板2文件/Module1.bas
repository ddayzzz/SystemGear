Attribute VB_Name = "Module1"
Option Explicit
Public Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long
'REG
Private Declare Function SHDeleteKey Lib "shlwapi.dll" Alias "SHDeleteKeyA" (ByVal hkey As Long, ByVal pszSubKey As String) As Long
Private Const HKCR = &H80000000 'HKEY_CLASSES_ROOT
Private Const HKCU = &H80000001 'HKEY_CURRENT_USER
Private Const HKLM = &H80000002 'HKEY_LOCAL_MACHINE
Private Const HKU = &H80000003  'HKEY_USERS
Private Const HKCC = &H80000005 'HKEY_CURRENT_CONFIG

Private Const REG_SZ = 1 ' 字符串值
Private Const REG_EXPAND_SZ = 2 ' 可扩充字符串值
Private Const REG_BINARY = 3 ' 二进制值
Private Const REG_DWORD = 4 ' DWORD值
Private Const REG_MULTI_SZ = 7 ' 多字符串值

Private Const FO_MOVE = &H1
Private Const FO_COPY = &H2
Private Const FO_DELETE = &H3
Private Const FO_RENAME = &H4
Private Const FOF_NOCONFIRMATION = &H10
Private Const FOF_NOCONFIRMMKDIR = &H200
Private Const FOF_ALLOWUNDO = &H40
Private Const FOF_MULTIDESTFILES = &H1
Private Type SHFILEOPSTRUCT
hwnd As Long
wFunc As Long
pFrom As String
pTo As String
flags As Integer
fAborted  As Boolean
hNameMaps As Long
sProgress As String
End Type
Private Declare Function SHFileOperation Lib "shell32.dll" Alias "SHFileOperationA" (lpFileOp As SHFILEOPSTRUCT) As Long
Public Function getfileext(ByVal file As String) As String
On Error Resume Next   ' 设置错误处理。
Dim j As String
Dim n As String
j = ""
Dim s As String
Dim hzm As String
s = file    '文件名
n = InStr(s, ".")     '获取扩展名前的 点 的位置
hzm = Right(s, Len(s) - n) '根据位置截取扩展名
j = hzm
getfileext = j
End Function
'该函数用于获取剪切版的数据类型
Public Function GetClipboardDataType() As String
On Error Resume Next   ' 设置错误处理。
Dim istext As Boolean '定义是否是文本
Dim isimage As Boolean '定义是否是图像
Dim isfile As Boolean '定义是否是复制的文件
istext = Clipboard.GetFormat(vbCFText) '判断是否是文本
isimage = Clipboard.GetFormat(vbCFBitmap) '判断是否是图像
Dim retstr As String '返回的字符
retstr = "other"
If istext = True Then
   'IS TEXT
   retstr = "text"
Else
   'NOT TEXT
   If isimage = True Then
       'IS IMAGE
       retstr = "image"
   Else
       'NOT IMAGE
       If isfile = True Then
          'IS FILE
          retstr = "file"
       Else
          'DO NOT KNOWN
          retstr = "other"
        End If
   End If
End If
GetClipboardDataType = retstr
End Function
'该函数用于获取剪切版的数据
Public Sub GetClipboardData()
On Error Resume Next   ' 设置错误处理。
Dim istext As Boolean '定义是否是文本
Dim isimage As Boolean '定义是否是图像
istext = Clipboard.GetFormat(vbCFText) '判断是否是文本
isimage = Clipboard.GetFormat(vbCFBitmap) '判断是否是图像
Dim retstr As String '返回的字符
retstr = "other"
If istext = True Then
   'IS TEXT
    Form_main.Image1.Visible = False
    Form_main.Text1.Visible = True
    Form_main.Text1.Text = Clipboard.GetText(1)
    Form_main.Command_save.Enabled = True
    Form_main.Label1.Caption = "您当前剪切板的内容："
Else
   'NOT TEXT
   If isimage = True Then
       'IS IMAGE
       Form_main.Image1.Visible = True
       Form_main.Text1.Visible = False
       Form_main.Image1.Picture = Clipboard.GetData(2)
       Form_main.Command_save.Enabled = True
       Form_main.Label1.Caption = "您当前剪切板的内容："
   Else
          'DO NOT KNOW
          Form_main.Image1.Visible = False
       Form_main.Text1.Visible = False
       Form_main.Label1.Caption = "剪切板中没有内容或内容不被支持"
       Form_main.Command_save.Enabled = False
   End If
End If
End Sub
'保存文件
Public Function SaveDataAsFile() As Object
On Error Resume Next   ' 设置错误处理。
Dim datty As String
datty = Module1.GetClipboardDataType
Select Case datty
          Case "text"
                   save_text
        Case "image"
                   save_image
End Select
End Function
Public Sub SaveDataAsFile_CommandArg(ByVal folder As String)
On Error Resume Next   ' 设置错误处理。
Dim datty As String
datty = Module1.GetClipboardDataType
Select Case datty
          Case "text"
                   Module1.savetextasfile_commandarg (folder)
        Case "image"
                   Module1.saveimageasfile_commandarg (folder)
End Select
End Sub
Public Function deletefile(ByVal file As String)
Dim SHFileOp As SHFILEOPSTRUCT
SHFileOp.wFunc = FO_DELETE
SHFileOp.pFrom = file + Chr(0)
SHFileOp.flags = FOF_NOCONFIRMMKDIR + FOF_NOCONFIRMATION
SHFileOperation SHFileOp
End Function
Public Function SaveTextAsFile(ByVal txtfile As String, ByVal txt) As Long
Open txtfile For Output As #1
Print #1, txt
Close #1
End Function
Public Function AppendTextInFile(ByVal txtfile As String, ByVal txt) As Long
Open txtfile For Append As #1
Print #1, txt
Close #1
End Function
Public Sub save_text()
On Error Resume Next   ' 设置错误处理。
Dim f
Dim tim
tim = Format(Now, "yyyymmddhhmmss") '时间代码
'MsgBox "text"
                   Dim txtfile As String
                   txtfile = Module2.FileDialog(Form_main, True, "保存剪切板的中的文件", "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*", "来自剪切板的文本 " & tim & ".txt")
                   If txtfile <> "" Then
                        'OK SELECTFILE
                        '判断文件是否存在
                        If Dir(txtfile) <> "" Then
                            '存在现有文件询问用户是否替换
                            Dim sel
                            sel = MsgBox("是否要替换现有的文本文件""" & txtfile & """？", vbYesNoCancel + vbQuestion, "是否替换文件？") '6 yes 7 no 2 取消
                            Select Case sel
                                      Case 6
                                          'delete
                                           deletefile (txtfile)
                                            '检查是否已经删除
                                            If Dir(txtfile) <> "" Then
                                                sel = MsgBox("无法保存文本文件因为：无法替换选择的文件", vbCritical + vbOKOnly, "错误")
                                                 Exit Sub
                                            Else
                                                f = Module1.SaveTextAsFile(txtfile, Form_main.Text1.Text)
                                            End If
                                      Case 7
                                      '不过可以附加
                                      sel = MsgBox("是否附加文本到""" & txtfile & """？", vbYesNo + vbQuestion, "是否附加？")
                                      'MsgBox sel
                                      If sel = 6 Then
                                      '那就附加吧
                                      f = Module1.AppendTextInFile(txtfile, Form_main.Text1.Text)
                                      Else
                                      Exit Sub
                                      End If
                                      Case 2
                                      Exit Sub
                            End Select
                        Else
                            '本来就没有
                             f = Module1.SaveTextAsFile(txtfile, Form_main.Text1.Text)
                        End If
                   End If
End Sub
Public Sub save_image()
On Error Resume Next   ' 设置错误处理。
Dim f
Dim tim
tim = Format(Now, "yyyymmddhhmmss") '时间代码
'MsgBox "text"
                   Dim txtfile As String
                   Dim ext As String
                   ext = "jpg"
                   txtfile = Module2.FileDialog(Form_main, True, "保存剪切板的中的文件", "JPEG图片格式(*.jpg)|*.jpg|Windows 位图(*.bmp)|*.bmp", "来自剪切板的图片 " & tim, ".jpg")
                   If txtfile <> "" Then
                        'OK SELECTFILE
                        '判断文件是否存在
                        If Dir(txtfile) <> "" Then
                            '存在现有文件询问用户是否替换
                            ext = Module1.getfileext(txtfile)
                            Dim sel
                            sel = MsgBox("是否要替换现有的图片文件""" & txtfile & """？", vbYesNoCancel + vbQuestion, "是否替换文件？") '6 yes 7 no 2 取消
                            Select Case sel
                                      Case 6
                                          'delete
                                           deletefile (txtfile)
                                            '检查是否已经删除
                                            If Dir(txtfile) <> "" Then
                                                sel = MsgBox("无法保存图片文件因为：无法替换选择的文件", vbCritical + vbOKOnly, "错误")
                                                 Exit Sub
                                            Else
                                                SaveImage.SavePic Form_main.Image1.Picture, txtfile, "." & ext, 100
                                            End If
                                      Case 7
                                      '不过可以附加
                                      Exit Sub
                                      Case 2
                                      Exit Sub
                            End Select
                        Else
                            '本来就没有
                             SaveImage.SavePic Form_main.Image1.Picture, txtfile, "." & ext, 100
                        End If
                   End If
End Sub
Public Sub savetextasfile_commandarg(ByVal folder As String)
On Error Resume Next   ' 设置错误处理。
Dim tim
tim = Format(Now, "yyyymmddhhmmss") '时间代码
Dim txtfile As String
txtfile = folder & "来自剪切板的文本 " & tim & ".txt"
If Dir(txtfile) <> "" Then
   deletefile (txtfile)
End If
'再次检查
If Dir(txtfile) <> "" Then
   Exit Sub
End If
'可以保存了
  Module1.SaveTextAsFile txtfile, Clipboard.GetText(1)
End Sub
Public Sub saveimageasfile_commandarg(ByVal folder As String)
On Error Resume Next   ' 设置错误处理。
Dim tim
tim = Format(Now, "yyyymmddhhmmss") '时间代码
Dim txtfile As String
txtfile = folder & "来自剪切板的图片 " & tim & ".jpg"
If Dir(txtfile) <> "" Then
   deletefile (txtfile)
End If
'再次检查
If Dir(txtfile) <> "" Then
   Exit Sub
End If
'可以保存了
  SaveImage.SavePic Clipboard.GetData(2), txtfile, ".jpg", 100
End Sub
Public Sub RegSystem()
On Error Resume Next   ' 设置错误处理。
Dim LO
Dim hkey_1 As Long
Dim hkey_1_cmd As Long
Dim subname As String
subname = "SaveClipboardAsFile"
Dim CMD As String
Dim MUI As String
Dim ICO As String
CMD = App.Path & "\" & App.EXEName & ".exe /SA /F=""%V\"""
ICO = App.Path & "\" & App.EXEName & ".exe,0"
MUI = "保存剪切板内容为文件"
LO = RegeditAPI.RegCreateKey(HKCR, "Directory\background\shell\" & subname, hkey_1)
LO = RegeditAPI.RegCreateKey(HKCR, "Directory\background\shell\" & subname & "\command", hkey_1_cmd)
LO = RegeditAPI.RegSetValueEx(hkey_1_cmd, "", 0, REG_SZ, ByVal CMD, LenB(CMD))
LO = RegeditAPI.RegSetValueEx(hkey_1, "MUIVerb", 0, REG_SZ, ByVal MUI, LenB(MUI))
LO = RegeditAPI.RegSetValueEx(hkey_1, "Icon", 0, REG_SZ, ByVal ICO, LenB(ICO))
LO = RegeditAPI.RegSetValueEx(hkey_1, "Position", 0, REG_SZ, ByVal "Top", 3)
'folder
LO = RegeditAPI.RegCreateKey(HKCR, "Directory\shell\" & subname, hkey_1)
LO = RegeditAPI.RegCreateKey(HKCR, "Directory\shell\" & subname & "\command", hkey_1_cmd)
LO = RegeditAPI.RegSetValueEx(hkey_1_cmd, "", 0, REG_SZ, ByVal CMD, LenB(CMD))
LO = RegeditAPI.RegSetValueEx(hkey_1, "MUIVerb", 0, REG_SZ, ByVal MUI, LenB(MUI))
LO = RegeditAPI.RegSetValueEx(hkey_1, "Icon", 0, REG_SZ, ByVal ICO, LenB(ICO))
'DISK
LO = RegeditAPI.RegCreateKey(HKCR, "Drive\shell\" & subname, hkey_1)
LO = RegeditAPI.RegCreateKey(HKCR, "Drive\shell\" & subname & "\command", hkey_1_cmd)
LO = RegeditAPI.RegSetValueEx(hkey_1_cmd, "", 0, REG_SZ, ByVal CMD, LenB(CMD))
LO = RegeditAPI.RegSetValueEx(hkey_1, "MUIVerb", 0, REG_SZ, ByVal MUI, LenB(MUI))
LO = RegeditAPI.RegSetValueEx(hkey_1, "Icon", 0, REG_SZ, ByVal ICO, LenB(ICO))
End Sub
Public Sub UnRegSystem()
On Error Resume Next   ' 设置错误处理。
Dim LO
Dim hkey_1 As Long
Dim hkey_1_cmd As Long
Dim subname As String
subname = "SaveClipboardAsFile"
LO = SHDeleteKey(HKCR, "Directory\background\shell\" & subname)
'folder
LO = SHDeleteKey(HKCR, "Directory\shell\" & subname)
LO = SHDeleteKey(HKCR, "Drive\shell\" & subname)
End Sub
Public Sub runasadmin(ByVal args As String)
'MsgBox App.Path & "\" & App.EXEName & ".exe " & args
ShellExecute Form_main.hwnd, "runas", App.Path & "\" & App.EXEName & ".exe", args, App.Path, 1
End Sub
