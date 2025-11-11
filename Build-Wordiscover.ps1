# Wordiscover Build Script
# PowerShell script to build Wordiscover VSTO Add-in

param(
    [string]$Configuration = "Release",
    [string]$OutputPath = ".\Build-Output",
    [switch]$Publish,
    [switch]$Help
)

function Show-Help {
    Write-Host @"
Wordiscover Build Script
========================

Usage: .\Build-Wordiscover.ps1 [options]

Options:
  -Configuration <Debug|Release>  Build configuration (default: Release)
  -OutputPath <path>              Output directory for publish (default: .\Build-Output)
  -Publish                        Create deployment package
  -Help                           Show this help message

Examples:
  .\Build-Wordiscover.ps1                           # Build in Release mode
  .\Build-Wordiscover.ps1 -Configuration Debug      # Build in Debug mode
  .\Build-Wordiscover.ps1 -Publish                  # Build and create deployment package
  .\Build-Wordiscover.ps1 -Publish -OutputPath "C:\Deploy"

Requirements:
  - Visual Studio 2019 or later with Office Development workload
  - .NET Framework 4.8 SDK
  - Microsoft Office Word (2013 or later)

"@
    exit 0
}

if ($Help) {
    Show-Help
}

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Wordiscover VSTO Add-in Build Script" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Find MSBuild
Write-Host "Looking for MSBuild..." -ForegroundColor Yellow
$msbuildPath = $null

# Check common Visual Studio paths
$vsPaths = @(
    "${env:ProgramFiles}\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe",
    "${env:ProgramFiles}\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe",
    "${env:ProgramFiles}\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe",
    "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe",
    "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe",
    "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe"
)

foreach ($path in $vsPaths) {
    if (Test-Path $path) {
        $msbuildPath = $path
        Write-Host "✓ Found MSBuild at: $msbuildPath" -ForegroundColor Green
        break
    }
}

if (-not $msbuildPath) {
    Write-Host "✗ ERROR: MSBuild not found!" -ForegroundColor Red
    Write-Host "Please install Visual Studio with Office Development workload." -ForegroundColor Red
    exit 1
}

# Check if solution exists
$solutionFile = ".\Wordiscover.sln"
if (-not (Test-Path $solutionFile)) {
    Write-Host "✗ ERROR: Wordiscover.sln not found in current directory!" -ForegroundColor Red
    Write-Host "Please run this script from the wordiscover2 root directory." -ForegroundColor Red
    exit 1
}

Write-Host ""
Write-Host "Building Wordiscover..." -ForegroundColor Yellow
Write-Host "Configuration: $Configuration" -ForegroundColor Cyan

# Clean previous build
Write-Host "Cleaning previous build..." -ForegroundColor Yellow
& $msbuildPath $solutionFile /t:Clean /p:Configuration=$Configuration /v:minimal

if ($LASTEXITCODE -ne 0) {
    Write-Host "✗ Clean failed!" -ForegroundColor Red
    exit 1
}

# Restore NuGet packages (if needed)
Write-Host "Restoring NuGet packages..." -ForegroundColor Yellow
$nugetPath = "nuget.exe"
if (Get-Command nuget -ErrorAction SilentlyContinue) {
    nuget restore $solutionFile
} else {
    Write-Host "⚠ NuGet not found, skipping package restore..." -ForegroundColor Yellow
}

# Build solution
Write-Host ""
Write-Host "Building solution..." -ForegroundColor Yellow
& $msbuildPath $solutionFile /p:Configuration=$Configuration /p:Platform="Any CPU" /v:minimal

if ($LASTEXITCODE -ne 0) {
    Write-Host ""
    Write-Host "✗ Build FAILED!" -ForegroundColor Red
    exit 1
}

Write-Host ""
Write-Host "✓ Build SUCCESS!" -ForegroundColor Green

# Show output location
$binPath = ".\Wordiscover\bin\$Configuration"
Write-Host ""
Write-Host "Build output location:" -ForegroundColor Cyan
Write-Host "  $binPath" -ForegroundColor White

if (Test-Path $binPath) {
    $files = Get-ChildItem $binPath -File | Select-Object -First 10
    Write-Host ""
    Write-Host "Main output files:" -ForegroundColor Cyan
    foreach ($file in $files) {
        Write-Host "  - $($file.Name)" -ForegroundColor White
    }
}

# Publish if requested
if ($Publish) {
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Cyan
    Write-Host "Creating Deployment Package" -ForegroundColor Cyan
    Write-Host "========================================" -ForegroundColor Cyan
    Write-Host ""

    # Create output directory
    if (-not (Test-Path $OutputPath)) {
        New-Item -ItemType Directory -Path $OutputPath -Force | Out-Null
    }

    $fullOutputPath = (Resolve-Path $OutputPath).Path
    Write-Host "Output path: $fullOutputPath" -ForegroundColor Cyan

    # Publish using MSBuild
    Write-Host "Publishing..." -ForegroundColor Yellow
    & $msbuildPath ".\Wordiscover\Wordiscover.csproj" /t:Publish /p:Configuration=$Configuration /p:PublishUrl="$fullOutputPath\" /v:minimal

    if ($LASTEXITCODE -eq 0) {
        Write-Host ""
        Write-Host "✓ Publish SUCCESS!" -ForegroundColor Green
        Write-Host ""
        Write-Host "Deployment files created at:" -ForegroundColor Cyan
        Write-Host "  $fullOutputPath" -ForegroundColor White
        Write-Host ""
        Write-Host "To install:" -ForegroundColor Yellow
        Write-Host "  1. Navigate to: $fullOutputPath" -ForegroundColor White
        Write-Host "  2. Run setup.exe" -ForegroundColor White
        Write-Host "  3. Follow the installation wizard" -ForegroundColor White
    } else {
        Write-Host ""
        Write-Host "✗ Publish FAILED!" -ForegroundColor Red
        exit 1
    }
}

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Build Complete!" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""
