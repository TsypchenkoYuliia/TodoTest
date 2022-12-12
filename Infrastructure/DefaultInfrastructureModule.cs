using Autofac;
using SharedCore.Interfaces;
using Infrastructure.Data;
using Module = Autofac.Module;

namespace Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>))
              .As(typeof(IRepository<>))
              .InstancePerLifetimeScope();
        }
    }
}
