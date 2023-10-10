using WebMVC.Domain.Entity.request;
using WebMVC.Models;

namespace WebMVC.Domain.Interfaces.Services
{
    public interface IUserService
    {
        string LogId { get; set; }
        Task<string> CreateUserAsync(UserFrontRequest user);
        Task<string> GetAllUserAsync();
    }
}
