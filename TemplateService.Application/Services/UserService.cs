using TemplateService.Domain.Models;
using TemplateService.Infrastructure.Reposotories;

namespace TemplateService.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserReposotory _userReposotory;

        public UserService(IUserReposotory userReposotory)
        {
            _userReposotory = userReposotory;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _userReposotory.Get();
        }

        public async Task<Guid> CreateUser(UserModel userModel)
        {
            return await _userReposotory.Create(userModel);
        }

        public async Task<Guid> UpdateUser(Guid id, string username, string email)
        {
            return await _userReposotory.Update(id, username, email);
        }

        public async Task<Guid> DeleteUser(Guid id)
        {
            return await _userReposotory.Delete(id);
        }
    }
}
