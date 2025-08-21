using TemplateService.Domain.Models;

namespace TemplateService.Application.Services
{
    public interface IUserService
    {
        Task<Guid> CreateUser(UserModel userModel);
        Task<Guid> DeleteUser(Guid id);
        Task<List<UserModel>> GetAllUsers();
        Task<Guid> UpdateUser(Guid id, string username, string email);
    }
}