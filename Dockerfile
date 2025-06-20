# Etapa base para ejecutar la app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar todo el proyecto
COPY . .

# Restaurar dependencias
RUN dotnet restore "TransActiva.API/TransActiva.API.csproj"

# Publicar en una carpeta coherente
RUN dotnet publish "TransActiva.API/TransActiva.API.csproj" -c Release -o /src/publish

# Etapa final: imagen liviana
FROM base AS final
WORKDIR /app
COPY --from=build /src/publish .

# Punto de entrada
ENTRYPOINT ["dotnet", "TransActiva.API.dll"]
