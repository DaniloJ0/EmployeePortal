namespace Domain.Epss;

public interface IEpsRepository
{
    Task<Eps?> GetByIdAsync(Eps id);
    Task Add(Eps customer);
}
