#!/usr/bin/env bash
set -euo pipefail

# ====== Paramètres modifiables ======
RG=${RG:-rg-mycoach}
LOC=${LOC:-westeurope}
ENVNAME=${ENVNAME:-env-mycoach}
APPNAME=${APPNAME:-mycoach-api}
PORT=${PORT:-8080}

# ====== Login & groupe ======
az login
az account show >/dev/null

az group create -n "$RG" -l "$LOC"

# ====== Environnement Container Apps (si pas existant) ======
if ! az containerapp env show -g "$RG" -n "$ENVNAME" >/dev/null 2>&1; then
  az containerapp env create -g "$RG" -n "$ENVNAME" -l "$LOC"
fi

# ====== Build & déploiement à partir du Dockerfile local ======
az containerapp up \
  --name "$APPNAME" \
  --resource-group "$RG" \
  --location "$LOC" \
  --environment "$ENVNAME" \
  --ingress external \
  --target-port "$PORT" \
  --source . \
  --env-vars JSON_DATA_PATH=/app/data

# Affiche l'URL
echo "URL publique : $(az containerapp show -g "$RG" -n "$APPNAME" --query properties.configuration.ingress.fqdn -o tsv)"
