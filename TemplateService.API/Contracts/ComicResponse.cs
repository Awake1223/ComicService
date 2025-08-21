namespace TemplateService.API.Contracts
{
    public record ComicResponse(
        Guid id,
        string title,
        string description,
        string publisher,
        List<string> authors);
}
