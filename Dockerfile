
# FROM microsoft/dotnet:2.1-sdk AS build-env
# WORKDIR /JmBlog

# # Copiar csproj e restaurar dependencias
# COPY JmBlog/*.csproj ./
# RUN dotnet restore

# # Build da aplicacao
# COPY . ./
# RUN dotnet publish -c Release -o out

# Build da imagem
# FROM microsoft/dotnet:2.1-aspnetcore-runtime
# WORKDIR /JmBlog
# COPY --from=build-env ./JmBlog/JmBlog/out/ .
# ENTRYPOINT ["dotnet", "JmBlog.dll"]

FROM microsoft/dotnet:2.1-aspnetcore-runtime
RUN mkdir /app
WORKDIR /app
COPY JmBlog/bin/Debug/netcoreapp2.1/publish/ /app/
ENTRYPOINT dotnet /app/api.dll