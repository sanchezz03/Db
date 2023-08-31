using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Центр_зайнятості.Models;

namespace Центр_зайнятості.Controllers
{
    public class GetClientsByOwnershipFormController : Controller
    {
        private readonly ЦентрЗайнятостіContext _context;

        public GetClientsByOwnershipFormController(ЦентрЗайнятостіContext context)
        {
            _context = context;
        }
        // GET: GetClientsByOwnershipForm
        public async Task<ActionResult> Index(string ownershipForm = "Приватна")
        {
            var parameters = new[]
            {
                new SqlParameter("@OwnershipForm", ownershipForm)
            };

            var query = @"EXEC GetClientsByCriteria @OwnershipForm";

            var clients = await _context.GetClientsByOwnershipForms.FromSqlRaw(query, parameters).ToListAsync();

            return View(clients);
        }
    }
}
