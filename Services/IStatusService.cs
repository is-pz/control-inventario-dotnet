using control_inventario.Models;

namespace control_inventario.Services
{
    public interface IStatusService
    {
        Status? Get(int id);
        ICollection<Status> GetAll();
        void Add(Status status);
        void Update(Status status);
        void Delete(int id);
    }
}
