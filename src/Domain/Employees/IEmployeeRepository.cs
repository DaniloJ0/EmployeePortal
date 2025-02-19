namespace Domain.Employees;

public interface IEmployeeRepository
{
    Task<Employee?> GetByIdAsync(EmployeeId id);
    Task Add(Employee employee);
    Task<List<Employee>> GetAll();
    Task<bool> GetByIdentification(string identification);
    void Delete(Employee employee);
    void Update(Employee employee);

}
