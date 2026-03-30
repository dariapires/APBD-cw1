using EquipmentRentalSystem.Models;
using EquipmentRentalSystem.Exceptions;

namespace EquipmentRentalSystem.Services;

public class UserService
{
    private readonly List<User> _users = new();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public User GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id)
               ?? throw new UserNotFoundException(id);
    }
}