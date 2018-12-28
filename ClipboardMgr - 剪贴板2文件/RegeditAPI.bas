Attribute VB_Name = "RegeditAPI"

Option Explicit

Option Compare Text
Type FILETIME
    lLowDateTime    As Long
    lHighDateTime   As Long
End Type

'---------------------------------------------------------------
'- 注册表 API 声明...
'---------------------------------------------------------------
Public Declare Function RegCloseKey Lib "advapi32.dll" (ByVal hKey As Long) As Long
Public Declare Function RegCreateKeyEx Lib "advapi32.dll" Alias "RegCreateKeyExA" (ByVal hKey As Long, ByVal lpSubKey As String, ByVal Reserved As Long, ByVal lpClass As String, ByVal dwOptions As Long, ByVal samDesired As Long, lpSecurityAttributes As SECURITY_ATTRIBUTES, phkResult As Long, lpdwDisposition As Long) As Long
Public Declare Function RegDeleteKey Lib "advapi32.dll" Alias "RegDeleteKeyA" (ByVal hKey As Long, ByVal lpSubKey As String) As Long
Public Declare Function RegDeleteValue Lib "advapi32.dll" Alias "RegDeleteValueA" (ByVal hKey As Long, ByVal lpValueName As String) As Long

Public Declare Function RegOpenKeyExA Lib "advapi32.dll" Alias "RegOpenKeyA" (ByVal hKey As Long, ByVal lpSubKey As String, phkResult As Long) As Long
Public Declare Function RegOpenKeyEx Lib "advapi32.dll" Alias "RegOpenKeyExA" (ByVal hKey As Long, ByVal lpSubKey As String, ByVal ulOptions As Long, ByVal samDesired As Long, phkResult As Long) As Long

Public Declare Function RegQueryValueEx Lib "advapi32.dll" Alias "RegQueryValueExA" (ByVal hKey As Long, ByVal lpValueName As String, ByVal lpReserved As Long, lpType As Long, ByVal lpData As String, lpcbData As Long) As Long
Public Declare Function RegRestoreKey Lib "advapi32.dll" Alias "RegRestoreKeyA" (ByVal hKey As Long, ByVal lpFile As String, ByVal dwFlags As Long) As Long
Public Declare Function RegSaveKey Lib "advapi32.dll" Alias "RegSaveKeyA" (ByVal hKey As Long, ByVal lpFile As String, lpSecurityAttributes As SECURITY_ATTRIBUTES) As Long
Public Declare Function RegSetValueEx Lib "advapi32.dll" Alias "RegSetValueExA" (ByVal hKey As Long, ByVal lpValueName As String, ByVal Reserved As Long, ByVal dwType As Long, lpData As Any, ByVal cbData As Long) As Long
Public Declare Function RegQueryInfoKey Lib "advapi32.dll" Alias "RegQueryInfoKeyA" (ByVal hKey As Long, ByVal lpClass As String, lpcbClass As Long, ByVal lpReserved As Long, lpcSubKeys As Long, lpcbMaxSubKeyLen As Long, lpcbMaxClassLen As Long, lpcValues As Long, lpcbMaxValueNameLen As Long, lpcbMaxValueLen As Long, lpcbSecurityDescriptor As Long, lpftLastWriteTime As FILETIME) As Long
Public Declare Function RegEnumValue Lib "advapi32.dll" Alias "RegEnumValueA" (ByVal hKey As Long, ByVal dwIndex As Long, ByVal lpValueName As String, lpcbValueName As Long, ByVal lpReserved As Long, lpType As Long, lpData As Byte, lpcbData As Long) As Long
Public Declare Function RegEnumKeyEx Lib "advapi32.dll" Alias "RegEnumKeyExA" (ByVal hKey As Long, ByVal dwIndex As Long, ByVal lpName As String, lpcbName As Long, ByVal lpReserved As Long, ByVal lpClass As String, lpcbClass As Long, lpftLastWriteTime As FILETIME) As Long

Public Declare Function AdjustTokenPrivileges Lib "advapi32.dll" (ByVal TokenHandle As Long, ByVal DisableAllPriv As Long, NewState As TOKEN_PRIVILEGES, ByVal BufferLength As Long, PreviousState As TOKEN_PRIVILEGES, ReturnLength As Long) As Long 'Used to adjust your program's security privileges, can't restore without it!
Public Declare Function LookupPrivilegeValue Lib "advapi32.dll" Alias "LookupPrivilegeValueA" (ByVal lpSystemName As Any, ByVal lpName As String, lpLuid As LUID) As Long 'Returns a valid LUID which is important when making security changes in NT.
Public Declare Function OpenProcessToken Lib "advapi32.dll" (ByVal ProcessHandle As Long, ByVal DesiredAccess As Long, TokenHandle As Long) As Long
Public Declare Function GetCurrentProcess Lib "kernel32" () As Long

