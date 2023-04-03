using control_inventario.Models;

namespace control_inventario.Services
{
    public interface ISaleService
    {
        SaleModel? Get(int id);
        ICollection<SaleModel> GetAll();
        void Add(SaleModel sale);
        void Update(SaleModel sale);
        void Delete(int id);
    }
}
