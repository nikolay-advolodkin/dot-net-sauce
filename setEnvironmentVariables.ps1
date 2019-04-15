
Param(
[string]$sauceUserName,
[string]$sauceAccessKey,
[string]$sauceHeadlessUserName,
[string]$sauceHeadlessAccessKey
)
Write-Output "sauce.userName that was passed in from Azure DevOps=>$sauceUserName"
Write-Output "sauce.accessKey that was passed in from Azure DevOps=>$sauceAccessKey"
Write-Output "sauce.headless.userName that was passed in from Azure DevOps=>$sauceHeadlessUserName"
Write-Output "sauce.headless.access.key that was passed in from Azure DevOps=>$sauceHeadlessAccessKey"

[Environment]::SetEnvironmentVariable("SAUCE_USERNAME", "$sauceUserName", "User")
[Environment]::SetEnvironmentVariable("SAUCE_ACCESS_KEY", "$sauceAccessKey", "User")
[Environment]::SetEnvironmentVariable("SAUCE_HEADLESS_USERNAME", "$sauceUserName", "User")
[Environment]::SetEnvironmentVariable("SAUCE_HEADLESS_ACCESS_KEY", "$sauceAccessKey", "User")
