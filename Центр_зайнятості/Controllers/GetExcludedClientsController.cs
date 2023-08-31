using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Центр_зайнятості.Models;

namespace Центр_зайнятості.Controllers
{
    public class GetExcludedClientsController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;
        public GetExcludedClientsController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }
        // GET: GetClientEmploymentPercentage
        public async Task<ActionResult> Index()
        {
            var query = @"SELECT * FROM dbo.GetExcludedClients()";

            var clients = await _context.GetExcludedClients.FromSqlRaw(query).ToListAsync();

            return View(clients);
        }
    }
}
