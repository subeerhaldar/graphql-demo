# GraphQL vs REST Demo

This project demonstrates a complete CRUD implementation using both REST API and GraphQL with HotChocolate in .NET 8.

## Project Structure

- **Models/Employee.cs**: Employee entity with Id, Name, Department, and Salary properties
- **Data/ApplicationDbContext.cs**: EF Core context with InMemory database
- **Controllers/EmployeesController.cs**: REST API controller with full CRUD operations
- **GraphQL/Queries/EmployeeQuery.cs**: GraphQL queries for reading employees
- **GraphQL/Mutations/EmployeeMutation.cs**: GraphQL mutations for creating, updating, and deleting employees
- **Program.cs**: Configuration for both REST and GraphQL endpoints

## Running the Application

```bash
cd GraphQLDemo
dotnet run
```

The application will start on http://localhost:5213 (or similar).

## Testing the APIs

### REST API Testing
- **Swagger UI**: Visit `http://localhost:5213/swagger` to test REST endpoints interactively

### GraphQL API Testing
- **Banana Cake Pop**: Visit `http://localhost:5213/graphql` to test GraphQL queries and mutations interactively in your browser

## REST API Endpoints

### GET /api/employees
Get all employees
```bash
curl -X GET "https://localhost:5001/api/employees" -H "accept: application/json"
```

### GET /api/employees/{id}
Get employee by ID
```bash
curl -X GET "https://localhost:5001/api/employees/1" -H "accept: application/json"
```

### POST /api/employees
Create new employee
```bash
curl -X POST "https://localhost:5001/api/employees" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "John Doe",
    "department": "Engineering",
    "salary": 75000
  }'
```

### PUT /api/employees/{id}
Update employee
```bash
curl -X PUT "https://localhost:5001/api/employees/1" \
  -H "Content-Type: application/json" \
  -d '{
    "id": 1,
    "name": "John Smith",
    "department": "Engineering",
    "salary": 80000
  }'
```

### DELETE /api/employees/{id}
Delete employee
```bash
curl -X DELETE "https://localhost:5001/api/employees/1"
```

## GraphQL Endpoints

GraphQL is available at `/graphql` endpoint. You can use tools like GraphQL Playground, Banana Cake Pop, or any HTTP client.

### Query Examples

#### Get all employees
```graphql
query {
  employees {
    id
    name
    department
    salary
  }
}
```

#### Get employee by ID
```graphql
query {
  employee(id: 1) {
    id
    name
    department
    salary
  }
}
```

#### Get employees with filtering and sorting
```graphql
query {
  employees(where: { department: { eq: "Engineering" } }, order: { name: ASC }) {
    id
    name
    department
    salary
  }
}
```

### Mutation Examples

#### Create employee
```graphql
mutation {
  createEmployee(name: "Jane Doe", department: "HR", salary: 65000) {
    id
    name
    department
    salary
  }
}
```

#### Update employee
```graphql
mutation {
  updateEmployee(id: 1, name: "Jane Smith", salary: 70000) {
    id
    name
    department
    salary
  }
}
```

#### Delete employee
```graphql
mutation {
  deleteEmployee(id: 1)
}
```

## Conceptual Differences: GraphQL vs REST

### Data Fetching

**REST**: Multiple endpoints return fixed data structures. To get related data, you need multiple requests or over-fetch data.

**GraphQL**: Single endpoint with flexible queries. Clients specify exactly what data they need, avoiding over/under-fetching.

### Over/Under Fetching

**REST**: Endpoints often return more data than needed (over-fetching) or require multiple calls for complete data (under-fetching).

**GraphQL**: Clients request exactly the fields they need, eliminating both over-fetching and under-fetching.

### Versioning

**REST**: API versioning typically done through URL paths (v1, v2) or headers, requiring maintenance of multiple versions.

**GraphQL**: Schema evolution allows adding new fields without breaking changes. Deprecation warnings guide clients to migrate.

### Performance and Flexibility

**REST**: Fixed response structures limit flexibility. Caching is endpoint-based.

**GraphQL**: Highly flexible queries enable optimized data fetching. Resolver-based execution allows fine-grained performance optimization.

## Comparison Table

| Aspect | REST | GraphQL |
|--------|------|---------|
| **Data Fetching** | Multiple endpoints with fixed structures | Single endpoint with flexible queries |
| **Over-fetching** | Common - endpoints return unnecessary data | Eliminated - clients specify needed fields |
| **Under-fetching** | Common - multiple requests needed | Eliminated - single query gets all data |
| **Versioning** | URL/header-based versioning | Schema evolution with deprecation |
| **Caching** | HTTP caching per endpoint | Application-level caching |
| **Documentation** | Manual/API specs | Auto-generated from schema |
| **Real-time** | WebSockets/SSE | Subscriptions built-in |
| **Type Safety** | Runtime validation | Compile-time schema validation |
| **Learning Curve** | Lower for simple APIs | Higher due to query language |
| **Performance** | Predictable per endpoint | Query-dependent optimization needed |

## Technologies Used

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core with InMemory Database
- HotChocolate GraphQL Server
- Minimal dependencies for clarity