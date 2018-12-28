Attribute VB_Name = "iSaDMIN"
Private Const HKCR = &H80000000 'HKEY_CLASSES_ROOT
Private Const HKCU = &H80000001 'HKEY_CURRENT_USER
Private Const HKLM = &H80000002 'HKEY_LOCAL_MACHINE
Private Const HKU = &H80000003  'HKEY_USERS
Private Const HKCC = &H80000005 'HKEY_CURRENT_CONFIG
Private Declare Function SHDeleteKey Lib "shlwapi.dll" Alias "SHDeleteKeyA" (ByVal hkey As Long, ByVal pszSubKey As String) As Long
Public Function Getisadmin() As Boolean
On Error Resume Next   ' …Ë÷√¥ÌŒÛ¥¶¿Ì°£
Getisadmin = False
Dim k As Long
RegeditAPI.RegCreateKey HKCR, "refexon", k
RegeditAPI.RegSetValueEx k, "TEST", 0, 1, ByVal "TEST", 4
Dim R
Set R = CreateObject("wscript.Shell")
a = R.regread("HKEY_CLASSES_ROOT\refexon\test")
If a = "TEST" Then
SHDeleteKey HKCR, "refexon"
Getisadmin = True
Else
Getisadmin = False
End If
End Function

