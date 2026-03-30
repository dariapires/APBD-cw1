namespace EquipmentRentalSystem.Models;

public class Student : User
{
    public string StudentNumber { get; set; }
    public string Faculty { get; set; }

    public Student(string firstName, string lastName, string studentNumber, string faculty) 
        : base(firstName, lastName)
    {
        StudentNumber = studentNumber;
        Faculty = faculty;
    }
}