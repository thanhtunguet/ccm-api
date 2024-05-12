# Use the .NET 8.0 SDK image as a base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project files into the container
COPY . ./

# Restore dependencies and build the project
RUN dotnet restore
RUN dotnet build --configuration Release --no-restore

# Publish the project
RUN dotnet publish --configuration Release --no-restore --output /app/out

# Create a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the published output from the build stage to the runtime image
COPY --from=build /app/out ./

# Expose the port the application will run on
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "CCM.dll"]
