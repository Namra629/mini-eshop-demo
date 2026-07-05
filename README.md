# 🛒 Mini E-Shop

A full-stack e-commerce demo application demonstrating modern web application architecture, API development, database integration, caching, and deployment concepts.

## 🚀 Technology Stack

| Layer | Technology |
|---------|------------|
| Frontend | Angular (Standalone Components) |
| Backend | ASP.NET Core Web API (.NET 8) |
| Database | PostgreSQL |
| ORM | Entity Framework Core |
| Cache | Redis |
| Web Server | NGINX |
| Hosting | Linux VM |

![Architecture Diagram](./assets/'mini-eshop architecture.png)

---

# 🏗️ Architecture

```text
┌─────────────────────────┐
│      User Browser       │
│      Angular UI         │
└────────────┬────────────┘
             │
             │ HTTP
             ▼
┌─────────────────────────┐
│         NGINX           │
│ Reverse Proxy & Static  │
│     File Hosting        │
└────────────┬────────────┘
             │
      ┌──────┴──────┐
      │             │
      ▼             ▼
Frontend Files   /api/*
(index.html)      Requests
                    │
                    ▼
        ┌────────────────────┐
        │ ASP.NET Core API   │
        │    Catalog.API     │
        └─────────┬──────────┘
                  │
         ┌────────┴────────┐
         │                 │
         ▼                 ▼
   PostgreSQL DB      Redis Cache
```

---

# 🔄 Application Flow

## Loading the Application

1. User opens the application URL.
2. NGINX serves Angular static files.
3. Angular application loads in the browser.
4. User interacts with the UI.

---

## Product Retrieval Flow

```text
User Clicks "Load Products"
           │
           ▼
Angular Frontend
           │
           ▼
GET /api/products
           │
           ▼
NGINX Reverse Proxy
           │
           ▼
ProductsController
           │
           ▼
Redis Cache Check
           │
     ┌─────┴─────┐
     │ Cache Hit │
     │    or     │
     │ Cache Miss│
     └─────┬─────┘
           ▼
     PostgreSQL
           ▼
      JSON Response
           ▼
Angular UI Updated
```

---

## Order Placement Flow

```text
User Clicks "Buy Now"
          │
          ▼
Angular Frontend
          │
          ▼
POST /api/orders
          │
          ▼
NGINX
          │
          ▼
OrdersController
          │
          ▼
Process Request
          │
          ▼
Return Response
          │
          ▼
Success Message
```

---

# 📂 Project Structure

## Backend

```text
Catalog.API
│
├── Controllers
│   ├── ProductsController.cs
│   └── OrdersController.cs
│
├── Data
│   └── CatalogDbContext.cs
│
├── Models
│   └── Product.cs
│
├── Program.cs
│
└── appsettings.json
```

### Backend Startup Sequence

When the application starts:

1. `Program.cs`
2. Dependency Injection Configuration
3. Database Connection Registration
4. Redis Registration
5. Controller Registration
6. Middleware Configuration
7. API Starts Listening

---

## Frontend

```text
frontend
│
├── src
│   └── app
│       ├── app.ts
│       ├── app.html
│       ├── app.css
│       └── api.service.ts
│
├── angular.json
└── package.json
```

### Frontend Startup Sequence

When a user opens the application:

1. `index.html`
2. Angular bootstrap process
3. `app.ts`
4. `app.html`
5. User interactions
6. `api.service.ts` sends API requests

---

# 🔗 Frontend ↔ Backend Communication

The frontend communicates with the backend using REST APIs.

Example:

```typescript
GET /api/products
POST /api/orders
```

Angular:

```typescript
this.http.get('/api/products');
```

NGINX:

```nginx
location /api/ {
    proxy_pass http://localhost:5006;
}
```

Backend:

```csharp
[HttpGet]
public async Task<IActionResult> GetAll()
{
    ...
}
```

---

# 🚀 Running the Project

## Start PostgreSQL

```bash
sudo systemctl start postgresql
```

## Start Redis

```bash
redis-server
```

## Run Backend

```bash
cd Catalog.API
dotnet run
```

Backend URL:

```text
http://localhost:5006
```

## Build Frontend

```bash
cd frontend
ng build --configuration production
```

## Deploy Angular Build

```bash
sudo cp -r dist/frontend/browser/* /var/www/html/
sudo systemctl restart nginx
```

---

# 🌐 Access the Application

```text
http://<VM-IP>/
```

---

# 📚 Key Concepts Demonstrated

- REST API Development
- ASP.NET Core Dependency Injection
- Entity Framework Core
- PostgreSQL Integration
- Redis Caching
- Angular Frontend Development
- Reverse Proxy Configuration
- NGINX Deployment
- Full Stack Application Flow

---

# 🔮 Future Enhancements

- Docker Containerization
- Docker Compose
- Kubernetes Deployment
- Helm Charts
- ArgoCD GitOps
- CI/CD Pipeline
- JWT Authentication
- Order Persistence
- Distributed Tracing
- Monitoring with Prometheus & Grafana

---

# 👨‍💻 Author

Namra Rasheed

DevOps Engineer | Cloud & Platform Engineering | CI/CD | Kubernetes | Azure | AWS
