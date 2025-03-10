using Books.Domain.Models;

namespace Books.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> CreateAsync(User user);
        public Task UpdateAsync( string name,string Email,string password);
        public Task DeleteAsync(Guid id);
        public Task<User> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();

    }
}
