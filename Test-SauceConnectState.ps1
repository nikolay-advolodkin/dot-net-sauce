$IntervalForRestart = 120

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
        if($IsConnected -ne $true)
        {
            Send-Notification
            Wait-SauceConnectToRestart -SecondsToWait $IntervalForRestart
        }
        else
        {
            Start-Sleep -Seconds 15
        }
    } while ($IsInfiniteLoop)
}
function Send-Notification() {
    return Write-Host "Sauce Connect is down! Please restart."
}
function Wait-SauceConnectToRestart($SecondsToWait) {
    return Start-Sleep -Seconds $SecondsToWait
}