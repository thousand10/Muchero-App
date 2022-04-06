using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using mucheroapp.Models;
using mucheroapp.Data;


namespace MainFruits.Controllers
{
    public class MainFruitsController: Controller
    {
        private readonly ApplicationDbContext _context;

        public MainFruitsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult listFruits()
        {
            IEnumerable<Fruit> fruits = _context.fruits;
            return View(fruits);
        }


        [HttpGet]
        public IActionResult listDetail(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            var data = _context.fruits.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
    }
}