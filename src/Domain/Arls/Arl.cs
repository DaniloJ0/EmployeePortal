﻿using Domain.Arls;
using Domain.Employees;

namespace Domain.Arls;

public class Arl(Guid id, string name, DateTime createdAt)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public DateTime CreatedAt { get; set; } = createdAt;

    public List<Employee> Employees { get; set; }
}
