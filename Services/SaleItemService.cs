using control_inventario.Data;
using control_inventario.Models;

namespace control_inventario.Services
{
    public class SaleItemService : ISaleItemService
    {
        private readonly InventarioDbContext _context;
        public SaleItemService(InventarioDbContext inventario) {
            this._context = inventario;
        }

        public SalesItem? Get(int id)
        {
            return _context.SalesItems.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<SalesItem> GetAll()
        {
            return _context.SalesItems.ToList();
        }

        public void Add(SalesItem items)
        {
            _context.Add(items);
            _context.SaveChanges(); 
        }

        public void Update(SalesItem items)
        {
            _context.Update(items);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            SalesItem? items = _context.SalesItems.Where(c => c.Id == id).FirstOrDefault();

            _context.Remove(items);
            _context.SaveChanges();
        }

    }
}
