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


            

            // Seed data for Category
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Personal" },
                new Category { Id = 2, Name = "Business" },
                new Category { Id = 3, Name = "Other" }
            );

            // Seed data for SubCategory
            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory { Id = 1, Name = "Boss", CategoryId = 2},
                new SubCategory { Id = 2, Name = "Client", CategoryId = 2 }
            );

            // Seed data for User
            modelBuilder.Entity<User>().HasData(
                // password = "password"
                new User { Id = 1, Username = "admin", Email = "test@test.com", Password = "$2a$11$CcoleKoLGIDchqqPt3P6i.mQFy4X/UilynKTnOIbTt8zXtuVYVyae" }
            );

            // Seed data for Contact
            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, FirstName = "Robin", LastName = "Crane", Email = "wandacarter@yahoo.com", Password = "&jNraKMIa5", Category = "Personal", SubCategory = "", PhoneNumber = "001-265-432-9150", BirthDate = DateTime.Parse("1957-02-06T03:25:48Z").ToUniversalTime(), UserId = 1 },
                new Contact { Id = 2, FirstName = "Monique", LastName = "Moran", Email = "rgreen@gmail.com", Password = "(4#GAV_hYb", Category = "Other", SubCategory = "civil", PhoneNumber = "0118807176", BirthDate = DateTime.Parse("1950-05-05T14:37:12Z").ToUniversalTime(), UserId = 1 },
                new Contact { Id = 3, FirstName = "Christine", LastName = "Pena", Email = "mgoodman@mccall.com", Password = "U9G5v(tt_l", Category = "Business", SubCategory = "Boss", PhoneNumber = "001-516-329-1903x568", BirthDate = DateTime.Parse("1958-02-13T22:49:01Z").ToUniversalTime(), UserId = 1 },
                new Contact { Id = 4, FirstName = "Benjamin", LastName = "Nichols", Email = "howardmichele@hotmail.com", Password = "&9U*Soq(Xe", Category = "Business", SubCategory = "Client", PhoneNumber = "805-736-4268x6968", BirthDate = DateTime.Parse("1928-11-22T09:15:30Z").ToUniversalTime(), UserId = 1 }


            );
        }

    }
}
