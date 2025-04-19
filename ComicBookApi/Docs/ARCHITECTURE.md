# 🧱 Comic Book Web API – Architecture Overview (Updated with SEQ Logging)

## 🎯 Project Summary

A full-featured RESTful Web API built with **.NET 8**, **Entity Framework Core**, and **MS SQL Server**, exposing a rich comic book universe with structured data around comics, characters, creators, events, and more — all wrapped in a clean, secure, and scalable architecture.

---

## 🧩 Tech Stack

| Layer            | Tech                                     |
|------------------|------------------------------------------|
| Framework        | .NET 8 Web API                           |
| ORM              | Entity Framework Core                    |
| Database         | Microsoft SQL Server                     |
| Docs / UI        | Swagger / Swashbuckle                    |
| Authentication   | JWT Bearer Tokens                        |
| Serialization    | System.Text.Json + DTOs                  |
| Object Mapping   | AutoMapper                               |
| Caching          | In-Memory Cache                          |
| Logging          | Serilog + SEQ                            |
| Dev Environment  | Visual Studio 2022 + Docker (Planned)    |

---

## 📦 Folder Structure

```
ComicBookApi/
├── Controllers/       # API endpoints (CRUD logic)
├── DTOs/              # Data Transfer Objects (input/output)
├── Mapping/           # AutoMapper profiles
├── Models/            # EF Core entity models
├── Services/          # JWT token generator
├── Data/              # DbContext
├── Middlewares/       # Global error handler
├── Responses/         # Base response wrapper
├── Program.cs         # Main config + DI + middleware
├── appsettings.json   # Config (connection strings, JWT keys, Serilog)
```

---

## 🗃️ Database Design

### 💡 Key Entities:
- **Comic** – Individual issues, includes SeriesId FK
- **Series** – Comic collections (e.g., Uncanny X-Men)
- **Character** – Heroes, villains, etc.
- **Creator** – Artists, writers
- **Event** – Big crossover storylines
- **Story** – Subcomponents of comics (covers, arcs)

### 🔗 Relationships:
- Comics → Series (many-to-one)
- Comics ↔ Characters (many-to-many)
- Comics ↔ Creators (many-to-many)
- Comics ↔ Events (many-to-many)
- Comics → Stories (one-to-many)

---

## 🔐 Authentication

- Uses JWT-based token auth
- `AuthController` issues signed tokens on login
- `Bearer` tokens passed via `Authorization: Bearer {token}` headers
- `[Authorize]` + `[Authorize(Roles = "...")]` for protection

---

## 🧼 Clean API Architecture

| Element          | Usage                                             |
|------------------|---------------------------------------------------|
| **DTOs**         | Prevent circular refs, shape client-friendly data |
| **AutoMapper**   | Model → DTO mapping and vice versa                |
| **Validation**   | `[Required]`, `[MaxLength]` via CreateDTOs        |
| **Swagger**      | Enabled, JWT integration supported                |
| **BaseResponse** | Unified structure for all responses               |
| **ErrorHandler** | Global middleware for 500 errors                  |
| **Logging**      | Serilog with SEQ sink for structured log events   |

---

## 🧪 Swagger

- All endpoints are documented
- Token support via 🔒 "Authorize" button
- DTOs simplify JSON structure
- Clean error responses for invalid data

---

## ✅ Completed Controllers (CRUD + DTO Refactor)

| Controller         | Output DTO | Input Validation |
|--------------------|------------|------------------|
| Comics             | ✅ ComicDTO | ✅ ComicCreateDTO |
| Characters         | ✅ CharacterDTO | ✅ CharacterCreateDTO |
| Series             | ✅ SeriesDTO | ✅ SeriesCreateDTO |
| Creators           | ✅ CreatorDTO | ✅ CreatorCreateDTO |
| Events             | ✅ EventDTO | ✅ EventCreateDTO |
| Stories            | ✅ StoryDTO | ✅ StoryCreateDTO |

---

## 🔍 Logging & Observability

- Integrated **Serilog**
- Logs structured events to **SEQ**
- Logs unhandled exceptions in `ErrorHandlingMiddleware`
- Future ready for SEQ dashboard monitoring, alerts, and search

---

## ✅ Performance Features

- Pagination on `GET` endpoints
- In-memory caching for repeated queries
- Async/await for non-blocking performance
- `.AsNoTracking()` for read-only calls

---

## 🧭 Next Steps (Deployment & CI/CD)

- Dockerize the API for cross-platform deployment
- Push to Azure App Service (or other)
- Set up CI/CD via GitHub Actions or Azure Pipelines