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

        public SaleItemModel? Get(int id)
        {
            return _context.SalesItems.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<SaleItemModel> GetAll()
        {
            return _context.SalesItems.ToList();
        }

        public void Add(SaleItemModel items)
        {
            _context.Add(items);
            _context.SaveChanges(); 
        }

        public void Update(SaleItemModel items)
        {
            _context.Update(items);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            SaleItemModel? items = _context.SalesItems.Where(c => c.Id == id).FirstOrDefault();

            _context.Remove(items);
            _context.SaveChanges();
        }

    }
}
