using control_inventario.Models;

namespace control_inventario.Services
{
    public interface IUserService
    {
        User? Get(int id);
        ICollection<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
