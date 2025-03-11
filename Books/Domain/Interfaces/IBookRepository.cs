using Books.Domain.Models;

namespace Books.Domain.Interfaces
{
    public interface IBookRepository
    {
        public Task<Book> GetByIdAsync(Guid id);
        public Task<Book> CreateAsync(string Title, string description, string author, string genre, decimal price, string cover);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Book>> GetAllAsync();
    }
}
