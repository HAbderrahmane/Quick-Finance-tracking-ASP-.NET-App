using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.data.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly FinanceContext _context;

        public ExpensesService(FinanceContext context)
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
            var data = _context.Expenses
                               .GroupBy(e => e.Category)
                               .Select(x => new
                               {
                                   Category = x.Key,
                                   Total = x.Sum(e => e.Amount)
                               });
            return data;
        }
    }
}
