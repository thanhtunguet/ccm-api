# Create a runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the published output from the build stage to the runtime image
COPY ./publish ./

# Expose the port the application will run on
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "CCM.dll"]
