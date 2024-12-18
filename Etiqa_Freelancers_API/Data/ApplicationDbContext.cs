using Etiqa_Freelancers_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Etiqa_Freelancers_API.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
        }


        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Skillset> Skillsets { get; set; }
    }
}
