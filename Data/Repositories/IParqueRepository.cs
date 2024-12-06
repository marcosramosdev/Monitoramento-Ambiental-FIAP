using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Data.Repositories
{
    public interface IParqueRepository : IRepository<Parque>
    {
        Task<IEnumerable<Parque>> GetParquesComConfiguracoesAsync();
    }
}
