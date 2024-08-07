using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Migrations;
using RecruitmentTask.Models;

namespace RecruitmentTask.Contexts
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // non-standard table names
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<SubCategory>().ToTable("SubCategory");

            // Define the relationship
            modelBuilder.Entity<Contact>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<SubCategory>()
                .HasOne<Category>(sc => sc.Category)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(sc => sc.CategoryId);

            // database seed
            //modelBuilder.ApplyConfiguration(new SeedData());
        }

    }
}
