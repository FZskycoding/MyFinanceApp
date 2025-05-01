using MyFinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MyFinanceApp.Data
{
    public class MyFinanceAppContext : DbContext
    {
        public MyFinanceAppContext(DbContextOptions<MyFinanceAppContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
    }
}
