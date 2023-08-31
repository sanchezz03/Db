using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Центр_зайнятості.Models;

namespace Центр_зайнятості.Controllers
{
    public class GetReturnedClientsController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public GetReturnedClientsController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }
        // GET: GetClientsByCriteria
        public async Task<ActionResult> Index()
        {
            var query = @"SELECT * FROM GetReturnedClients()";

            var clients = await _context.GetReturnedClients.FromSqlRaw(query).ToListAsync();

            return View(clients);
        }
    }
}
