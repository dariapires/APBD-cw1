namespace EquipmentRentalSystem.Models;

public class Laptop : Equipment
{
    public int Ram { get; set; }
    public string OperatingSystem { get; set; }

    public Laptop(string name, int ram, string operatingSystem) : base(name)
    {
        Ram = ram;
        OperatingSystem = operatingSystem;
    }
}