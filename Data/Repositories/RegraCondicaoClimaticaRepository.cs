using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbiental.Data.Repositories;
using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Data
{
    public class RegraCondicaoClimaticaRepository : Repository<RegraCondicaoClimatica>, IRegraCondicaoClimaticaRepository
    {
        private readonly ApplicationDbContext _context;
        public RegraCondicaoClimaticaRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        public async Task<IEnumerable<RegraCondicaoClimatica>> GetRegrasAtivasPorParqueAsync(int parqueId)
        {
            return await _context.RegrasCondicoesClimaticas
                .Where(r => r.ParqueId == parqueId && r.Ativo)
                .ToListAsync();
        }
    }
}
