using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Services
{
    public interface IParqueService
    {
        IEnumerable<Parque> GetAllParques();

        Parque GetParqueById(int id);

        void CreateParque(Parque parque);

        void UpdateParque(Parque parque);

        void DeleteParque(int id);
    }
}
