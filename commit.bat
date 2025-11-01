@echo off
echo Incrementing version...
for /f "tokens=2 delims=:, " %%a in ('findstr "version" version.json') do set OLD_VERSION=%%~a
for /f "tokens=1,2,3 delims=." %%a in ("%OLD_VERSION%") do (
    set MAJOR=%%a
    set MINOR=%%b
    set /a PATCH=%%c+1
)
set NEW_VERSION=%MAJOR%.%MINOR%.%PATCH%
echo {"version": "%NEW_VERSION%"} > version.json
echo {"version": "%NEW_VERSION%"} > wwwroot\version.json
echo Updated version: %OLD_VERSION% -^> %NEW_VERSION%

echo Formatting code and removing unused usings...
dotnet format WAAI.sln
if %errorlevel% neq 0 (
    echo FAILED: Code formatting failed
    exit /b 1
)

echo Building project...
dotnet build
if %errorlevel% neq 0 (
    echo FAILED: Build failed
    exit /b 1
)

echo Adding files to git...
git add .

echo Committing changes...
git commit -m "%*"
if %errorlevel% neq 0 (
    echo FAILED: Commit failed
    exit /b 1
)

echo Creating version tag...
git tag -a v%NEW_VERSION% -m "Release v%NEW_VERSION%"

echo Pushing to remote...
git push origin master
git push origin v%NEW_VERSION%
if %errorlevel% neq 0 (
    echo FAILED: Push failed
    exit /b 1
)

echo SUCCESS: Changes formatted, built, committed and pushed!
