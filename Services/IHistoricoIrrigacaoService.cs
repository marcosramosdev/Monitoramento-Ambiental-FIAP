using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Services
{
    public interface IHistoricoIrrigacaoService
        {
            Task<IEnumerable<HistoricoIrrigacao>> GetAllAsync();
            Task<HistoricoIrrigacao> GetByIdAsync(int id);
            Task<HistoricoIrrigacao> CreateAsync(HistoricoIrrigacao historico);
            Task<HistoricoIrrigacao> UpdateAsync(int id, HistoricoIrrigacao updatedHistorico);
            Task<bool> DeleteAsync(int id);
        }
    
}
