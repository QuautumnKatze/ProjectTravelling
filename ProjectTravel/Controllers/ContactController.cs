using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTravel.Areas.Admin.Models;
using ProjectTravel.Models;
using ProjectTravel.Ultilities;

namespace ProjectTravel.Controllers
{
	public class ContactController : Controller
	{
		private readonly DataContext _context;
		public ContactController(DataContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public bool Create(string name, string phone, string email, string message)
		{
			try
			{
				if (string.IsNullOrEmpty(message))
				{
					Functions._Message = "Nội dung không được để trống !";
					return false;
				}
				Contact content = new Contact();
				content.Name = name;
				content.Phone = phone;
				content.Email = email;
				content.Message = message;
				content.CreatedDate = DateTime.Now;
				content.IsRead = true;
				_context.Contacts.Add(content);
				_context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}

