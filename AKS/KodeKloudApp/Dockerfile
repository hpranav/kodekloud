FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["KodeKloudApp.csproj", "./"]
RUN dotnet restore "KodeKloudApp.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "KodeKloudApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KodeKloudApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KodeKloudApp.dll"]
