::@echo off
setlocal
set regkey="HKEY_CURRENT_USER\Software\SoraArt\Unity2DPerson"
reg add %regkey% /v "Screenmanager Resolution Width_h182942802" /T REG_DWORD /D 1920 /f
reg add %regkey% /v "Screenmanager Resolution Height_h2627697771" /T REG_DWORD /D 1080 /f
endlocal
::echo on