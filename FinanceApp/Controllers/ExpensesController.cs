using FinanceApp.data;
using FinanceApp.data.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _service;

        public ExpensesController(IExpensesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var expenses = await _service.GetAll();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Add(expense);
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    // Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View(expense);
        }
        public IActionResult GetChart()
        {
            var data = _service.GetChartData();
            return Json(data);
        }
    }
}