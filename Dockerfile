# Multi-stage Dockerfile for building and running the BethanysPieShop app
# Exposes port 5010 and configures the app to listen on any IP address

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

# Listen on port 5010 and bind to any IP
EXPOSE 5010
ENV ASPNETCORE_URLS="http://+:5010"

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY ["2026-web02.csproj", "./"]
RUN dotnet restore

# copy the rest of the sources and build
COPY . .
WORKDIR "/src/."
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "2026-web02.dll"]
