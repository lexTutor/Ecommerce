#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["HomeManagement.UserInterfcae/HomeManagement.UserInterfcae.csproj", "HomeManagement.UserInterfcae/"]
RUN dotnet restore "HomeManagement.UserInterfcae/HomeManagement.UserInterfcae.csproj"
COPY . .
WORKDIR "/src/HomeManagement.UserInterfcae"
RUN dotnet build "HomeManagement.UserInterfcae.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeManagement.UserInterfcae.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeManagement.UserInterfcae.dll"]