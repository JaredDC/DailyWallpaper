REM cd to project dir.
REM FUCK
dir
echo "bin\Release\"
dir "bin\Release\"
xcopy "bin\Release\"  "..\Output" /q /e /y /i
del "..\Output\config*.ini" 
del "..\Output\*.log.txt"
echo fuck appveyor.
set errorlevel=0