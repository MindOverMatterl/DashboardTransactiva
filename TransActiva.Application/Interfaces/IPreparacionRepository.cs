using System.Collections.Generic;
using System.Threading.Tasks;
using TransActiva.Domain.Entities;

namespace TransActiva.Application.Interfaces
{
    public interface IPreparacionRepository
    {
        Task<IEnumerable<Preparacion>> GetAllAsync();
        Task<Preparacion?> GetByIdAsync(int id);
    }
}