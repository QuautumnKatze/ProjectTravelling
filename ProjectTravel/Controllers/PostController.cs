using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTravel.Models;

namespace ProjectTravel.Controllers
{
	public class PostController : Controller
	{
		private readonly DataContext _context;
		public PostController(DataContext context)
		{
			_context = context;
		}

		[Route("/post.html", Name = "Bài viết")]
		public IActionResult Index()
		{
			var postList = _context.Posts
				.Where(m => (m.IsActive == true)).OrderByDescending(m => m.PostID)
				.ToList();
			return View(postList);
		}
	}
}
