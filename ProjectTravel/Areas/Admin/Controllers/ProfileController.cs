using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectTravel.Models;
using ProjectTravel.Ultilities;
using ProjectTravel.Areas.Admin.Models;

namespace ProjectTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileController : Controller
    {
        int id = Functions._AccountID;

        private readonly DataContext _context;
        public ProfileController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var items = _context.Accounts.Find(Functions._AccountID);
            if (items == null)
            {
                return NotFound();
            }
            return View(items);
        }

        public IActionResult EditProfile()
        {
            var items = _context.Accounts.Find(Functions._AccountID);
            if (items == null)
            {
                return NotFound();
            }
            return View(items);
        }

        [HttpPost]
        public IActionResult EditProfile(Account user)
        {
            var check = _context.Accounts.Where(m => m.Email == user.Email && user.Email != Functions._Email).FirstOrDefault();
            if (check != null)
            {
                Functions._MessageEmail = "Email đã tồn tại!";
                return RedirectToAction("EditProfile");
            }
            var check2 = _context.Accounts.Where(m => m.Phone == user.Phone && user.Phone != Functions._Phone).FirstOrDefault();
            if (check2 != null)
            {
                Functions._Message = "Số điện thoại đã tồn tại!";
                return RedirectToAction("EditProfile");
            }
            Functions._Avatar = user.Avatar;
            Functions._FullName = user.FullName;
            Functions._Email = user.Email;
            Functions._Phone = user.Phone;
            Functions._Address = user.Address;
            Functions._Birthday = user.Birthday;
            Functions._MessageEmail = string.Empty;
            Functions._Message = string.Empty;
            user.RoleID = Functions._RoleID;
            user.IsActive = true;
            _context.Accounts.Update(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditPassword(string oldPassword, string newPassword, string renewPassword)
        {
            if (ModelState.IsValid)
            {
                Account? edit = _context.Accounts.Find(Functions._AccountID);
                string pw = Functions.MD5Password(oldPassword);
                if (pw != edit?.Password)
                {
                    Functions._Message = "Mật khẩu không chính xác!";
                    return RedirectToAction("EditPassword");
                }
                if (newPassword != renewPassword)
                {
                    Functions._Message = "Không trùng khớp mật khẩu mới!";
                    return RedirectToAction("EditPassword");
                }
                edit.AccountID = Functions._AccountID;
                edit.Avatar = Functions._Avatar;
                edit.FullName = Functions._FullName;
                edit.UserName = Functions._UserName;
                edit.Password = Functions.MD5Password(newPassword);
                edit.Phone = Functions._Phone;
                edit.Email = Functions._Email;
                edit.Address = Functions._Address;
                edit.Birthday = Functions._Birthday;
                edit.RoleID = Functions._RoleID;
                edit.IsActive = true;
                _context.Accounts.Update(edit);
                _context.SaveChanges();
                Functions._Message = "Đổi mật khẩu thành công !";
                return RedirectToAction("EditPassword");
            }
            return View();
        }

    }
}
