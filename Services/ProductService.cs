using control_inventario.Data;
using control_inventario.Models;

namespace control_inventario.Services
{
    public class ProductService : IProdutService
    {
        private readonly InventarioDbContext _context;
        public ProductService(InventarioDbContext inventario) {
            this._context = inventario;
        }

        public Product? Get(int id)
        {
            return _context.Products.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Add(Product product)
        {
            _context.Add(product);
            _context.SaveChanges(); 
        }

        public void Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product? product = _context.Products.Where(c => c.Id == id).FirstOrDefault();

            _context.Remove(product);
            _context.SaveChanges();
        }

    }
}
