using _5_DTOKullanimi.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace _5_DTOKullanimi.Controllers
{
    public class GonderilerController : Controller
    {
        //private readonly BlogDbContext _dbContext;

        //public GonderilerController(BlogDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public IActionResult Index()
        {
            //    var gonderiler = _dbContext.Gonderiler.ToList();
            //    var gonderiDTOs = gonderiler.Select(gonderi => new GonderiDTO
            //    {
            //        Id = gonderi.Id,
            //        Baslik = gonderi.Baslik
            //    }).ToList();

            //return View(gonderiDTOs);
            return View();
        }

        // Diğer CRUD işlemleri ve DTO kullanımları
    }
}
