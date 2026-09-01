# SchoolProject API

A RESTful Web API built with **ASP.NET Core (.NET 10)** following **Clean Architecture** principles.

## Architecture

The solution is divided into 5 layers:

| Project | Role |
|---|---|
| `SchoolProject.Api` | Presentation layer - controllers, middleware, Swagger |
| `SchoolProject.Core` | Application layer - CQRS handlers, validators, mappings |
| `SchoolProject.Service` | Service layer - business logic |
| `SchoolProject.Infrastructure` | Data access - EF Core repositories, migrations |
| `SchoolProject.Data` | Domain layer - entities, configurations, shared models |

## Features

- **CQRS** with MediatR
- **JWT Authentication** with refresh tokens
- **Role-based Authorization**
- **Fluent Validation**
- **Mapster** for object mapping
- **Localization** (English & Arabic)
- **Serilog** structured logging
- **Swagger / OpenAPI** documentation
- **Global error handling** middleware
- **Email support** via SMTP

## Tech Stack

- .NET 10 / ASP.NET Core
- Entity Framework Core + SQL Server
- MediatR 14
- FluentValidation 12
- Mapster 10
- Serilog
- Swashbuckle (Swagger)

## API Endpoints

### Students
| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/students` | Get all students |
| GET | `/api/students/{id}` | Get student by ID |
| POST | `/api/students` | Add a student |
| PUT | `/api/students` | Update a student |
| DELETE | `/api/students/{id}` | Delete a student |

### Departments
| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/departments/{id}` | Get department by ID |
| GET | `/api/departments/student-count` | Get student count per department |
| GET | `/api/departments/{id}/student-count` | Get student count for a specific department |

### Users
| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/users` | Get all users |
| GET | `/api/users/{id}` | Get user by ID |
| POST | `/api/users/register` | Register a new user |
| POST | `/api/users/sign-in` | Sign in and get JWT token |
| POST | `/api/users/refresh-token` | Refresh JWT token |
| PUT | `/api/users` | Update user |
| DELETE | `/api/users/{id}` | Delete user |
| PUT | `/api/users/change-password` | Change password |

### Authorization
| Method | Route | Description |
|--------|-------|-------------|
| POST | `/api/authorization/add-role` | Add a new role |
| PUT | `/api/authorization/edit-role` | Edit a role |
| DELETE | `/api/authorization/delete-role/{id}` | Delete a role |

## Configuration

Update `appsettings.json` before running:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": ""
  },
  "JwtSettings": {
    "Key": "<your-secret-key>",
    "Issuer": "SchoolProject",
    "Audience": "SchoolProject_Users",
    "ExpiresIn": "60"
  },
  "MailSettings": {
    "Mail": "<your-email>",
    "DisplayName": "School Support",
    "UserName": "<your-email>",
    "Password": "<your-app-password>",
    "Host": "smtp.gmail.com",
    "Port": 587
  },
  "Serilog": {
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Microsoft.AspNetCore.Watch": "Warning",
        "Microsoft.AspNetCore.Watch.BrowserRefresh": "Warning"
      }
    },
    "WriteTo": [
      { "Name": "Console" }
    ],
    "Properties": {
      "ApplicationName": "SchoolProject"
    }
  }
}
```

> **Note:** For Gmail, generate an App Password from your Google Account security settings instead of using your real password.

## Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server / SQL Server Express

### Run the Application

```bash
# Clone the repository
git clone <repo-url>
cd SchoolProject

# Apply database migrations
dotnet ef database update --project SchoolProject.Infrastructure --startup-project SchoolProject.Api

# Run the API
dotnet run --project SchoolProject.Api
```

Swagger UI will be available at: `https://localhost:<port>/swagger`
