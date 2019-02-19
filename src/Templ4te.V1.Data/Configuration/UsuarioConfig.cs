using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Templ4te.V1.Domain.Usuarios;

namespace Templ4te.V1.Data.Configuration
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Nome)
              .HasColumnType("varchar(150)")
              .IsRequired();

            //builder.HasOne(u => u.Telefones)
            //   .WithMany(t => o.Eventos)
            //   .HasForeignKey(e => e.OrganizadorId);


            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);
            builder.ToTable("Usuarios");

            /*            
            builder.Property(e => e.DescricaoCurta)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.DescricaoLonga)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.NomeEmpresa)
                .HasColumnType("varchar(150)")
                .IsRequired();

            

            builder.Ignore(e => e.Tags);


            builder.HasOne(e => e.Organizador)
                .WithMany(o => o.Eventos)
                .HasForeignKey(e => e.OrganizadorId);

            builder.HasOne(e => e.Categoria)
                .WithMany(e => e.Eventos)
                .HasForeignKey(e => e.CategoriaId)
                .IsRequired(false);
                */
        }
    }
}
