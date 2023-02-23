#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CrudeApp/CrudeApp.csproj", "CrudeApp/"]
RUN dotnet restore "CrudeApp/CrudeApp.csproj"
COPY . .
WORKDIR "/src/CrudeApp"
RUN dotnet build "CrudeApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CrudeApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CrudeApp.dll"]