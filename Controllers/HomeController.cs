using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Areas.Identity.Data;
using WebApplication.Models;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<WebApplicationUser> _userManager;
        private DbContect _context;

        public HomeController(ILogger<HomeController> logger, UserManager<WebApplicationUser> userManager, DbContect context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel();
            var userId = _userManager.GetUserId(User);

            var trackings = await _context.Tracking.Where(i => i.UserId.Equals(userId)).ToListAsync();
			if (trackings.Count()>0)
			{
                viewModel.numberLoggedInLastMonth = trackings.Count();
                viewModel.LastLoggedIn = trackings.LastOrDefault().Logged;
            }
           

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
