using TemplateService.Domain.Models;

namespace TemplateService.Infrastructure.Reposotories
{
    public interface IUserReposotory
    {
        Task<Guid> Create(UserModel userModel);
        Task<Guid> Delete(Guid id);
        Task<List<UserModel>> Get();
        Task<Guid> Update(Guid id, string username, string email);
    }
}