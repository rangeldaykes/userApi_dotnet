using junto.dotnet.user.api.Dominio.Entities;
using junto.dotnet.user.api.InfraStructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace junto.dotnet.user.api.InfraStructure.Persistence.DataContexts
{
    public class UserDataContext : DbContext
    {
        private readonly PersistenceOptions _config;

        public UserDataContext(DbContextOptions options, IOptions<PersistenceOptions> config) : base(options)
        {
            _config = config.Value;
        }

        public DbSet<UserEntity> UserEntityDb { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql(_config.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        }
    }
}
