using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Practical_18.Data
{
    public class ApplicationDBcontext : IdentityDbContext<User>
    {
        public ApplicationDBcontext(DbContextOptions options) : base(options)
        {

        }
        DbSet<Student> students { get; set; }
    }
}
