using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Центр_зайнятості.Models;

namespace Центр_зайнятості.Controllers
{
    public class GetRepeatedlyContactedCompaniesController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        public GetRepeatedlyContactedCompaniesController(ЦентрЗайнятостіContext context)
        {
            _context = context;
            _startDate = new DateTime(2023, 3, 1);
            _endDate = new DateTime(2023, 3, 31);
        }
        // GET: GetVacanciesByCriteria
        public async Task<IActionResult> Index(
            string vacancyTitle = "Менеджер з логістики")
        {
            var parameters = new[]
            {
                new SqlParameter("@VacancyTitle", vacancyTitle),
                new SqlParameter("@StartDate", _startDate),
                new SqlParameter("@EndDate", _endDate)
            };

            var query = @"SELECT * FROM dbo.GetRepeatedlyContactedCompanies(@VacancyTitle, @StartDate, @EndDate)";

            var clients = await _context.GetRepeatedlyContactedCompanies.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
