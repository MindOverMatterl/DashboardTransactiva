using System.Collections.Generic;
using System.Threading.Tasks;
using TransActiva.Domain.Entities;

namespace TransActiva.Application.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> GetAllAsync();
        Task<UserProfile?> GetByIdAsync(int id);
    }
}