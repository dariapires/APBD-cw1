namespace EquipmentRentalSystem.Exceptions;

public class UserNotFoundException(int userId)
    : Exception($"User with id {userId} not found.");