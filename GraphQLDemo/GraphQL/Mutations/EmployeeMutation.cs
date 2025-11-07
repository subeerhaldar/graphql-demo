using GraphQLDemo.Data;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQL.Mutations;

public class EmployeeMutation
{
    public async Task<Employee> CreateEmployee(
        string name,
        string department,
        decimal salary,
        [Service] ApplicationDbContext context)
    {
        var employee = new Employee
        {
            Name = name,
            Department = department,
            Salary = salary
        };

        context.Employees.Add(employee);
        await context.SaveChangesAsync();

        return employee;
    }

    public async Task<Employee?> UpdateEmployee(
        int id,
        string? name,
        string? department,
        decimal? salary,
        [Service] ApplicationDbContext context)
    {
        var employee = await context.Employees.FindAsync(id);
        if (employee == null)
        {
            return null;
        }

        if (name != null)
            employee.Name = name;
        if (department != null)
            employee.Department = department;
        if (salary.HasValue)
            employee.Salary = salary.Value;

        await context.SaveChangesAsync();
        return employee;
    }

    public async Task<bool> DeleteEmployee(int id, [Service] ApplicationDbContext context)
    {
        var employee = await context.Employees.FindAsync(id);
        if (employee == null)
        {
            return false;
        }

        context.Employees.Remove(employee);
        await context.SaveChangesAsync();
        return true;
    }
}