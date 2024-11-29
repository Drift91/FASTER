@cd /d "%~dp0\FASTER"

dotnet publish --configuration Release -a x64 --self-contained true /p:useapphost=true --output ..\Release_x64 ./FASTER.csproj

@cd ..

pause
