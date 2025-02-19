namespace Core.DTOs;

public record EmployeeDto
(
    Guid EmployeeId,
    string Name,
    string Identification,
    string BloodType,
    string Phone,
    string ArlName,
    Guid ArlId,
    string EpsName,
    Guid EpsId,
    string PensionName,
    Guid PensionId,
    decimal Salary
);
