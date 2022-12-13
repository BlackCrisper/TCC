using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TCC_2._0.Models;

namespace TCC_2._0.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ENTRADA> ENTRADA { get; set; }
        public DbSet<CATEGORIA> CATEGORIA { get; set; }
        public DbSet<ITENSENTRADA> ITENSENTRADA { get; set; }
        public DbSet<ITENSSAIDA> ITENSSAIDA { get; set; }
        public DbSet<PRODUTO> PRODUTO { get; set; }
        public DbSet<PROTIPO> PROTIPO { get; set; }
        public DbSet<SAIDA> SAIDA { get; set; }
        public DbSet<TIPO> TIPO { get; set; }
    }
}