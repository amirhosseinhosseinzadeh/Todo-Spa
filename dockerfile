FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY ./src/back-end/Todo.Api/Todo.Api.csproj ./
RUN dotnet restore ./

COPY ./src/back-end/Todo.Api/. ./
RUN dotnet publish -o ./pub/ -c Release

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS production
WORKDIR /etc/Todo.Api/
ENV PROD_TYPE=docker
COPY --from=build /app/pub/. ./
EXPOSE 60917
ENTRYPOINT ["dotnet","./Todo.Api.dll"]