using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTravel.Models;

namespace ProjectTravel.Controllers
{
	public class TourController : Controller
	{
		private readonly DataContext _context;
		public TourController(DataContext context)
		{
			_context = context;
		}


		[Route("/tour.html", Name = "Tour Du Lịch")]
		public IActionResult Index()
		{
			var tourList = _context.Tours.Join(_context.Locations,
				m => m.LocationID,
				n => n.LocationID,
				(m, n) => new TourJoinLocation() { tour = m, locate = n}).ToList();
			return View(tourList);
		}
	}
}
