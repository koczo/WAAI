@echo off
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
for /f "tokens=2 delims=:, " %%a in ('findstr "version" version.json') do set VERSION=%%~a
git tag -a v%VERSION% -m "Release v%VERSION%"

echo Pushing to remote...
git push origin master
git push origin v%VERSION%
if %errorlevel% neq 0 (
    echo FAILED: Push failed
    exit /b 1
)

echo SUCCESS: Changes formatted, built, committed and pushed!
