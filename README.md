# MarketSystem V3.0.0 — Products & Categories REST API

> ASP.NET Core Web API · 3-Layer Architecture · JWT Authentication · ASP.NET Identity · FluentValidation · AutoMapper

---

## What's New in V3

| Feature | V2 | V3 |
|---|---|---|
| Authentication | None | JWT Bearer Token |
| Authorization | None | Role-based (Admin / User) |
| Validation | Manual | FluentValidation + Extension Methods |
| Object Mapping | Manual | AutoMapper |
| User Management | None | ASP.NET Core Identity |
| Search by Title | No | Yes |

---

## Architecture

```
MarketSystem.API          →  Controllers · Auth · Role Guards · DI
        ↓
MarketSystem.BLL          →  Managers · DTOs · Validators · AutoMapper Profile
        ↓
MarketSystem.DAL          →  Repositories · EF Core · Models · Migrations
```

---

## Project Structure

```
MarketSystem/
├── MArketSystem.API/
│   ├── Controllers/
│   │   ├── AuthController.cs           # Register & Login → JWT token
│   │   ├── ProductController.cs        # [Authorize] CRUD + search by title
│   │   └── CategoryController.cs       # [Authorize] CRUD + search by name
│   ├── AdminAccountCreation/
│   │   └── AdminAccount.cs             # Seeds default admin on startup
│   ├── Roles/
│   │   └── ApplicatioRoles.cs          # "Admin" / "User" constants
│   └── Program.cs
│
├── MarketSystem.BLL/
│   ├── AutoMapping/
│   │   └── MappingProfile.cs           # All AutoMapper mappings
│   ├── DTOs/
│   │   ├── Account/
│   │   │   ├── RegisterDTO.cs
│   │   │   └── LoginDTO.cs
│   │   ├── Produtc/
│   │   │   ├── ProductReadAllDTO.cs
│   │   │   ├── ProductGetByIDDTO.cs
│   │   │   ├── ProducGetByTitleDTO.cs
│   │   │   ├── ProductAddDTO.cs
│   │   │   └── ProductUpdateDTO.cs
│   │   └── Category/
│   │       ├── CategoryReadAllDTO.cs
│   │       ├── CategoryGetByIDDTO.cs
│   │       ├── CategoryGetByTitleDTO.cs
│   │       ├── CategoryAddDto.cs
│   │       └── CategoryUpdateDTO.cs
│   ├── Manager/
│   │   ├── Product/
│   │   │   ├── IProductManager.cs
│   │   │   └── ProductManager.cs
│   │   └── Category/
│   │       ├── ICategoryManager.cs
│   │       └── CategoryManager.cs
│   └── Validation/
│       ├── Product/
│       │   ├── ProductAddValidator.cs
│       │   └── ProductUpdateValidator.cs
│       ├── Category/
│       │   ├── CategorAddValidator.cs
│       │   └── CategoryUpdateValidator.cs
│       ├── Account/
│       │   └── RegisterValidator.cs
│       └── GenericExtentionMethodValidation/
│           ├── ProductExtentionMethodVAlidation.cs
│           └── AccountExtentionMethodValidation.cs
│
└── MarketSystem.DAL/
    ├── Data/
    │   ├── Models/
    │   │   ├── ProductModel.cs
    │   │   ├── CategoryModel.cs
    │   │   └── ApplicationUser.cs      # Extends IdentityUser
    │   ├── ApplicationContext/
    │   │   └── MarketSystemContext.cs  # IdentityDbContext + seed data
    │   └── Configrations/
    │       └── ProductConfigration.cs
    ├── Repositories/
    │   ├── Products/
    │   │   ├── IProductRepo.cs
    │   │   └── ProductRepo.cs
    │   └── Categories/
    │       ├── ICategoryRepo.cs
    │       └── CategoryRepo.cs
    └── Migrations/
```

---

## Authentication & Authorization

### Flow

```
POST /api/Auth/Sign-Up   →  Create account → assigned "User" role
POST /api/Auth/Login     →  Returns JWT token (valid 2 days)
Authorization: Bearer <token>  →  Required on all other endpoints
```

### Roles

| Role | Permissions |
|---|---|
| `User` | GET only (read products & categories) |
| `Admin` | Full access (GET + POST + PUT + DELETE) |

A default Admin account is seeded automatically on first run.

### JWT Token Structure

Claims included in every token:
- `NameIdentifier` — User ID
- `Name` — Username
- `Role` — Admin or User

---

## API Endpoints

### Auth · `/api/Auth`

