using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Templ4te.V1.Data.Configuration;
using Templ4te.V1.Domain.Usuarios;




namespace Templ4te.V1.Data.Context
{
    public class ContextEFC : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Telefone> Telefones { get; set; }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .HasDefaultValue(0)
                .IsRequired();

            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new TelefoneConfig());
            modelBuilder.ApplyConfiguration(new EnderecoConfig());



            //modelBuilder.AddConfiguration(new UsuarioConfig());
            //modelBuilder.AddConfiguration(new OrganizadorConfig());
            //modelBuilder.AddConfiguration(new EnderecoConfig());
            //modelBuilder.AddConfiguration(new CategoriaConfig());

            base.OnModelCreating(modelBuilder);
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

    }
}
