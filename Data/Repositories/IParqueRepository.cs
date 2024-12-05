using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Data.Repositories
{
    public interface IParqueRepository
    {
        Parque GetById(int id);
        IEnumerable<Parque> GetAll();
        void Add(Parque parque);
        void Update(Parque parque);
        void Delete(int id);
    }
}
