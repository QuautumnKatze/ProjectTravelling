using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTravel.Areas.Admin.Models;
using ProjectTravel.Models;
using ProjectTravel.Ultilities;

namespace ProjectTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        public LoginController(DataContext context)
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
            //Mã hóa mật khẩu trước khi kiểm tra
            string pw = Functions.MD5Password(user.Password);
            //Kiểm tra sự tồn tại của tên tài khoản và mật khẩu
            var check = _context.Accounts.Where(m => (m.UserName == user.UserName) && (m.Password == pw) && ((m.RoleID == 2) || (m.RoleID == 1))).FirstOrDefault();
            if (check == null)
            {
                Functions._Message = "Sai tên tài khoản hoặc mật khẩu";
                return LocalRedirect("/Admin/Login/Index");
            }
            //Nếu đăng nhập thành công thì lưu lại thông tin đăng nhập và vào Admin
            Functions._Message = string.Empty;
            Functions._AccountID = check.AccountID;
            Functions._UserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Functions._Password = string.IsNullOrEmpty(user.Password) ? string.Empty : user.Password;
            Functions._FullName = string.IsNullOrEmpty(check.FullName) ? string.Empty : check.FullName;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            Functions._Phone = string.IsNullOrEmpty(check.Phone) ? string.Empty : check.Phone;
            Functions._Avatar = string.IsNullOrEmpty(check.Avatar) ? string.Empty : check.Avatar;
            Functions._Address = string.IsNullOrEmpty(check.Address) ? string.Empty : check.Address;
            Functions._Birthday = string.IsNullOrEmpty(check.Birthday.ToString()) ? DateTime.MinValue : check.Birthday;
            Functions._RoleID = check.RoleID;

            return LocalRedirect("/Admin/Home/Index");
        }
    }
}