Public Declare Function RegCreateKey Lib "advapi32.dll" Alias "RegCreateKeyA" (ByVal hKey As Long, ByVal lpSubKey As String, phkResult As Long) As Long
Public Declare Function RegQueryValueExA Lib "advapi32.dll" (ByVal hKey As Long, ByVal lpValueName As String, ByVal lpReserved As Long, lpType As Long, ByRef lpData As Long, lpcbData As Long) As Long
Public Declare Function RegSetValueExA Lib "advapi32.dll" (ByVal hKey As Long, ByVal lpValueName As String, ByVal Reserved As Long, ByVal dwType As Long, ByRef lpData As Long, ByVal cbData As Long) As Long
Public Declare Function RegSetValueExB Lib "advapi32.dll" Alias "RegSetValueExA" (ByVal hKey As Long, ByVal lpValueName As String, ByVal Reserved As Long, ByVal dwType As Long, ByRef lpData As Byte, ByVal cbData As Long) As Long


'---------------------------------------------------------------
'- 注册表 Api 常数...
'---------------------------------------------------------------
' 注册表创建类型值...
Const REG_OPTION_NON_VOLATILE = 0 ' 当系统重新启动时，关键字被保留

' 注册表关键字安全选项...
Const READ_CONTROL = &H20000
Const KEY_QUERY_VALUE = &H1
Const KEY_SET_VALUE = &H2
Const KEY_CREATE_SUB_KEY = &H4
Const KEY_ENUMERATE_SUB_KEYS = &H8
Const KEY_NOTIFY = &H10
Const KEY_CREATE_LINK = &H20
Const KEY_READ = KEY_QUERY_VALUE + KEY_ENUMERATE_SUB_KEYS + KEY_NOTIFY + READ_CONTROL
Const KEY_WRITE = KEY_SET_VALUE + KEY_CREATE_SUB_KEY + READ_CONTROL
Const KEY_EXECUTE = KEY_READ
Const KEY_ALL_ACCESS = KEY_QUERY_VALUE + KEY_SET_VALUE + KEY_CREATE_SUB_KEY + KEY_ENUMERATE_SUB_KEYS + KEY_NOTIFY + KEY_CREATE_LINK + READ_CONTROL
Const KEY_WOW64_64KEY = &H100 + KEY_ALL_ACCESS

Const ERROR_SUCCESS = 0&
Const ERROR_BADDB = 1009&
Const ERROR_BADKEY = 1010&
Const ERROR_CANTOPEN = 1011&
Const ERROR_CANTREAD = 1012&
Const ERROR_CANTWRITE = 1013&
Const ERROR_OUTOFMEMORY = 14&
Const ERROR_INVALID_PARAMETER = 87&
Const ERROR_ACCESS_DENIED = 5&
Const ERROR_NO_MORE_ITEMS = 259&
Const ERROR_MORE_DATA = 234&

Const REG_NONE = 0&
Const REG_DWORD_LITTLE_ENDIAN = 4&
Const REG_DWORD_BIG_ENDIAN = 5&
Const REG_LINK = 6&
Const REG_RESOURCE_LIST = 8&
Const REG_FULL_RESOURCE_DESCRIPTOR = 9&
Const REG_RESOURCE_REQUIREMENTS_LIST = 10&

Const WRITE_DAC = &H40000
Const WRITE_OWNER = &H80000
Const SYNCHRONIZE = &H100000
Const STANDARD_RIGHTS_REQUIRED = &HF0000
Const STANDARD_RIGHTS_READ = READ_CONTROL
Const STANDARD_RIGHTS_WRITE = READ_CONTROL
Const STANDARD_RIGHTS_EXECUTE = READ_CONTROL

Dim hKey As Long, MainKeyHandle As Long
Dim rtn As Long, lBuffer As Long, sBuffer As String
Dim lBufferSize As Long
Dim lDataSize As Long
Dim ByteArray() As Byte

' 返回值...
Const ERROR_NONE = 0

' 有关导入/导出的常量
Const REG_FORCE_RESTORE As Long = 8&
Const TOKEN_QUERY As Long = &H8&
Const TOKEN_ADJUST_PRIVILEGES As Long = &H20&
Const SE_PRIVILEGE_ENABLED As Long = &H2
Const SE_RESTORE_NAME = "SeRestorePrivilege"
Const SE_BACKUP_NAME = "SeBackupPrivilege"

'---------------------------------------------------------------
'- 注册表类型...
'---------------------------------------------------------------
Private Type SECURITY_ATTRIBUTES
nLength As Long
lpSecurityDescriptor As Long
bInheritHandle As Boolean
End Type

Private Type LUID
lowpart As Long
highpart As Long
End Type

Private Type LUID_AND_ATTRIBUTES
pLuid As LUID
Attributes As Long
End Type

Private Type TOKEN_PRIVILEGES
PrivilegeCount As Long
Privileges As LUID_AND_ATTRIBUTES
End Type

