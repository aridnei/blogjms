#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 50051
EXPOSE 44349

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY ["JmBlog/JmBlog.csproj", "JmBlog/"]
RUN dotnet restore "JmBlog/JmBlog.csproj"
COPY . .
WORKDIR "/src/JmBlog"
RUN dotnet build "JmBlog.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "JmBlog.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JmBlog.dll"]