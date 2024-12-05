using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbiental.Data;
using MonitoramentoAmbiental.Models;
using MonitoramentoAmbiental.Repositories; // Adicionada a diretiva using

namespace MonitoramentoAmbiental.Services
{
    public class CondicaoClimaticaService : ICondicaoClimaticaService
    {
        private readonly ICondicaoClimaticaRepository _condicaoRepository;

        public CondicaoClimaticaService(ICondicaoClimaticaRepository condicaoRepository)
        {
            _condicaoRepository = condicaoRepository;
        }

        public IEnumerable<CondicaoClimatica> GetAllCondicoes()
        {
            return _condicaoRepository.GetAll();
        }

        public CondicaoClimatica GetCondicaoById(int id)
        {
            return _condicaoRepository.GetById(id);
        }

        public void CreateCondicao(CondicaoClimatica condicao)
        {
            _condicaoRepository.Add(condicao);
        }

        public void UpdateCondicao(CondicaoClimatica condicao)
        {
            _condicaoRepository.Update(condicao);
        }

        public void DeleteCondicao(int id)
        {
            _condicaoRepository.Delete(id);
        }
    }
}
