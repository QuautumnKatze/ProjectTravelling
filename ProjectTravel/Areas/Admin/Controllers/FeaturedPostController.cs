using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectTravel.Models;
using ProjectTravel.Ultilities;

namespace ProjectTravel.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class FeaturedPostController : Controller
	{
		private readonly DataContext _context;

		public FeaturedPostController(DataContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            var listfp = _context.Posts.OrderBy(m => m.PostID).ToList();
			return View(listfp);
		}

        public IActionResult Edit(long? id)
        {
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Posts.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            var mnList = (from m in _context.Menus
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.mnList = mnList;
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Post mn)
        {
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            if (ModelState.IsValid)
            {
                _context.Posts.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
    }
}
