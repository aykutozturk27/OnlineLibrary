using Autofac;
using AutoMapper;
using OnlineLibrary.Business.Mappings.AutoMapper.Profiles;

namespace OnlineLibrary.Business.DependencyResolvers.Autofac
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(CreateConfiguration().CreateMapper()).As<IMapper>();
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });

            return config;
        }
    }
}
