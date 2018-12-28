Attribute VB_Name = "Module1"
'声明
'重建缩略图图标缓存
Private Declare Sub SHChangeNotify Lib "shell32.dll" (ByVal wEventId As Long, ByVal uFlags As Long, ByVal dwItem1 As Long, ByVal dwItem2 As Long)
Private Const SHCNE_ASSOCCHANGED = &H8000000
Private Const SHCNF_IDLIST = &H0
'关屏API
Private Declare Function GetForegroundWindow Lib "user32" () As Long
Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
Const WM_SYSCOMMAND = &H112&
Const SC_MONITORPOWER = &HF170&
'关闭64位定位
Private Declare Function Wow64DisableWow64FsRedirection Lib "kernel32.dll" (IntPtr As Boolean) As Boolean
'光驱操作
Private Declare Function CDDoor Lib "winmm.dll" Alias "mciSendStringA" _
(ByVal lpstrCommand As String, ByVal lpstrReturnString As String, _
ByVal uReturnLength As Long, ByVal hwndCallback As Long) As Long

Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Long, ByVal dwExtraInfo As Long) '发送按键
Private Const VK_LWIN As Long = &H5B
Private Const KEYEVENTF_KEYUP = &H2
Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hWnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long


Public Sub ShellCMD(ByVal cmd As String)
Call Wow64DisableWow64FsRedirection(False) '关闭文件转向
Select Case LCase(cmd)
       Case "startscreen"
              Module1.StartScreen
        Case "restartexplorer"
              Module1.ReStartExplorer
        Case "startexplorer"
              Module1.StartExplorer
        Case "closescreen"
              Module1.CloseScreen
        Case "closecddoor"
              Module1.CloseCDDoor
        Case "opencddoor"
              Module1.OpenCDDoor
        Case "refreshiconcache"
              Module1.ReFreshIconCache
End Select
End Sub
Public Sub StartScreen()
Call keybd_event(VK_LWIN, 0, 0, 0)         '按下S键。
Call keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0)  '放开S键。
End
End Sub
Public Sub ReStartExplorer()
Dim tsk As String
tsk = Environ("windir") & "\system32\tskill.exe"
'MsgBox tsk
ShellExecute Form1.hWnd, "open", tsk, "explorer", "", 0
End
End Sub
Public Sub StartExplorer()
Dim tsk As String
tsk = "explorer.exe"
ShellExecute Form1.hWnd, "open", tsk, "", "", 1
End
End Sub
Public Sub CloseScreen()
SendMessage GetForegroundWindow, WM_SYSCOMMAND, SC_MONITORPOWER, 2
End
End Sub
Public Sub OpenCDDoor()
Call CDDoor("set CDAudio door OPEN", 0, 0, 0)
End
End Sub
Public Sub CloseCDDoor()
Call CDDoor("set CDAudio door closed", 0, 0, 0)
End
End Sub
Public Sub ReFreshIconCache()
Call SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_IDLIST, 0, 0)
End
End Sub
Public Sub SetWallpapaperToLockScreen()

End Sub
