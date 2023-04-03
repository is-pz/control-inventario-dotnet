using control_inventario.Models;

namespace control_inventario.Services
{
    public interface ISaleItemService
    {
        SaleItemModel? Get(int id);
        ICollection<SaleItemModel> GetAll();
        void Add(SaleItemModel item);
        void Update(SaleItemModel item);
        void Delete(int id);
    }
}
