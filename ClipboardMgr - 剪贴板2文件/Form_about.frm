VERSION 5.00
Begin VB.Form Form_about 
   BackColor       =   &H00FFFFFF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "¹ØÓÚ"
   ClientHeight    =   2010
   ClientLeft      =   45
   ClientTop       =   390
   ClientWidth     =   9390
   BeginProperty Font 
      Name            =   "Î¢ÈíÑÅºÚ"
      Size            =   9
      Charset         =   134
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "Form_about.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   134
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   626
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  '´°¿ÚÈ±Ê¡
   Begin VB.CommandButton Command_clear 
      Caption         =   "¹Ù·½ÍøÕ¾"
      Height          =   495
      Left            =   7440
      TabIndex        =   2
      Top             =   600
      Width           =   1575
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      Caption         =   "°æÈ¨ËùÓÐ(C)2014.Refexon.All Rights Reserved."
      BeginProperty Font 
         Name            =   "Î¢ÈíÑÅºÚ"
         Size            =   9
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   360
      TabIndex        =   1
      Top             =   1440
      Width           =   4080
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      BackColor       =   &H00FFFFFF&
      Caption         =   "V1.0"
      BeginProperty Font 
         Name            =   "Î¢ÈíÑÅºÚ"
         Size            =   9
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   3840
      TabIndex        =   0
      Top             =   720
      Width           =   390
   End
   Begin VB.Image Image2 
      Height          =   795
      Left            =   1320
      Picture         =   "Form_about.frx":08CA
      Top             =   360
      Width           =   2595
   End
   Begin VB.Image Image1 
      Height          =   960
      Left            =   240
      Picture         =   "Form_about.frx":197B
      Top             =   240
      Width           =   960
   End
End
Attribute VB_Name = "Form_about"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
