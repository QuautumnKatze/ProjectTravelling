using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectTravel.Models;
using ProjectTravel.Ultilities;

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

		//public IActionResult Index()
		//{
  //          //kiểm tra đăng nhập
  //          if (!Functions.IsLogin())
  //              return LocalRedirect("/Admin/Login/Index");

  //          var listofPost = _context.Posts.OrderBy(m => m.PostID).ToList();
		//	return View(listofPost);
		//}

		public async Task<IActionResult> Index(string searchString)
		{
			var listpost = from m in _context.Posts
						 select m;

			if (!String.IsNullOrEmpty(searchString))
			{
				listpost = listpost.Where(s => s.Title!.Contains(searchString));
			}

			return View(await listpost.ToListAsync());
		}

		public IActionResult Delete(long? id)
		{
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

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
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

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
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

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
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            if (ModelState.IsValid)
			{
				_context.Posts.Add(post);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(post);
			
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
