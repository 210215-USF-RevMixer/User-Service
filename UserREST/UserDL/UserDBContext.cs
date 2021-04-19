using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace UserDL
{
    [ExcludeFromCodeCoverage]
    /// <summary>
    /// DB Context for User-Service
    /// </summary>
    public class UserDBContext: DbContext
    {
        public UserDBContext(DbContextOptions options) : base(options)
        {
        }
        protected UserDBContext()
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Report> Report { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Auto incrememnt Id when new user is added to DB
            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            //Auto increment Id when new report is added to DB
            modelBuilder.Entity<Report>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            //Establish 1:M relationship b/w users and reports 
            modelBuilder.Entity<User>()
                .HasMany(r => r.Reports)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade); //don't want to delete the rule, just the user associated with it 
        }
    }
}
