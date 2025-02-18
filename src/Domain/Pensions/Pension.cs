﻿using Domain.Employees;

namespace Domain.Pensions;

public class Pension(Guid id, string name, DateTime creationDate)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public DateTime CreatedAt { get; set; } = creationDate;

    public List<Employee> Employees { get; set; }

}
