using Microsoft.AspNetCore.Mvc;
using ViewComponentOrnegi.Models;

namespace ViewComponentOrnegi.Controllers.ViewComponents
{
    public class UrunListeViewComponent : ViewComponent
    {
        private readonly List<Urun> _urunler; // Ürünlerin örnek listesi (örnek olarak)

        public UrunListeViewComponent()
        {
            // Ürünleri burada örnek olarak doldurabilirsiniz.
            _urunler = new List<Urun>
            {
                new Urun { Id = 1, Ad = "Ürün 1", Fiyat = 100, Kategori = "Kategori 1" },
                new Urun { Id = 2, Ad = "Ürün 2", Fiyat = 150, Kategori = "Kategori 2" },
                // ...
            };
        }

        public IViewComponentResult Invoke(string kategori = null)
        {
            var filtreliUrunler = _urunler;
            if (!string.IsNullOrEmpty(kategori))
            {
                filtreliUrunler = _urunler.Where(p => p.Kategori == kategori).ToList();
            }

            return View(filtreliUrunler);
        }

    }
}
