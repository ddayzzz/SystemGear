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

Private Const REG_SZ = 1 ' �ַ���ֵ
Private Const REG_EXPAND_SZ = 2 ' �������ַ���ֵ
Private Const REG_BINARY = 3 ' ������ֵ
Private Const REG_DWORD = 4 ' DWORDֵ
Private Const REG_MULTI_SZ = 7 ' ���ַ���ֵ

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
On Error Resume Next   ' ���ô�����
Dim j As String
Dim n As String
j = ""
Dim s As String
Dim hzm As String
s = file    '�ļ���
n = InStr(s, ".")     '��ȡ��չ��ǰ�� �� ��λ��
hzm = Right(s, Len(s) - n) '����λ�ý�ȡ��չ��
j = hzm
getfileext = j
End Function
'�ú������ڻ�ȡ���а����������
Public Function GetClipboardDataType() As String
On Error Resume Next   ' ���ô�����
Dim istext As Boolean '�����Ƿ����ı�
Dim isimage As Boolean '�����Ƿ���ͼ��
Dim isfile As Boolean '�����Ƿ��Ǹ��Ƶ��ļ�
istext = Clipboard.GetFormat(vbCFText) '�ж��Ƿ����ı�
isimage = Clipboard.GetFormat(vbCFBitmap) '�ж��Ƿ���ͼ��
Dim retstr As String '���ص��ַ�
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
'�ú������ڻ�ȡ���а������
Public Sub GetClipboardData()
On Error Resume Next   ' ���ô�����
Dim istext As Boolean '�����Ƿ����ı�
Dim isimage As Boolean '�����Ƿ���ͼ��
istext = Clipboard.GetFormat(vbCFText) '�ж��Ƿ����ı�
isimage = Clipboard.GetFormat(vbCFBitmap) '�ж��Ƿ���ͼ��
Dim retstr As String '���ص��ַ�
retstr = "other"
If istext = True Then
   'IS TEXT
    Form_main.Image1.Visible = False
    Form_main.Text1.Visible = True
    Form_main.Text1.Text = Clipboard.GetText(1)
    Form_main.Command_save.Enabled = True
    Form_main.Label1.Caption = "����ǰ���а�����ݣ�"
Else
   'NOT TEXT
   If isimage = True Then
       'IS IMAGE
       Form_main.Image1.Visible = True
       Form_main.Text1.Visible = False
       Form_main.Image1.Picture = Clipboard.GetData(2)
       Form_main.Command_save.Enabled = True
       Form_main.Label1.Caption = "����ǰ���а�����ݣ�"
   Else
          'DO NOT KNOW
          Form_main.Image1.Visible = False
       Form_main.Text1.Visible = False
       Form_main.Label1.Caption = "���а���û�����ݻ����ݲ���֧��"
       Form_main.Command_save.Enabled = False
   End If
