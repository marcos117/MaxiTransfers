FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Data/Data.csproj", "Data/"]
RUN dotnet restore "Data/Data.csproj"
COPY . .
WORKDIR "/src/Data"
RUN dotnet build "Data.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Data.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Data.dll"]
