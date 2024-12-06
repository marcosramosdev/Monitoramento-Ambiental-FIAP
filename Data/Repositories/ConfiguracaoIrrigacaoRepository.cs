using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbiental.Data.Repositories;
using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Data
{
    public class ConfiguracaoIrrigacaoRepository : Repository<ConfiguracaoIrrigacao>, IConfiguracaoIrrigacaoRepository
    {

        private readonly ApplicationDbContext _context;
        public ConfiguracaoIrrigacaoRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        public async Task<IEnumerable<ConfiguracaoIrrigacao>> GetConfiguracoesPorParqueAsync(int parqueId)
        {
            return await _context.ConfiguracoesIrrigacao
                .Where(c => c.ParqueId == parqueId)
                .ToListAsync();
        }
    }
}
