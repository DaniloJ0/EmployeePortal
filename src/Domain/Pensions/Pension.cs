namespace Domain.Pensions;

public class Pension(PensionId id, string name, DateTime creationDate)
{
    public PensionId Id { get; set; } = id;
    public string Name { get; set; } = name;
    public DateTime CreationDate { get; set; } = creationDate;
}
