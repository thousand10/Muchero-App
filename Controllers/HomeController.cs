using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using mucheroapp.Models;
using mucheroapp.Data;
using System.Linq;

namespace muchero.HomeControllers
{
    public class HomeController: Controller
    {

        private readonly ApplicationDbContext _context;
        public HomeController( ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            
            IEnumerable<Fruit> allFruits = _context.fruits;
            return View(allFruits);
        }


        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }


        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

    }
}

