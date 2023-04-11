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

        public Status? Get(int id)
        {
            return _context.Statuses.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Status> GetAll()
        {
            return _context.Statuses.ToList();
        }

        public void Add(Status status)
        {
            _context.Add(status);
            _context.SaveChanges(); 
        }

        public void Update(Status status)
        {
            _context.Update(status);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Status? status = _context.Statuses.Where(c => c.Id == id).FirstOrDefault();

            _context.Remove(status);
            _context.SaveChanges();
        }

    }
}
