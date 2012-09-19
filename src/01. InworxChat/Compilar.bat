@echo off
cls
csc.exe /out:bin\Server.dll /target:library Client.cs Message.cs Server.cs User.cs
csc.exe /out:bin\ServerUI.exe /target:exe /reference:bin\Server.dll ServerUI.cs
csc.exe /out:bin\ClientUI.exe /target:exe ClientUI.cs