nuget install NUnit.Runners -Version 3.6.0 -OutputDirectory testrunner
nuget install NUnit.Framework -OutputDirectory testrunner
nuget install OpenCover -Version 4.6.519 -OutputDirectory coverage
nuget install coveralls.net -Version 0.6.0 -OutputDirectory coverage
dotnet restore .\test\NetCore.Simple.ObjectIdentifier.Tests\
dotnet build .\test\NetCore.Simple.ObjectIdentifier.Tests\
.\coverage\OpenCover.4.6.519\tools\Opencover.console.exe -register:user -target:"C:\Program Files\dotnet\dotnet.exe" -targetargs:"test "".\test\NetCore.Simple.ObjectIdentifier.Tests"" -f netcoreapp1.0" -returntargetcode -output:"coverage.xml" -oldStyle
.\coverage\coveralls.net.0.6.0\tools\csmacnz.Coveralls.exe --opencover -i .\coverage.xml
