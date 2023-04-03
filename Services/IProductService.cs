using control_inventario.Models;

namespace control_inventario.Services
{
    public interface IProdutService
    {
        ProductModel? Get(int id);
        ICollection<ProductModel> GetAll();
        void Add(ProductModel product);
        void Update(ProductModel product);
        void Delete(int id);
    }
}
