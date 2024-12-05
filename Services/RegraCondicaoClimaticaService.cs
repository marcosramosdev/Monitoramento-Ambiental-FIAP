using MonitoramentoAmbiental.Data;
using MonitoramentoAmbiental.Models;
using MonitoramentoAmbiental.Repositories; // Adicionada a diretiva using para o namespace correto
using Microsoft.EntityFrameworkCore;

namespace MonitoramentoAmbiental.Services
{
    public class RegraCondicaoClimaticaService : IRegraCondicaoClimaticaService
    {
        private readonly IRegraCondicaoClimaticaRepository _regraRepository;

        public RegraCondicaoClimaticaService(IRegraCondicaoClimaticaRepository regraRepository)
        {
            _regraRepository = regraRepository;
        }

        public IEnumerable<RegraCondicaoClimatica> GetAllRegras()
        {
            return _regraRepository.GetAll();
        }

        public RegraCondicaoClimatica GetRegraById(int id)
        {
            return _regraRepository.GetById(id);
        }

        public void CreateRegra(RegraCondicaoClimatica regra)
        {
            _regraRepository.Add(regra);
        }

        public void UpdateRegra(RegraCondicaoClimatica regra)
        {
            _regraRepository.Update(regra);
        }

        public void DeleteRegra(int id)
        {
            _regraRepository.Delete(id);
        }
    }
}
