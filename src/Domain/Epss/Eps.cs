using Domain.Epss;

namespace Domain.Epss;

public class Eps(Guid id, string name, DateTime creationDate)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public DateTime CreationDate { get; set; } = creationDate;
}
