
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

            CreateMap<ComicCreateDTO, Comic>();

            CreateMap<Character, CharacterDTO>();
            CreateMap<CharacterCreateDTO, Character>();

            CreateMap<Series, SeriesDTO>();

            CreateMap<Creator, CreatorDTO>();

            CreateMap<Event, EventDTO>();

            CreateMap<Story, StoryDTO>()
                .ForMember(dest => dest.ComicTitle,
                    opt => opt.MapFrom(src => src.Comic != null ? src.Comic.Title : null));

        }
    }
}
