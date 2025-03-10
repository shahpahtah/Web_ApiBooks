namespace Books.Domain.Models
{
    public class Book
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
        public string Author { get; }
        public string Genre { get; }
        public decimal Price { get; }
        public string Cover { get; }
        public Book(Guid id,string title,string description,string author,string genre, decimal price,string cover)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
            Genre = genre;
            Price = price;
            Cover = cover;
        }
    }
}
