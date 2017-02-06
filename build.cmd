
@ECHO OFF
dotnet restore
dotnet pack src\NetCore.Simple.ObjectIdentifier --configuration Release
