@echo off
rem A batch file for SimpleCSharpApp.exe
rem which captures the app's return value.
dotnet run
@if "%ERRORLEVEL%" == "0" goto success
:fail
echo This application has failed!
Chapter 3 ■ Core C# Programming Constructs, Part 1
echo return value = %ERRORLEVEL%
goto end
:success
echo This application has succeeded!
echo return value = %ERRORLEVEL%
goto end
:end
echo All Done.