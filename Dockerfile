# Stage 1 - Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "WorkSuiteAI.Api/WorkSuiteAI.Api.csproj"
RUN dotnet publish "WorkSuiteAI.Api/WorkSuiteAI.Api.csproj" -c Release -o /app/publish

# Stage 2 - Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WorkSuiteAI.Api.dll"]