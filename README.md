<h1 style="color:aquamarine"> ConsoleToWorkerService </h1>

console to worker service
##

<h2 style="color:greenyellow"> Command to install as service in windows powershell </h2>

<h4 style="color:orange"> sc means source configuration manager for exe file </h4>
<h4 style="color:orange"> start auto means service as windows startup file</h4>

```ps1
sc.exe create WebsiteStatus binpath= C:\temp\WorkerService\ConsoleToSevice.exe start= auto
```

<h2 style="color:greenyellow">Command to delete service in windows powershell</h2> 

```ps1
sc.exe delete WebsiteStatus
```