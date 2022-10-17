using Doing_List.Models;
using Microsoft.EntityFrameworkCore;

namespace Doing_List.Data
{
    //DBcontext is the entity framework core name

    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //Categories is subset of Category Model 
        public DbSet<Category> Categories { get; set; } 


    }
}
