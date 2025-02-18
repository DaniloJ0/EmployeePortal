using Domain.Arls;

namespace Domain.Arls;

public class Arl(ArlId id, string name, DateTime creationDate)
{
    public ArlId Id { get; set; } = id;
    public string Name { get; set; } = name;
    public DateTime CreationDate { get; set; } = creationDate;
}
