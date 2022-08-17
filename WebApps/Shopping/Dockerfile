FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebApps/Shopping/Shopping.csproj", "WebApps/Shopping/"]
RUN dotnet restore "WebApps/Shopping/Shopping.csproj"
COPY . .
WORKDIR "/src/WebApps/Shopping"
RUN dotnet build "Shopping.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopping.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopping.dll"]
