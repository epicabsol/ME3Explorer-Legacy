﻿get-childitem "$($PSScriptRoot)\Release\" -include *.7z -recurse | foreach ($_) {remove-item $_.fullname}

#Remove PDBs
$Dir = get-childitem "$($PSScriptRoot)\Release\lib" -recurse 
$List = $Dir | where {$_.extension -eq ".pdb"} 
foreach ($item in $List) {
    if ($item.Name -eq 'ME3Explorer.pdb') {
        Write-Host "Move ME3Explorer PDB next to executable..."
        move "$($PSScriptRoot)\Release\lib\ME3Explorer.pdb" "$($PSScriptRoot)\Release\ME3Explorer.pdb"
        continue
    }
    Write-Host "Deleting extra PDB: $($item)"
    Remove-Item "$($PSScriptRoot)\Release\lib\$($item)" -Force
}

#Sign EXEs
$Cert = Get-ChildItem -Path "Cert:\CurrentUser\My" -CodeSigningCert
$Dir = get-childitem "$($PSScriptRoot)\Release\"
$List = $Dir | where {$_.extension -eq ".exe"} 
foreach ($item in $List) {
    Write-Host "Signing $($item)..."
    Set-AuthenticodeSignature -FilePath "$($PSScriptRoot)\Release\$($item)" -TimestampServer "http://timestamp.digicert.com" -HashAlgorithm "SHA256" -Certificate $Cert
}

$fileversion = [System.Diagnostics.FileVersionInfo]::GetVersionInfo("Release\ME3Explorer.exe").FileVersion
$outputfile = "$($PSScriptRoot)\ME3Explorer_$($fileversion).7z"
$exe = "$($PSScriptRoot)..\..\..\Deployment\7za.exe"
$arguments = "a", "`"$($outputfile)`"", "`"$($PSScriptRoot)\Release\*`"", "-mmt6"
Write-Host "Running: $($exe) $($arguments)"
Start-Process $exe -ArgumentList $arguments -Wait -NoNewWindow