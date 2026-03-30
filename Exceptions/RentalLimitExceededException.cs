namespace EquipmentRentalSystem.Exceptions;

public class RentalLimitExceededException(int userId)
    : Exception($"User {userId} exceeded rental limit.");