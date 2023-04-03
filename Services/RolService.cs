using control_inventario.Data;
using control_inventario.Models;

namespace control_inventario.Services
{
    public class RolService : IRolService
    {
        private readonly InventarioDbContext _context;
        public RolService(InventarioDbContext inventario) {
            this._context = inventario;
        }

        public RolModel? Get(int id)
        {
            return _context.Roles.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<RolModel> GetAll()
        {
            return _context.Roles.ToList();
        }

        public void Add(RolModel rol)
        {
            _context.Add(rol);
            _context.SaveChanges(); 
        }

        public void Update(RolModel rol)
        {
            _context.Update(rol);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            RolModel? rol = _context.Roles.Where(c => c.Id == id).FirstOrDefault();

            _context.Remove(rol);
            _context.SaveChanges();
        }

    }
}
