using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec_MVC_DEV.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliotec_MVC_DEV.Contexts
{
    public class BbDbContext : DbContext

    {

        public BbDbContext(DbContextOptions<BbDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; } = null!;

        public DbSet<Categoria> Categoria { get; set; } = null!;
        public DbSet<Livro> Livro { get; set; } = null!;
        public DbSet<LivroCategoria> LivroCategoria { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
modelBuilder.Entity<LivroCategoria>().HasKey(lc => new {lc.LivroId, lc.CategoriaId});
        }
    }
}