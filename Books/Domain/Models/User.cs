namespace Books.Domain.Models
{
    public class User
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string PasswordHash { get;  }
        public bool IsAdmin { get;  }
        public User(Guid id, string name,string email,string passwordhash,bool isAdmin)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = passwordhash;
            IsAdmin = isAdmin;
        }
    }
}
