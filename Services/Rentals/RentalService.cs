using EquipmentRentalSystem.Enums;
using EquipmentRentalSystem.Models;
using EquipmentRentalSystem.Exceptions;
using EquipmentRentalSystem.Policies;


namespace EquipmentRentalSystem.Services.Rentals;

public class RentalService
{
    private readonly List<Rental> _rentals = new();

    public void RentEquipment(User user, Equipment equipment, int days)
    {
        if (equipment.Status != EquipmentStatus.Available)
            throw new EquipmentUnavailableException(equipment.Id);;

        int activeRentals = _rentals.Count(r => r.User == user && !r.IsReturned);

        int limit = RentalPolicy.GetRentalLimit(user);

        if (activeRentals >= limit)
            throw new RentalLimitExceededException(user.Id);

        var rental = new Rental(
            user,
            equipment,
            DateTime.Now,
            DateTime.Now.AddDays(days)
        );

        equipment.Status = EquipmentStatus.Rented;

        _rentals.Add(rental);
    }

    public void ReturnEquipment(int rentalId)
    {
        var rental = _rentals.FirstOrDefault(r => r.Id == rentalId);

        if (rental == null)
            throw new RentalNotFoundException(rentalId);

        if (rental.ReturnDate == null)
        {
            rental.ReturnDate = DateTime.Now;
        }

        rental.Equipment.Status = EquipmentStatus.Available;
        rental.Penalty = PenaltyPolicy.CalculatePenalty(rental.DueDate, rental.ReturnDate.Value);
    }

    public List<Rental> GetUserRentals(User user)
    {
        return _rentals.Where(r => r.User == user && !r.IsReturned).ToList();
    }

    public List<Rental> GetAll()
    {
        return _rentals;
    }

    public List<Rental> GetOverdue()
    {
        return _rentals.Where(r => !r.IsReturned && r.DueDate < DateTime.Now).ToList();
    }
}