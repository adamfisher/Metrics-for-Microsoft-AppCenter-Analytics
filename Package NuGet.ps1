# Package Nuget
dotnet pack AppCenter.Analytics.Metrics\AppCenter.Analytics.Metrics.csproj -c Release --no-build
Move-Item AppCenter.Analytics.Metrics\bin\Release\*.nupkg -Destination . -force

pause