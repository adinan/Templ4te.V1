using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Templ4te.V1.Data.Configuration;
using Templ4te.V1.Domain.Usuarios;




namespace Templ4te.V1.Data.Context
{
    public class ContextEFC : DbContext
    {

        public ContextEFC(DbContextOptions<ContextEFC> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new TelefoneConfig());
            modelBuilder.ApplyConfiguration(new EnderecoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
