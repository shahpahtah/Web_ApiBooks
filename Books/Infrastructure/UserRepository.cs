using AutoMapper;
using Books.Domain.Interfaces;
using Books.Domain.Models;
using Books.Domain.ModelsDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Books.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<UserDb> _passwordHasher;
        public UserRepository(AppDbContext context,IMapper mapper,IPasswordHasher<UserDb> passwordHasher)
        {
            _context = context;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task<User> CreateAsync(string name,string email, string password)
        {
            var user = new UserDb() { Email = email, Name = name, Id = new Guid()};
            user.PasswordHash = _passwordHasher.HashPassword(user, password);
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<User>(user);
            
            
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.users.FindAsync(id);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _context.users.ToListAsync();
            return users.Select(i=>_mapper.Map<User>(i));
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _context.users.FindAsync(id);
            return _mapper.Map<User>(user);
        }

        public async Task UpdateAsync(Guid id,string name, string Email, string password)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.Id == id);
            user.Name = name;
            user.Email = Email;
            user.PasswordHash =_passwordHasher.HashPassword(user, password);
            await _context.SaveChangesAsync();


        }
    }
}
