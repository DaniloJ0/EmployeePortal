using Domain.Epss;

namespace Domain.Epss;

public class Eps(EpsId id, string name, DateTime creationDate)
{
    public EpsId Id { get; set; } = id;
    public string Name { get; set; } = name;
    public DateTime CreationDate { get; set; } = creationDate;
}
