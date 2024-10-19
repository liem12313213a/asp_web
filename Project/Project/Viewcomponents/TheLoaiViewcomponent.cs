using Microsoft.AspNetCore.Mvc;
using Project.Data;
namespace Project.Viewcomponents
{
    public class TheLoaiViewcomponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiViewcomponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var theloai = _db.TheLoai.ToList();
            return View(theloai);
        }
    }
}
