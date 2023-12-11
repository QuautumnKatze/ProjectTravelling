using Microsoft.AspNetCore.Mvc;
using ProjectTravel.Ultilities;

namespace ProjectTravel.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Logout()
        {
            Functions._AccountID = 0;
            Functions._FullName = string.Empty;
            Functions._UserName = string.Empty;
            Functions._Password = string.Empty;
            Functions._Email = string.Empty;
            Functions._Phone = string.Empty;
            Functions._Message = string.Empty;
            Functions._MessageEmail = string.Empty;
            Functions._Avatar = string.Empty;
            Functions._Address = string.Empty;
            Functions._Birthday = DateTime.MinValue;
            Functions._RoleID = 0;
            return LocalRedirect("/Home/Index");
        }
    }
}
