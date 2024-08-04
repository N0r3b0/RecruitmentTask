using RecruitmentTask.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
        }
    }
}
