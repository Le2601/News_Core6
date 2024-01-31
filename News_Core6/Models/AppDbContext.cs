using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace News_Core6.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<New> News { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Account> Accounts { get; set; }

       
    //  protected override void OnConfiguring(DbContextOptionsBuilder options)
    //{
    //    // connect to sql server with connection string from app settings
    //    options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    //}
      


        //fluent
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           

            modelBuilder.Entity<Post>()
                .HasOne(p => p.New)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.NewId);

            modelBuilder.Entity<Account>()
                .HasOne(p => p.Role)
                .WithMany(p => p.Accounts)
                .HasForeignKey(p => p.RoleId);



        }


    }
}
