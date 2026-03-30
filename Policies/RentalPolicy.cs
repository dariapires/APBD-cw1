using EquipmentRentalSystem.Models;

namespace EquipmentRentalSystem.Policies;

public static class RentalPolicy
{
    public static int GetRentalLimit(User user)
    {
        return user switch
        {
            Student => 2,
            Employee => 5,
            _ => 0
        };
    }
}