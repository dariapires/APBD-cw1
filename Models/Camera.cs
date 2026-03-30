namespace EquipmentRentalSystem.Models;

public class Camera : Equipment
{
    public int Resolution { get; set; }
    public bool HasStabilization { get; set; }

    public Camera(string name, int resolution, bool hasStabilization) : base(name)
    {
        Resolution = resolution;
        HasStabilization = hasStabilization;
    }
}