using control_inventario.Models;

namespace control_inventario.Services
{
    public interface IUserService
    {
        UserModel? Get(int id);
        ICollection<UserModel> GetAll();
        void Add(UserModel user);
        void Update(UserModel user);
        void Delete(int id);
    }
}
