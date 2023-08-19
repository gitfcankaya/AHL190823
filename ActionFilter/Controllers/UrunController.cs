using ActionFilter.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilter.Controllers
{
    public class UrunController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        [LoglamaFilter]
        public IActionResult SepeteEkle()
        {
            return View();
        }
    }
}
