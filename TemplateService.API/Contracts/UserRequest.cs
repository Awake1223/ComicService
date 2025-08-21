namespace TemplateService.API.Contracts
{
    public record UserRequest(
        string Username,
        string Email,
        string PasswordHash);
}
