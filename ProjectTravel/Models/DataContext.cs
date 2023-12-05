using Microsoft.EntityFrameworkCore;
using ProjectTravel.Areas.Admin.Models;

namespace ProjectTravel.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Post> Posts { get; set; }

		public DbSet<view_Post_Menu> PostMenus { get; set; }

		public DbSet<AdminMenu> AdminMenus { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Role> Roles { get; set; }

		public DbSet<Contact> Contacts { get; set; }


	}
}
