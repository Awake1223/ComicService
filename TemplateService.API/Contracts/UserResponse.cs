namespace TemplateService.API.Contracts
{
    public record UserResponse(
        Guid id,
        string Username,
        string Email);
}
