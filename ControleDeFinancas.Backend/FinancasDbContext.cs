using Microsoft.EntityFrameworkCore;

namespace ControleDeFinancas.Backend
{
    public class FinancasDbContext: DbContext
    {
        public FinancasDbContext(DbContextOptions<FinancasDbContext> op): base(op) 
        {
            
        }
        public DbSet<Financas> Financas { get; set; }
    }
}
