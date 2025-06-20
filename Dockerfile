# Etapa base para ejecutar la app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar toda la solución
COPY . .

# Restaurar dependencias desde el proyecto principal
RUN dotnet restore "TransActiva.API/TransActiva.API.csproj"

# Publicar el proyecto principal (API)
RUN dotnet publish "TransActiva.API/TransActiva.API.csproj" -c Release -o /app/publish

# Etapa final: imagen liviana para producción
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Punto de entrada
ENTRYPOINT ["dotnet", "TransActiva.API.dll"]
