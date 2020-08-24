using Autofac;
using AutoMapper;
using VisualSoftware.Application.Interfaces;
using VisualSoftware.Application.Mapper;
using VisualSoftware.Application.Services;
using VisualSoftware.Domain.Core.Interfaces.Services;
using VisualSoftware.Domain.Services;
using VisualSoftware.Domain.Services.Services;
using VisualSoftware.Infrastructure.Repository.Repositories;

namespace VisualSoftware.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC
            
            builder.RegisterType<ApplicationServicePerson>().As<IApplicationServicePerson>();
           
            builder.RegisterType<ServicePerson>().As<IServicePerson>();

            builder.RegisterType<RepositoryPerson>().As<IRepositoryPerson>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelMappingPerson());
                cfg.AddProfile(new ModelToDtoMappingPerson());
                cfg.AddProfile(new RequestToDomainProfile());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
            
            #endregion IOC
        }
    }
}
