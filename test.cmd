nuget install coveralls.net -Version 0.7.0 -OutputDirectory coverage
.\coverage\OpenCover.4.6.519\tools\OpenCover.Console.exe -target:dotnet test -targetargs:"test\NetCore.Simple.ObjectIdentifier.Tests" -filter:"+[*]* -[*.Test]*" -register:user
dir
.\coverage\coveralls.net.0.7.0\tools\csmacnz.Coveralls.exe --opencover -i .\results.xml
dir