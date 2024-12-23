# Base com runtime do .NET e Python
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app

# Instalar Python no container
RUN apt-get update && apt-get install -y \
    python3 \
    python3-pip \
    && apt-get clean

RUN python3 --version

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar arquivos de projeto
COPY PythonCSharp.csproj . 

RUN dotnet restore "./PythonCSharp.csproj"

COPY . .  
RUN dotnet build "./PythonCSharp.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicar o projeto
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PythonCSharp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
COPY ./command.py /app/command.py
COPY ./file.txt /app/file.txt
COPY ./foto/teste.jpg /app/foto/teste.jpg


# Configurar o ponto de entrada
ENTRYPOINT ["dotnet", "PythonCSharp.dll"]