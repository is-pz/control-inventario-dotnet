using control_inventario.Models;

namespace control_inventario.Services
{
    public interface IRolService
    {
        RolModel? Get(int id);
        ICollection<RolModel> GetAll();
        void Add(RolModel rol);
        void Update(RolModel rol);
        void Delete(int id);
    }
}
