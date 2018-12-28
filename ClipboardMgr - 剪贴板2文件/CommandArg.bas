Attribute VB_Name = "CommandArg"
Option Explicit
  
Private Declare Function GetCommandLineW Lib "kernel32" () As Long
Private Declare Function lstrlenW Lib "kernel32" (ByVal lpString As Long) As Long
Private Declare Function CommandLineToArgvW Lib "shell32" (ByVal lpCmdLine As Long, pnNumArgs As Long) As Long
Private Declare Function LocalFree Lib "kernel32" (ByVal hMem As Long) As Long
Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (Destination As Any, Source As Any, ByVal Length As Long)
Private Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Long, ByVal bInheritHandle As Long, ByVal dwProcessId As Long) As Long
Public Function SplitCmd(ByRef Argc As Long, ByRef Argv() As String)
   Dim nNumArgs As Long       '//�����в�������
   Dim lpszArglist As Long    '//�����в��������ַ
   Dim lpszArg As Long        '//�����и�������ַ
   Dim nArgLength As Long     '//�����и���������
   Dim szArg() As Byte        '//�����и�����
   Dim i As Long
    
   lpszArglist = CommandLineToArgvW(GetCommandLineW(), nNumArgs)
   If lpszArglist Then
      Argc = nNumArgs   '//����ܸ���
      ReDim Argv(nNumArgs - 1)
      CopyMemory ByVal VarPtr(lpszArg), ByVal lpszArglist, 4   '//�õ�argv(0)�ĵ�ַ
      
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
Public Function TrimPath(sPath As String) As String
Dim i As Integer
i = InStrRev(sPath, ".") + 1
TrimPath = Mid(sPath, i)
End Function