'---------------------------------------------------------------
'- 自定义枚举类型...
'---------------------------------------------------------------
' 注册表数据类型...
Public Enum valuetype
REG_SZ = 1 ' 字符串值
REG_EXPAND_SZ = 2 ' 可扩充字符串值
REG_BINARY = 3 ' 二进制值
REG_DWORD = 4 ' DWORD值
REG_MULTI_SZ = 7 ' 多字符串值
End Enum

' 注册表关键字根类型...
Public Enum KeyRoot
HKEY_CLASSES_ROOT = &H80000000
HKEY_CURRENT_USER = &H80000001
HKEY_LOCAL_MACHINE = &H80000002
HKEY_USERS = &H80000003
HKEY_PERFORMANCE_DATA = &H80000004
HKEY_CURRENT_CONFIG = &H80000005
HKEY_DYN_DATA = &H80000006
End Enum

Private i As Long, j As Long ' 循环变量
Private Success As Long ' API函数的返回值, 判断函数调用是否成功

Const DisplayErrorMsg = False

'-------------------------------------------------------------------------------------------------------------
'- 新建注册表关键字并设置注册表关键字的值...
'- 如果 ValueName 和 Value 都缺省, 则只新建 KeyName 空项, 无子键...
'- 如果只缺省 ValueName 则将设置指定 KeyName 的默认值
'- 参数说明: KeyRoot--根类型, KeyName--子项名称, ValueName--值项名称, Value--值项数据, ValueType--值项类型
'-------------------------------------------------------------------------------------------------------------
Public Function SetKeyValue(KeyRoot As KeyRoot, Keyname As String, Optional ValueName As String, Optional Value As Variant = "", Optional valuetype As valuetype = REG_SZ) As Boolean
Dim lpAttr As SECURITY_ATTRIBUTES ' 注册表安全类型
lpAttr.nLength = 50 ' 设置安全属性为缺省值...
lpAttr.lpSecurityDescriptor = 0 ' ...
lpAttr.bInheritHandle = True ' ...

' 新建注册表关键字...
Success = RegCreateKeyEx(KeyRoot, Keyname, 0, valuetype, REG_OPTION_NON_VOLATILE, KEY_ALL_ACCESS, lpAttr, hKey, 0)
If Success <> ERROR_SUCCESS Then SetKeyValue = False: RegCloseKey hKey: Exit Function

' 设置注册表关键字的值...
If IsMissing(ValueName) = False Then
Select Case valuetype
Case REG_SZ, REG_EXPAND_SZ, REG_MULTI_SZ
Success = RegSetValueEx(hKey, ValueName, 0, valuetype, ByVal CStr(Value), LenB(StrConv(Value, vbFromUnicode)) + 1)
Case REG_DWORD
If CDbl(Value) <= 4294967295# And CDbl(Value) >= 0 Then
Dim sValue As String
sValue = DoubleToHex(Value)
Dim dValue(3) As Byte
dValue(0) = Format("&h" & Mid(sValue, 7, 2))
dValue(1) = Format("&h" & Mid(sValue, 5, 2))
dValue(2) = Format("&h" & Mid(sValue, 3, 2))
dValue(3) = Format("&h" & Mid(sValue, 1, 2))
Success = RegSetValueEx(hKey, ValueName, 0, valuetype, dValue(0), 4)
Else
Success = ERROR_BADKEY
End If
Case REG_BINARY
On Error Resume Next
Success = 1 ' 假设调用API不成功(成功返回0)
ReDim tmpValue(UBound(Value)) As Byte
For i = 0 To UBound(tmpValue)
tmpValue(i) = Value(i)
Next i
Success = RegSetValueEx(hKey, ValueName, 0, valuetype, tmpValue(0), UBound(Value) + 1)
End Select
End If
If Success <> ERROR_SUCCESS Then SetKeyValue = False: RegCloseKey hKey: Exit Function

' 关闭注册表关键字...
RegCloseKey hKey
SetKeyValue = True ' 返回函数值
End Function

'-------------------------------------------------------------------------------------------------------------
'- 获得已存在的注册表关键字的值...
'- 如果 ValueName="" 则返回 KeyName 项的默认值...
'- 如果指定的注册表关键字不存在, 则返回空串...
'- 参数说明: KeyRoot--根类型, KeyName--子项名称, ValueName--值项名称, ValueType--值项类型
'-------------------------------------------------------------------------------------------------------------
Public Function GetKeyValue(KeyRoot As KeyRoot, Keyname As String, ValueName As String, Optional valuetype As Long) As String
Dim TempValue As String ' 注册表关键字的临时值
Dim Value As String ' 注册表关键字的值
Dim ValueSize As Long ' 注册表关键字的值的实际长度
TempValue = Space(1024) ' 存储注册表关键字的临时值的缓冲区
ValueSize = 1024 ' 设置注册表关键字的值的默认长度

' 打开一个已存在的注册表关键字...
RegOpenKeyEx KeyRoot, Keyname, 0, KEY_ALL_ACCESS, hKey

