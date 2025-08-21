namespace TemplateService.Domain.Models
{
    public class ComicModel
    {
        private ComicModel(Guid id, string title, string description, string publisher, List<string> authors)
        {
            Id = id;
            Title = title;
            Description = description;
            Publisher = publisher;
            Authors = authors;
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public List<string> Authors { get; set; } = new();

        public static (ComicModel? comicModel, string error) Create(Guid id, string title, string description, string publisher, List<string> authors)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(title))
            {
                error = "Введите название книги!";
                return (null, error);
            }
            if (string.IsNullOrEmpty(description))
            {
                error = "Введите описание";
                return (null, error);
            }
            if (string.IsNullOrEmpty(publisher))
            {
                error = "Введите публикацию";
                return (null, error);
            }
            if (authors == null || authors.Count == 0)
            {
                error = "Введите авторов комикса";
                return (null, error);
            }

            var comicModel = new ComicModel(id, title, description, publisher, authors);
            return (comicModel, error);
        }
    }
}