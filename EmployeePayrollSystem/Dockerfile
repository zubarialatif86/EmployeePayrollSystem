# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore (file directly in root, no subfolder)
COPY ["EmployeePayrollSystem.csproj", "."]
RUN dotnet restore "EmployeePayrollSystem.csproj"

# Copy all source code
COPY . .

# Publish
RUN dotnet publish "EmployeePayrollSystem.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EmployeePayrollSystem.dll"]