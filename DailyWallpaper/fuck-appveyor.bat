REM cd to project dir.
echo I should in project diretory
ECHO COULD dir
RMDIR /Q /S "..\OUTPUT"
md "..\OUTPUT"
copy "bin\Release\"  "..\OUTPUT" /y
del "..\OUTPUT\config*.ini" 
del "..\OUTPUT\*.log.txt"
echo fuck appveyor: NO XCOPY.
set errorlevel=0