#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ServerSide_GameRater/Server/ServerSide_GameRater.Server.csproj", "ServerSide_GameRater/Server/"]
COPY ["ServerSide_GameRater/Client/ServerSide_GameRater.Client.csproj", "ServerSide_GameRater/Client/"]
COPY ["ServerSide_GameRater/Shared/ServerSide_GameRater.Shared.csproj", "ServerSide_GameRater/Shared/"]
RUN dotnet restore "ServerSide_GameRater/Server/ServerSide_GameRater.Server.csproj"
COPY . .
WORKDIR "/src/ServerSide_GameRater/Server"
RUN dotnet build "ServerSide_GameRater.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServerSide_GameRater.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServerSide_GameRater.Server.dll"]