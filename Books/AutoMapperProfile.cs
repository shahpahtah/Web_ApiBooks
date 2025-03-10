using AutoMapper;
using Books.Domain.Models;
using Books.Domain.ModelsDb;


    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDb>().ReverseMap();
            CreateMap<User, UserDb>().ReverseMap();
        }
    }

