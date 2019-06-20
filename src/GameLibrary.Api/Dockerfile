FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
ENV ASPNETCORE_URLS http://*:8286
EXPOSE 8286

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/GameLibrary.Api/GameLibrary.Api.csproj src/GameLibrary.Api/
COPY src/GameLibrary.Domain/GameLibrary.Domain.csproj src/GameLibrary.Domain/
COPY src/GameLibrary.Domain.Core/GameLibrary.Domain.Core.csproj src/GameLibrary.Domain.Core/
COPY src/GameLibrary.IoC/GameLibrary.IoC.csproj src/GameLibrary.IoC/
COPY src/GameLibrary.Data/GameLibrary.Data.csproj src/GameLibrary.Data/
RUN dotnet restore src/GameLibrary.Api/GameLibrary.Api.csproj
COPY . .
WORKDIR /src/src/GameLibrary.Api
RUN dotnet build GameLibrary.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish GameLibrary.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GameLibrary.Api.dll"]