| Method | Endpoint | Auth | Body |
|---|---|---|---|
| `POST` | `/api/Auth/Sign-Up` | None | `RegisterDTO` |
| `POST` | `/api/Auth/Login` | None | `LoginDTO` |

**Register body:**
```json
{
  "firstName": "Ahmed",
  "lastNAme": "Elzayady",
  "email": "ahmed@example.com",
  "userName": "ahmed_dev",
  "password": "pass123"
}
```

**Login body:**
```json
{
  "userName": "ahmed_dev",
  "password": "pass123"
}
```

**Login response:** JWT token string

---

### Products · `/api/Product`

| Method | Endpoint | Role | Description |
|---|---|---|---|
| `GET` | `/api/Product/GetAllProducts` | Admin, User | Get all products |
| `GET` | `/api/Product/{id}` | Admin, User | Get by ID |
| `GET` | `/api/Product/GetByTitle?Title=` | Admin, User | Search by title |
| `POST` | `/api/Product` | Admin only | Add product |
| `PUT` | `/api/Product/{id}` | Admin only | Update product |
| `DELETE` | `/api/Product/{id}` | Admin only | Delete product |

**POST / PUT body:**
```json
{
  "title": "iPhone 15 Pro",
  "description": "256GB Titanium",
  "price": 1200.00,
  "unitOFStock": 15,
  "categoryModelId": 1
}
```

---

### Categories · `/api/Category`

| Method | Endpoint | Role | Description |
|---|---|---|---|
| `GET` | `/api/Category/GetAllCategories` | Admin, User | Get all categories |
| `GET` | `/api/Category/{id}` | Admin, User | Get by ID |
| `GET` | `/api/Category/GetByName?Name=` | Admin, User | Search by name |
| `POST` | `/api/Category` | Admin only | Add category |
| `PUT` | `/api/Category/{id}` | Admin only | Update category |
| `DELETE` | `/api/Category` | Admin only | Delete category |

---

## Validation Rules

### Product
| Field | Rules |
|---|---|
| `Title` | Required · Max 20 characters |
| `Description` | Required · Max 40 characters |
| `Price` | Min $20 |
| `UnitOFStock` | Min 0 |

### Category
| Field | Rules |
|---|---|
| `Name` | Required · Max 15 characters |

### Register
| Field | Rules |
|---|---|
| `FirstName` | Required · Max 15 characters |
| `LastName` | Required · Max 15 characters |

All validators use **FluentValidation** with custom error codes (e.g. `ERR:INVALID_TITLE`).
Reusable rules are extracted into **Extension Methods** to avoid repetition across validators.

---

## Seed Data

**Categories:** Smartphones · Laptops · Electronics & Gaming · Accessories

**Products (10 items):** iPhone 15 Pro · Samsung Galaxy S24 Ultra · Dell XPS 15 · MacBook Air M3 · LG OLED TV 55 · Sony PlayStation 5 · AirPods Pro 2 · Samsung T7 SSD · Logitech MX Master 3S · Asus ROG Swift

---

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server

### Setup

**1. Clone the repo**
```bash
git clone <your-repo-url>
cd "MarketSystem V3.0.0"
```

**2. Update `appsettings.json`**
```json
{
  "ConnectionStrings": {
    "cs": "Data Source=YOUR_SERVER;Initial Catalog=MarketSystemDB;Integrated Security=True;TrustServerCertificate=True"
  },
  "SecretKey": "your-secret-key-min-16-chars",
  "Issure": "MyCpmpany",
  "Audiance": "MobileApp"
}
```

**3. Apply migrations**
```bash
dotnet ef database update --project MarketSystem.DAL --startup-project MArketSystem.API
```

**4. Run**
```bash
dotnet run --project MArketSystem.API
```

**5. Open Swagger**
```
https://localhost:{port}/swagger
```

To test protected endpoints in Swagger: Login first → copy the token → click Authorize → paste as `Bearer <token>`

---

## Key Concepts Applied

- **JWT Authentication** — Stateless token-based auth with claims (ID, username, role)
- **Role-based Authorization** — `[Authorize(Roles = "Admin")]` guards write operations
- **ASP.NET Core Identity** — Full user management with hashed passwords and roles
- **FluentValidation** — Declarative validation rules with custom error codes, reused via extension methods
- **AutoMapper** — Zero manual mapping code; all mappings centralized in `MappingProfile`
- **Admin Seeding** — Default admin account created on startup if it doesn't exist
- **async/await** — All DB operations fully async end-to-end
