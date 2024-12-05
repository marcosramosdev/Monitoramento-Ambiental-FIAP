using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbiental.Data;
using MonitoramentoAmbiental.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitoramentoAmbiental.Services
{
    public class HistoricoIrrigacaoService : IHistoricoIrrigacaoService
    {
        private readonly ApplicationDbContext _context;

        public HistoricoIrrigacaoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HistoricoIrrigacao>> GetAllAsync()
        {
            return await _context.HistoricosIrrigacao.ToListAsync();
        }

        public async Task<HistoricoIrrigacao> GetByIdAsync(int id)
        {
            return await _context.HistoricosIrrigacao.FindAsync(id);
        }

        public async Task<HistoricoIrrigacao> CreateAsync(HistoricoIrrigacao historico)
        {
            _context.HistoricosIrrigacao.Add(historico);
            await _context.SaveChangesAsync();
            return historico;
        }

        public async Task<HistoricoIrrigacao> UpdateAsync(int id, HistoricoIrrigacao updatedHistorico)
        {
            var historico = await _context.HistoricosIrrigacao.FindAsync(id);
            if (historico == null) return null;

            historico.DataHoraIrrigacao = updatedHistorico.DataHoraIrrigacao;
            historico.ParqueId = updatedHistorico.ParqueId;
            historico.ConfiguracaoIrrigacaoId = updatedHistorico.ConfiguracaoIrrigacaoId;

            await _context.SaveChangesAsync();
            return historico;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var historico = await _context.HistoricosIrrigacao.FindAsync(id);
            if (historico == null) return false;

            _context.HistoricosIrrigacao.Remove(historico);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
