# Vegia Product Service - API Endpoints Documentation

## 🌐 Base URL
\https://localhost:7000/api\

## 🔐 Authentication
*Currently no authentication implemented*

## 📦 Products Endpoints

### Get All Products
\\\http
GET /api/products
\\\

**Response:**
\\\json
{
  \"data\": [
    {
      \"productId\": 1,
      \"name\": \"Organic Apples\",
      \"description\": \"Fresh organic apples\",
      \"price\": 4.99,
      \"sku\": \"ORG-APP-001\",
      \"categoryId\": 1,
      \"createdDate\": \"2024-01-15T10:30:00Z\",
      \"isActive\": true
    }
  ],
  \"totalCount\": 1,
  \"page\": 1,
  \"pageSize\": 20
}
\\\

### Get Product by ID
\\\http
GET /api/products/{id}
\\\

**Parameters:**
- \id\ (path, integer, required): Product ID

### Create Product
\\\http
POST /api/products
Content-Type: application/json
\\\

**Request Body:**
\\\json
{
  \"name\": \"New Product\",
  \"description\": \"Product description\",
  \"price\": 19.99,
  \"sku\": \"NEW-PROD-001\",
  \"categoryId\": 1
}
\\\

### Update Product
\\\http
PUT /api/products/{id}
Content-Type: application/json
\\\

### Delete Product
\\\http
DELETE /api/products/{id}
\\\

## 📂 Categories Endpoints

### Get All Categories
\\\http
GET /api/categories
\\\

### Get Category Products
\\\http
GET /api/categories/{id}/products
\\\

## 🏢 Vendors Endpoints

### Get All Vendors
\\\http
GET /api/vendors
\\\

### Get Vendor Products
\\\http
GET /api/vendors/{id}/products
\\\

## 🖼️ Product Images Endpoints

### Upload Product Image
\\\http
POST /api/products/{id}/images
Content-Type: multipart/form-data
\\\

### Get Product Images
\\\http
GET /api/products/{id}/images
\\\

## 📄 Common Response Formats

### Success Response
\\\json
{
  \"success\": true,
  \"data\": { ... },
  \"message\": \"Operation completed successfully\"
}
\\\

### Error Response
\\\json
{
  \"success\": false,
  \"error\": {
    \"code\": \"VALIDATION_ERROR\",
    \"message\": \"Invalid input data\",
    \"details\": [ ... ]
  }
}
\\\

### Pagination Response
\\\json
{
  \"data\": [ ... ],
  \"pagination\": {
    \"page\": 1,
    \"pageSize\": 20,
    \"totalCount\": 100,
    \"totalPages\": 5
  }
}
\\\

## 🔍 Query Parameters

### Pagination
- \page\ (default: 1)
- \pageSize\ (default: 20, max: 100)

### Sorting
- \sortBy\ (e.g., \
ame\, \price\, \createdDate\)
- \sortOrder\ (\sc\ or \desc\)

### Filtering
- \categoryId\ - Filter by category
- \endorId\ - Filter by vendor
- \minPrice\, \maxPrice\ - Price range filter
- \search\ - Search in name and description

## 📋 Status Codes

| Code | Description |
|------|-------------|
| 200 | Success |
| 201 | Created |
| 400 | Bad Request |
| 404 | Not Found |
| 500 | Internal Server Error |
