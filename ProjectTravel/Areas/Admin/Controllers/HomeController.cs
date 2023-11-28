using Microsoft.AspNetCore.Mvc;
using ProjectTravel.Ultilities;

namespace ProjectTravel.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            return View();
		}
	}
}
