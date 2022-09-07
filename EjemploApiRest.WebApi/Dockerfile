#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EjemploApiRest.WebApi/EjemploApiRest.WebApi.csproj", "EjemploApiRest.WebApi/"]
COPY ["EjemploApiRest.Services/EjemploApiRest.Services.csproj", "EjemploApiRest.Services/"]
COPY ["EjemploApiRest.Abstractions/EjemploApiRest.Abstractions.csproj", "EjemploApiRest.Abstractions/"]
COPY ["EjemploApiRest.Entities/EjemploApiRest.Entities.csproj", "EjemploApiRest.Entities/"]
COPY ["EjemploApiRest.Application/EjemploApiRest.Application.csproj", "EjemploApiRest.Application/"]
COPY ["EjemploApiRest.Repository/EjemploApiRest.Repository.csproj", "EjemploApiRest.Repository/"]
COPY ["EjemploApiRest.DataAccess/EjemploApiRest.DataAccess.csproj", "EjemploApiRest.DataAccess/"]
RUN dotnet restore "EjemploApiRest.WebApi/EjemploApiRest.WebApi.csproj"
COPY . .
WORKDIR "/src/EjemploApiRest.WebApi"
RUN dotnet build "EjemploApiRest.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EjemploApiRest.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EjemploApiRest.WebApi.dll"]
