using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbiental.Data;
using MonitoramentoAmbiental.Models;

namespace MonitoramentoAmbiental.Services
{
    public class ParqueService : IParqueService
    {
        private readonly ApplicationDbContext _context;

        public ParqueService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parque>> GetAllAsync()
        {
            return await _context.Parques.ToListAsync();
        }

        public async Task<Parque> GetByIdAsync(int id)
        {
            return await _context.Parques.FindAsync(id);
        }

        public async Task<Parque> CreateAsync(Parque parque)
        {
            _context.Parques.Add(parque);
            await _context.SaveChangesAsync();
            return parque;
        }

        public async Task<Parque> UpdateAsync(int id, Parque updatedParque)
        {
            var parque = await _context.Parques.FindAsync(id);
            if (parque == null) return null;

            parque.Nome = updatedParque.Nome;
            parque.Localizacao = updatedParque.Localizacao;

            await _context.SaveChangesAsync();
            return parque;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var parque = await _context.Parques.FindAsync(id);
            if (parque == null) return false;

            _context.Parques.Remove(parque);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
