@echo off
rem RenameMsi.bat "C:\Zdrojaky\VB\Helixoft\VSdocman\VS2005\VSdocman\VSdocmanWixSetup\Release\VSdocmanSetup.msi"

REM batch parameter modifiers:
REM %~1   Expands %1 and removes any surrounding quotation marks ("").
REM %~f1  Expands %1 to a fully qualified path name.
REM %~d1  Expands %1 to a drive letter.
REM %~p1  Expands %1 to a path.
REM %~n1  Expands %1 to a file name.
REM %~x1  Expands %1 to a file extension.
REM %~s1  Expanded path contains short names only.
REM %~a1  Expands %1 to file attributes.
REM %~t1  Expands %1 to date and time of file.
REM %~z1  Expands %1 to size of file.
REM %~$PATH:1  Searches the directories listed in the PATH environment variable and expands %1 to the fully 
REM            qualified name of the first one found. If the environment variable name is not defined 
REM 					 or the file is not found, this modifier expands to the empty string.
REM %~dp1  Expands %1 to a drive letter and path.
REM %~nx1  Expands %1 to a file name and extension.
REM %~dp$PATH:1  Searches the directories listed in the PATH environment variable for %1 and expands 
REM              to the drive letter and path of the first one found.
REM %~ftza1  Expands %1 to a dir-like output line.

REM Get MSI version
REM capture script output in MSI_VERSION variable
for /f "usebackq tokens=*" %%a in (`cscript "%~dp0\getmsiversion.vbs" "%~dp0..\bin\Release\VsMultilineSearchReplaceSetup.msi"`) do (set MSI_VERSION=%%a)

set ZIPFILE="%~dp0..\bin\Release\VsMultilineSearchReplace_%MSI_VERSION%_setup.zip"
if EXIST %ZIPFILE% del %ZIPFILE% 

echo Creating the final ZIP file ...
"C:\Program Files (x86)\IZArc\IZARCC.exe" -a -p -cx -w ^
%ZIPFILE% "%~dp0..\bin\Release\VsMultilineSearchReplaceSetup.msi" "%~dp0\license.txt" "%~dp0\readme.txt"
echo Finished creating the ZIP


pause

exit /B 0