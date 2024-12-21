# Estágio de base com o runtime do .NET
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base

# Estabelecer o usuário root para garantir permissões para instalar pacotes
USER root

WORKDIR /app

# Atualizar e instalar o Python3 e pip
RUN apt-get update && apt-get install -y \
    python3 \
    python3-pip \
    && apt-get clean

# Verificando a instalação do Python
RUN python3 --version

# Estágio para build do .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PythonCSharp.csproj", "PythonCSharp/"]
RUN dotnet restore "./PythonCSharp/PythonCSharp.csproj"
COPY . .  # Copiar o restante do código, incluindo o Python
WORKDIR "/src/PythonCSharp"
RUN dotnet build "./PythonCSharp.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Estágio de publicação do .NET
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PythonCSharp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Estágio final para produção
FROM base AS final
WORKDIR /app

# Copiar o arquivo Python (command.py) e o arquivo de entrada (file.txt)
COPY ./command.py /app/command.py
COPY ./file.txt /app/file.txt

# Copiar os arquivos do .NET
COPY --from=publish /app/publish .

# Rodar o script Python "command.py"
ENTRYPOINT ["python3", "/app/command.py", "/app/file.txt"]