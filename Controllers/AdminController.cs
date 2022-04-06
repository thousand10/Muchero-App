using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using mucheroapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using mucheroapp.Data;


namespace Muchero.Admin
{
    public class AdminController: Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Dashboard()
        {
            // getting a collection of all fruits
            IEnumerable<Fruit> fruits = _context.fruits;
            return View(fruits);
        }


       
        [Authorize]
        public IActionResult Create()
        {
            return View("CreateFruit");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Fruit dataInput)
        {
            if (ModelState.IsValid)
            {

                _context.fruits.Add(dataInput);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
                
            }
            Console.WriteLine("error");
            return View("CreateFruit",dataInput);
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var dataToDelete = _context.fruits.Find(id);
            if (dataToDelete == null)
            {
                return NotFound();
            }
            return View("DeleteFruit", dataToDelete);
        }

            
        [Authorize]
        [HttpPost]
        public IActionResult DeleteData(int? id)
        {
            if(id == 0 && id == null)
            {
                return NotFound();
            }
            var data = _context.fruits.Find(id);
            if (data != null)
            {
                _context.fruits.Remove(data);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("Delete");
           
        }

        [Authorize]
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            var dataToUpdate = _context.fruits.Find(id);
            if (dataToUpdate == null)
            {
                return NotFound();
            }
            return View("UpdateFruit", dataToUpdate);
        }


        [Authorize]
         [ValidateAntiForgeryToken]
         [HttpPost]
         public IActionResult Update(Fruit dataUpdate)
        {
            if (ModelState.IsValid)
            {
                _context.fruits.Update(dataUpdate);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
                
            }
            return NotFound();

        }


        [Authorize]
        public IActionResult Detail(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var fruitDetail = _context.fruits.Find(id);
            if (fruitDetail == null)
            {
                return NotFound();
            }
            return View("DetailFruit", fruitDetail);
        }

    }
}