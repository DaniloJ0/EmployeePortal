namespace Domain.Employees;

public interface IEmployeeRepository
{
    Task<Employee?> GetByIdAsync(EmployeeId id);
    Task Add(Employee customer);
}
