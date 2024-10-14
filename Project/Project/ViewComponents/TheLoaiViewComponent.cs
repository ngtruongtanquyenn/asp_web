using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;

namespace Project.ViewComponents
{
    public class TheLoaiViewComponent : ViewComponent
    {
        public readonly ApplicationDbContext _db;
        public TheLoaiViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var theloai = await  _db.TheLoai.ToListAsync();
            return View(theloai);
        }
    }
}
