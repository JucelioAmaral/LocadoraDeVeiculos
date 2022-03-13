using DesafioTecEngLocaliza.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTecEngLocaliza.Persistence.Contexto
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        

        public DbSet<Cliente> tblCliente { get; set; }
        public DbSet<Endereco> tblEndereco { get; set; }
        public DbSet<Operador> tblOperador { get; set; }
        public DbSet<Usuario> tblUsuario { get; set; }
        public DbSet<Veiculo> tblVeiculo { get; set; }
        public DbSet<Marca> tblMarca { get; set; }
        public DbSet<Modelo> tblModelo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
