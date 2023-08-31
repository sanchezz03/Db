using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Центр_зайнятості.Models;

namespace Центр_зайнятості.Controllers
{
    public class GetClientsNotQualifiedAndRejectedController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public GetClientsNotQualifiedAndRejectedController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }
        // GET: GetClientsByCriteria
        public async Task<ActionResult> Index()
        {
            var query = @"EXEC GetClientsNotQualifiedAndRejected";

            var clients = await _context.GetClientsNotQualifiedAndRejecteds.FromSqlRaw(query).ToListAsync();

            return View(clients);
        }
    }
}
