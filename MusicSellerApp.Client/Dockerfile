FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MusicSellerApp.Client/MusicSellerApp.Client.csproj", "MusicSellerApp.Client/"]
RUN dotnet restore "MusicSellerApp.Client/MusicSellerApp.Client.csproj"
COPY . .
WORKDIR "/src/MusicSellerApp.Client"
RUN dotnet build "MusicSellerApp.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusicSellerApp.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusicSellerApp.Client.dll"]
