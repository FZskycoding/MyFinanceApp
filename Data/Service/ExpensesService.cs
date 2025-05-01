using MyFinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MyFinanceApp.Data.Service
{
    public class ExpensesService : IExpensesService
    {
        private readonly MyFinanceAppContext _context;
        public ExpensesService(MyFinanceAppContext context)
        {
            _context = context;
        }

        public async Task Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return expenses;
        }

        public IQueryable GetChartData()
        {
            var data = _context.Expenses.GroupBy(e => e.Category)
                                                       .Select(g => new
                                                       {
                                                           Category = g.Key,
                                                           Total = g.Sum(e => e.Amount)
                                                       });
            return data;
        }

        public async Task<bool> Delete(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null) return false;
            
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
