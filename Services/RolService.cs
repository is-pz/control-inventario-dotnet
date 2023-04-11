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

        public Rol? Get(int id)
        {
            return _context.Roles.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Rol> GetAll()
        {
            return _context.Roles.ToList();
        }

        public void Add(Rol rol)
        {
            _context.Add(rol);
            _context.SaveChanges(); 
        }

        public void Update(Rol rol)
        {
            _context.Update(rol);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Rol? rol = _context.Roles.Where(c => c.Id == id).FirstOrDefault();

            _context.Remove(rol);
            _context.SaveChanges();
        }

    }
}
