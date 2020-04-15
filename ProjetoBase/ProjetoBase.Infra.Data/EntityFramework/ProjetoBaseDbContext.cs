using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoBase.Domain.Model.Usuarios;
using ProjetoBase.Infra.Data.EntityFramework.Mappings;

namespace ProjetoBase.Infra.Data.EntityFramework
{
    public class ProjetoBaseDbContext : DbContext
    {
        public ProjetoBaseDbContext(DbContextOptions<ProjetoBaseDbContext> options) : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.StringPropertiesTrimmer();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
