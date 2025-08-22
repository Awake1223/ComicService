using System.Threading.Tasks;

namespace TestUnoApp.Services
{
    public interface IApiService
    {
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T>(string url, object data);
        Task<bool> DeleteAsync(string url);
    }
}