' 获得已打开的注册表关键字的值...
RegQueryValueEx hKey, ValueName, 0, valuetype, ByVal TempValue, ValueSize

' 返回注册表关键字的的值...
Select Case valuetype ' 通过判断关键字的类型, 进行处理
Case REG_SZ, REG_MULTI_SZ, REG_EXPAND_SZ
TempValue = Left$(TempValue, ValueSize - 1) ' 去掉TempValue尾部空格
Value = TempValue
Case REG_DWORD
ReDim dValue(3) As Byte
RegQueryValueEx hKey, ValueName, 0, REG_DWORD, dValue(0), ValueSize
For i = 3 To 0 Step -1
Value = Value + String(2 - Len(Hex(dValue(i))), "0") + Hex(dValue(i)) ' 生成长度为8的十六进制字符串
Next i
If CDbl("&H" & Value) < 0 Then ' 将十六进制的 Value 转换为十进制
Value = 2 ^ 32 + CDbl("&H" & Value)
Else
Value = CDbl("&H" & Value)
End If
Case REG_BINARY
If ValueSize > 0 Then
ReDim bValue(ValueSize - 1) As Byte ' 存储 REG_BINARY 值的临时数组
RegQueryValueEx hKey, ValueName, 0, REG_BINARY, bValue(0), ValueSize
For i = 0 To ValueSize - 1
Value = Value + String(2 - Len(Hex(bValue(i))), "0") + Hex(bValue(i)) + " " ' 将数组转换成字符串
Next i
End If
End Select

' 关闭注册表关键字...
RegCloseKey hKey
GetKeyValue = Trim(Value) ' 返回函数值
End Function

'-------------------------------------------------------------------------------------------------------------
'- 删除已存在的注册表关键字的值...
'- 如果指定的注册表关键字不存在, 则不做任何操作...
'- 参数说明: KeyRoot--根类型, KeyName--子项名称, ValueName--值项名称
'-------------------------------------------------------------------------------------------------------------
Public Function DeleteKey(KeyRoot As KeyRoot, Keyname As String, Optional ValueName As String) As Boolean
Dim tmpKeyName As String ' 注册表关键字的临时子项名称
Dim tmpValueName As String ' 注册表关键字的临时子键名称

' 打开一个已存在的注册表关键字...
Success = RegOpenKeyEx(KeyRoot, Keyname, 0, KEY_ALL_ACCESS, hKey)
If Success <> ERROR_SUCCESS Then DeleteKey = False: RegCloseKey hKey: Exit Function

