using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Upload()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            var fileName = System.IO.Path.GetFileName(file.FileName);
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }

            //create new local file and copy the contents of uploaded files
            using (var localFile = System.IO.File.OpenWrite(fileName))
                using(var uploadedFile = file.OpenReadStream())
            {
                uploadedFile.CopyTo(localFile);
            }

            ViewBag.Message = "File successfully uploaded";
            return View();
        }
    }
}
