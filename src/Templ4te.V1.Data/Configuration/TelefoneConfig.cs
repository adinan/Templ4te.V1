﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Templ4te.V1.Domain.Usuarios;

namespace Templ4te.V1.Data.Configuration
{
    public class TelefoneConfig : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {

            builder.HasOne(t => t.Usuario)
              .WithMany(t => t.Telefones)
              .HasForeignKey(t => t.UsuarioId)
              .IsRequired();

            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);
            builder.ToTable("Telefones");
        }
    }
}
