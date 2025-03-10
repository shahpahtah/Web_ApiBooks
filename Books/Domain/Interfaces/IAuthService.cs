using Books.Domain.Models;

namespace Books.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(string email, string password);
        Task Register(User user);
    }
}
