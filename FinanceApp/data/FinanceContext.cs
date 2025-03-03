
using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.data
{
    public class FinanceContext : DbContext
    {
        public FinanceContext(DbContextOptions<FinanceContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }

    }
}