' 删除已打开的注册表关键字...
tmpKeyName = ""
tmpValueName = Keyname
If ValueName = "" Then ' 判断ValueName是否缺省, 如缺省作相应处理
If InStrRev(Keyname, "\") > 1 Then
tmpValueName = Right(Keyname, InStrRev(Keyname, "\") + 1)
tmpKeyName = Left(Keyname, InStrRev(Keyname, "\") - 1)
End If
Success = RegOpenKeyEx(KeyRoot, tmpKeyName, 0, KEY_ALL_ACCESS, hKey)
Success = RegDeleteKey(hKey, tmpValueName)
Else
Success = RegDeleteValue(hKey, ValueName)
End If
If Success <> ERROR_SUCCESS Then DeleteKey = False: RegCloseKey hKey: Exit Function

' 关闭注册表关键字...
RegCloseKey hKey
DeleteKey = True ' 返回函数值
End Function

'-------------------------------------------------------------------------------------------------------------
'- 获得注册表关键字的一些信息...
'- SubKeyName() 注册表关键字的所有子项的名称(注意:最小下标为0)
'- ValueName() 注册表关键字的所有子键的名称(注意:最小下标为0)
'- ValueType() 注册表关键字的所有子键的类型(注意:最小下标为0)
'- CountKey 注册表关键字的子项数量
'- CountValue 注册表关键字的子键数量
'- MaxLenKey 注册表关键字的子项名称的最大长度
'- MaxLenValue 注册表关键字的子键名称的最大长度
'-------------------------------------------------------------------------------------------------------------
Public Function GetKeyInfo(KeyRoot As KeyRoot, Keyname As String, _
SubKeyName() As String, ValueName() As String, valuetype() As Long, _
Optional CountKey As Long, Optional CountValue As Long, Optional MaxLenKey As Long, Optional MaxLenValue As Long) As Boolean



Dim f As FILETIME
Dim l As Long, s As String

' 打开一个已存在的注册表关键字...
Success = RegOpenKeyEx(KeyRoot, Keyname, 0, KEY_READ Or KEY_WOW64_64KEY, hKey)
If Success <> ERROR_SUCCESS Then GetKeyInfo = False: RegCloseKey hKey: Exit Function

' 获得一个已打开的注册表关键字的信息...
Success = RegQueryInfoKey(hKey, vbNullString, ByVal 0&, ByVal 0&, CountKey, MaxLenKey, ByVal 0&, CountValue, MaxLenValue, ByVal 0&, ByVal 0&, f)
If Success <> ERROR_SUCCESS Then GetKeyInfo = False: RegCloseKey hKey: Exit Function

If CountKey <> 0 Then
ReDim SubKeyName(CountKey - 1) As String ' 重新定义数组, 使用数组大小与注册表关键字的子项数量匹配
For i = 0 To CountKey - 1
SubKeyName(i) = Space(255)
l = 255
RegEnumKeyEx hKey, i, ByVal SubKeyName(i), l, 0, vbNullString, ByVal 0&, f
SubKeyName(i) = Left(SubKeyName(i), l)
Next i

' 下面的二重循环对字符串数组进行冒泡排序
For i = 0 To UBound(SubKeyName)
For j = i + 1 To UBound(SubKeyName)
If SubKeyName(i) > SubKeyName(j) Then
s = SubKeyName(i)
SubKeyName(i) = SubKeyName(j)
SubKeyName(j) = s
End If
Next j
Next i
End If

If CountValue <> 0 Then
ReDim ValueName(CountValue - 1) As String ' 重新定义数组, 使用数组大小与注册表关键字的子键数量匹配
ReDim valuetype(CountValue - 1) As Long ' 重新定义数组, 使用数组大小与注册表关键字的子键数量匹配
For i = 0 To CountValue - 1
ValueName(i) = Space(255)
l = 255
RegEnumValue hKey, i, ByVal ValueName(i), l, 0, valuetype(i), ByVal 0&, ByVal 0&
ValueName(i) = Left(ValueName(i), l)
Next i

' 下面的二重循环对字符串数组进行冒泡排序
For i = 0 To UBound(ValueName)
For j = i + 1 To UBound(ValueName)
If ValueName(i) > ValueName(j) Then
s = ValueName(i)
ValueName(i) = ValueName(j)
ValueName(j) = s
End If
Next j
Next i
End If

' 关闭注册表关键字...
RegCloseKey hKey
GetKeyInfo = True ' 返回函数值
End Function

'-------------------------------------------------------------------------------------------------------------
'- 导出注册表关键字的值
'- 参数说明: KeyRoot--根类型, KeyName--子项名称, FileName--导出的文件路径及文件名(原始数据库格式)
'-------------------------------------------------------------------------------------------------------------
Public Function SaveKey(KeyRoot As KeyRoot, Keyname As String, FileName As String) As Boolean
On Error Resume Next

Dim lpAttr As SECURITY_ATTRIBUTES ' 注册表安全类型
lpAttr.nLength = 50 ' 设置安全属性为缺省值...
lpAttr.lpSecurityDescriptor = 0 ' ...
lpAttr.bInheritHandle = True ' ...

If EnablePrivilege(SE_BACKUP_NAME) = False Then
SaveKey = False
Exit Function
End If

Success = RegOpenKeyEx(KeyRoot, Keyname, 0&, KEY_ALL_ACCESS, hKey)
If Success <> 0 Then
SaveKey = False
Success = RegCloseKey(hKey)
Exit Function
End If

Success = RegSaveKey(hKey, FileName, lpAttr)
If Success = 0 Then SaveKey = True Else SaveKey = False

Success = RegCloseKey(hKey)
End Function

'-------------------------------------------------------------------------------------------------------------
'- 导入注册表关键字的值
'- 参数说明: KeyRoot--根类型, KeyName--子项名称, FileName--导入的文件路径及文件名(原始数据库格式)
'-------------------------------------------------------------------------------------------------------------
Public Function RestoreKey(KeyRoot As KeyRoot, Keyname As String, FileName As String) As Boolean
On Error Resume Next

If EnablePrivilege(SE_RESTORE_NAME) = False Then
RestoreKey = False
Exit Function
End If

Success = RegOpenKeyEx(KeyRoot, Keyname, 0&, KEY_ALL_ACCESS, hKey)
If Success <> 0 Then
RestoreKey = False
Success = RegCloseKey(hKey)
Exit Function
End If

Success = RegRestoreKey(hKey, FileName, REG_FORCE_RESTORE)
If Success = 0 Then RestoreKey = True Else RestoreKey = False

Success = RegCloseKey(hKey)
End Function

'-------------------------------------------------------------------------------------------------------------
'- 使注册表允许导入/导出
'-------------------------------------------------------------------------------------------------------------
Private Function EnablePrivilege(seName As String) As Boolean
On Error Resume Next

Dim p_lngRtn As Long
Dim p_lngToken As Long
Dim p_lngBufferLen As Long
Dim p_typLUID As LUID
Dim p_typTokenPriv As TOKEN_PRIVILEGES
Dim p_typPrevTokenPriv As TOKEN_PRIVILEGES

p_lngRtn = OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, p_lngToken)
If p_lngRtn = 0 Then
EnablePrivilege = False
Exit Function
End If
If Err.LastDllError <> 0 Then
EnablePrivilege = False
Exit Function
End If

p_lngRtn = LookupPrivilegeValue(0&, seName, p_typLUID)
If p_lngRtn = 0 Then
EnablePrivilege = False
Exit Function
End If

p_typTokenPriv.PrivilegeCount = 1
p_typTokenPriv.Privileges.Attributes = SE_PRIVILEGE_ENABLED
p_typTokenPriv.Privileges.pLuid = p_typLUID

EnablePrivilege = (AdjustTokenPrivileges(p_lngToken, False, p_typTokenPriv, Len(p_typPrevTokenPriv), p_typPrevTokenPriv, p_lngBufferLen) <> 0)
End Function

'-------------------------------------------------------------------------------------------------------------
'- 将 Double 型( 限制在 0--2^32-1 )的数字转换为十六进制并在前面补零
'- 参数说明: Number--要转换的 Double 型数字
'-------------------------------------------------------------------------------------------------------------
Private Function DoubleToHex(ByVal Number As Double) As String
Dim strHex As String
strHex = Space(8)
For i = 1 To 8
Select Case Number - Int(Number / 16) * 16
Case 10
Mid(strHex, 9 - i, 1) = "A"
Case 11
Mid(strHex, 9 - i, 1) = "B"
Case 12
Mid(strHex, 9 - i, 1) = "C"
Case 13
Mid(strHex, 9 - i, 1) = "D"
Case 14
Mid(strHex, 9 - i, 1) = "E"
Case 15
Mid(strHex, 9 - i, 1) = "F"
Case Else
Mid(strHex, 9 - i, 1) = CStr(Number - Int(Number / 16) * 16)
End Select
Number = Int(Number / 16)
Next i
DoubleToHex = strHex
End Function



Function SetDWORDValue(SubKey As String, Entry As String, Value As Long)

Call ParseKey(SubKey, MainKeyHandle)

If MainKeyHandle Then
   rtn = RegOpenKeyEx(MainKeyHandle, SubKey, 0, KEY_WRITE, hKey) 'open the key '打开键
   If rtn = ERROR_SUCCESS Then 'if the key was open successfully then '如果键成功打开,那么
      rtn = RegSetValueExA(hKey, Entry, 0, REG_DWORD, Value, 4) 'write the value '写入值
      If Not rtn = ERROR_SUCCESS Then   'if there was an error writting the value '如果写入值发生错误
         If DisplayErrorMsg = True Then 'if the user want errors displayed '如果用户想显示错误
            MsgBox ErrorMsg(rtn)        'display the error '显示错误
         End If
      End If
      rtn = RegCloseKey(hKey) 'close the key '关闭键
   Else 'if there was an error opening the key '如果打开键时发生错误
      If DisplayErrorMsg = True Then 'if the user want errors displayed 如果用户想显示错误
         MsgBox ErrorMsg(rtn) 'display the error '显示错误
      End If
   End If
End If

End Function

Function GetDWORDValue(SubKey As String, Entry As String)

Call ParseKey(SubKey, MainKeyHandle)

If MainKeyHandle Then
   rtn = RegOpenKeyEx(MainKeyHandle, SubKey, 0, KEY_READ, hKey) 'open the key '打开键
   If rtn = ERROR_SUCCESS Then 'if the key could be opened then '如果键能被打开,那么
      rtn = RegQueryValueExA(hKey, Entry, 0, REG_DWORD, lBuffer, 4) 'get the value from the registry '从注册表中得到键值
      If rtn = ERROR_SUCCESS Then 'if the value could be retreived then '如果键值能被获取,那么
         rtn = RegCloseKey(hKey) 'close the key '关闭键
         GetDWORDValue = lBuffer 'return the value 返回键值
      Else                        'otherwise, if the value couldnt be retreived '否则,如果键值不能被获取
         GetDWORDValue = "Error" 'return Error to the user '返回错误给用户
         If DisplayErrorMsg = True Then 'if the user wants errors displayed '如果用户想显示错误
            MsgBox ErrorMsg(rtn)        'tell the user what was wrong '告知用户出了什么错
         End If
      End If
   Else 'otherwise, if the key couldnt be opened '否则,如果键不能被打开
      GetDWORDValue = "Error"        'return Error to the user '返回错误给用户
      If DisplayErrorMsg = True Then 'if the user wants errors displayed '如果用户想显示错误
         MsgBox ErrorMsg(rtn)        'tell the user what was wrong '告知用户出了什么错
      End If
   End If
End If

End Function

Function SetBinaryValue(SubKey As String, Entry As String, Value As String)

Call ParseKey(SubKey, MainKeyHandle)

If MainKeyHandle Then
   rtn = RegOpenKeyEx(MainKeyHandle, SubKey, 0, KEY_WRITE, hKey) 'open the key '打开键
   If rtn = ERROR_SUCCESS Then 'if the key was open successfully then '如果键成功打开,那么
      lDataSize = Len(Value)
      ReDim ByteArray(lDataSize)
      For i = 1 To lDataSize
      ByteArray(i) = Asc(Mid$(Value, i, 1))
      Next
      rtn = RegSetValueExB(hKey, Entry, 0, REG_BINARY, ByteArray(1), lDataSize) 'write the value
      If Not rtn = ERROR_SUCCESS Then   'if the was an error writting the value '如果键成功打开,那么
         If DisplayErrorMsg = True Then 'if the user want errors displayed '如果用户想显示错误
            MsgBox ErrorMsg(rtn)        'display the error '显示错误
         End If
      End If
      rtn = RegCloseKey(hKey) 'close the key '关闭键
   Else 'if there was an error opening the key '如果打开键时发生错误
      If DisplayErrorMsg = True Then 'if the user wants errors displayed '如果用户想显示错误
         MsgBox ErrorMsg(rtn) 'display the error '显示错误
      End If
   End If
End If

End Function


Function GetBinaryValue(SubKey As String, Entry As String)

Call ParseKey(SubKey, MainKeyHandle)

If MainKeyHandle Then
   rtn = RegOpenKeyEx(MainKeyHandle, SubKey, 0, KEY_READ, hKey) 'open the key '打开键
   If rtn = ERROR_SUCCESS Then 'if the key could be opened '如果键能被打开
      lBufferSize = 1
      rtn = RegQueryValueEx(hKey, Entry, 0, REG_BINARY, 0, lBufferSize) 'get the value from the registry '从注册表得到键值
      sBuffer = Space(lBufferSize)
      rtn = RegQueryValueEx(hKey, Entry, 0, REG_BINARY, sBuffer, lBufferSize) 'get the value from the registry '从注册表得到键值
      If rtn = ERROR_SUCCESS Then 'if the value could be retreived then '如果键值能被获取,那么
         rtn = RegCloseKey(hKey) 'close the key '关闭键
         GetBinaryValue = sBuffer 'return the value to the user '返回错误给用户
      Else                        'otherwise, if the value couldnt be retreived '否则,如果键值不能被获取
         GetBinaryValue = "Error" 'return Error to the user '返回错误给用户
         If DisplayErrorMsg = True Then 'if the user wants to errors displayed '如果用户想显示错误
            MsgBox ErrorMsg(rtn) 'display the error to the user '显示错误
         End If
      End If
   Else 'otherwise, if the key couldnt be opened '否则,如果键不能被打开
      GetBinaryValue = "Error" 'return Error to the user '返回错误给用户
      If DisplayErrorMsg = True Then 'if the user wants to errors displayed '如果用户想显示错误
         MsgBox ErrorMsg(rtn) 'display the error to the user '显示错误
      End If
   End If
End If

End Function

Function GetMainKeyHandle(MainKeyName As String) As Long

Const HKEY_CLASSES_ROOT = &H80000000
Const HKEY_CURRENT_USER = &H80000001
Const HKEY_LOCAL_MACHINE = &H80000002
Const HKEY_USERS = &H80000003
Const HKEY_PERFORMANCE_DATA = &H80000004
Const HKEY_CURRENT_CONFIG = &H80000005
Const HKEY_DYN_DATA = &H80000006
   
Select Case MainKeyName
       Case "HKEY_CLASSES_ROOT"
            GetMainKeyHandle = HKEY_CLASSES_ROOT
       Case "HKEY_CURRENT_USER"
            GetMainKeyHandle = HKEY_CURRENT_USER
       Case "HKEY_LOCAL_MACHINE"
            GetMainKeyHandle = HKEY_LOCAL_MACHINE
       Case "HKEY_USERS"
            GetMainKeyHandle = HKEY_USERS
       Case "HKEY_PERFORMANCE_DATA"
            GetMainKeyHandle = HKEY_PERFORMANCE_DATA
       Case "HKEY_CURRENT_CONFIG"
            GetMainKeyHandle = HKEY_CURRENT_CONFIG
       Case "HKEY_DYN_DATA"
            GetMainKeyHandle = HKEY_DYN_DATA
End Select

End Function

Function ErrorMsg(lErrorCode As Long) As String
    
'If an error does accurr, and the user wants error messages displayed, then
'如果一个错误发生了,且用户想显示错误信息,那么
'display one of the following error messages
'显示以下错误信息之一


'Select Case lErrorCode
'       Case 1009, 1015
'            GetErrorMsg = "注册表数据库已损坏!(The Registry Database is corrupt!)"
'       Case 2, 1010
'            GetErrorMsg = "错误键名(Bad Key Name)"
'       Case 1011
'            GetErrorMsg = "无法打开键(Can't Open Key)"
'       Case 4, 1012
'            GetErrorMsg = "无法读取键(Can't Read Key)"
'       Case 5
'            GetErrorMsg = "存取此键被拒绝(Access to this key is denied)"
'       Case 1013
'            GetErrorMsg = "无法写入键(Can't Write Key)"
'       Case 8, 14
'            GetErrorMsg = "内存不足(Out of memory)"
'       Case 87
'            GetErrorMsg = "错漏的参数(Invalid Parameter)"
'       Case 234
'            GetErrorMsg = "缓冲器内太多数据等待被分配.(There is more data than the buffer has been allocated to hold.)"
'       Case Else
'            GetErrorMsg = "不明错误代码:" & Str$(lErrorCode) & "(Undefined Error Code: " & Str$(lErrorCode) & ")"
'End Select

End Function

Function GetStringValue(SubKey As String, Entry As String)

Call ParseKey(SubKey, MainKeyHandle)

If MainKeyHandle Then
   rtn = RegOpenKeyEx(MainKeyHandle, SubKey, 0, KEY_READ Or KEY_WOW64_64KEY, hKey) 'open the key '打开键
   If rtn = ERROR_SUCCESS Then 'if the key could be opened then '如果键能被打开,那么
      sBuffer = Space(255)     'make a buffer '创建一个缓冲
      lBufferSize = Len(sBuffer)
      rtn = RegQueryValueEx(hKey, Entry, 0, REG_SZ, sBuffer, lBufferSize) 'get the value from the registry '从注册表中得到键值
      If rtn = ERROR_SUCCESS Then 'if the value could be retreived then '如果键值能被获取,那么
         rtn = RegCloseKey(hKey) 'close the key '关闭键
         sBuffer = Trim(sBuffer)
         GetStringValue = Left(sBuffer, Len(sBuffer) - 1) 'return the value to the user '返回键值给用户
      Else                        'otherwise, if the value couldnt be retreived '否则,如果键无法被获取
         GetStringValue = "Error" 'return Error to the user '返回错误给用户
         If DisplayErrorMsg = True Then 'if the user wants errors displayed then '如果用户想显示错误信息,那么
            MsgBox ErrorMsg(rtn) 'tell the user what was wrong '告知用户出了什么错
         End If
      End If
   Else 'otherwise, if the key couldnt be opened '否则,如果键无法被打开
      GetStringValue = "Error"       'return Error to the user '返回错误给用户
      If DisplayErrorMsg = True Then 'if the user wants errors displayed then '如果用户想显示错误,那么
         MsgBox ErrorMsg(rtn)        'tell the user what was wrong '告知用户出了什么错
      End If
   End If
End If

End Function

Private Sub ParseKey(Keyname As String, Keyhandle As Long)
    
rtn = InStr(Keyname, "\") 'return if "\" is contained in the Keyname '返回如果键名中包含"\"

If Left(Keyname, 5) <> "HKEY_" Or Right(Keyname, 1) = "\" Then 'if the is a "\" at the end of the Keyname then '如果"\"出现在键名结尾
   MsgBox "Incorrect Format:" + Chr(10) + Chr(10) + Keyname 'display error to the user '显示错误给用户
   Exit Sub 'exit the procedure '退出程序
ElseIf rtn = 0 Then 'if the Keyname contains no "\" '如果键名没包含"\"
   Keyhandle = GetMainKeyHandle(Keyname)
   Keyname = "" 'leave Keyname blank '让键名留空
Else 'otherwise, Keyname contains "\" '另外,键名包含"\"
   Keyhandle = GetMainKeyHandle(Left(Keyname, rtn - 1)) 'seperate the Keyname '分离键名
   Keyname = Right(Keyname, Len(Keyname) - rtn)
End If

End Sub
Function CreateKey(SubKey As String)

Call ParseKey(SubKey, MainKeyHandle)

If MainKeyHandle Then
   rtn = RegCreateKey(MainKeyHandle, SubKey, hKey) 'create the key '创建键
   If rtn = ERROR_SUCCESS Then 'if the key was created then '如果键被创建
      rtn = RegCloseKey(hKey) 'close the key '关闭键
   End If
End If

End Function
Function SetStringValue(SubKey As String, Entry As String, Value As String)

Call ParseKey(SubKey, MainKeyHandle)

If MainKeyHandle Then
   rtn = RegOpenKeyEx(MainKeyHandle, SubKey, 0, KEY_WRITE, hKey) 'open the key '打开键
   If rtn = ERROR_SUCCESS Then 'if the key was open successfully then '如果键被成功打开
      rtn = RegSetValueEx(hKey, Entry, 0, REG_SZ, ByVal Value, Len(Value)) 'write the value '写入值
      If Not rtn = ERROR_SUCCESS Then   'if there was an error writting the value '如果写入值时发生错误
         If DisplayErrorMsg = True Then 'if the user wants errors displayed '如果用户想显示错误
            MsgBox ErrorMsg(rtn)        'display the error '显示错误
         End If
      End If
      rtn = RegCloseKey(hKey) 'close the key '关闭键
   Else 'if there was an error opening the key '如果打开键时发生错误
      If DisplayErrorMsg = True Then 'if the user wants errors displayed '如果用户想显示错误
         MsgBox ErrorMsg(rtn)        'display the error '显示错误
      End If
   End If
End If

End Function

