FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
WORKDIR /app/asset-register-api
COPY asset-register-api/*.csproj .
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app/asset-register-api
COPY asset-register-api/. .
RUN dotnet publish -c Release -o out

# test application -- see: dotnet-docker-unit-testing.md
FROM build AS testrunner
WORKDIR /app/tests
COPY asset-register-tests/. .
ENTRYPOINT ["dotnet", "test", "--logger:trx"]

FROM microsoft/dotnet:2.1-runtime AS runtime
WORKDIR /app
COPY --from=build /app/asset-register-api/out ./
ENTRYPOINT ["dotnet", "dotnetapp.dll"]
