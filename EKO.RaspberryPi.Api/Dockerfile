#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ENV DOTNET_URLS=http://+:5000

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EKO.RaspberryPi.Api/EKO.RaspberryPi.Api.csproj", "EKO.RaspberryPi.Api/"]
RUN dotnet restore -r linux-arm64 "./EKO.RaspberryPi.Api/./EKO.RaspberryPi.Api.csproj"
COPY . .
WORKDIR "/src/EKO.RaspberryPi.Api"
RUN dotnet build -r linux-arm64 "./EKO.RaspberryPi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -r linux-arm64 "./EKO.RaspberryPi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EKO.RaspberryPi.Api.dll"]