using Microsoft.AspNetCore.Mvc;

namespace ProjectTravel.Areas.Admin.Controllers
{
	public class PostCommentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
