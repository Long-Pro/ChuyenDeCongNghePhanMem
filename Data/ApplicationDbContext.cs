using ChuyenDeCongNghePhanMem.Models;
using Microsoft.EntityFrameworkCore;

namespace ChuyenDeCongNghePhanMem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Test> Tests { get; set; }
    }
}
