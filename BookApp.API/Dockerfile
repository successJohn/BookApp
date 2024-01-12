#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BookApp.API/BookApp.API.csproj", "BookApp.API/"]
COPY ["BookApp.Domain/BookApp.Domain.csproj", "BookApp.Domain/"]
COPY ["BookApp.Infrastructure/BookApp.Infrastructure.csproj", "BookApp.Infrastructure/"]
COPY ["BookApp.Application/BookApp.Application.csproj", "BookApp.Application/"]
RUN dotnet restore "BookApp.API/BookApp.API.csproj"
COPY . .
WORKDIR "/src/BookApp.API"
RUN dotnet build "BookApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookApp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookApp.API.dll"]