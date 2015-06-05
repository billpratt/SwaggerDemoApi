using AutoMapper;

namespace SwaggerDemoApi.Models
{
    public class SuperheroAutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<PostSuperheroModel, Superhero>();
        }
    }
}