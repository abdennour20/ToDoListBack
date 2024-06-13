using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {


        public DbSet<User> Users { get; set; }
        public DbSet<TasK> Tasks { get; set; }
      //  public DbSet<TaskAssignet> TaskAssignments { get; set; }
        public   ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        
        { 
        }
        
 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>()
             .HasMany(u => u.AssignedTasks)
             .WithOne(t => t.AssignedUser)
             .HasForeignKey(t => t.assigned_user_id);
        }
    }

}

