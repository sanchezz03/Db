using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Центр_зайнятості.Models;

namespace Центр_зайнятості.Controllers
{
    public class GetUnfilledVacanciesController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;
        public GetUnfilledVacanciesController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }
        // GET: GetClientEmploymentPercentage
        public async Task<ActionResult> Index()
        {
            var query = @"SELECT * FROM GetUnfilledVacancies()";

            var clients = await _context.GetUnfilledVacancies.FromSqlRaw(query).ToListAsync();

            return View(clients);
        }
    }
}
