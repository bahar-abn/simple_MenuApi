using Microsoft.EntityFrameworkCore;
using MenuApi.Models;
using System.Collections.Generic;

namespace MenuApi.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }

        public DbSet<MenuItem> menuItems { get; set; }
    }
}