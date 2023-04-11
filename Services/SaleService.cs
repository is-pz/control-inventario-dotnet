using control_inventario.Data;
using control_inventario.Models;

namespace control_inventario.Services
{
    public class SaleService : ISaleService
    {
        private readonly InventarioDbContext _context;
        public SaleService(InventarioDbContext inventario) {
            this._context = inventario;
        }

        public Sale? Get(int id)
        {
            return _context.Sales.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Sale> GetAll()
        {
            return _context.Sales.ToList();
        }

        public void Add(Sale sale)
        {
            _context.Add(sale);
            _context.SaveChanges(); 
        }

        public void Update(Sale sale)
        {
            _context.Update(sale);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Sale? sale = _context.Sales.Where(c => c.Id == id).FirstOrDefault();

            _context.Remove(sale);
            _context.SaveChanges();
        }

    }
}
