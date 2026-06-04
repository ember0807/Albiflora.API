FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

#  опируем csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

#  опируем остальной код и собираем релизную версию
COPY . ./
RUN dotnet publish -c Release -o out

# «апуск готового приложени€
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Albiflora.API.dll"]