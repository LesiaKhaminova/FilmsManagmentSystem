using AutoMapper;
using BLL.DTO;
using DAL.BaseEntities;

namespace BLL.Utils
{
    public class FilmsAutoMapper :Profile
    {
        public FilmsAutoMapper() 
        {
            CreateMap<Film, FilmResponse>()
                 .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.ToString()));

            CreateMap<FilmAddRequest, Film>()
                 .ForMember(dest => dest.Genre, opt => opt.ConvertUsing(new GenreConverter(), src => src.Genre));

            CreateMap<FilmUpdateRequest, Film>()
                 .ForMember(dest => dest.Genre, opt => opt.ConvertUsing(new GenreConverter(), src => src.Genre));
        }
    }
}
