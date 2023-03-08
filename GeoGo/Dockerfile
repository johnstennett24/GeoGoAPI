FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GeoGo.csproj", "GeoGo/"]
WORKDIR /src/GeoGo
RUN dotnet restore "GeoGo.csproj"
COPY . .
WORKDIR /src/GeoGo
RUN dotnet build "GeoGo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeoGo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeoGo.dll"]
RUN bash
