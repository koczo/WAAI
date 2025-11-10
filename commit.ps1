param(
    [Parameter(Mandatory=$true)]
    [string]$Message
)

$ErrorActionPreference = "Stop"

try {
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
    git add -A
    git commit -m $Message
    if ($LASTEXITCODE -ne 0) { throw "Commit failed" }

    # Determine current branch and push there (safer than hardcoding 'master')
    Write-Host "`nDetermining current git branch..." -ForegroundColor Cyan
    $branch = (git rev-parse --abbrev-ref HEAD).Trim()
    if ([string]::IsNullOrWhiteSpace($branch)) { throw "Failed to determine current branch" }

    Write-Host "`nPushing to remote branch '$branch'..." -ForegroundColor Cyan
    git push origin $branch
    if ($LASTEXITCODE -ne 0) { throw "Push failed" }

    Write-Host "`nSUCCESS: Changes committed and pushed!" -ForegroundColor Green
}
catch {
    Write-Host "`nFAILED: $_" -ForegroundColor Red
    exit 1
}
