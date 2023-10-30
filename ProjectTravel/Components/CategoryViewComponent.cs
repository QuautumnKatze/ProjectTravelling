using Microsoft.AspNetCore.Mvc;
using ProjectTravel.Models;

namespace ProjectTravel.Components
{
    [ViewComponent(Name = "CategoryView")]
    public class CategoryViewComponent : ViewComponent
    {
        private DataContext _context;
        public CategoryViewComponent(DataContext context) 
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listCategory = (from c in _context.Categories
                                where (c.IsActive == true)
                                orderby c.CategoryID descending
                                select c).Take(4).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listCategory));
        }

    }
}
