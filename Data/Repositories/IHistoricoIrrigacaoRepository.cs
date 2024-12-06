using MonitoramentoAmbiental.Data.Repositories;
using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Data
{
    public interface IHistoricoIrrigacaoRepository : IRepository<HistoricoIrrigacao>
    {
        Task<IEnumerable<HistoricoIrrigacao>> GetHistoricoPorPeriodoAsync(int parqueId, DateTime inicio, DateTime fim);
    }
}
