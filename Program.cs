using EquipmentRentalSystem.Models;
using EquipmentRentalSystem.Services;
using EquipmentRentalSystem.Services.Rentals;

var equipmentService = new EquipmentService();
var userService = new UserService();
var rentalService = new RentalService();
var reportService = new ReportService();

var laptop1 = new Laptop("Dell Latitude 5520", 16, "Windows 11");
var laptop2 = new Laptop("Lenovo ThinkPad E14", 8, "Windows 10");
var projector1 = new Projector("Epson EB-X49", 3600, true);
var camera1 = new Camera("Canon EOS 250D", 24, true);

equipmentService.AddEquipment(laptop1);
equipmentService.AddEquipment(laptop2);
equipmentService.AddEquipment(projector1);
equipmentService.AddEquipment(camera1);

var student1 = new Student("Anna", "Nowak", "s12345", "Computer Science");
var student2 = new Student("Piotr", "Kowalski", "s54321", "Mathematics");
var employee1 = new Employee("Jan", "Wisniewski", "Lecturer", "IT Department");

userService.AddUser(student1);
userService.AddUser(student2);
userService.AddUser(employee1);

reportService.PrintAllEquipment(equipmentService.GetAllEquipment());
reportService.PrintAvailableEquipment(equipmentService.GetAvailableEquipment());

try
{
    Console.WriteLine("\n--- Correct rental ---");
    rentalService.RentEquipment(student1, laptop1, 7);
    Console.WriteLine($"{student1.FirstName} rented {laptop1.Name}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    Console.WriteLine("\n--- Mark equipment as unavailable and try to rent it ---");
    equipmentService.SetUnavailable(projector1.Id);
    rentalService.RentEquipment(student2, projector1, 3);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    Console.WriteLine("\n--- Exceed student rental limit ---");
    rentalService.RentEquipment(student1, laptop2, 5);
    rentalService.RentEquipment(student1, camera1, 5);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

var rentals = rentalService.GetAll();

if (rentals.Count > 0)
{
    rentals[0].ReturnDate = rentals[0].DueDate;
    rentalService.ReturnEquipment(rentals[0].Id);
    Console.WriteLine($"\nReturned on time: {rentals[0].Equipment.Name}, penalty: {rentals[0].Penalty}");
}

if (rentals.Count > 1)
{
    rentals[1].ReturnDate = rentals[1].DueDate.AddDays(3);
    rentalService.ReturnEquipment(rentals[1].Id);
    Console.WriteLine($"Returned late: {rentals[1].Equipment.Name}, penalty: {rentals[1].Penalty}");
}

Console.WriteLine("\n--- Active rentals for employee ---");
rentalService.RentEquipment(employee1, camera1, 4);
reportService.PrintUserRentals(employee1, rentalService.GetUserRentals(employee1));

Console.WriteLine("\n--- Overdue rentals ---");
var employeeRentals = rentalService.GetUserRentals(employee1);
if (employeeRentals.Count > 0)
{
    employeeRentals[0].DueDate = DateTime.Now.AddDays(-2);
}
reportService.PrintOverdue(rentalService.GetOverdue());

reportService.PrintSummary(equipmentService.GetAllEquipment(), rentalService.GetAll());