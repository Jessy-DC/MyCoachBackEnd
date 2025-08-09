# ---- Build ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie le .csproj en premier pour optimiser le cache Docker (si tu ajoutes d'autres projets, ajoute leurs .csproj pareil)
COPY MyCoach.API/MyCoach.API.csproj MyCoach.API/
RUN dotnet restore MyCoach.API/MyCoach.API.csproj

# Copie le reste du code
COPY . .

# Publie en Release, sans apphost (image plus légère)
RUN dotnet publish MyCoach.API/MyCoach.API.csproj -c Release -o /out /p:UseAppHost=false

# ---- Run ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Kestrel écoute sur 8080 pour Azure Container Apps
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

# (Optionnel) réduire un peu l'image
# ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1

COPY --from=build /out ./

# Démarrage
ENTRYPOINT ["dotnet","MyCoach.API.dll"]
