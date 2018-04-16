@echo off
:start
set op=clear_pack_push
set /p op=请输入操作命令pack、push、delete、clear或直接回车打包并发布：
if "%op%"=="pack" (
dotnet build -c release
dotnet pack -c release
goto start)
if "%op%"=="push" (
dotnet nuget push *.nupkg -s http://nuget.xiaobao100.cn/nuget/xiaobao
del /s *.nupkg
goto start)

if "%op%"=="delete" (
set /p id=请输入包名称：
set /p version=请输入版本号：
dotnet nuget delete "%id%" "%version%"  -s http://nuget.xiaobao100.cn/nuget/xiaobao
goto start)

if "%op%"=="clear" (
del /s *.nupkg
goto start)

if "%op%"=="clear_pack_push" (
del /s *.nupkg
dotnet build -c release
dotnet pack -c release
dotnet nuget push *.nupkg -s http://nuget.xiaobao100.cn/nuget/xiaobao
del /s *.nupkg
goto start)

echo 输入命令无效
goto start
pause