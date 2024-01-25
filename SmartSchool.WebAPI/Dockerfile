# Use an official ASP.NET Core runtime as a base image


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

#Copy csproj and restorre as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SmartSchool.WebAPI.dll"]

 

