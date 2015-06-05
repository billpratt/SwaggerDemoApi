using System.Web;
using AutoMapper;
using SwaggerDemoApi;
using SwaggerDemoApi.Models;

[assembly: PreApplicationStartMethod(typeof(AutoMapperConfig), "Configure")]

namespace SwaggerDemoApi
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new SuperheroAutoMapperProfile()));
        }
    }
}