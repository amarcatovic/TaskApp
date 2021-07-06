#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["TaskApp.Photos/TaskApp.Photos.csproj", "TaskApp.Photos/"]
RUN dotnet restore "TaskApp.Photos/TaskApp.Photos.csproj"
COPY . .
WORKDIR "/src/TaskApp.Photos"
RUN dotnet build "TaskApp.Photos.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskApp.Photos.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskApp.Photos.dll"]