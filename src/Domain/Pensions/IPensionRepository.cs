namespace Domain.Pensions;

public interface IPensionRepository
{
    Task<Pension?> GetByIdAsync(Pension id);
    Task Add(Pension customer);
}
