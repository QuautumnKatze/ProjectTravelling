using Microsoft.AspNetCore.Mvc;
using ProjectTravel.Models;

namespace ProjectTravel.Components
{

	[ViewComponent(Name = "TopFeaturedPostView")]
	public class TopFeaturedPost : ViewComponent
	{
		private readonly DataContext _context;
		public TopFeaturedPost(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listofPost = (from p in _context.Posts
							  where (p.IsActive == true) && (p.Status == 1) && (p.IsFeatured == true)
							  orderby p.PostID descending
							  select p).Take(1).ToList();

			return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
		}
	}
}
