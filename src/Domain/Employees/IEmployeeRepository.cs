namespace Domain.Employees;

public interface IEmployeeRepository
{
    Task<Employee?> GetByIdAsync(Employee id);
    Task Add(Employee customer);
}
