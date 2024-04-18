using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using MVCWebApplication4.Models;
using MVCWebApplication4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;



namespace MVCWebApplication4.Controllers
{
    public class AdminController : Controller
    {
        private readonly Cloudinary _cloudinary;
        private readonly ModernFoodDbContext _dbContext;
       

        public AdminController(Cloudinary cloudinary,ModernFoodDbContext dbContext)
        {
            _cloudinary = cloudinary;
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult CreateItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateItem(ModernImageModel model)
        {
            Console.WriteLine("creat4ee");
            if (ModelState.IsValid)
            {
                var itemname = model.ItemName;
                var description = model.Description;
                var price = model.price;

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(@"c:\my_image.jpg")
                };

                var uploadResult = _cloudinary.Upload(uploadParams);
                if (uploadResult != null)
                {
                    var imageEntity = new Modern
                    {
                        ItemName = itemname,
                        Description = description,
                        price = price,
                        imageurl = uploadResult.SecureUrl.AbsoluteUri

                    };
                    _dbContext.Moderns.Add(imageEntity);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Doo");
                }

                return View(model);

            }
            else {
                Console.WriteLine("hfghfghfh");
                return View(model);
            }

           
        }

        public IActionResult Doo()
        {
            return View();
        }
    }
}
