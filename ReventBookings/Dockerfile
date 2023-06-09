#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Build state | Base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY *.csproj ./
RUN dotnet restore 

COPY . ./
RUN dotnet publish -c Release -o out

# Runtime stage | Final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
Copy --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ReventBookings.dll"]