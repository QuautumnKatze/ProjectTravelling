using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectTravel.Models;
using ProjectTravel.Areas.Admin.Models;

namespace ProjectTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var item = _context.Accounts.Where(m => (m.IsActive == true) && ((m.RoleID == 2) || (m.RoleID == 3))).ToList();
            return View(item);
        }

        public IActionResult ListDisabled()
        {
            var item = _context.Accounts.Where(m => (m.IsActive == false) && ((m.RoleID == 2) || (m.RoleID == 3))).ToList();
            return View(item);
        }
        public IActionResult ListAdmin()
        {
            var item = _context.Accounts.Where(m => (m.RoleID == 1)).ToList();
            return View(item);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _context.Accounts.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            var rList = (from m in _context.Roles
                         select new SelectListItem()
                         {
                             Text = m.RoleName,
                             Value = m.RoleID.ToString(),
                         }).ToList();
            rList.Insert(0, new SelectListItem()
            {
                Text = "---Chọn---",
                Value = string.Empty
            });
            ViewBag.rList = rList;
            return View(item);
        }

        public IActionResult Disable(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _context.Accounts.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disable(Account edit)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Update(edit);
                _context.SaveChanges();
                return LocalRedirect("/Admin/Account/ListDisabled");
            }
            return View(edit);
        }

        public IActionResult Enable(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _context.Accounts.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enable(Account edit)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Update(edit);
                _context.SaveChanges();
                return LocalRedirect("/Admin/Account/Index");
            }
            return View(edit);
        }
    }
}
