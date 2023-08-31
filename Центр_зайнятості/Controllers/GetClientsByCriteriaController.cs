using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Центр_зайнятості.Models;

namespace Центр_зайнятості.Controllers
{
    public class GetClientsByCriteriaController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public GetClientsByCriteriaController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }
        // GET: GetClientsByCriteria
        public async Task<ActionResult> Index(string skills = "Маркетингові навички", string education = "Вища")
        {
            var parameters = new[]
            {
                new SqlParameter("@Skills", skills),
                new SqlParameter("@Education", education)
            };

            var query = @"EXEC GetClientsByCriteria @Skills, @Education";

            var clients = await _context.Працівникs.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
