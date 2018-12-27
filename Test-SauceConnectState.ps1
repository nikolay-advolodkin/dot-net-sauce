$IntervalForRestart = 120
$SauceConnectFilePath = "C:\Source\SauceLabs\sc-4.5.2-win32"
$UserName = [Environment]::GetEnvironmentVariable("SAUCE_USERNAME", "User")
$AccessKey = [Environment]::GetEnvironmentVariable("SAUCE_ACCESS_KEY", "User")
$TunnelIdentifier = "NikolaysTunnel"

function Get-KgpConnectionStatus($Response) {
    if ($Response.StatusCode -eq 200) {
        $json = ConvertFrom-Json $Response.Content
        return $json.kgp.Connected
    }
    return $false
}
function Invoke-SauceConnectDebugUrl() {
    try { Invoke-WebRequest -Uri http://localhost:8888/debug/vars -Method get }
    catch { return $false }    
}
function Test-SauceConnectStatus($IsInfiniteLoop = $true) {
    do {
        $IsConnected = Get-KgpConnectionStatus -Response (Invoke-SauceConnectDebugUrl)
        Invoke-RestartOperations -IsConnected $IsConnected
    } while ($IsInfiniteLoop)
}
function Invoke-RestartOperations($IsConnected) {
    if($IsConnected -ne $true)
    {            
        Send-Notification
        Restart-SauceConnect -SauceConnectFilePath $SauceConnectFilePath -UserName $UserName `
            -AccessKey $AccessKey -TunnelIdentifier $TunnelIdentifier
        Wait-SauceConnectToRestart -SecondsToWait $IntervalForRestart
        return
    }
    Start-Sleep -Seconds 15
}
function Restart-SauceConnect($SauceConnectFilePath, $UserName, $AccessKey, $TunnelIdentifier) {
    $startSauceCommand = "$($SauceConnectFilePath)\sc.exe -u $($UserName) -k $($AccessKey) -i $($TunnelIdentifier) --no-remove-colliding-tunnels -s"
    Invoke-Expression $startSauceCommand
    return [string]$startSauceCommand
}
function Send-Notification() {
    return Write-Host "Sauce Connect is down! Please restart."
}
function Wait-SauceConnectToRestart($SecondsToWait) {
    return Start-Sleep -Seconds $SecondsToWait
}