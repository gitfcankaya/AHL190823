using FileUploadİslemleri.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FileUploadİslemleri.Controllers
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


        [HttpGet]
        public IActionResult ImageUpload()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ImageUpload(UyeKayit yeni)
        {
            //...ekleme işlemleri   
            if (yeni.Resim != null)
            {
                var uzanti = Path.GetExtension(yeni.Resim.FileName);
                var rastgeleIsim = ($"{Guid.NewGuid()}{uzanti}");
                var resimYol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", rastgeleIsim);

                yeni.ResimAd = resimYol;

                //Uye yeniUye = new Uye();//DB'deki tablomuzdan oluşan nesne
                //yeniUye.Ad = yeni.Ad;
                //yeniUye.ResimAd = yeni.ResimAd;
                //_context.Uyes.Add(yeniUye);
                //_context.SaveChanges();

                using (var stream = new FileStream(resimYol, FileMode.Create))
                {
                    await yeni.Resim.CopyToAsync(stream);
                }
            }
            return View();
        }


        [HttpGet]
        public IActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileUpload(IFormFile dosya)
        {
            //...dosya ekleme işlemleri   
            if (dosya != null)
            {
                //a.png
                var uzanti = Path.GetExtension(dosya.FileName);

                Guid benzersiz = Guid.NewGuid();// Guid sınıfı 1410bb9a-b229-490c-82ca-70e38e0dc92d gibi rastgele ve yenilenmesi neredeyse imkansız bir key üretir

                var rastgeleIsim = ($"{Guid.NewGuid()}{uzanti}");

                //wwwroot klasörü altında img/resim/resimler gibi dosyaları koyacak klasörü kendimiz oluşturmalıyız. 
                //Directory ve Path classları devreye giriyor

                //c:\projeler\Fileuploadprojesi\wwwrooot\img\1410bb9a-b229-490c-82ca-70e38e0dc92d.png
                var resimYol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", rastgeleIsim);

                //using ifadesi using bloğu bittiğinde nesneyi garbage collectorun bellekten silmesine yarar
                //FileStream sınıfı devreye giriyor
                using (var stream = new FileStream(resimYol, FileMode.Create))
                {
                    await dosya.CopyToAsync(stream);
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}