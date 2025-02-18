namespace Domain.Arls;

public interface IArlRepository
{
    Task<Arl?> GetByIdAsync(Arl id);
    Task Add(Arl customer);
}
