using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Центр_зайнятості.Models;

namespace Центр_зайнятості.Controllers
{
    public class GetCompaniesByWorkConditionsController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public GetCompaniesByWorkConditionsController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }
        // GET: GetVacanciesByCriteria
        public async Task<IActionResult> Index(string workDayLocation = "Київ, вул. Шевченка 10", string representativeName = "Матвієнко Максим Іванович")
        {
            var parameters = new[]
            {
                new SqlParameter("@WorkDayLocation", workDayLocation),
                new SqlParameter("@RepresentativeName", representativeName)
            };

            var query = @"EXEC GetCompaniesByWorkConditions @WorkDayLocation, @RepresentativeName";

            var clients = await _context.GetCompaniesByWorkConditions.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
