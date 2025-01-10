# Imagen base para la compilación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copiar archivo de solución y proyectos
COPY ITLA-TV.sln ./
COPY Application/*.csproj ./Application/
COPY Database/*.csproj ./Database/
COPY ITLA-TV/*.csproj ./ITLA-TV/

# Restaurar dependencias
RUN dotnet restore ITLA-TV.sln

# Copiar todo el contenido del proyecto
COPY . ./

# Publicar la aplicación
RUN dotnet publish ./ITLA-TV -c Release -o out

# Imagen base para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exponer el puerto
EXPOSE 5126

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "ITLA-TV.dll"]
