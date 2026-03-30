namespace EquipmentRentalSystem.Models;

public class Rental
{
    private static int _nextId = 1;

    public int Id { get; }
    public User User { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public decimal Penalty { get; set; }

    public bool IsReturned => ReturnDate != null;

    public Rental(User user, Equipment equipment, DateTime rentalDate, DateTime dueDate)
    {
        if (dueDate <= rentalDate)
            throw new ArgumentException("Invalid rental period");

        Id = _nextId++;
        User = user;
        Equipment = equipment;
        RentalDate = rentalDate;
        DueDate = dueDate;
    }
}