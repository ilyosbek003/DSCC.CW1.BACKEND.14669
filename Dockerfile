# Use the official SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the csproj and restore dependencies
COPY *.sln ./
COPY DSCC.CW1.BACKEND.14669/*.csproj DSCC.CW1.BACKEND.14669/
RUN dotnet restore

# Copy the rest of the code and build the project
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the published output from the build stage
COPY --from=build /app/out .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "DSCC.CW1.BACKEND.14669.dll"]
