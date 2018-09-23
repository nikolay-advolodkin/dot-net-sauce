[Environment]::SetEnvironmentVariable("SAUCE_USERNAME", "$(sauce.userName)", "User")
Write-Host "sauce.userName=>$(sauce.userName)"

[Environment]::SetEnvironmentVariable("SAUCE_ACCESS_KEY", "$(sauce.accessKey)", "User")
Write-Host "sauce.accessKey=>$(sauce.accessKey)"
