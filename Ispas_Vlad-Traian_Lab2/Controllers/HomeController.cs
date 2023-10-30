﻿using Microsoft.EntityFrameworkCore;
using Ispas_Vlad_Traian_Lab2.Models;
using Ispas_Vlad_Traian_Lab2.Data;
using Ispas_Vlad_Traian_Lab2.Models.LibraryViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ispas_Vlad_Traian_Lab2.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, LibraryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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
        public async Task<ActionResult> Statistics()
        {
            IQueryable<OrderGroup> data =
            from order in _context.Orders
            group order by order.OrderDate into dateGroup
            select new OrderGroup()
            {
                OrderDate = dateGroup.Key,
                BookCount = dateGroup.Count()
            };
            return View(await data.AsNoTracking().ToListAsync());
        }
    }
}