using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Damain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFacil.Api.Data.Mappings
{
    public class NaturezaLancamentoMap : IEntityTypeConfiguration<NaturezaLancamento>
    {
        public void Configure(EntityTypeBuilder<NaturezaLancamento> builder)
        {
            builder.ToTable("naturezaLancamento").HasKey(p => p.ID);
            builder.HasOne(p => p.Usuario).WithMany().HasForeignKey(fr => fr.IdUser);
            builder.Property(p => p.Descricao).HasColumnType("varchar").IsRequired();
            builder.Property(p => p.Obs).HasColumnType("varchar").IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("varchar");
            builder.Property(p => p.DataInativacao).HasColumnType("varchar").IsRequired();
        }
    }
}