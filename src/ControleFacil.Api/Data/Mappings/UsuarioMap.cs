using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Damain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFacil.Api.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario").HasKey(p => p.ID);
            builder.Property(p => p.Email).HasColumnType("varchar").IsRequired();
            builder.Property(p => p.Password).HasColumnType("varchar").IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("varchar");
            builder.Property(p => p.DataInativacao).HasColumnType("varchar").IsRequired();
        }
    }
}