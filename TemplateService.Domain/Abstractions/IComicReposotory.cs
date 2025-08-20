using TemplateService.Domain.Models;

namespace TemplateService.Infrastructure.Reposotories
{
    public interface IComicReposotory
    {
        Task<Guid> Create(ComicModel comic);
        Task<Guid> Delete(Guid id);
        Task<List<ComicModel>> Get();
        Task<Guid> Update(Guid id, string title, string description, string publisher, List<string> authors);
    }
}