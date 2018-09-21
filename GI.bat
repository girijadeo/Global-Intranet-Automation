
cd C:\Users\%username%\AppData\Local
del %TEMP%\*.* /f /s /q


REM VS needs to be installed. Modify %VS140COMNTOOLS% according to your VS version, 14 == Visual Studio 2015
CALL "%VS120COMNTOOLS%\vsvars32.bat"

REM Modify according to the root folder where the source code has been checked out, I.E. where the SLN file of the project lives

D:
CD D:\GI-Execution-CI-Chrome\CRAFT - Selenium(.NET) 2.0

msbuild CRAFT_Selenium2.0.sln /p:Configuration=Release /t:Clean,Build



vstest.console.exe bin\Release\CRAFT_Selenium2.0.dll /TestCaseFilter:"TestCategory=GI"




