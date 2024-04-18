using CloudinaryDotNet.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCWebApplication4.Data;
using MVCWebApplication4.Models;

namespace MVCWebApplication4.Controllers
{
    [Authorize(Roles = "User")]
    public class PageController:Controller
    {
        private readonly MainDbContext _dbContext;

            public PageController(MainDbContext dbContext) 
        { 
             _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create (Intern Application)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("isvalid ki dandi");
                _dbContext.Interns.Add(Application);
                _dbContext.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                Console.WriteLine("model state not valid");
                return View(Application);
            }
        }
        [HttpGet]

        public IActionResult List()
        {
            List<Intern> interns = _dbContext.Interns.ToList();
            return View(interns);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var intern = _dbContext.Interns.Find(id);

            if (intern == null)
            {
                return NotFound();
            }

            return View(intern);
        }
        [HttpPost]
        public IActionResult Edit(Intern updatedIntern)
        {
            if (ModelState.IsValid)
            {
                var existingIntern = _dbContext.Interns.Find(updatedIntern.Id);

                if (existingIntern == null)
                {
                    return NotFound();
                }

                existingIntern.Name = updatedIntern.Name;
                existingIntern.Email = updatedIntern.Email;
                existingIntern.PhoneNumber = updatedIntern.PhoneNumber;
                existingIntern.Address = updatedIntern.Address;
                _dbContext.SaveChanges();

                return RedirectToAction("List");
            }
            return View(updatedIntern);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var intern = _dbContext.Interns.Find(id);

            if (intern == null)
            {
                return NotFound(); // Return a 404 error if the intern is not found
            }
            return View(intern);
        }
        [HttpPost]
        public IActionResult Deleted(int id)
        {
            var intern = _dbContext.Interns.Find(id);

            if (intern == null)
            {
                return NotFound();
            }
            _dbContext.Interns.Remove(intern);
            _dbContext.SaveChanges();
            return RedirectToAction("List");
        }
    }
}



    
