using Microsoft.AspNetCore.Mvc;

namespace ViewComponentOrnegi.Controllers.Components
{
    public class Son10HaberViewComponent:ViewComponent
{

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
