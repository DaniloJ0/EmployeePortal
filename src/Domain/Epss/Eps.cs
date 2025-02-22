﻿using Domain.Employees;
using Domain.Epss;

namespace Domain.Epss;

public class Eps(Guid id, string name, DateTime createdAt)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public DateTime CreatedAt { get; set; } = createdAt;
    public List<Employee> Employees { get; set; }

}
