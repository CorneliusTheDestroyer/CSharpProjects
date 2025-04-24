## ✅ Comic Book Web API – Project Checklist

### Phase 1: Setup
- [x] Set up .NET 8 Web API project with Swagger
- [x] Define MS SQL database schema
- [x] Add Entity Framework Core and configure DB context

### Phase 2: Clean Architecture & DTOs
- [x] Organize code by feature (Controllers, Models, DTOs, Services)
- [x] Add DTOs and AutoMapper
- [x] Add model validation and error handling
- [x] Implement consistent API response structure

### Phase 3: Secure the API (JWT + Roles)
- [x] Add JWT Authentication
- [x] Create custom Users table and seed users
- [x] Role-based Authorization with [Authorize(Roles = "Admin")]
- [x] Secure Swagger with Authorize button

### Phase 4: Improve Performance
- [x] Pagination for all GET endpoints
- [x] Async methods using EF Core
- [x] Add sorting and filtering options
- [x] Add response compression

### Phase 5: Logging & Monitoring
- [x] Add Serilog
- [x] Enable console logging and SEQ integration
- [x] Centralize error logging

### Phase 6: Deployment
- [x] Create Dockerfile and .dockerignore
- [x] Build and run the API in Docker
- [x] Expose Swagger from Docker container
- [x] Resolve port binding and runtime entrypoint issues