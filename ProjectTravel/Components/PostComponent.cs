﻿using Microsoft.AspNetCore.Mvc;
using ProjectTravel.Models;

namespace ProjectTravel.Components
{
    [ViewComponent(Name = "Post")]
    public class PostComponent : ViewComponent
    {
        private readonly DataContext _context;
        public PostComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _context.Posts
                              where (p.IsActive == true) && (p.Status == 1)
                              orderby p.PostID descending
                              select p).Take(4).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}