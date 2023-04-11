using control_inventario.Models;

namespace control_inventario.Services
{
    public interface ISaleItemService
    {
        SalesItem? Get(int id);
        ICollection<SalesItem> GetAll();
        void Add(SalesItem item);
        void Update(SalesItem item);
        void Delete(int id);
    }
}
