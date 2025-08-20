
namespace TemplateService.Infrastructure.Entities
{
    public class ComicEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty; // Marvel, DC, etc.
        public List<string> Authors { get; set; } = new();
    }
}
