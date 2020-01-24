using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace e_diary.Database
{
    public static class RegisterContext
    {
        public static IServiceCollection AddDbContext(IServiceCollection services, string nameOrConnectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    nameOrConnectionString,
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.ToString())
                );
            });

            return services;
        }

        public static ContainerBuilder Register(ContainerBuilder builder, string nameOrConnectionString)
        {
            return SetupIoC(builder, nameOrConnectionString);
        }

        private static ContainerBuilder SetupIoC(ContainerBuilder builder, string nameOrConnectionString)
        {
            builder.RegisterType<DbContextOptions<ApplicationDbContext>>()
                .WithParameter(new NamedParameter("nameOrConnectionString", nameOrConnectionString))
                .AsSelf();

            builder.RegisterType<ApplicationDbContext>()
                .AsSelf()
                .WithParameter(new NamedParameter("nameOrConnectionString", nameOrConnectionString))
                .InstancePerLifetimeScope();

            return builder;
        }
    }
}
