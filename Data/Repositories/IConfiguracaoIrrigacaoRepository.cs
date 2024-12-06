using MonitoramentoAmbiental.Data.Repositories;

namespace MonitoramentoAmbiental.Data
{
    public interface IConfiguracaoIrrigacaoRepository : IRepository<ConfiguracaoIrrigacao>
    {
        Task<IEnumerable<ConfiguracaoIrrigacao>> GetConfiguracoesPorParqueAsync(int parqueId);
    }
}
