# 🧱 Comic Book Web API – Architecture Overview (Victory Lap Edition)

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
| Dev Environment  | Visual Studio 2022                       |

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
├── Responses/         # (optional) base response wrappers
├── Program.cs         # Main config + DI + middleware
├── appsettings.json   # Config (connection strings, JWT keys)
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
- `[Authorize]` attribute locks down endpoints

---

## 🧼 Clean API Architecture

| Element          | Usage                                             |
|------------------|---------------------------------------------------|
| **DTOs**         | Prevent circular refs, shape client-friendly data |
| **AutoMapper**   | Model → DTO mapping and vice versa                |
| **Validation**   | `DataAnnotations` (`[Required]`, `[MaxLength]`)   |
| **Swagger**      | Enabled, clean response models                    |

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
| Series             | ✅ SeriesDTO | ❌ (optional next) |
| Creators           | ✅ CreatorDTO | ❌ (optional next) |
| Events             | ✅ EventDTO | ❌ (optional next) |
| Stories            | ✅ StoryDTO | ❌ (optional next) |

---

## 🧭 Next Steps (Phase 3+ and beyond)

- Add CreateDTOs + validation for Series, Events, etc.
- Add BaseResponse<T> wrapper for consistent responses
- Add pagination, caching
- Deploy via Docker or Azure App Service
- Add a frontend (Angular? Blazor? React?)