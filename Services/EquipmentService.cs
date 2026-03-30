using EquipmentRentalSystem.Enums;
using EquipmentRentalSystem.Models;
using EquipmentRentalSystem.Exceptions;

namespace EquipmentRentalSystem.Services;

public class EquipmentService
{
    private readonly List<Equipment> _equipmentList = new();

    public void AddEquipment(Equipment equipment)
    {
        _equipmentList.Add(equipment);
    }

    public List<Equipment> GetAllEquipment()
    {
        return _equipmentList;
    }

    public List<Equipment> GetAvailableEquipment()
    {
        return _equipmentList.Where(e => e.Status == EquipmentStatus.Available).ToList();
    }

    public Equipment GetEquipmentById(int id)
    {
        return _equipmentList.FirstOrDefault(e => e.Id == id)
               ?? throw new EquipmentNotFoundException(id);
    }

    public void SetUnavailable(int id)
    {
        var equipment = GetEquipmentById(id);
        equipment.Status = EquipmentStatus.Unavailable;
    }
}