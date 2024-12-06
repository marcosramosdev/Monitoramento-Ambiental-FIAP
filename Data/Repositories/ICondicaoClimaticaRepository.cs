using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Data.Repositories
{
    public interface ICondicaoClimaticaRepository : IRepository<CondicaoClimatica>
    {
        Task<IEnumerable<CondicaoClimatica>> GetCondicoesRecentesAsync();
    }
}
