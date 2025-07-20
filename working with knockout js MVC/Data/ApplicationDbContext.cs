using System.Collections.Generic;
using working_with_knockout_js_MVC.Models;
using Microsoft.EntityFrameworkCore;


namespace working_with_knockout_js_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Models.Employee> Employees { get; set; }
    }
}
