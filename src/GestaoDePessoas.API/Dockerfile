#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/GestaoDePessoas.API/GestaoDePessoas.API.csproj", "src/GestaoDePessoas.API/"]
COPY ["src/GestaoDePessoas.Application/GestaoDePessoas.Application.csproj", "src/GestaoDePessoas.Application/"]
COPY ["src/GestaoDePessoas.Dominio.Core/GestaoDePessoas.Dominio.Core.csproj", "src/GestaoDePessoas.Dominio.Core/"]
COPY ["src/GestaoDePessoas.Dominio/GestaoDePessoas.Dominio.csproj", "src/GestaoDePessoas.Dominio/"]
COPY ["src/GestaoDePessoas.Infra.CrossCutting.Ioc/GestaoDePessoas.Infra.CrossCutting.Ioc.csproj", "src/GestaoDePessoas.Infra.CrossCutting.Ioc/"]
COPY ["src/GestaoDePessoas.Infra.Data/GestaoDePessoas.Infra.Data.csproj", "src/GestaoDePessoas.Infra.Data/"]
RUN dotnet restore "src/GestaoDePessoas.API/GestaoDePessoas.API.csproj"
COPY . .
WORKDIR "/src/src/GestaoDePessoas.API"
RUN dotnet build "GestaoDePessoas.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GestaoDePessoas.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GestaoDePessoas.API.dll"]