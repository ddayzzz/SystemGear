Attribute VB_Name = "Module1"
Declare Function CopyFile Lib "kernel32" Alias "CopyFileA" (ByVal lpExistingFileName As String, ByVal lpNewFileName As String, ByVal bFailIfExists As Long) As Long
Public Sub OnlyCreateVdisk(ByVal FileName As String, ByVal FileSize As String, ByVal FileType, ByVal Load As Boolean, ByVal Letter)
On Error GoTo err
Dim ScriptFile  As String
If Load = False Then
ScriptFile = Environ("tmp") & "\Disk.txt"
Open ScriptFile For Output As #1
Print #1, "create vdisk file=""" & FileName & """ maximum=" & FileSize & " type=" & FileType
Print #1, "select vdisk file=""" & FileName & """"
Print #1, "attach vdisk"
Print #1, "create partition primary"
Print #1, "format fs=ntfs quick"
Close #1
Else
ScriptFile = Environ("tmp") & "\Disk.txt"
Open ScriptFile For Output As #1
Print #1, "create vdisk file=""" & FileName & """ maximum=" & FileSize & " type=" & FileType
Print #1, "select vdisk file=""" & FileName & """"
Print #1, "attach vdisk"
Print #1, "create partition primary"
Print #1, "format fs=ntfs quick"
Print #1, "assign letter=" & Letter
Close #1
End If
Dim po As Long
po = Shell("diskpart.exe /s """ & ScriptFile & """", vbHide)
End
err:
  If Load = False Then
  MsgBox "无法创建指定的虚拟磁盘文件！", "错误"
  Else
  MsgBox "无法创建并加载指定的虚拟磁盘文件！", "错误"
  End If
End Sub
Public Sub OnlyUninstallVdisk(ByVal FileName As String, ByVal Delete As Boolean)
On Error GoTo err
Dim ScriptFile  As String
ScriptFile = Environ("tmp") & "\Disk.txt"
Open ScriptFile For Output As #1
Print #1, "select vdisk file=""" & FileName & """"
Print #1, "detach vdisk"
Close #1
Dim po As Long
po = Shell("cmd.exe /c diskpart.exe /s """ & ScriptFile & """ && del /q """ & FileName & """", vbHide)
End
err:
  If Delete = True Then
  MsgBox "无法卸载并删除指定的虚拟磁盘文件！", "错误"
  Else
  MsgBox "无法卸载指定的虚拟磁盘文件！", "错误"
  End If
End Sub
Public Sub CheckFileAndOs()
On Error GoTo haserrr
'检查操作系统
Dim strComputer, objWMIService, colItems, objItem, strOSversion As String
strComputer = "."
Set objWMIService = GetObject("winmgmts:\\" & strComputer & "\root\cimv2")
Set colItems = objWMIService.ExecQuery("Select * from Win32_OperatingSystem")
For Each objItem In colItems
strOSversion = objItem.Version
Next
Select Case Left(strOSversion, 3)
Case "5.2"
strOSversion = "5.2"
Case "5.0"
strOSversion = "5.0"
Case "5.1"
strOSversion = "5.1"
Case "6.0"
strOSversion = "6.0"
Case "6.1"
strOSversion = "6.1"
Case "6.2"
strOSversion = "6.2"
Case "6.3"
strOSversion = "6.3"
Case Else
strOSversion = "未知"
End Select
'检查操作系统完毕 开始
Dim OSVer As String
OSVer = strOSversion
If OSVer = "6.1" Or OSVer = "6.2" Or OSVer = "6.3" Then
If Dir(Environ("windir") & "\System32\Diskpart.exe") <> "" Then
Else
Dim kk
kk = MsgBox("文件丢失，找不到：""" & Environ("windir") & "\System32\Diskpart.exe""", vbCritical, "系统齿轮 虚拟磁盘管理工具")
End
End If
Else
Dim k
k = MsgBox("不支持您当前的操作系统，请使用Windows 7或以上的操作系统", vbExclamation, "系统齿轮 虚拟磁盘管理工具")
End
Exit Sub
haserrr:
End
End If
End Sub
Public Sub RegInOS()

End Sub

