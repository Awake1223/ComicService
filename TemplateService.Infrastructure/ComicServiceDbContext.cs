using TemplateService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace TemplateService.Infrastructure
{
    public class ComicServiceDbContext : DbContext
    {
        public ComicServiceDbContext(DbContextOptions<ComicServiceDbContext> options) : base(options)
        {
        }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<ComicEntity> Comic { get; set; }
    }
}
