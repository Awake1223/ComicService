using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateService.Domain.Models;
using TemplateService.Infrastructure.Entities;

namespace TemplateService.Infrastructure.Reposotories
{
    public class ComicReposotory : IComicReposotory
    {
        private readonly ComicServiceDbContext _context;

        public ComicReposotory(ComicServiceDbContext context)
        {
            _context = context;
        }

        public async Task<List<ComicModel>> Get()
        {
            var comicEntities = await _context.Comic.AsNoTracking().ToListAsync();

            var comic = comicEntities.Select(c => ComicModel.Create(c.Id, c.Title, c.Description, c.Publisher, c.Authors).comicModel).ToList();

            return comic;
        }

        public async Task<Guid> Create(ComicModel comic)
        {
            var comicEntity = new ComicEntity
            {
                Id = comic.Id,
                Title = comic.Title,
                Description = comic.Description,
                Publisher = comic.Publisher,
                Authors = comic.Authors,

            };
            await _context.Comic.AddAsync(comicEntity);
            await _context.SaveChangesAsync();

            return comic.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, string publisher, List<string> authors)
        {
            await _context.Comic.Where(c => c.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Id, c => id)
                .SetProperty(c => c.Title, c => title)
                .SetProperty(c => c.Description, c => description)
                .SetProperty(c => c.Publisher, c => publisher)
                .SetProperty(c => c.Authors, c => authors));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Comic.Where(c => c.Id == id).ExecuteDeleteAsync();

            return id;
        }
    }
}
