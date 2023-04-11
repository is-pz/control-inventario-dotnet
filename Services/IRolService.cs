using control_inventario.Models;

namespace control_inventario.Services
{
    public interface IRolService
    {
        Rol? Get(int id);
        ICollection<Rol> GetAll();
        void Add(Rol rol);
        void Update(Rol rol);
        void Delete(int id);
    }
}
