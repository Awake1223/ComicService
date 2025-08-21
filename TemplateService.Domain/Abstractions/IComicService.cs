using TemplateService.Domain.Models;

namespace TemplateService.Application.Services
{
    public interface IComicService
    {
        Task<Guid> CreateComic(ComicModel comicModel);
        Task<Guid> DeleteComic(Guid id);
        Task<List<ComicModel>> GetAllComic();
        Task<Guid> UpdateComic(Guid id, string title, string description, string publisher, List<string> authors);
    }
}