using control_inventario.Data;
using control_inventario.Models;

namespace control_inventario.Services
{
    public class StatusService : IStatusService
    {
        private readonly InventarioDbContext _context;
        public StatusService(InventarioDbContext inventario) {
            this._context = inventario;
        }

        public StatusModel? Get(int id)
        {
            return _context.Status.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<StatusModel> GetAll()
        {
            return _context.Status.ToList();
        }

        public void Add(StatusModel status)
        {
            _context.Add(status);
            _context.SaveChanges(); 
        }

        public void Update(StatusModel status)
        {
            _context.Update(status);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            StatusModel? status = _context.Status.Where(c => c.Id == id).FirstOrDefault();

            _context.Remove(status);
            _context.SaveChanges();
        }

    }
}
