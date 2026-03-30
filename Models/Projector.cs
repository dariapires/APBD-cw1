namespace EquipmentRentalSystem.Models;

public class Projector : Equipment
{
    public int Lumens { get; set; }
    public bool IsPortable { get; set; }

    public Projector(string name, int lumens, bool isPortable) : base(name)
    {
        Lumens = lumens;
        IsPortable = isPortable;
    }
}