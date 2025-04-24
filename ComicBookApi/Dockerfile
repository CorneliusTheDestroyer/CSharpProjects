# --- Build Stage ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ComicBookApi/ComicBookApi.csproj ComicBookApi/
RUN dotnet restore ComicBookApi/ComicBookApi.csproj

# Copy all source files
COPY . .

# Build and publish to /app/publish
WORKDIR /src/ComicBookApi
RUN dotnet publish -c Release -o /app/publish

# --- Runtime Stage ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "ComicBookApi.dll"]