using BackEnd.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data
{
    public class AspNetIdentityDbContext : IdentityDbContext<User>
    {
        public AspNetIdentityDbContext(DbContextOptions<AspNetIdentityDbContext> options) 
            : base(options) { }
    }
}
