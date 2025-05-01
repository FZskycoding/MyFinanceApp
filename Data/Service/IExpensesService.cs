using MyFinanceApp.Models;
namespace MyFinanceApp.Data.Service
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAll();
        Task Add(Expense expense);
        Task<bool> Delete(int id);
        IQueryable GetChartData();
    }
}
