
@ECHO OFF
dotnet restore
dotnet test test\NetCore.Simple.ObjectIdentifier.Tests -appveyor
dotnet pack src\NetCore.Simple.ObjectIdentifier --configuration Release