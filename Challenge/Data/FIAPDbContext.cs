using Challenge.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Challenge.Data
{
    public class FIAPDbContext : DbContext

    {
        public FIAPDbContext(DbContextOptions<FIAPDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<EnderecoModel> Endereco { get; set; }

        public DbSet<PreferenciaViagemModel> PreferenciaViagem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UsuarioMapeamento());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            base.OnModelCreating(modelBuilder);
        }

    }
}

