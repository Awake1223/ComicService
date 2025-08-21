namespace TemplateService.API.Contracts
{
    public record ComicRequest(
        string title,
        string description,
        string publisher,
        List<string> authors);
}
