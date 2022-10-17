FROM nginx:alpine AS base
WORKDIR /app


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
WORKDIR /var/www/web
COPY --from=publish /app/publish/wwwroot .
COPY MusicSellerApp.Client/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
