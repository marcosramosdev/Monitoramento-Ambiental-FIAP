using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Services
{
    public interface ICondicaoClimaticaService
    {
        IEnumerable<CondicaoClimatica> GetAllCondicoes();
        CondicaoClimatica GetCondicaoById(int id);
        void CreateCondicao(CondicaoClimatica condicao);
        void UpdateCondicao(CondicaoClimatica condicao);
        void DeleteCondicao(int id);
    }
}
