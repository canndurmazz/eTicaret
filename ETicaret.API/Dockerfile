#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ETicaret.API/ETicaret.API.csproj", "ETicaret.API/"]
COPY ["ETicaret.Business/ETicaret.Business.csproj", "ETicaret.Business/"]
COPY ["ETicaret.Conctrats/ETicaret.Conctrats.csproj", "ETicaret.Conctrats/"]
COPY ["eTicaret.DataAccsess/eTicaret.DataAccsess.csproj", "eTicaret.DataAccsess/"]
COPY ["eTicaret.Entities/eTicaret.Entities.csproj", "eTicaret.Entities/"]
RUN dotnet restore "ETicaret.API/ETicaret.API.csproj"
COPY . .
WORKDIR "/src/ETicaret.API"
RUN dotnet build "ETicaret.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ETicaret.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ETicaret.API.dll"]