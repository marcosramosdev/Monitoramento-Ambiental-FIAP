using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbiental.Data;
using MonitoramentoAmbiental.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitoramentoAmbiental.Services
{
    public class ConfiguracaoIrrigacaoService : IConfiguracaoIrrigacaoService
    {
        private readonly ApplicationDbContext _context;

        public ConfiguracaoIrrigacaoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ConfiguracaoIrrigacao>> GetAllAsync()
        {
            return await _context.ConfiguracoesIrrigacao.ToListAsync();
        }

        public async Task<ConfiguracaoIrrigacao> GetByIdAsync(int id)
        {
            return await _context.ConfiguracoesIrrigacao.FindAsync(id);
        }

        public async Task<ConfiguracaoIrrigacao> CreateAsync(ConfiguracaoIrrigacao configuracao)
        {
            _context.ConfiguracoesIrrigacao.Add(configuracao);
            await _context.SaveChangesAsync();
            return configuracao;
        }

        public async Task<ConfiguracaoIrrigacao> UpdateAsync(int id, ConfiguracaoIrrigacao updatedConfiguracao)
        {
            var configuracao = await _context.ConfiguracoesIrrigacao.FindAsync(id);
            if (configuracao == null) return null;

            configuracao.Intervalo = updatedConfiguracao.Intervalo;
            configuracao.Duracao = updatedConfiguracao.Duracao;

            await _context.SaveChangesAsync();
            return configuracao;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var configuracao = await _context.ConfiguracoesIrrigacao.FindAsync(id);
            if (configuracao == null) return false;

            _context.ConfiguracoesIrrigacao.Remove(configuracao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
