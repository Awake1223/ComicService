using TemplateService.Domain.Models;
using TemplateService.Infrastructure.Reposotories;

namespace TemplateService.Application.Services
{
    public class ComicService : IComicService
    {
        private readonly IComicReposotory _comicReposotory;

        public ComicService(IComicReposotory comicReposotory)
        {
            _comicReposotory = comicReposotory;
        }

        public async Task<List<ComicModel>> GetAllComic()
        {
            return await _comicReposotory.Get();
        }

        public async Task<Guid> CreateComic(ComicModel comicModel)
        {
            return await _comicReposotory.Create(comicModel);
        }

        public async Task<Guid> UpdateComic(Guid id, string title, string description, string publisher, List<string> authors)
        {
            return await _comicReposotory.Update(id, title, description, publisher, authors);
        }

        public async Task<Guid> DeleteComic(Guid id)
        {
            return await _comicReposotory.Delete(id);
        }

    }
}
