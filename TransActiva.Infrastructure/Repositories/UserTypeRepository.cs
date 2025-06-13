using Microsoft.EntityFrameworkCore;
using TransActiva.Application.Interfaces;
using TransActiva.Domain.Entities;
using TransActiva.Infrastructure.Persistence;
using TransActiva.Infrastructure.Persistence.Entities;

namespace TransActiva.Infrastructure.Repositories;

public class UserTypeRepository : IUserTypeRepository
{
    private readonly TransactivaDbContext _context;

    public UserTypeRepository(TransactivaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserType>> GetAllAsync()
    {
        var data = await _context.Usertypes.ToListAsync();

        return data.Select(e => new UserType
        {
            Id = e.UserTypeId,
            Name = e.Name
        });
    }
}