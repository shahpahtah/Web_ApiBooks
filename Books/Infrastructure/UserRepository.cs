using AutoMapper;
using Books.Domain.Interfaces;
using Books.Domain.Models;
using Books.Domain.ModelsDb;

namespace Books.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<User> CreateAsync(User user)
        {
            var addUser = await _context.AddAsync(_mapper.Map<UserDb>(user));
            return _mapper.Map<User>(addUser);
            
            
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string name, string Email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
