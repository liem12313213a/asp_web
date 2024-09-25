using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Microsoft.EntityFrameworkCore;

namespace Project.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SanPhamController(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
