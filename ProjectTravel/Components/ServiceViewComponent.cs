using Microsoft.AspNetCore.Mvc;
using ProjectTravel.Models;

namespace ProjectTravel.Components
{
	[ViewComponent(Name = "ServiceView")]
	public class ServiceViewComponent : ViewComponent
	{
		private DataContext _context;
		public ServiceViewComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listservice = (from c in _context.Services
								where (c.IsActive == true)
								orderby c.ServiceID descending
								select c).Take(4).ToList();

			return await Task.FromResult((IViewComponentResult)View("Default", listservice));
		}

	}
}
