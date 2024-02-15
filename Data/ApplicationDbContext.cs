using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Week5CaseStudy.Models;
using System.Reflection.Metadata;

namespace Week5CaseStudy.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }

        public DbSet<HashtagPostMap> HashtagPostMap { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HashtagPostMap>().HasKey(u => new { u.Hashtag_Id, u.Post_Id});

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
           .Property(b => b.CreatedDate)
           .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Category>()
           .Property(b => b.Id)
           .UseIdentityColumn();

            modelBuilder.Entity<Post>()
           .Property(b => b.Id)
           .UseIdentityColumn();

            modelBuilder.Entity<Hashtag>()
           .Property(b => b.Id)
           .UseIdentityColumn();

        }
    }
}
