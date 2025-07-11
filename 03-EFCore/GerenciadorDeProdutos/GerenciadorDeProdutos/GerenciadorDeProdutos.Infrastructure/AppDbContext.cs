﻿using GerenciadorDeProdutos.Domain;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeProdutos.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().Property(p => p.Preco).HasPrecision(18, 2);
        }
    }
}
