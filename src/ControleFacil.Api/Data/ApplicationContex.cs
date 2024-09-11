using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Data
{
    public class ApplicationContex : DbContext
    {
        public DbSet<Usuario> Usuario {get; set;}
        public DbSet<NaturezaLancamento> NaturezaLancamento {get; set;}
        public DbSet<Apagar> Apagar {get; set;}

        public ApplicationContex(DbContextOptions<ApplicationContex> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new NaturezaLancamentoMap());
            modelBuilder.ApplyConfiguration(new ApagarMap());
        }
    }
}