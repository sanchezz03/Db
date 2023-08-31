using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Центр_зайнятості.Models;

namespace Центр_зайнятості.Controllers
{
    public class GetClientAndVacancyCountsController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;
        private readonly DateTime _startedDate;
        private readonly DateTime _endDate;
        public GetClientAndVacancyCountsController(ЦентрЗайнятостіContext context)
        {
            _context = context;
            _startedDate = DateTime.Parse("2023-01-01");
            _endDate = DateTime.Parse("2023-12-31");
        }
        // GET: GetClientEmploymentPercentage
        public async Task<ActionResult> Index()
        {
            var parameters = new[]
            {
                new SqlParameter("@StartDate", _startedDate),
                new SqlParameter("@EndDate", _endDate)
            };

            var query = @"SELECT * FROM dbo.GetClientAndVacancyCounts(@StartDate, @EndDate)";

            var clients = await _context.GetClientAndVacancyCounts.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
