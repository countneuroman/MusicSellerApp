FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebMvc/WebMvc.csproj", "WebMvc/"]
RUN dotnet restore "WebMvc/WebMvc.csproj"
COPY . .
WORKDIR "/src/WebMvc"
RUN dotnet build "WebMvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebMvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebMvc.dll"]
