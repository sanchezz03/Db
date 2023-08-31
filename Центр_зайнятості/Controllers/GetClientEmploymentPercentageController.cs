using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Центр_зайнятості.Models;

namespace Центр_зайнятості.Controllers
{
    public class GetClientEmploymentPercentageController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;
        private readonly DateTime _qualificationDate;
        public GetClientEmploymentPercentageController(ЦентрЗайнятостіContext context)
        {
            _context = context;
            _qualificationDate = DateTime.Parse("2023-01-01");
        }
        // GET: GetClientEmploymentPercentage
        public async Task<ActionResult> Index()
        {
            var parameters = new[]
            {
                new SqlParameter("@QualificationDate", _qualificationDate)
            };

            var query = @"EXEC GetClientEmploymentPercentage @QualificationDate";

            var clients = await _context.GetClientEmploymentPercentages.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
