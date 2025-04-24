# 🏗️ Comic Book Web API Architecture

## ✅ Overview
This project is a .NET 8 Web API for managing comic books, characters, creators, and events. It follows Clean Architecture principles with support for JWT security, AutoMapper, Entity Framework Core, Docker deployment, and logging.

---

## ✅ Layers & Structure

- `Controllers/` – Web API endpoints
- `DTOs/` – Data transfer objects for responses and requests
- `Models/` – Entity models mapped to database
- `Data/` – EF Core DbContext and migrations
- `Mapping/` – AutoMapper profiles
- `Services/` – JWT auth, business logic

---

## ✅ Technology Stack

- ASP.NET Core 8.0
- MS SQL Server
- Entity Framework Core
- AutoMapper
- JWT Authentication
- Serilog + SEQ
- Docker

---

## ✅ Logging & Monitoring

- Console logging for local development
- Serilog structured logs
- SEQ integration via Docker (optional)
- Error and request tracking

---

## ✅ Deployment

The API is containerized and ready for cloud or local deployment:

- `Dockerfile` builds and publishes the app
- Exposes port 80 internally
- Mapped to host port 8080 for Swagger access
- `.dockerignore` used to slim down the build

### Example:
```bash
docker build -t comicbookapi .
docker run -d -p 8080:80 --name comicapi comicbookapi
```

Swagger available at [http://localhost:8080/swagger](http://localhost:8080/swagger)