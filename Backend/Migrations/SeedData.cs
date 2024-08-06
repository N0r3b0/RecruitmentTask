using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitmentTask.Models;

namespace RecruitmentTask.Migrations
{
    public class SeedData : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(
                new Contact { Id = 1, FirstName = "Robin", LastName = "Crane", Email = "wandacarter@yahoo.com", Password = "&jNraKMIa5", Category = "Personal", SubCategory = "", PhoneNumber = "001-265-432-9150", BirthDate = DateTime.Parse("1957-02-06T03:25:48Z").ToUniversalTime() },
                new Contact { Id = 2, FirstName = "Monique", LastName = "Moran", Email = "rgreen@gmail.com", Password = "(4#GAV_hYb", Category = "Other", SubCategory = "civil", PhoneNumber = "0118807176", BirthDate = DateTime.Parse("1950-05-05T14:37:12Z").ToUniversalTime() },
                new Contact { Id = 3, FirstName = "Christine", LastName = "Pena", Email = "mgoodman@mccall.com", Password = "U9G5v(tt_l", Category = "Business", SubCategory = "Boss", PhoneNumber = "001-516-329-1903x568", BirthDate = DateTime.Parse("1958-02-13T22:49:01Z").ToUniversalTime() },
                new Contact { Id = 4, FirstName = "Benjamin", LastName = "Nichols", Email = "howardmichele@hotmail.com", Password = "&9U*Soq(Xe", Category = "Business", SubCategory = "Client", PhoneNumber = "805-736-4268x6968", BirthDate = DateTime.Parse("1928-11-22T09:15:30Z").ToUniversalTime() },
                new Contact { Id = 5, FirstName = "Jodi", LastName = "Mclean", Email = "robertbraun@gmail.com", Password = "0(08zLCd7H", Category = "Other", SubCategory = "song", PhoneNumber = "9085445089", BirthDate = DateTime.Parse("1938-03-17T11:55:44Z").ToUniversalTime() },
                new Contact { Id = 6, FirstName = "Thomas", LastName = "Tyler", Email = "charles97@hotmail.com", Password = "&2CyModfq2", Category = "Personal", SubCategory = "", PhoneNumber = "837.087.5302x942", BirthDate = DateTime.Parse("2017-11-15T07:42:22Z").ToUniversalTime() },
                new Contact { Id = 7, FirstName = "Michael", LastName = "Williams", Email = "brenda52@hotmail.com", Password = "*99$c8Keub", Category = "Business", SubCategory = "Client", PhoneNumber = "923.241.4303x53037", BirthDate = DateTime.Parse("2010-09-20T19:30:00Z").ToUniversalTime() },
                new Contact { Id = 8, FirstName = "Bradley", LastName = "Riley", Email = "johnsmary@everett.com", Password = "%fPMZco*@3", Category = "Other", SubCategory = "hit", PhoneNumber = "001-995-809-8220x270", BirthDate = DateTime.Parse("1942-03-01T23:11:05Z").ToUniversalTime() },
                new Contact { Id = 9, FirstName = "Jacob", LastName = "Coleman", Email = "owilson@hughes-martinez.com", Password = "*@y119L42q", Category = "Business", SubCategory = "Boss", PhoneNumber = "+1-195-972-2281x7606", BirthDate = DateTime.Parse("2010-10-19T06:22:35Z").ToUniversalTime() },
                new Contact { Id = 10, FirstName = "Lindsay", LastName = "Gray", Email = "kthornton@yahoo.com", Password = "&S1BX9gsH8", Category = "Other", SubCategory = "movement", PhoneNumber = "245-124-6602x231", BirthDate = DateTime.Parse("1923-02-28T15:18:59Z").ToUniversalTime() }
            );
        }
    }

}
