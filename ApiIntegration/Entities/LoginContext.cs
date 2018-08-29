using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiIntegration.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiIntegration.Entities
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options) : base(options)
        {
            Database.Migrate();
        }
        [Key]
        public DbSet<LoginDto> Login { get; set; }
        public DbSet<UserProfileDto> UserProfile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //index
            modelBuilder.Entity<LoginDto>()
                .HasIndex(i => i.EmailAddress);

            modelBuilder.Entity<UserProfileDto>()
                .HasIndex(x => x.EmailAddress);
            
            //Associations
            modelBuilder.Entity<LoginDto>()
                .HasOne(x => x.UsepProfileDto)
                .WithOne(x => x.LoginDto)
                .HasForeignKey<UserProfileDto>();

           

        }
    }
}
