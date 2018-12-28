# SystemGear Project
- SystemGear v3.x source codes and its component's source codes. The lastest version is v3.0.0.1210(Beta 2) which is avaiable in `release` tag. 
- Because I have written this project since I took over this original project named `MagicGear` from my buddy [Mooction](https://moooc.cc) when I was a junior school student(2011), this is a lite version of SystemGear.
# Features
1. SystemGear is written in C# and it use many WIN32 APIs to implement:
- modification of desktop icon, folder icon, extension icon and so on.
- show system dialogs(especially choose icon dialog)
- change registery settings and read configuration data(*.ini format)
- read mui file using WIN32 to show multi-locale languages in different system.
# Components
- ClipboardMgr: save clip board content from memory to file(only support text and image).
- SGShell: execute program(as admin).
- WinImageTool: a GUI utility based on `imagex` which offer a friendly interface for user to use.
- VDISKOP: a virtual disk utility.
- UpdateResources: update resources of WIN32 dynamic library.
# Not include
1. old codes(previous version, because it costs many space to store the trivial codes, redundancy backups and unnecessary executables).
2. design image and icon resources.
3. documents for design.
# Acknowledgement
1. [Mooction](https://moooc.cc/)
2. [Ruanmei Mofang](https://mofang.ruanmei.com/)
3. Microsoft Windows documents