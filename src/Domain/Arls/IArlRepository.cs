namespace Domain.Arls;

public interface IArlRepository
{
    Task<Arl?> GetByIdAsync(Guid id);
    Task Add(Arl customer);
    Task<List<Arl>> GetAll();
}
