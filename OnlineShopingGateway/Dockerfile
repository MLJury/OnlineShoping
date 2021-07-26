#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OnlineShopingGateway/OnlineShopingGateway.csproj", "OnlineShopingGateway/"]
RUN dotnet restore "OnlineShopingGateway/OnlineShopingGateway.csproj"
COPY . .
WORKDIR "/src/OnlineShopingGateway"
RUN dotnet build "OnlineShopingGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineShopingGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineShopingGateway.dll"]