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
	}
}
