#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TomV-K8s-Showcase.csproj", "."]
RUN dotnet restore "TomV-K8s-Showcase.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "TomV-K8s-Showcase.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TomV-K8s-Showcase.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TomV.K8s.Showcase.dll"]