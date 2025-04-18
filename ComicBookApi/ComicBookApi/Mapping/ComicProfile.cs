
using AutoMapper;
using ComicBookApi.Models;
using ComicBookApi.DTOs;

namespace ComicBookApi.Mapping
{
    public class ComicProfile : Profile
    {
        public ComicProfile()
        {
            CreateMap<Comic, ComicDTO>()
                .ForMember(dest => dest.SeriesTitle,
                    opt => opt.MapFrom(src => src.Series != null ? src.Series.Title : null));

            CreateMap<Character, CharacterDTO>();

        }
    }
}
