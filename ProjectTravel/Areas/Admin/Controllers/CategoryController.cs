using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectTravel.Models;

namespace ProjectTravel.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly DataContext _context;
		public CategoryController(DataContext context) 
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var cateList = _context.Categories.OrderBy(c => c.CategoryID).ToList();
			return View(cateList);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var ctgr = _context.Categories.Find(id);

			if (ctgr == null)
			{
				return NotFound();
			}
			return View(ctgr);
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			var deleCate = _context.Categories.Find(id);
			if (deleCate == null)
			{
				return NotFound();
			}
			_context.Categories.Remove(deleCate);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Create()
        {
            var mnList = (from m in _context.Menus
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString()
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.mnList = mnList;
            return View();
        }
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Create(Category ctgr)
		{
			if (ModelState.IsValid)
			{
				_context.Categories.Add(ctgr);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(ctgr);
		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var ctgr = _context.Categories.Find(id);
			if (ctgr == null)
			{
				return NotFound();
			}
			return View(ctgr);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Edit(Category ctgr)
		{
			if (ModelState.IsValid)
			{
				_context.Categories.Update(ctgr);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(ctgr);
		}
	}
}
