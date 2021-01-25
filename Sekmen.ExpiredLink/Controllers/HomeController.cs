using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sekmen.ExpiredLink.Database;
using Sekmen.ExpiredLink.Database.Entity;
using Sekmen.ExpiredLink.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sekmen.ExpiredLink.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExpiredLinkContext _context;

        public HomeController(ILogger<HomeController> logger, ExpiredLinkContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<LinksTable> links = await _context.Links.ToListAsync();
            return View(links);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("error");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
