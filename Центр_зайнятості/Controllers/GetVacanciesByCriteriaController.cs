using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Центр_зайнятості.Models;

namespace Центр_зайнятості.Controllers
{
    public class GetVacanciesByCriteriaController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public GetVacanciesByCriteriaController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }
        // GET: GetVacanciesByCriteria
        public async Task<IActionResult> Index(string education = "Вища", int experienceYears = 3)
        {
            var parameters = new[]
            {
                new SqlParameter("@Education", education),
                new SqlParameter("@ExperienceYears", experienceYears)
            };

            var query = @"EXEC GetVacanciesByCriteria @Education, @ExperienceYears";

            var clients = await _context.Вакансіяs.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
