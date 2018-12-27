$here = Split-Path -Parent $MyInvocation.MyCommand.Path
$sut = (Split-Path -Leaf $MyInvocation.MyCommand.Path) -replace '\.Tests\.', '.'
. "$here\$sut"

Describe "Get-KgpConnectionStatus" {
    $fakeResponse = New-Object -TypeName psobject 
    $fakeResponse | Add-Member -MemberType NoteProperty -Name StatusCode -Value 200

    Mock ConvertFrom-Json {}
    It "Should convert from json if tunnel is up" {
        $result = Get-KgpConnectionStatus $fakeResponse
        Assert-MockCalled ConvertFrom-Json -Times 1
        #Get-KgpConnectionStatus $fakeResponse.StatusCode | Should -Be $true
    }
    $fakeResponse.StatusCode = 404     
    It "Should return false if tunnel is down" {
        Get-KgpConnectionStatus $fakeResponse | Should -Be $false
    }
}
Describe "Test-SauceConnectStatus" {
    Mock Get-KgpConnectionStatus {return $true}
    Mock Invoke-RestartOperations {}
    $result = Test-SauceConnectStatus -IsInfiniteLoop $false
    It "Should invoke restart operations when called" {
        Assert-MockCalled Invoke-RestartOperations -Times 1
    }
    It "Should invoke Get-KgpConnectionStatus when called" {
        Assert-MockCalled Get-KgpConnectionStatus -Times 1
    }
}

Describe "Restart-SauceConnect"{
    $SauceConnectFilePath = "c:/fake"
    $UserName = "nikolay"
    $AccessKey = "abc123"
    $TunnelIdentifier = "testTunnel"
    Mock Invoke-Expression{}
    It "Should form a valid string to execute"{
        [string]$Command = Restart-SauceConnect $SauceConnectFilePath $UserName $AccessKey $TunnelIdentifier
        $Command | Should -Be "$($SauceConnectFilePath)\sc.exe -u $($UserName) -k $($AccessKey) -i $($TunnelIdentifier) --no-remove-colliding-tunnels -s"
    }
}