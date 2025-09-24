# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a .NET 8 security API with JWT authentication for user management and authorization. The API includes endpoints for user registration, authentication, and user retrieval with role-based access control.

## Architecture

The solution follows a layered architecture pattern:

- **API**: ASP.NET Core Web API project with controllers and configuration
- **Abstracciones**: Contains interfaces and abstract classes for all layers
- **BC**: Business Component layer - handles business logic validation
- **BW**: Business Workflow layer - orchestrates business operations
- **DA**: Data Access layer - handles database operations using Dapper
- **BD**: SQL Server Database project with schema definitions
- **Helpers**: Utility classes and shared functionality

### Dependencies Flow
API → BC/BW → DA → Database
- API layer depends on BC and BW layers
- BC/BW layers depend on DA layer
- All layers depend on Abstracciones for interfaces

## Development Commands

### Building the Solution
```bash
# Build entire solution
dotnet build Seguridad.sln

# Build specific project
dotnet build API/API.csproj --configuration Release

# Build all projects individually (excluding BD)
dotnet build API/API.csproj --configuration Release --no-restore
dotnet build Abstracciones/Abstracciones.csproj --configuration Release --no-restore
dotnet build BC/BC.csproj --configuration Release --no-restore
dotnet build BW/BW.csproj --configuration Release --no-restore
dotnet build DA/DA.csproj --configuration Release --no-restore
dotnet build Helpers/Helpers.csproj --configuration Release --no-restore
```

### Running the API
```bash
# Run the API locally
dotnet run --project API

# Publish for deployment
dotnet publish API/API.csproj -c Release -o ./publish --no-restore
```

### Package Management
The solution uses both public NuGet packages and private GitHub packages. Use the existing NuGet.config for proper package resolution:

```bash
# Restore packages with custom config
dotnet restore Seguridad.sln --configfile NuGet.config
```

### Database Operations
The BD project is a SQL Server Database project (.sqlproj) that requires MSBuild for compilation:

```bash
# Build database project (requires MSBuild on Windows)
msbuild "BD/BD.sqlproj" /p:Configuration=Release /p:Platform="Any CPU" /p:OutputPath="./bin/Release/"
```

## Configuration

### Database Connection
Configure the connection string in `appsettings.json` under `ConnectionStrings:Seguridad`.

### JWT Configuration
JWT settings are configured in `appsettings.json` under the `Token` section:
- `key`: Secret signing key for JWT tokens
- `Issuer`: Token issuer
- `Audience`: Valid audience
- `ExpiresIn`: Token validity duration in minutes

## API Endpoints

- `POST /api/Usuario/RegistrarUsuario` - Public user registration
- `POST /api/Usuario/ObtenerUsuario` - Get user (requires role 2)
- `POST /api/Autenticacion/login` - User authentication

## Testing

```bash
# Run tests if available
dotnet test API/API.csproj --no-restore --verbosity normal --configuration Release
```

## Deployment

The project includes GitHub Actions workflows for automated deployment:
- `deployApi.yml`: Builds and deploys the API to Azure Web App
- `deployBD.yml`: Deploys database changes to Azure SQL Database

Both workflows trigger on pushes to the master branch and support manual dispatch.

## Key Libraries and Dependencies

- **Authentication**: Microsoft.AspNetCore.Authentication.JwtBearer
- **API Documentation**: Swashbuckle.AspNetCore (Swagger)
- **Database Access**: Dapper (via custom DA layer)
- **Custom Packages**: Autorizacion.* packages from private GitHub registry

## Development Notes

- The solution targets .NET 8.0
- Uses dependency injection for service registration in Program.cs
- Follows repository pattern with Dapper for database operations
- Implements middleware for authorization claims processing
- JWT tokens are used for stateless authentication
- Role-based authorization is implemented for protected endpoints