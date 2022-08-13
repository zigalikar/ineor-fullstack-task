FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IneorTaskBackend/IneorTaskBackend.csproj", "IneorTaskBackend/"]
RUN dotnet restore "IneorTaskBackend\IneorTaskBackend.csproj"
COPY . .
WORKDIR "/src/IneorTaskBackend"
RUN dotnet build "IneorTaskBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IneorTaskBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./IneorTaskBackend/wait-for-it.sh /wait-for-it.sh
RUN chmod +x /wait-for-it.sh

# this config should be taken by Heroku - Docker overrides these variable in docker-compose.yml
CMD ASPNETCORE_ENVIRONMENT=Production ; PORT=$PORT
ENTRYPOINT ["/wait-for-it.sh", "localhost:3306", "--", "dotnet", "IneorTaskBackend.dll"]
