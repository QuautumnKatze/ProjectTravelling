using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectTravel.Models;
using ProjectTravel.Ultilities;

namespace ProjectTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly DataContext _context;  
        public TestimonialController(DataContext context) 
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            var TestimonialList = _context.Testimonials.OrderBy(c => c.TestimonialID).ToList();
            return View(TestimonialList);
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
            var ttml = _context.Testimonials.Find(id);

            if (ttml == null)
            {
                return NotFound();
            }
            return View(ttml);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            var deleTest = _context.Testimonials.Find(id);
            if (deleTest == null)
            {
                return NotFound();
            }
            _context.Testimonials.Remove(deleTest);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

		public IActionResult Create()
		{
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            var mnList = (from m in _context.Testimonials
						  select new SelectListItem()
						  {
							  Text = m.FullName,
							  Value = m.TestimonialID.ToString()
						  }).ToList();
			ViewBag.mnList = mnList;
			return View();
		}
		[HttpPost]

		public IActionResult Create(Testimonial test)
		{
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            if (ModelState.IsValid)
			{
				_context.Add(test);
				_context.SaveChanges();
			}
			return RedirectToAction("Index");
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
            var ttml = _context.Testimonials.Find(id);
            if (ttml == null)
            {
                return NotFound();
            }
            return View(ttml);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Testimonial ttml)
        {
            //kiểm tra đăng nhập
            if (!Functions.IsLogin())
                return LocalRedirect("/Admin/Login/Index");

            if (ModelState.IsValid)
            {
                _context.Testimonials.Update(ttml);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ttml);
        }
    }
}
