# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY SistemaDeVisitaCampeon.Server/SistemaDeVisitaCampeon.Server.csproj SistemaDeVisitaCampeon.Server/
RUN dotnet restore SistemaDeVisitaCampeon.Server/SistemaDeVisitaCampeon.Server.csproj

COPY . .
WORKDIR /src/SistemaDeVisitaCampeon.Server
RUN dotnet publish -c Release -o /app/out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "SistemaDeVisitaCampeon.Server.dll"]

