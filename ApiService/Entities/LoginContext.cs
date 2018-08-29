using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiIntegration.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiIntegration.Models
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options) : base(options)
        {
            Database.Migrate();
        }

      public DbSet<User> User { get; set; }
        
    }
}
