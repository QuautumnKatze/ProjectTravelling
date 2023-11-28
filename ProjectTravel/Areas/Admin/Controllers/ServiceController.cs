using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectTravel.Models;
using ProjectTravel.Ultilities;

namespace ProjectTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly DataContext _context;
        public ServiceController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            var servList = _context.Services.OrderBy(c => c.ServiceID).ToList();
            return View(servList);
        }

        public IActionResult Delete(int? id)
        {
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var serv = _context.Services.Find(id);

            if (serv == null)
            {
                return NotFound();
            }
            return View(serv);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            var deleServ = _context.Services.Find(id);
            if (deleServ == null)
            {
                return NotFound();
            }
            _context.Services.Remove(deleServ);
            _context.SaveChanges();
            return LocalRedirect("/Admin/Service/Index");
        }

        public IActionResult Create()
        {
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            //var mnList = (from m in _context.Menus
            //              select new SelectListItem()
            //              {
            //                  Text = m.MenuName,
            //                  Value = m.MenuID.ToString()
            //              }).ToList();
            //mnList.Insert(0, new SelectListItem()
            //{
            //    Text = "----Select----",
            //    Value = "0"
            //});
            //ViewBag.mnList = mnList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Service serv)
        {
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            if (ModelState.IsValid)
            {
                _context.Services.Add(serv);
                _context.SaveChanges();
                return LocalRedirect("/Admin/Service/Index");
            }
            return View(serv);
        }

        public IActionResult Edit(int? id)
        {
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var serv = _context.Services.Find(id);
            if (serv == null)
            {
                return NotFound();
            }
            return View(serv);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Service serv)
        {

            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            if (ModelState.IsValid)
            {
                _context.Services.Update(serv);
                _context.SaveChanges();
                return LocalRedirect("/Admin/Service/Index");
            }
            return View(serv);
        }
    }
}
