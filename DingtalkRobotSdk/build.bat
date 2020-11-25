@echo off
cd %~dp0
dotnet clean DingtalkRobotSdk.csproj -c Release
rd /s /Q bin\Release
dotnet build DingtalkRobotSdk.csproj -c Release

dotnet nuget push bin\Release\*.nupkg -s http://nuget.xiaobao100.cn/nuget/xiaobao
pause