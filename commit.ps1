param(
    [Parameter(Mandatory=$true)]
    [string]$Message
)

$ErrorActionPreference = "Stop"

try {
    # Increment version
    Write-Host "Incrementing version..." -ForegroundColor Cyan
    $version = (Get-Content version.json | ConvertFrom-Json).version
    $parts = $version.Split('.')
    $newVersion = "$($parts[0]).$($parts[1]).$([int]$parts[2] + 1)"
    @{version = $newVersion} | ConvertTo-Json | Set-Content version.json
    @{version = $newVersion} | ConvertTo-Json | Set-Content wwwroot\version.json
    Write-Host "Updated version: $version -> $newVersion" -ForegroundColor Green

    # Format code
    Write-Host "`nFormatting code..." -ForegroundColor Cyan
    dotnet format WAAI.sln --verbosity quiet
    if ($LASTEXITCODE -ne 0) { throw "Format failed" }

    # Build
    Write-Host "`nBuilding project..." -ForegroundColor Cyan
    dotnet build --nologo --verbosity quiet
    if ($LASTEXITCODE -ne 0) { throw "Build failed" }

    # Git operations
    Write-Host "`nCommitting changes..." -ForegroundColor Cyan
    git add .
    git commit -m $Message
    if ($LASTEXITCODE -ne 0) { throw "Commit failed" }

    git tag -a "v$newVersion" -m "Release v$newVersion"
    
    Write-Host "`nPushing to remote..." -ForegroundColor Cyan
    git push origin master
    git push origin "v$newVersion"
    if ($LASTEXITCODE -ne 0) { throw "Push failed" }

    Write-Host "`nSUCCESS: v$newVersion committed and pushed!" -ForegroundColor Green
}
catch {
    Write-Host "`nFAILED: $_" -ForegroundColor Red
    exit 1
}
