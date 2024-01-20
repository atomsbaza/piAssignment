# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY piAssignment.csproj .
RUN dotnet restore

# Copy everything else and build the application
COPY . .
RUN dotnet publish -c Release -o out

# Install Entity Framework Core tools
RUN dotnet tool install --global dotnet-ef --version 7.0.0

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expose the port
EXPOSE 80

# Run database migrations during the build process
#RUN dotnet ef database update --project piAssignment.csproj --context piDbContext

# Command to run the application
ENTRYPOINT ["dotnet", "piAssignment.dll"]
