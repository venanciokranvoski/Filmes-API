using AutoMapper;
using Filmes_API.Data;
using Filmes_API.Models;

namespace Filmes_API.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();

        }

    }
}
