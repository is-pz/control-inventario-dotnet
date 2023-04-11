using control_inventario.Data;
using control_inventario.Models;

namespace control_inventario.Services
{
    public class UserService : IUserService
    {
        private readonly InventarioDbContext _context;
        public UserService(InventarioDbContext inventario) {
            this._context = inventario;
        }

        public User? Get(int id)
        {
            return _context.Users.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Add(User user)
        {
            _context.Add(user);
            _context.SaveChanges(); 
        }

        public void Update(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            User? user = _context.Users.Where(c => c.Id == id).FirstOrDefault();

            _context.Remove(user);
            _context.SaveChanges();
        }

    }
}
