using AutoMapper;
using Books.Domain.Interfaces;
using Books.Domain.Models;
using Books.Domain.ModelsDb;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public BookRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Book> CreateAsync(string Title, string description, string author, string genre, decimal price, string cover)
        {
            var book = new BookDb { Id = new Guid(), Author = author, Cover = cover, Description = description, Genre = genre, Price = price, Title = Title };
            await _context.books.AddAsync(book);
            _context.SaveChangesAsync();
            return _mapper.Map<Book>(book);
        }

        public async  Task DeleteAsync(Guid id)
        {
            var book = await _context.books.FindAsync(id);
            _context.books.Remove(book);
            await _context.SaveChangesAsync();        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var books = await _context.books.ToListAsync();
            return books.Select(i => _mapper.Map<Book>(i));
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            var book = await _context.books.FindAsync(id);
            return _mapper.Map<Book>(book);
        }

        public async Task UpdateAsync(Book book)
        {
            var bookDb = await _context.books.FindAsync(book.Id);
            bookDb.Description = book.Description;
            bookDb.Price = book.Price;
            bookDb.Author = book.Author;
            bookDb.Cover = book.Cover;
            bookDb.Genre = book.Genre;
            bookDb.Title = book.Title;
            await _context.SaveChangesAsync();
        }
    }
}
