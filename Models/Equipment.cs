using EquipmentRentalSystem.Enums;

namespace EquipmentRentalSystem.Models;

public abstract class Equipment
{
    private static int _nextId = 1;

    public int Id { get; }
    public string Name { get; set; }
    public EquipmentStatus Status { get; set; }

    public Equipment(string name)
    {
        Id = _nextId++;
        Name = name;
        Status = EquipmentStatus.Available;
    }
}