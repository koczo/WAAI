@echo off
echo Formatting code and removing unused usings...
dotnet format --verify-no-changes --verbosity diagnostic
if %errorlevel% neq 0 dotnet format
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

echo Pushing to remote...
git push origin master
if %errorlevel% neq 0 (
    echo FAILED: Push failed
    exit /b 1
)

echo SUCCESS: Changes formatted, built, committed and pushed!
