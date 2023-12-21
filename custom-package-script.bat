@cd /d "%~dp0\FASTER"

dotnet publish --configuration Release -r win-x64 --self-contained true --output ..\Release_x64
