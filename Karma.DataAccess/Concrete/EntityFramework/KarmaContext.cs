using Karma.Entities;
using Karma.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Karma.DataAccess.Concrete.EntityFramework
{
    public class KarmaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=KarmaDb;Integrated Security=true;TrustServerCertificate=True;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Spesification> Spesifications { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<NewstellerSub> NewstellerSubs { get; set; }
        public DbSet<CampaignProduct> CampaginProducts { get; set; }
        public DbSet<ShowcaseProducts> ShowcaseProducts{ get; set; }

    }
}