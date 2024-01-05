using Microsoft.AspNetCore.Mvc;
using ProjectTravel.Models;
using ProjectTravel.Ultilities;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace ProjectTravel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/post/{slug}-{id:long}.html", Name = "Details")]
        public IActionResult Details(long? id)
        {
            if (id == null) 
            { 
                return NotFound();
            }
            var post = _context.Posts.FirstOrDefault(m => (m.PostID == id) && (m.IsActive == true));
            if (post == null) 
            {
                return NotFound();
            }
            ViewBag.postComment = _context.PostComments.Where(i => i.PostID  == id).ToList();
            return View(post);
        }

        [Route("/list/{slug}-{id:int}.html", Name = "List")]
        public IActionResult List(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list = _context.PostMenus
                .Where(m => (m.MenuID == id) && (m.IsActive == true)).OrderByDescending(m => m.PostID)
                .Take(6).ToList();

            if (list == null)
            {
                return NotFound();
            }

            return View(list);
        }

		[Route("/dulich/{slug}-{id:long}.html", Name = "Tour Details")]
		public IActionResult TourDetails(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var tour = _context.Tours.FirstOrDefault(m => (m.TourID == id) && (m.IsActive == true));
			if (tour == null)
			{
				return NotFound();
			}
			//ViewBag.postComment = _context.PostComments.Where(i => i.PostID == id).ToList();
			return View(tour);
		}

		[HttpPost]
        public IActionResult CreateNoAccount(long id, string name, string phone, string email, string message)
        {
            try
            {
                PostComment comment = new PostComment();
                comment.PostID = id;
                comment.Name = name;
                comment.Phone = phone;
                comment.Email = email;
                comment.Contents = message;
                comment.CreatedDate = DateTime.Now;
                _context.Add(comment);
                _context.SaveChangesAsync();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }

		public IActionResult CreateWithAccount(long id, string name, string phone, string email, string message)
		{
			try
			{
				PostComment comment = new PostComment();
				comment.PostID = id;
				comment.Name = name;
				comment.Phone = phone;
				comment.Email = email;
				comment.Contents = message;
				comment.CreatedDate = DateTime.Now;
                comment.AccountID = Functions._AccountID;
				_context.Add(comment);
				_context.SaveChangesAsync();
				return Json(new { status = true });
			}
			catch
			{
				return Json(new { status = false });
			}
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}