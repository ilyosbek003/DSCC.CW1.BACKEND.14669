# Use the official ASP.NET Core runtime as a base image for .NET 6
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the published output from the build stage
COPY . . 

# Set the entry point for the application
ENTRYPOINT ["dotnet", "DSCC.CW1.BACKEND._14669.dll"]
