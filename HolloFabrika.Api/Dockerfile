FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HolloFabrika.Api/HolloFabrika.Api.csproj", "HolloFabrika.Api/"]
RUN dotnet restore "HolloFabrika.Api/HolloFabrika.Api.csproj"
COPY . .
WORKDIR "/src/HolloFabrika.Api"
RUN dotnet build "HolloFabrika.Api.csproj" -c Release -o /app/build

COPY .env-test .env

WORKDIR /src
RUN dotnet test -c Release

FROM build AS publish
RUN dotnet publish "HolloFabrika.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HolloFabrika.Api.dll"]
