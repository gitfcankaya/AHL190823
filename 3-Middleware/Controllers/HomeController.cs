using _3_Middleware.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _3_Middleware.Controllers
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
            //Logla();
            //SmsAt();
            //TxtDosyayaBilgiVer();
            return View();
        }

        public IActionResult Privacy()
        {
            //SmsAt();
            //TxtDosyayaBilgiVer();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}