using Microsoft.EntityFrameworkCore;
using TemplateService.Domain.Models;
using TemplateService.Infrastructure.Entities;

namespace TemplateService.Infrastructure.Reposotories
{
    public class UserReposotory : IUserReposotory
    {
        private readonly ComicServiceDbContext _context;

        public UserReposotory(ComicServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserModel>> Get()
        {
            var userEntities = await _context.User.AsNoTracking().ToListAsync();

            var users = userEntities.Select(u => UserModel.Create(u.Id, u.Username, u.Email, u.PasswordHash).userModel).ToList();

            return users;
        }

        public async Task<Guid> Create(UserModel userModel)
        {
            var userEntity = new UserEntity
            {
                Id = userModel.Id,
                Username = userModel.Username,
                Email = userModel.Email,
                PasswordHash = userModel.PasswordHash,
            };
            await _context.User.AddRangeAsync(userEntity);
            await _context.SaveChangesAsync();

            return (userEntity.Id);
        }

        public async Task<Guid> Update(Guid id, string username, string email)
        {
            await _context.User.Where(u => u.Id == id).ExecuteUpdateAsync(s => s
                .SetProperty(u => u.Id, u => id)
                .SetProperty(u => u.Username, u => username)
                .SetProperty(u => u.Email, u => email));
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.User.Where(u => u.Id == id).ExecuteDeleteAsync();
            return id;
        }


    }
}
