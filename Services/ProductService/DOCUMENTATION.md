# Vegia Product Service - Complete Documentation

## 📖 Overview

Vegia Product Service is a .NET 8 microservice for managing product catalog, categories, vendors, and product images using clean architecture principles.

## 🏗️ Architecture

### Clean Architecture Layers

\\\
Vegia.ProductService/
├── 🎯 API (Presentation Layer)
├── ⚙️ BLL (Business Logic Layer) 
├── 💾 DAL (Data Access Layer)
├── 🔮 Core (Domain Layer)
├── 📊 Reports (Reporting Module)
└── 🧪 Tests (Test Projects)
\\\

### Project Responsibilities

| Project | Responsibility | Technologies |
|---------|----------------|--------------|
| **Vegia.ProductService.API** | Web API, Controllers, HTTP endpoints | ASP.NET Core 8, Swagger |
| **Vegia.ProductService.BLL** | Business logic, validation, services | C#, FluentValidation, AutoMapper |
| **Vegia.ProductService.Core** | Domain entities, interfaces, DTOs | .NET 8, Entity Framework Core |
| **Vegia.ProductService.DAL** | Data access, repositories, DbContext | EF Core, SQL Server |
| **Vegia.ProductService.Reports** | Reporting, templates, exports | .NET 8, PDF generation |
| **Vegia.ProductService.Tests** | Unit & integration tests | xUnit, Moq, EF Core InMemory |

## 🗃️ Domain Model

### Entity Relationships

\\\
Product (1) ←→ (N) ProductImage
Product (N) ←→ (M) Vendor (through ProductVendor)
Category (1) ←→ (N) Product
Vendor (1) ←→ (N) ProductVendor
\\\

### Core Entities

#### Product
- Product ID, Name, Description, Price, SKU
- Category ID (foreign key), CreatedDate, IsActive

#### Category  
- Category ID, Name, Description, ParentCategoryID

#### Vendor
- Vendor ID, Name, Contact Info, Address

#### ProductImage
- Image ID, Product ID, Image URL, Alt Text, Display Order

#### ProductVendor (Junction Table)
- Product ID, Vendor ID, Cost Price, Stock Quantity

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK
- SQL Server 2019+
- Visual Studio 2022 or VS Code
- Git

### Installation Steps

1. **Clone Repository**
   \\\ash
   git clone https://github.com/RazaSandhu410/vegia-product-service.git
   cd vegia-product-service
   \\\

2. **Restore Dependencies**
   \\\ash
   dotnet restore
   \\\

3. **Database Setup**
   - Update connection string in \ppsettings.json\
   - Run migrations: \dotnet ef database update\

4. **Run Application**
   \\\ash
   cd Vegia.ProductService.API
   dotnet run
   \\\

5. **Access API**
   - API: https://localhost:7000
   - Swagger: https://localhost:7000/swagger

## 🔧 Configuration

### AppSettings.json
\\\json
{
  \"ConnectionStrings\": {
    \"DefaultConnection\": \"Server=.;Database=VegiaProducts;Trusted_Connection=true;TrustServerCertificate=true;\"
  },
  \"Logging\": {
    \"LogLevel\": {
      \"Default\": \"Information\"
    }
  },
  \"AllowedHosts\": \"*\"
}
\\\

## 📡 API Endpoints (Planned)

### Products
- \GET /api/products\ - Get all products
- \GET /api/products/{id}\ - Get product by ID
- \POST /api/products\ - Create new product
- \PUT /api/products/{id}\ - Update product
- \DELETE /api/products/{id}\ - Delete product

### Categories
- \GET /api/categories\ - Get all categories
- \GET /api/categories/{id}/products\ - Get products by category

### Vendors
- \GET /api/vendors\ - Get all vendors
- \GET /api/vendors/{id}/products\ - Get vendor products

## 🗃️ Database Schema

### Products Table
\\\sql
CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(1000),
    Price DECIMAL(18,2) NOT NULL,
    SKU NVARCHAR(100) UNIQUE,
    CategoryId INT FOREIGN KEY REFERENCES Categories(CategoryId),
    CreatedDate DATETIME2 DEFAULT GETUTCDATE(),
    IsActive BIT DEFAULT 1
);
\\\

### Categories Table
\\\sql
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(500),
    ParentCategoryId INT NULL FOREIGN KEY REFERENCES Categories(CategoryId)
);
\\\

## 🧪 Testing

### Run Tests
\\\ash
dotnet test
\\\

### Test Structure
- **UnitTests**: Business logic testing
- **IntegrationTests**: API and database testing
- **Mocks**: Test data and mock objects

## 📊 Reporting Features

- Product catalog reports
- Vendor performance reports
- Category-wise sales reports
- Stock level reports

## 🔄 Development Workflow

### Git Branch Strategy
\\\
main
└── develop
    ├── feature/*
    ├── bugfix/*
    └── release/*
\\\

### Commit Convention
- \eat:\ New features
- \ix:\ Bug fixes
- \docs:\ Documentation
- \	est:\ Tests
- \efactor:\ Code refactoring

## 🛠️ Build & Deployment

### Local Build
\\\ash
dotnet build
dotnet publish -c Release
\\\

### Docker Support (Future)
\\\dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT [\"dotnet\", \"Vegia.ProductService.API.dll\"]
\\\

## 🤝 Contributing

1. Fork the repository
2. Create feature branch (\git checkout -b feature/amazing-feature\)
3. Commit changes (\git commit -m 'Add amazing feature'\)
4. Push to branch (\git push origin feature/amazing-feature\)
5. Open Pull Request

## 📝 License

This project is licensed under the MIT License.

## 👨‍💻 Developer

**Raza Sandhu**  
- GitHub: [@RazaSandhu410](https://github.com/RazaSandhu410)
- Project: [Vegia Product Service](https://github.com/RazaSandhu410/vegia-product-service)

## 📞 Support

For support, email razasandhu410@gmail.com or create an issue in the GitHub repository.
