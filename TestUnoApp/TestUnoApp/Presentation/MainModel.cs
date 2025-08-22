using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using TestUnoApp.Services;

namespace TestUnoApp.Presentation
{
    public partial class MainModel
    {
        private readonly IApiService _apiService;

        public MainModel(IApiService apiService)
        {
            _apiService = apiService;
            Title = "API Test Page";

            TestGetUsersCommand = new AsyncRelayCommand(TestGetUsers);
            TestCreateUserCommand = new AsyncRelayCommand(TestCreateUser);
        }

        public string Title { get; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public ObservableCollection<string> Users { get; } = new ObservableCollection<string>();

        public ICommand TestGetUsersCommand { get; }
        public ICommand TestCreateUserCommand { get; }

        private async Task TestGetUsers()
        {
            try
            {
                Users.Clear();
                Users.Add("Loading users...");

                // Тестовый вызов GET /user
                var users = await _apiService.GetAsync<List<UserResponse>>("/user");

                Users.Clear();
                if (users != null && users.Count > 0)
                {
                    foreach (var user in users)
                    {
                        Users.Add($"{user.Username} - {user.Email}");
                    }
                }
                else
                {
                    Users.Add("No users found or empty response");
                }
            }
            catch (Exception ex)
            {
                Users.Clear();
                Users.Add($"Error: {ex.Message}");
                Console.WriteLine($"Error loading users: {ex.Message}");
            }
        }

        private async Task TestCreateUser()
        {
            try
            {
                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email))
                {
                    Users.Clear();
                    Users.Add("Please enter name and email");
                    return;
                }

                Users.Clear();
                Users.Add("Creating user...");

                // Тестовый вызов POST /user
                var userRequest = new
                {
                    Username = Name,
                    Email = Email,
                    PasswordHash = "test123" // временное значение
                };

                var result = await _apiService.PostAsync<object>("/user", userRequest);

                Users.Clear();
                Users.Add("User created successfully!");
                Users.Add($"Response: {result}");

                // Очищаем поля
                Name = "";
                Email = "";
            }
            catch (Exception ex)
            {
                Users.Clear();
                Users.Add($"Error: {ex.Message}");
                Console.WriteLine($"Error creating user: {ex.Message}");
            }
        }
    }
}
