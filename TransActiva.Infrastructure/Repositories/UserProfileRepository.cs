using Microsoft.EntityFrameworkCore;
using TransActiva.Application.Interfaces;
using TransActiva.Infrastructure.Persistence;
using TransActiva.Infrastructure.Persistence.Entities;
using DomainUserProfile = TransActiva.Domain.Entities.UserProfile;

namespace TransActiva.Infrastructure.Repositories
{
    public class UserProfileRepository(TransactivaDbContext context) : IUserProfileRepository
    {
        public async Task<IEnumerable<DomainUserProfile>> GetAllAsync()
        {
            var profiles = await context.Userprofiles.ToListAsync();

            return profiles.Select(e => new DomainUserProfile
            {
                Id = e.UserProfileId,
                UserId = e.UserId,
                Name = e.Name,
                Ruc = e.Ruc,
                ManagerName = e.ManagerName,
                ManagerDni = e.ManagerDni,
                ManagerEmail = e.ManagerEmail,
                Phone = e.Phone,
                Address = e.Address
            });
        }

        public async Task<DomainUserProfile?> GetByIdAsync(int id)
        {
            var e = await context.Userprofiles.FindAsync(id);
            if (e == null) return null;

            return new DomainUserProfile
            {
                Id = e.UserProfileId,
                UserId = e.UserId,
                Name = e.Name,
                Ruc = e.Ruc,
                ManagerName = e.ManagerName,
                ManagerDni = e.ManagerDni,
                ManagerEmail = e.ManagerEmail,
                Phone = e.Phone,
                Address = e.Address
            };
        }
    }
}