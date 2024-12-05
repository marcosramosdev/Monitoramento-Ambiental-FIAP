using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Services
{
    public interface IConfiguracaoIrrigacaoService
    {
        Task<IEnumerable<ConfiguracaoIrrigacao>> GetAllAsync();
        Task<ConfiguracaoIrrigacao> GetByIdAsync(int id);
        Task<ConfiguracaoIrrigacao> CreateAsync(ConfiguracaoIrrigacao configuracao);
        Task<ConfiguracaoIrrigacao> UpdateAsync(int id, ConfiguracaoIrrigacao updatedConfiguracao);
        Task<bool> DeleteAsync(int id);
    }
}
