# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY ProfitDistribution.Api/*.csproj .
RUN dotnet restore

# copy and publish app and libraries
COPY ProfitDistribution.Api/. .
RUN dotnet publish --no-restore -c Release -o /app --no-cache /restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "ProfitDistribution.Api.dll"]