using GerenciadorDeReceitas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeReceitas.Data
{
    public class ReceitaDbContext : DbContext
    {
        public ReceitaDbContext(DbContextOptions<ReceitaDbContext> options) : base(options)
        {
                
        }

        public DbSet<ReceitaModel> Receita { get; set; }
    }
}
