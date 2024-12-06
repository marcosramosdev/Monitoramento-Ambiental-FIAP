using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbiental.Data.Repositories;
using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Data
{
    public class CondicaoClimaticaRepository : Repository<CondicaoClimatica>, ICondicaoClimaticaRepository
    {

        private readonly ApplicationDbContext _context;

        public CondicaoClimaticaRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }



        public async Task<IEnumerable<CondicaoClimatica>> GetCondicoesRecentesAsync(int parqueId)
        {
            return await _context.CondicoesClimaticas
                .Where(c => c.ParqueId == parqueId)
                .OrderByDescending(c => c.DataHora)
                .Take(10)
                .ToListAsync();
        }

        public Task<IEnumerable<CondicaoClimatica>> GetCondicoesRecentesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
