nuget install coveralls.net -Version 0.6.0 -OutputDirectory coverage
.\coverage\OpenCover.4.6.519\tools\OpenCover.Console.exe -target:"C:/Program Files/dotnet/dotnet.exe" -targetargs:"test ./test/NetCore.Simple.ObjectIdentifier.Tests" -filter:"+[*]* -[*.Test]*" -register:user -output:"coverage.xml"
.\coverage\coveralls.net.0.6.0\tools\csmacnz.Coveralls.exe --opencover -i .\coverage.xml
dir