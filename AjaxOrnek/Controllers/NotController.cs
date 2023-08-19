using AjaxOrnek.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxOrnek.Controllers
{
    public class NotController : Controller
    {
        private static List<Not> _notlar = new List<Not>();

        public IActionResult Index()
        {
            return View(_notlar);
        }

        [HttpPost]
        public IActionResult NotEkle(Not not)
        {
            _notlar.Add(not);
            return RedirectToAction("Index");
        }
    }
}
