using FluentValidation;
using junto.dotnet.user.api.Dominio.Repositories;
using junto.dotnet.user.api.Dominio.UseCases.AddUser;
using junto.dotnet.user.api.Dominio.UseCases.AlterPassword;
using junto.dotnet.user.api.Dominio.UseCases.AlterPassWord;
using junto.dotnet.user.api.InfraStructure.Options;
using junto.dotnet.user.api.InfraStructure.Persistence.DataContexts;
using junto.dotnet.user.api.InfraStructure.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.InfraStructure.DependencyInjection
{
    public static class Bootstrapper
    {
        public static void AdicionarConfiguracoes(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PersistenceOptions>(configuration.GetSection("Persistence"));
            services.Configure<SecretOptions>(configuration.GetSection("Authenticate"));
        }

        public static void AdicionarServicosDaAplicacao(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDataContext>();

            services.AddMediatR(typeof(Program).Assembly);

            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AdicionarValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<AddUserCommand>, UserCommandValidator>();
            services.AddScoped<IValidator<AlterPasswordCommand>, AlterPasswordValidator>();
        }
    }
}
