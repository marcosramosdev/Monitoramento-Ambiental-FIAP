using MonitoramentoAmbiental.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonitoramentoAmbiental.Services
{
    public interface IParqueService
    {
        Task<IEnumerable<Parque>> GetAllAsync();
        Task<Parque> GetByIdAsync(int id);
        Task<Parque> CreateAsync(Parque parque);
        Task<Parque> UpdateAsync(int id, Parque parque);
        Task<bool> DeleteAsync(int id);
    }
}
