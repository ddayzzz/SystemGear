Attribute VB_Name = "SaveImage"
Private Type GUID
     Data1 As Long
     Data2 As Integer
     Data3 As Integer
     Data4(0 To 7) As Byte
End Type
Private Type GdiplusStartupInput
     GdiplusVersion As Long
     DebugEventCallback As Long
     SuppressBackgroundThread As Long
     SuppressExternalCodecs As Long
End Type
Private Type EncoderParameter
     GUID As GUID
     NumberOfValues As Long
     type As Long
     Value As Long
End Type
Private Type EncoderParameters
     count As Long
     Parameter As EncoderParameter
End Type
Private Declare Function GdiplusStartup Lib "GDIPlus" (token As Long, inputbuf As GdiplusStartupInput, Optional ByVal outputbuf As Long = 0) As Long
Private Declare Function GdiplusShutdown Lib "GDIPlus" (ByVal token As Long) As Long
Private Declare Function GdipCreateBitmapFromHBITMAP Lib "GDIPlus" (ByVal hbm As Long, ByVal hPal As Long, BITMAP As Long) As Long
Private Declare Function GdipDisposeImage Lib "GDIPlus" (ByVal Image As Long) As Long
Private Declare Function GdipSaveImageToFile Lib "GDIPlus" (ByVal Image As Long, ByVal FileName As Long, clsidEncoder As GUID, encoderParams As Any) As Long
Private Declare Function CLSIDFromString Lib "ole32" (ByVal Str As Long, id As GUID) As Long
Private Declare Function CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (Dest As Any, Src As Any, ByVal cb As Long) As Long


'*************************************************************************
 '**    作    者 ：    laviewpbt
 '**    函 数 名 ：    SavePic
 '**    输    入 ：    pic(StdPicture)        -   图象句柄
'**             ：    FileName(String)       -   保存路径
'**             ：    Quality(Byte)          -   JPG图象质量
'**             ：    TIFF_ColorDepth(Long)  -   TTF格式的颜色深度
'**             ：    TIFF_Compression(Long) -   TTF格式的压缩比
'**    输    出 ：    无
'**    功能描述 ：    把图象保存为JPG、TIFF、PNG、GIF、BMP格式
'**    日    期 ：
'**    修 改 人 ：    laviewpbt
 '**    日    期 ：    2005-10-23 14.43.52
 '**    版    本 ：    Version 1.2.1
 '*************************************************************************
Public Sub SavePic(ByVal pict As StdPicture, ByVal FileName As String, PicType As String, _
                     Optional ByVal Quality As Byte = 80, _
                     Optional ByVal TIFF_ColorDepth As Long = 24, _
                     Optional ByVal TIFF_Compression As Long = 6)
    Screen.MousePointer = vbHourglass
    Dim tSI As GdiplusStartupInput
    Dim lRes As Long
    Dim lGDIP As Long
    Dim lBitmap As Long
    Dim aEncParams() As Byte
    On Error GoTo ErrHandle:
    tSI.GdiplusVersion = 1   ' 初始化 GDI+
   lRes = GdiplusStartup(lGDIP, tSI)
    If lRes = 0 Then     ' 从句柄创建 GDI+ 图像
      lRes = GdipCreateBitmapFromHBITMAP(pict.Handle, 0, lBitmap)
       If lRes = 0 Then
          Dim tJpgEncoder As GUID
          Dim tParams As EncoderParameters    '初始化解码器的GUID标识
         Select Case LCase(PicType)
          Case ".jpg"
             CLSIDFromString StrPtr("{557CF401-1A04-11D3-9A73-0000F81EF32E}"), tJpgEncoder
             tParams.count = 1                               ' 设置解码器参数
            With tParams.Parameter ' Quality
               CLSIDFromString StrPtr("{1D5BE4B5-FA4A-452D-9CDD-5DB35105E7EB}"), .GUID    ' 得到Quality参数的GUID标识
               .NumberOfValues = 1
                .type = 4
                .Value = VarPtr(Quality)
             End With
             ReDim aEncParams(1 To Len(tParams))
             Call CopyMemory(aEncParams(1), tParams, Len(tParams))
         Case ".png"
              CLSIDFromString StrPtr("{557CF406-1A04-11D3-9A73-0000F81EF32E}"), tJpgEncoder
              ReDim aEncParams(1 To Len(tParams))
         Case ".gif"
              CLSIDFromString StrPtr("{557CF402-1A04-11D3-9A73-0000F81EF32E}"), tJpgEncoder
              ReDim aEncParams(1 To Len(tParams))
         Case ".tiff"
              CLSIDFromString StrPtr("{557CF405-1A04-11D3-9A73-0000F81EF32E}"), tJpgEncoder
              tParams.count = 2
              ReDim aEncParams(1 To Len(tParams) + Len(tParams.Parameter))
              With tParams.Parameter
                 .NumberOfValues = 1
                 .type = 4
                  CLSIDFromString StrPtr("{E09D739D-CCD4-44EE-8EBA-3FBF8BE4FC58}"), .GUID    ' 得到ColorDepth参数的GUID标识
                .Value = VarPtr(TIFF_Compression)
             End With
             Call CopyMemory(aEncParams(1), tParams, Len(tParams))
             With tParams.Parameter
                 .NumberOfValues = 1
                 .type = 4
                  CLSIDFromString StrPtr("{66087055-AD66-4C7C-9A18-38A2310B8337}"), .GUID    ' 得到Compression参数的GUID标识
                .Value = VarPtr(TIFF_ColorDepth)
             End With
             Call CopyMemory(aEncParams(Len(tParams) + 1), tParams.Parameter, Len(tParams.Parameter))
         Case ".bmp"                                               '可以提前写保存为BMP的代码，因为并没有用GDI+
            SavePicture pict, FileName
             Screen.MousePointer = vbDefault
             Exit Sub
         End Select
          lRes = GdipSaveImageToFile(lBitmap, StrPtr(FileName), tJpgEncoder, aEncParams(1))           '保存图像
         GdipDisposeImage lBitmap       ' 销毁GDI+图像
      End If
       GdiplusShutdown lGDIP              '销毁 GDI+
   End If
    Screen.MousePointer = vbDefault
    Erase aEncParams
    Exit Sub
ErrHandle:
     Screen.MousePointer = vbDefault
     MsgBox "在保存图片的过程中发生错误:" & vbCrLf & vbCrLf & "错误号:  " & Err.Number & vbCrLf & "错误描述:  " & Err.Description, vbInformation Or vbOKOnly, "错误"
End Sub

