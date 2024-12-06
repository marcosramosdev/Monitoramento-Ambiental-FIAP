using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbiental.Data.Repositories;
using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Data
{
    public class HistoricoIrrigacaoRepository : Repository<HistoricoIrrigacao>, IHistoricoIrrigacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public HistoricoIrrigacaoRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        public async Task<IEnumerable<HistoricoIrrigacao>> GetHistoricoPorPeriodoAsync(int parqueId, DateTime inicio, DateTime fim)
        {
            return await _context.HistoricoIrrigacoes
                .Where(h => h.ParqueId == parqueId && h.DataHora >= inicio && h.DataHora <= fim)
                .ToListAsync();
        }
    }
}
