using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbiental.Data;
using MonitoramentoAmbiental.Data.Repositories;
using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Services
{
    public class ParqueService : IParqueService
    {
        private readonly IParqueRepository _parqueRepository;

        public ParqueService(IParqueRepository parqueRepository)
        {
            _parqueRepository = parqueRepository;
        }

        public IEnumerable<Parque> GetAllParques()
        {
            return _parqueRepository.GetAll();
        }

        public Parque GetParqueById(int id)
        {
            return _parqueRepository.GetById(id);
        }

        public void CreateParque(Parque parque)
        {
            _parqueRepository.Add(parque);
        }

        public void UpdateParque(Parque parque)
        {
            _parqueRepository.Update(parque);
        }

        public void DeleteParque(int id)
        {
            _parqueRepository.Delete(id);
        }
    }
}
