using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Damain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFacil.Api.Data.Mappings
{
    public class AreceberMap : IEntityTypeConfiguration<Areceber>
    {
        public void Configure(EntityTypeBuilder<Areceber> builder)
        {
            builder.ToTable("areceber").HasKey(p => p.ID);
            builder.HasOne(u => u.Usuario).WithMany().HasForeignKey(fk => fk.IdUser);
            builder.HasOne(n => n.NaturezaLancamento).WithMany().HasForeignKey(fk => fk.IdNL);
            builder.Property(p => p.Descricao).HasColumnType("varchar").IsRequired();
            builder.Property(p => p.Obs).HasColumnType("varchar").IsRequired();
            builder.Property(p => p.ValorOriginal).HasColumnType("double precision").IsRequired();
            builder.Property(p => p.ValorRecebido).HasColumnType("double precision").IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("varchar");
            builder.Property(p => p.DataVencimento).HasColumnType("varchar").IsRequired();
            builder.Property(p => p.DataInativacao).HasColumnType("varchar").IsRequired();
            builder.Property(p => p.DataRefencia).HasColumnType("varchar").IsRequired();
            builder.Property(p => p.DataRecebimento).HasColumnType("varchar").IsRequired();
        }
    }
}