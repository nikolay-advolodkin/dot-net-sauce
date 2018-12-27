$here = Split-Path -Parent $MyInvocation.MyCommand.Path
$sut = (Split-Path -Leaf $MyInvocation.MyCommand.Path) -replace '\.Tests\.', '.'
. "$here\$sut"

Describe "Get-KgpConnectionStatus" {
    $fakeResponse = New-Object -TypeName psobject 
    $fakeResponse | Add-Member -MemberType NoteProperty -Name StatusCode -Value 200

    Mock ConvertFrom-Json {}
    It "Should return true if tunnel is up" {
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
    Mock Get-KgpConnectionStatus {return $false}
    Mock Start-Sleep {}
    Mock Send-Notification {}
    $result = Test-SauceConnectStatus -IsInfiniteLoop $false
    It "Should send notification" {
        Assert-MockCalled Send-Notification -Times 1
    }

    Mock Get-KgpConnectionStatus {return $true}
    Mock Start-Sleep {}
    Mock Send-Notification {}
    $result = Test-SauceConnectStatus -IsInfiniteLoop $false
    It "Should send notification" {
        Assert-MockCalled Start-Sleep -Times 1
    }
}
