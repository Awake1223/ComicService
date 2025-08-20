
namespace TemplateService.Domain.Models
{
    public class UserModel
    {
        private UserModel(Guid id, string username, string email, byte[] passwordHash) 
        {
            Id = id;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
        }

        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();


        public static(UserModel userModel, string error) Create(Guid id, string username, string email, byte[] passwordHash)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(username))
            {
                error = "Введите логин";
            }
            if (string.IsNullOrEmpty(email)) 
            {
                error = "Введите почту";
            }

            var userModel = new UserModel(id, username, email, passwordHash);
            
            return(userModel, error);
        }

    }
}
