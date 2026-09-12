# Gatelog uninstaller (proof of concept).
# Run from an elevated PowerShell prompt:
#   powershell -ExecutionPolicy Bypass -File uninstaller.ps1 -InstallPath "C:\Program Files\Gatelog"
# Stops and removes the services registered by the installer, then deletes the install folder.
param(
    [string]$InstallPath = "C:\Program Files\Gatelog"
)

$services = @("gatelogBot", "gatelogPortal", "MongoDB", "mosquitto")

foreach ($service in $services) {
    if (Get-Service -Name $service -ErrorAction SilentlyContinue) {
        Stop-Service -Name $service -Force -ErrorAction SilentlyContinue
        sc.exe delete $service | Out-Null
    }
}

if (Test-Path -Path $InstallPath) {
    Remove-Item -Path $InstallPath -Recurse -Force
}