End If
End Sub
'�����ļ�
Public Function SaveDataAsFile() As Object
On Error Resume Next   ' ���ô�����
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
On Error Resume Next   ' ���ô�����
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
On Error Resume Next   ' ���ô�����
Dim f
Dim tim
tim = Format(Now, "yyyymmddhhmmss") 'ʱ�����
'MsgBox "text"
                   Dim txtfile As String
                   txtfile = Module2.FileDialog(Form_main, True, "������а���е��ļ�", "�ı��ļ�(*.txt)|*.txt|�����ļ�(*.*)|*.*", "���Լ��а���ı� " & tim & ".txt")
                   If txtfile <> "" Then
                        'OK SELECTFILE
                        '�ж��ļ��Ƿ����
                        If Dir(txtfile) <> "" Then
                            '���������ļ�ѯ���û��Ƿ��滻
                            Dim sel
                            sel = MsgBox("�Ƿ�Ҫ�滻���е��ı��ļ�""" & txtfile & """��", vbYesNoCancel + vbQuestion, "�Ƿ��滻�ļ���") '6 yes 7 no 2 ȡ��
                            Select Case sel
                                      Case 6
                                          'delete
                                           deletefile (txtfile)
                                            '����Ƿ��Ѿ�ɾ��
                                            If Dir(txtfile) <> "" Then
                                                sel = MsgBox("�޷������ı��ļ���Ϊ���޷��滻ѡ����ļ�", vbCritical + vbOKOnly, "����")
                                                 Exit Sub
                                            Else
                                                f = Module1.SaveTextAsFile(txtfile, Form_main.Text1.Text)
                                            End If
                                      Case 7
                                      '�������Ը���
                                      sel = MsgBox("�Ƿ񸽼��ı���""" & txtfile & """��", vbYesNo + vbQuestion, "�Ƿ񸽼ӣ�")
                                      'MsgBox sel
                                      If sel = 6 Then
                                      '�Ǿ͸��Ӱ�
                                      f = Module1.AppendTextInFile(txtfile, Form_main.Text1.Text)
                                      Else
                                      Exit Sub
                                      End If
                                      Case 2
                                      Exit Sub
                            End Select
                        Else
                            '������û��
                             f = Module1.SaveTextAsFile(txtfile, Form_main.Text1.Text)
                        End If
                   End If
End Sub
Public Sub save_image()
On Error Resume Next   ' ���ô�����
Dim f
Dim tim
tim = Format(Now, "yyyymmddhhmmss") 'ʱ�����
'MsgBox "text"
                   Dim txtfile As String
                   Dim ext As String
                   ext = "jpg"
                   txtfile = Module2.FileDialog(Form_main, True, "������а���е��ļ�", "JPEGͼƬ��ʽ(*.jpg)|*.jpg|Windows λͼ(*.bmp)|*.bmp", "���Լ��а��ͼƬ " & tim, ".jpg")
                   If txtfile <> "" Then
                        'OK SELECTFILE
                        '�ж��ļ��Ƿ����
                        If Dir(txtfile) <> "" Then
                            '���������ļ�ѯ���û��Ƿ��滻
                            ext = Module1.getfileext(txtfile)
                            Dim sel
                            sel = MsgBox("�Ƿ�Ҫ�滻���е�ͼƬ�ļ�""" & txtfile & """��", vbYesNoCancel + vbQuestion, "�Ƿ��滻�ļ���") '6 yes 7 no 2 ȡ��
                            Select Case sel
                                      Case 6
                                          'delete
                                           deletefile (txtfile)
                                            '����Ƿ��Ѿ�ɾ��
                                            If Dir(txtfile) <> "" Then
                                                sel = MsgBox("�޷�����ͼƬ�ļ���Ϊ���޷��滻ѡ����ļ�", vbCritical + vbOKOnly, "����")
                                                 Exit Sub
                                            Else
                                                SaveImage.SavePic Form_main.Image1.Picture, txtfile, "." & ext, 100
                                            End If
                                      Case 7
                                      '�������Ը���
                                      Exit Sub
                                      Case 2
                                      Exit Sub
                            End Select
                        Else
                            '������û��
                             SaveImage.SavePic Form_main.Image1.Picture, txtfile, "." & ext, 100
                        End If
                   End If
End Sub
Public Sub savetextasfile_commandarg(ByVal folder As String)
On Error Resume Next   ' ���ô�����
Dim tim
tim = Format(Now, "yyyymmddhhmmss") 'ʱ�����
Dim txtfile As String
txtfile = folder & "���Լ��а���ı� " & tim & ".txt"
If Dir(txtfile) <> "" Then
   deletefile (txtfile)
End If
'�ٴμ��
If Dir(txtfile) <> "" Then
   Exit Sub
End If
'���Ա�����
  Module1.SaveTextAsFile txtfile, Clipboard.GetText(1)
End Sub
Public Sub saveimageasfile_commandarg(ByVal folder As String)
On Error Resume Next   ' ���ô�����
Dim tim
tim = Format(Now, "yyyymmddhhmmss") 'ʱ�����
Dim txtfile As String
txtfile = folder & "���Լ��а��ͼƬ " & tim & ".jpg"
If Dir(txtfile) <> "" Then
   deletefile (txtfile)
End If
'�ٴμ��
If Dir(txtfile) <> "" Then
   Exit Sub
End If
'���Ա�����
  SaveImage.SavePic Clipboard.GetData(2), txtfile, ".jpg", 100
End Sub
Public Sub RegSystem()
On Error Resume Next   ' ���ô�����
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
MUI = "������а�����Ϊ�ļ�"
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
On Error Resume Next   ' ���ô�����
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
