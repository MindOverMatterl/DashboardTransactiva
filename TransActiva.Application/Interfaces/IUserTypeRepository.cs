using TransActiva.Domain.Entities;

namespace TransActiva.Application.Interfaces;

public interface IUserTypeRepository
{
    Task<IEnumerable<UserType>> GetAllAsync();
}