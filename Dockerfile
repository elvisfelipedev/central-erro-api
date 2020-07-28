FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/CentralErros.Api/CentralErros.Api.csproj", "src/CentralErros.Api/"]
COPY ["src/CentralErros.Data/CentralErros.Data.csproj", "src/CentralErros.Data/"]
COPY ["src/CentralErros.Business/CentralErros.Business.csproj", "src/CentralErros.Business/"]
RUN dotnet restore "src/CentralErros.Api/CentralErros.Api.csproj"
COPY . .
WORKDIR "/src/src/CentralErros.Api"
RUN dotnet build "CentralErros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CentralErros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet CentralErros.Api.dll
