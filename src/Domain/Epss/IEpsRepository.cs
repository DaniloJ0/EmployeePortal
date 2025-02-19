namespace Domain.Epss;

public interface IEpsRepository
{
    Task<Eps?> GetByIdAsync(Guid id);
    Task Add(Eps customer);
    Task<List<Eps>> GetAll();

}
