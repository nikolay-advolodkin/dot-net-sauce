<<<<<<< HEAD
﻿
=======
>>>>>>> 07dd552c6474e9eb10ebca9c6a570f00a199eabb
Param(
[string]$sauceUserName,
[string]$sauceAccessKey
)
Write-Host "sauce.userName that was passed in from Azure DevOps=>$sauceUserName"
Write-Host "sauce.accessKey that was passed in from Azure DevOps=>$sauceAccessKey"

[Environment]::SetEnvironmentVariable("SAUCE_USERNAME", "$sauceUserName", "User")
[Environment]::SetEnvironmentVariable("SAUCE_ACCESS_KEY", "$sauceAccessKey)", "User")
<<<<<<< HEAD

=======
>>>>>>> 07dd552c6474e9eb10ebca9c6a570f00a199eabb
