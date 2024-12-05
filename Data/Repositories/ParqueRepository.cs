using MonitoramentoAmbiental.Data.Repositories;
using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Data.Repository
{
    public class ParqueRepository : IParqueRepository
    {
        private readonly ApplicationDbContext _context;

        public ParqueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Parque GetById(int id)
        {
            return _context.Parques.Find(id);
        }

        public IEnumerable<Parque> GetAll()
        {
            return _context.Parques;
        }

        public void Add(Parque parque)
        {
            _context.Parques.Add(parque);
            _context.SaveChanges();
        }


        public void Update(Parque parque)
        {
            _context.Parques.Update(parque);
            _context.SaveChanges();
        }


        public void Delete(int id)
        {
            var parque = _context.Parques.Find(id);
            if (parque == null) return;
            _context.Parques.Remove(parque);
            _context.SaveChanges();
        }

    }
}
