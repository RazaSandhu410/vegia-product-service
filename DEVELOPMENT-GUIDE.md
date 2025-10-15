# Vegia Product Service - Development Guide

## 🛠️ Development Environment Setup

### Required Tools
1. **Visual Studio 2022** or **VS Code**
2. **.NET 8.0 SDK**
3. **SQL Server** (LocalDB or full version)
4. **Git**
5. **Postman** (for API testing)

### Optional Tools
- **Azure Data Studio** (for database management)
- **GitHub Desktop** (for Git GUI)
- **Docker Desktop** (for containerization)

## 📁 Project Structure Deep Dive

### Vegia.ProductService.API
\\\
API/
├── Controllers/          # API Controllers
├── Models/              # Request/Response models
├── ViewModels/          # View models for presentation
├── Program.cs           # Application entry point
├── appsettings.json     # Configuration
└── Properties/          # Launch settings
\\\

### Vegia.ProductService.BLL
\\\
BLL/
├── Interfaces/          # Service interfaces
├── Services/           # Business logic implementations
├── Validators/         # FluentValidation validators
├── DTOs/              # Data Transfer Objects
└── Mappings/          # AutoMapper profiles
\\\

### Vegia.ProductService.Core
\\\
Core/
├── Entities/           # Domain entities
├── Enums/             # Enumerations
├── Interfaces/         # Repository interfaces
├── Exceptions/         # Custom exceptions
└── Constants/          # Application constants
\\\

### Vegia.ProductService.DAL
\\\
DAL/
├── Configurations/     # EF Entity configurations
├── Contexts/           # DbContext classes
├── Repositories/       # Repository implementations
├── Migrations/         # Database migrations
└── SeedData/           # Initial data seeding
\\\

## 🔄 Development Workflow

### 1. Feature Development Process
\\\
1. Create Feature Branch
   → git checkout -b feature/product-search

2. Implement Changes
   → Add business logic
   → Add/update entities
   → Create/update tests

3. Test Locally
   → Run unit tests
   → Test API endpoints
   → Verify database changes

4. Commit and Push
   → git add .
   → git commit -m \"feat: Add product search functionality\"
   → git push origin feature/product-search

5. Create Pull Request
   → Code review
   → CI/CD pipeline
   → Merge to develop
\\\

### 2. Code Standards

#### Naming Conventions
- **Classes**: PascalCase (\ProductService\)
- **Methods**: PascalCase (\GetProductById\)
- **Variables**: camelCase (\productId\)
- **Interfaces**: I + PascalCase (\IProductRepository\)
- **Constants**: UPPER_CASE (\MAX_PAGE_SIZE\)

#### File Organization
- One class per file
- Folder structure matches namespace
- Group related functionality

### 3. Database Development

#### Creating Migrations
\\\ash
# Add new migration
dotnet ef migrations add AddProductImagesTable

# Update database
dotnet ef database update

# Revert migration
dotnet ef database update PreviousMigration
\\\

#### Entity Configuration
\\\csharp
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.ProductId);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.HasIndex(p => p.SKU).IsUnique();
    }
}
\\\

## 🧪 Testing Strategy

### Unit Tests
- Test business logic in BLL
- Mock dependencies
- Focus on single responsibility

\\\csharp
[Fact]
public void CreateProduct_ValidInput_ReturnsProduct()
{
    // Arrange
    var mockRepo = new Mock<IProductRepository>();
    var service = new ProductService(mockRepo.Object);
    
    // Act
    var result = service.CreateProduct(validProductDto);
    
    // Assert
    Assert.NotNull(result);
    Assert.Equal(\"Test Product\", result.Name);
}
\\\

### Integration Tests
- Test API endpoints
- Use test database
- Test full request/response cycle

### Test Data Management
- Use test data builders
- Centralize test data creation
- Clean up after tests

## 🔍 Debugging Tips

### API Debugging
1. Use Swagger UI for endpoint testing
2. Enable detailed error messages in development
3. Use Postman for complex request scenarios

### Database Debugging
1. Use SQL Server Profiler
2. Check migration history
3. Verify connection strings

### Logging
\\\csharp
// Use structured logging
_logger.LogInformation(\"Creating product {ProductName} for category {CategoryId}\", 
    product.Name, product.CategoryId);
\\\

## 📦 Dependency Management

### Adding New Packages
\\\ash
# Add package to specific project
dotnet add Vegia.ProductService.API package Swashbuckle.AspNetCore

# Update all packages
dotnet outdated
dotnet update
\\\

### Common Dependencies
- **API**: Swashbuckle.AspNetCore (Swagger)
- **BLL**: FluentValidation, AutoMapper
- **DAL**: Microsoft.EntityFrameworkCore.SqlServer
- **Testing**: xUnit, Moq, Microsoft.EntityFrameworkCore.InMemory

## 🚀 Performance Considerations

### Database Optimization
- Use appropriate indexes
- Implement pagination for large datasets
- Use async/await for I/O operations

### API Optimization
- Implement response caching
- Use compression
- Minimize payload size

### Memory Management
- Dispose resources properly
- Use IAsyncDisposable for async cleanup
- Monitor memory usage

## 🔒 Security Best Practices

### Input Validation
- Validate all user inputs
- Use FluentValidation for complex rules
- Sanitize HTML inputs

### Data Protection
- Use parameterized queries
- Implement proper error handling
- Don't expose sensitive data in errors

### API Security
- Implement rate limiting
- Use HTTPS in production
- Consider authentication/authorization

## 📝 Code Review Checklist

- [ ] Code follows naming conventions
- [ ] Unit tests added/updated
- [ ] API documentation updated
- [ ] No sensitive data exposed
- [ ] Error handling implemented
- [ ] Performance considerations addressed
- [ ] Security best practices followed

## 🆘 Troubleshooting

### Common Issues

1. **Migration Errors**
   - Delete Migrations folder and recreate
   - Check for pending migrations

2. **Dependency Conflicts**
   - Clear NuGet cache
   - Delete bin/obj folders
   - Restore packages

3. **Database Connection**
   - Verify connection string
   - Check SQL Server service
   - Ensure TrustServerCertificate=true

### Getting Help
1. Check existing documentation
2. Search GitHub issues
3. Contact development team
