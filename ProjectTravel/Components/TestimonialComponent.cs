using Microsoft.AspNetCore.Mvc;
using ProjectTravel.Models;

namespace ProjectTravel.Components
{
    [ViewComponent(Name = "TestimonialView")]
    public class TestimonialComponent : ViewComponent
    {
        private readonly DataContext _context;
        public TestimonialComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listTestimonial = (from t in _context.Testimonials

                                orderby t.TestimonialID descending
                                select t).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listTestimonial));
        }
    }
}
