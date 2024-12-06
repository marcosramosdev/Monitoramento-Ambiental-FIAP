using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbiental.Data.Repositories;
using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Data.Repository
{
    public class ParqueRepository : Repository<Parque>, IParqueRepository
    {
        private readonly ApplicationDbContext _context;

        public ParqueRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parque>> GetParquesComConfiguracoesAsync()
        {
            return await _context.Parques
                .Include(p => p.ConfiguracoesIrrigacao)
                .ToListAsync();
        }
    }
}
