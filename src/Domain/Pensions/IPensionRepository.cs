namespace Domain.Pensions;

public interface IPensionRepository
{
    Task<Pension?> GetByIdAsync(Guid id);
    Task Add(Pension customer);
}
