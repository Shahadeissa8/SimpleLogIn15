using Microsoft.AspNetCore.Mvc;
using SimpleLogIn15.Data;

namespace SimpleLogIn15.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext _context;
        public RolesController (ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Roles);
        }
    }
}
