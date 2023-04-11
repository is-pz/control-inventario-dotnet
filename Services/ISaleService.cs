using control_inventario.Models;

namespace control_inventario.Services
{
    public interface ISaleService
    {
        Sale? Get(int id);
        ICollection<Sale> GetAll();
        void Add(Sale sale);
        void Update(Sale sale);
        void Delete(int id);
    }
}
