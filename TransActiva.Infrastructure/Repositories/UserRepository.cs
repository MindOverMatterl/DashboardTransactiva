using Microsoft.EntityFrameworkCore;
using TransActiva.Application.Interfaces;
using TransActiva.Infrastructure.Persistence;
using TransActiva.Infrastructure.Persistence.Entities;
using ScaffoldUser = TransActiva.Infrastructure.Persistence.Entities.User;
using DomainUser = TransActiva.Domain.Entities.User;

namespace TransActiva.Infrastructure.Repositories
{
    public class UserRepository(TransactivaDbContext context) : IUserRepository
    {
        public async Task<IEnumerable<DomainUser>> GetAllAsync()
        {
            var users = await context.Users.ToListAsync();

            return users.Select(e => new DomainUser
            {
                Id = e.UserId,
                Email = e.Email,
                Password = e.Password,
                CreatedAt = e.CreatedAt,
                UserTypeId = e.UserTypeId,
                FailedLoginAttempts = e.FailedLoginAttempts ?? 0,
                LockoutUntil = e.LockoutUntil
            });
        }

        public async Task<DomainUser?> GetByIdAsync(int id)
        {
            var e = await context.Users.FindAsync(id);
            if (e == null) return null;

            return new DomainUser
            {
                Id = e.UserId,
                Email = e.Email,
                Password = e.Password,
                CreatedAt = e.CreatedAt,
                UserTypeId = e.UserTypeId,
                FailedLoginAttempts = e.FailedLoginAttempts ?? 0,
                LockoutUntil = e.LockoutUntil
            };
        }
        public async Task AddAsync(DomainUser user)
        {
            var newUser = new ScaffoldUser
            {
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
                UserTypeId = user.UserTypeId,
                FailedLoginAttempts = user.FailedLoginAttempts,
                LockoutUntil = user.LockoutUntil
            };

            context.Users.Add(newUser);
            await context.SaveChangesAsync();

            user.Id = newUser.UserId; // ← Devuelve el ID generado
        }
        public async Task<DomainUser?> GetByEmailAsync(string email)
        {
            var entity = await context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (entity == null) return null;

            return new DomainUser
            {
                Id = entity.UserId,
                Email = entity.Email,
                Password = entity.Password,
                CreatedAt = entity.CreatedAt,
                UserTypeId = entity.UserTypeId,
                FailedLoginAttempts = entity.FailedLoginAttempts ?? 0,
                LockoutUntil = entity.LockoutUntil
            };
        }
    }
}