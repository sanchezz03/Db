using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Центр_зайнятості.Models;

namespace Центр_зайнятості.Controllers
{
    public class GetClientsAfterRequalificationController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public GetClientsAfterRequalificationController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }
        // GET: GetClientsAfterRequalification
        public async Task<ActionResult> Index()
        {
            var query = @"EXEC GetClientsAfterRequalification";

            var clients = await _context.GetClientsAfterRequalifications.FromSqlRaw(query).ToListAsync();

            return View(clients);
        }
    }
}
