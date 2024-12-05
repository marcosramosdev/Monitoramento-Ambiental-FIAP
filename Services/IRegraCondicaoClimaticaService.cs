using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Services
{
    public interface IRegraCondicaoClimaticaService
    {
        IEnumerable<RegraCondicaoClimatica> GetAllRegras();
        RegraCondicaoClimatica GetRegraById(int id);
        void CreateRegra(RegraCondicaoClimatica regra);
        void UpdateRegra(RegraCondicaoClimatica regra);
        void DeleteRegra(int id);
    }
}
