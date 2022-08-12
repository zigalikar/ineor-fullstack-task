FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001

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
#ENTRYPOINT ["dotnet", "IneorTaskBackend.dll"]
ENTRYPOINT ["/wait-for-it.sh", "localhost:3306", "--", "dotnet", "IneorTaskBackend.dll", "--environment", "Production"]
