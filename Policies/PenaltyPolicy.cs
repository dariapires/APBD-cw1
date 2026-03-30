namespace EquipmentRentalSystem.Policies;

public static class PenaltyPolicy
{
    private const decimal DailyPenalty = 10;

    public static decimal CalculatePenalty(DateTime dueDate, DateTime returnDate)
    {
        if (returnDate <= dueDate)
            return 0;

        int daysLate = (returnDate - dueDate).Days;
        return daysLate * DailyPenalty;
    }
}