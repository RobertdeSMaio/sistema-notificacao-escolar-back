FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY *.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
COPY --from=build /app/out .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "sistema-notificacao-escolar-back.dll"]