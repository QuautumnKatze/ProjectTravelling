using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectTravel.Models;

namespace ProjectTravel.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PostController : Controller
	{
		private readonly DataContext _context;

		public PostController(DataContext context) 
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var listofPost = _context.Posts.OrderBy(m => m.PostID).ToList();
			return View(listofPost);
		}

		public IActionResult Delete(long? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var post = _context.Posts.Find(id);

			if (post == null)
			{
				return NotFound();
			}
			return View(post);
		}

		[HttpPost]
		public IActionResult Delete(long id)
		{
			var delePost = _context.Posts.Find(id);
			if (delePost == null)
			{
				return NotFound();
			}
			_context.Posts.Remove(delePost);
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
				Value = string.Empty
			});
			ViewBag.mnList = mnList;
			return View();
		}
		[HttpPost]

		public IActionResult Create(Post post)
		{
			if (ModelState.IsValid)
			{
				_context.Add(post);
				_context.SaveChanges();
			}
			return RedirectToAction("Index");
		}

		public IActionResult Edit(long? id)
		{
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
