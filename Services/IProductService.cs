using control_inventario.Models;

namespace control_inventario.Services
{
    public interface IProdutService
    {
        Product? Get(int id);
        ICollection<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
