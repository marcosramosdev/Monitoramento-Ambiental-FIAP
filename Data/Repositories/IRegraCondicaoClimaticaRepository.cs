using MonitoramentoAmbiental.Data.Repositories;
using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Data
{
    public interface IRegraCondicaoClimaticaRepository : IRepository<RegraCondicaoClimatica>
    {
        Task<IEnumerable<RegraCondicaoClimatica>> GetRegrasAtivasPorParqueAsync(int parqueId);
    }
}
