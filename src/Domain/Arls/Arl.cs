using Domain.Arls;

namespace Domain.Arls;

public class Arl(Guid id, string name, DateTime creationDate)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public DateTime CreationDate { get; set; } = creationDate;
}
