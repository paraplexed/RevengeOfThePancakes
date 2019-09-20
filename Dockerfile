FROM mcr.microsoft.com/dotnet/core/sdk:2.2
COPY . .
RUN dotnet build ./RevengeOfThePancakes.sln
ENTRYPOINT ["/usr/bin/dotnet", "/RevengeOfThePancakes.ConsoleApp/bin/Debug/netcoreapp2.2/RevengeOfThePancakes.ConsoleApp.dll"]