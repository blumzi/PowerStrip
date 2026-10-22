# Deploys the Release build of the IP9258 ASCOM Switch driver and registers it for COM.
#
#   powershell -ExecutionPolicy Bypass -File tools\Deploy-IP9258.ps1
#
# Build first (Release; the post-build installer step needs Inno Setup 5, so skip it; and target
# 4.7.2 where the project's 4.6.1 targeting pack is not installed):
#   MSBuild "IP Power 9258\IP Power 9258.csproj" /p:Configuration=Release /p:PostBuildEvent= /p:TargetFrameworkVersion=v4.7.2
#
# Elevates itself (one UAC prompt). Registration is always redone: AssemblyVersion is 6.0.*,
# so every build has a new version, and a copied DLL that does not match the registered
# version fails to load with 0x80131040.

param([string]$Log)

$src = Join-Path $PSScriptRoot '..\IP Power 9258\bin\Release\ASCOM.IPPower9258.Switch.dll' | Resolve-Path
$dst = 'C:\Program Files (x86)\Common Files\ASCOM\Switch\ASCOM.IPPower9258.Switch.dll'

$admin = ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole(
    [Security.Principal.WindowsBuiltInRole]::Administrator)
if (-not $admin) {
    # Output of the elevated run goes to a log, since its window closes when done
    $Log = Join-Path $env:TEMP 'Deploy-IP9258.log'
    Remove-Item $Log -ErrorAction SilentlyContinue
    Start-Process powershell.exe -Verb RunAs -Wait -ArgumentList '-NoProfile', '-ExecutionPolicy', 'Bypass',
        '-File', "`"$PSCommandPath`"", '-Log', "`"$Log`""
    if (Test-Path $Log) { Get-Content $Log } else { 'The elevated run did not start (UAC declined?)' }
    return
}

& {
    try {
        Copy-Item $src $dst -Force -ErrorAction Stop
        'deployed'
    } catch {
        # A loaded DLL cannot be overwritten but can be renamed: the holder keeps the old
        # image and the next load gets the new one. Delete the set-aside copy once it is free.
        "direct copy failed: $($_.Exception.Message)"
        try {
            $old = "$dst.old-$(Get-Date -Format yyyyMMdd-HHmmss)"
            Rename-Item $dst (Split-Path $old -Leaf) -ErrorAction Stop
            Copy-Item $src $dst -ErrorAction Stop
            "deployed; the previous copy was in use and is now $old"
        } catch { "ERROR: $($_.Exception.Message)"; return }
    }

    foreach ($fw in 'Framework', 'Framework64') {
        "--- regasm $fw"
        & "C:\Windows\Microsoft.NET\$fw\v4.0.30319\RegAsm.exe" /nologo /codebase $dst
        "exit=$LASTEXITCODE"
    }

    $built = [Reflection.AssemblyName]::GetAssemblyName($dst).Version
    $registered = (Get-ItemProperty 'HKLM:\SOFTWARE\WOW6432Node\Classes\CLSID\{84FBB3F7-B195-451A-8782-5ECDF14745A8}\InprocServer32').Assembly
    "built $built, registered: $registered"
} *>&1 | ForEach-Object { if ($Log) { $_ | Out-File $Log -Append } else { $_ } }
