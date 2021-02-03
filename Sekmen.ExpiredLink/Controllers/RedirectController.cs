using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sekmen.ExpiredLink.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sekmen.ExpiredLink.Controllers
{
    public class RedirectController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExpiredLinkContext _context;

        public RedirectController(ILogger<HomeController> logger, ExpiredLinkContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Link(string id)
        {
            var link = _context.Links.FirstOrDefault(m => m.Guid.Equals(id));
            if (link==null)
            {
                return Content("link not found");
            }

            if (link.CreationTime< DateTime.Now.AddMonths(-1))
            {
                return Content("link expired");
            }

            return Content(link.Link);
        }
    }
}
