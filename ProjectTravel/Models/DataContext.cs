﻿using Microsoft.EntityFrameworkCore;
using ProjectTravel.Models;
//using Travel.Areas.Admin.Models;

namespace ProjectTravel.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }

        //public DbSet<AdminMenu> AdminMenus { get; set; }
    }
}
