using Books.Domain.Interfaces;
using Books.Domain.Models;
using Books.Domain.ModelsDb;
using Books.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Books.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<UserDb> _passwordHasher;
        public AuthService(AppDbContext context, IUserRepository userRepository, IPasswordHasher<UserDb> passwordHasher)
        {
            _context = context;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<string> Authenticate(string email, string password)
        {
            var userDb = await _context.users.FirstOrDefaultAsync(u => u.Email == email);

            if (userDb == null)
            {
                throw new Exception("Invalid email or password.");
            }
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(userDb, userDb.PasswordHash, password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid email or password.");
            }
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, userDb.Name), new Claim(ClaimTypes.Email, userDb.Email) };
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }

        public async Task<string> Register(string name,string email,string password)
        {
            if (await _context.users.AnyAsync(u => u.Email == email))
            {
                throw new Exception("User exists");
            }
            else
            {
                await _userRepository.CreateAsync(name,email,password);
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, name),new Claim(ClaimTypes.Email,email)};
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromHours(2)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                return new JwtSecurityTokenHandler().WriteToken(jwt);
            }
            
        }
    }
}
