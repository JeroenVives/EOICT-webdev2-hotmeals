FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY HotMeals/*.sln .
COPY HotMeals/*.csproj .
RUN dotnet restore

# copy everything else and build app
COPY HotMeals/. ./HotMeals/
WORKDIR /app/HotMeals
RUN dotnet publish -o out


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/HotMeals/out ./
ENTRYPOINT ["dotnet", "HotMeals.dll"]