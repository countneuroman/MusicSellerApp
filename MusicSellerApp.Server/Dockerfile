FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MusicSellerApp.Server/MusicSellerApp.Server.csproj", "MusicSellerApp.Server/"]
RUN dotnet restore "MusicSellerApp.Server/MusicSellerApp.Server.csproj"
COPY . .
WORKDIR "/src/MusicSellerApp.Server"
RUN dotnet build "MusicSellerApp.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusicSellerApp.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusicSellerApp.Server.dll"]
