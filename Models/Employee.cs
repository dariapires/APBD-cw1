namespace EquipmentRentalSystem.Models;

public class Employee : User
{
    public string Position { get; set; }
    public string Department { get; set; }

    public Employee(string firstName, string lastName, string position, string department)
        : base(firstName, lastName)
    {
        Position = position;
        Department = department;
    }
}