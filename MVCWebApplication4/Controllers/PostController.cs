using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCWebApplication4.Models;

namespace MVCWebApplication4.Controllers
{
    public class PostController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Intern Interns)
        {
            return View();
        }
       





        [Authorize]
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(Intern Interns) 
        {

            return View();

        }






        [Authorize]
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        { return View();
        }




        [Authorize]
        [HttpGet]
        public IActionResult Read()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Read(int id)
        {
            return View();
        }
    }
}
