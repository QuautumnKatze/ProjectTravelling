using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectTravel.Models;

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
            var featuredList = _context.FeaturedPosts.OrderBy(f => f.FeaturedPostID).ToList();
            return View(featuredList);
        }

        public IActionResult Create()
        {
            var postList = (from p in _context.Posts
                            select new SelectListItem() 
                            {
                                Text = p.Title,
                                Value = p.PostID.ToString()
                            }).ToList();
            postList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.postList = postList;
            return View();
        }
        [HttpPost]

        public IActionResult Create(Featured_Post featuredPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(featuredPost);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var featuredPost = _context.DBFeaturedPosts.Find(id);

            if (featuredPost == null)
            {
                return NotFound();
            }
            return View(featuredPost);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var deleFeaturedPost = _context.DBFeaturedPosts.Find(id);
            if (deleFeaturedPost == null)
            {
                return NotFound();
            }
            _context.DBFeaturedPosts.Remove(deleFeaturedPost);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

		public IActionResult Edit(long? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var ftpost = _context.DBFeaturedPosts.Find(id);
			if (ftpost == null)
			{
				return NotFound();
			}
			var postList = (from p in _context.Posts
						  select new SelectListItem()
						  {
							  Text = p.Title,
							  Value = p.PostID.ToString(),
						  }).ToList();
			postList.Insert(0, new SelectListItem()
			{
				Text = "----Select----",
				Value = string.Empty
			});
			ViewBag.postList = postList;
			return View(ftpost);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Edit(Featured_Post ftpost)
		{
			if (ModelState.IsValid)
			{
				_context.DBFeaturedPosts.Update(ftpost);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(ftpost);
		}
	}
}
