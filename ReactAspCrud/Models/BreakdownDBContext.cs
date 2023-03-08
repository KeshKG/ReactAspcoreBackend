using Microsoft.EntityFrameworkCore;

namespace ReactAspCrud.Models
{
    public class BreakdownDBContext : DbContext
    {
        public BreakdownDBContext(DbContextOptions<BreakdownDBContext> options) : base(options)
        {
        }

        public DbSet<Breakdown> Breakdowns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-HBOD95K;Initial Catalog=breakdowndb;Integrated Security=True;Trust Server Certificate=true");
        }
    }
}
