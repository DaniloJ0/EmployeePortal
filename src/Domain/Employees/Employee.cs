using Domain.Arls;
using Domain.Epss;
using Domain.Pensions;
using Domain.ValueObjects;

namespace Domain.Employees;

public class Employee
{
    public Employee(EmployeeId id, string name, string cedula, string bloodType, PhoneNumber phone, Guid arlId, Guid epsId, Guid pensionId)
    {
        Id = id;
        Name = name;
        Cedula = cedula;
        BloodType = bloodType;
        Phone = phone;
        ArlId = arlId;
        EpsId = epsId;
        PensionId = pensionId;
    }

    public EmployeeId Id { get; set; }
    public string Name { get; set; }
    public string Cedula { get; set; }
    public string BloodType { get; set; }
    public PhoneNumber Phone { get; set; }

    public Guid ArlId { get; set; }
    public Arl Arl { get; set; }

    public Guid EpsId { get; set; }
    public Eps Eps { get; set; }

    public Guid PensionId { get; set; }
    public Pension Pension { get; set; }

    public decimal Salary { get; set; }

    public DateTime CreatedAt { get; set; }
}
