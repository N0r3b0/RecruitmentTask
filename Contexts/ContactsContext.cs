using RecruitmentTask.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecruitmentTask.Contexts
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
