Param(
[string]$sauceUserName,
[string]$sauceAccessKey
)
Write-Host "sauce.userName that was passed in from Azure DevOps=>$sauceUserName"
Write-Host "sauce.accessKey that was passed in from Azure DevOps=>$sauceAccessKey"

[Environment]::SetEnvironmentVariable("SAUCE_USERNAME", "$sauceUserName", "User")
[Environment]::SetEnvironmentVariable("SAUCE_ACCESS_KEY", "$sauceAccessKey)", "User")
