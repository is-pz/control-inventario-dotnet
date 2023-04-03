using control_inventario.Models;

namespace control_inventario.Services
{
    public interface IStatusService
    {
        StatusModel? Get(int id);
        ICollection<StatusModel> GetAll();
        void Add(StatusModel status);
        void Update(StatusModel status);
        void Delete(int id);
    }
}
