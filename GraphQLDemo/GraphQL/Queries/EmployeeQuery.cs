using GraphQLDemo.Data;
using GraphQLDemo.Models;
using HotChocolate.Data;

namespace GraphQLDemo.GraphQL.Queries;

public class EmployeeQuery
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Employee> GetEmployees([Service] ApplicationDbContext context)
    {
        return context.Employees;
    }

    [UseFirstOrDefault]
    public IQueryable<Employee> GetEmployee(int id, [Service] ApplicationDbContext context)
    {
        return context.Employees.Where(e => e.Id == id);
    }
}