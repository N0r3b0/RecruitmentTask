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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // non-standard table names
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<User>().ToTable("User");

            // Define the relationship
            modelBuilder.Entity<Contact>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId);

            // database seed
            //modelBuilder.ApplyConfiguration(new SeedData());
        }
    }
}
