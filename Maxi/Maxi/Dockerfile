FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Maxi/Maxi.csproj", "Maxi/"]
RUN dotnet restore "Maxi/Maxi.csproj"
COPY . .
WORKDIR "/src/Maxi"
RUN dotnet build "Maxi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Maxi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Maxi.dll"]
