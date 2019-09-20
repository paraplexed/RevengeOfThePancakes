# RevengeOfThePancakes

### How to run via docker
- Clone down repo
- Run from commandline
```
# Build the docker image
docker build . -t revenge

# Run the container with parameters
docker run revenge 5 -- ++ -+ +- -+-+-+

# For an interactive experience
docker run -it revenge
```

### How to run via dotnet core cli
- Clone down repo
- Ensure you have dotnet 2.2 sdk installed: https://dotnet.microsoft.com/download
- Run from commandline
```
# Build
dotnet build .

# Run with parameters
dotnet run --project RevengeOfThePancakes.ConsoleApp\RevengeOfThePancakes.ConsoleApp.csproj 5 -- ++ -+ +- -+-+-+

# For an interactive experience
dotnet run --project RevengeOfThePancakes.ConsoleApp\RevengeOfThePancakes.ConsoleApp.csproj
```