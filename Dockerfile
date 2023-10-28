#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RecipesApi.csproj", "RecipesApi/"]
COPY [".", "."]
#COPY . /src/
RUN dotnet restore "RecipesApi.csproj"
#COPY . /src/

#COPY FNPOSInscription.WebApi/Resources/* /src/Resources
# /src/FNPOSInscription.WebApi/Resources

WORKDIR "/src/"
RUN dotnet build "RecipesApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecipesApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
EXPOSE 587
EXPOSE 25
WORKDIR /app
COPY --from=publish /app/publish .
COPY FNPOSInscription.WebApi/Resources/* /app/Resources/
ENTRYPOINT ["dotnet", "Recipes.dll"]
