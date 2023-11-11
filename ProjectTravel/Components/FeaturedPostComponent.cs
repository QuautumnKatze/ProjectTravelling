using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using ProjectTravel.Models;

namespace ProjectTravel.Components
{
	[ViewComponent(Name = "FeaturedPostView")]
	public class FeaturedPostComponent : ViewComponent
	{
		private DataContext _context;

		public FeaturedPostComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listFeatured = (from f in _context.FeaturedPosts
								where (f.IsActive == true) && (f.Status == 1)
								orderby f.PostID
								select f).Take(3).ToList();

			return await Task.FromResult((IViewComponentResult)View("Default", listFeatured));
		}
	}
}
