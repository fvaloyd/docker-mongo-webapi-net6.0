FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /APP
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["docker-mongo-webapi.csproj", "./"]
RUN dotnet restore "docker-mongo-webapi.csproj"
COPY . .
RUN dotnet publish "docker-mongo-webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "docker-mongo-webapi.dll"]
