using CCLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CCLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        //DbContext for the database when it is made avaiable. 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Launch> Launches { get; set; }
    }
}