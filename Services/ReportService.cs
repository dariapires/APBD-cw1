using EquipmentRentalSystem.Models;

namespace EquipmentRentalSystem.Services;

public class ReportService
{
    public void PrintAllEquipment(List<Equipment> equipment)
    {
        Console.WriteLine("\n--- All Equipment ---");
        foreach (var e in equipment)
        {
            Console.WriteLine($"ID: {e.Id}, Name: {e.Name}, Status: {e.Status}");
        }
    }

    public void PrintAvailableEquipment(List<Equipment> equipment)
    {
        Console.WriteLine("\n--- Available Equipment ---");
        foreach (var e in equipment)
        {
            Console.WriteLine($"ID: {e.Id}, Name: {e.Name}");
        }
    }

    public void PrintUserRentals(User user, List<Rental> rentals)
    {
        Console.WriteLine($"\n--- Rentals for {user.FirstName} {user.LastName} ---");
        foreach (var r in rentals)
        {
            Console.WriteLine($"Equipment: {r.Equipment.Name}, Due: {r.DueDate}");
        }
    }

    public void PrintOverdue(List<Rental> rentals)
    {
        Console.WriteLine("\n--- Overdue Rentals ---");
        foreach (var r in rentals)
        {
            Console.WriteLine($"User: {r.User.FirstName}, Equipment: {r.Equipment.Name}, Due: {r.DueDate}");
        }
    }

    public void PrintSummary(List<Equipment> equipment, List<Rental> rentals)
    {
        Console.WriteLine("\n--- Summary ---");

        int total = equipment.Count;
        int available = equipment.Count(e => e.Status.ToString() == "Available");
        int rented = equipment.Count(e => e.Status.ToString() == "Rented");

        Console.WriteLine($"Total equipment: {total}");
        Console.WriteLine($"Available: {available}");
        Console.WriteLine($"Rented: {rented}");
        Console.WriteLine($"Active rentals: {rentals.Count(r => !r.IsReturned)}");
    }
}