using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTravel.Areas.Admin.Models;
using ProjectTravel.Models;
using ProjectTravel.Ultilities;

namespace ProjectTravel.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class RegisterController : Controller
	{
		private readonly DataContext _context;
		public RegisterController(DataContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]		
		public IActionResult Index(Account user)
		{
			if (user == null)
			{
				return NotFound();
			}
			//kiểm tra nếu UserName có dấu cách
			if (user.UserName.Contains(" "))
			{
				Functions._MessageEmail = "Tên tài khoản không được nhập dấu cách";
				return LocalRedirect("/Admin/Register/Index");
			}
            //kiểm tra tên tài khoản đã tồn tại chưa
            var check1 = _context.Accounts.Where(m => m.UserName == user.UserName).FirstOrDefault();
            if (check1 != null)
            {
                Functions._MessageEmail = "Tên tài khoản này đã có người sử dụng!";
                return LocalRedirect("/Admin/Register/Index");
            }
            //kiểm tra email đã tồn tại chưa
            var check2 = _context.Accounts.Where(m => m.Email == user.Email).FirstOrDefault();
			if (check2 != null)
			{
				Functions._MessageEmail = "Email này đã có người sử dụng!";
				return LocalRedirect("/Admin/Register/Index");
			}
			//kiểm tra số điện thoại đã tồn tại chưa
            var check3 = _context.Accounts.Where(m => m.Phone == user.Phone).FirstOrDefault();
            if (check3 != null)
            {
                Functions._MessageEmail = "Số điện thoại này đã có người đăng ký!";
				return LocalRedirect("/Admin/Register/Index");
			}
			//vượt qua được 3 bước kiểm tra thì thêm vào Database
            Functions._MessageEmail = string.Empty;
			user.Password = Functions.MD5Password(user.Password);
			_context.Add(user);
			_context.SaveChanges();
			return LocalRedirect("/Admin/Login/Index");
		}
	}
}
