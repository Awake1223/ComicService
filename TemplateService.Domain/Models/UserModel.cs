namespace TemplateService.Domain.Models
{
    public class UserModel
    {
        private UserModel(Guid id, string username, string email, string passwordHash)
        {
            Id = id;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
        }

        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public static (UserModel? userModel, string error) Create(Guid id, string username, string email, string passwordHash)
        {
            string error = string.Empty; // Убрано повторное объявление

            if (string.IsNullOrEmpty(username))
            {
                error = "Введите логин";
                return (null, error); // Возвращаем сразу при ошибке
            }

            if (string.IsNullOrEmpty(email))
            {
                error = "Введите почту";
                return (null, error); // Возвращаем сразу при ошибке
            }

            if (string.IsNullOrEmpty(passwordHash))
            {
                error = "Password hash is required";
                return (null, error);
            }

            var userModel = new UserModel(id, username, email, passwordHash);

            return (userModel, error);
        }
    }
}