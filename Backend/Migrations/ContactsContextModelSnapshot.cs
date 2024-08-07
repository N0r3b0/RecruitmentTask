﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RecruitmentTask.Contexts;

#nullable disable

namespace RecruitmentTask.Migrations
{
    [DbContext(typeof(ContactsContext))]
    partial class ContactsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RecruitmentTask.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Personal"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Business"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("RecruitmentTask.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SubCategory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contact", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1957, 2, 6, 3, 25, 48, 0, DateTimeKind.Utc),
                            Category = "Personal",
                            Email = "wandacarter@yahoo.com",
                            FirstName = "Robin",
                            LastName = "Crane",
                            Password = "&jNraKMIa5",
                            PhoneNumber = "001-265-432-9150",
                            SubCategory = "",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1950, 5, 5, 14, 37, 12, 0, DateTimeKind.Utc),
                            Category = "Other",
                            Email = "rgreen@gmail.com",
                            FirstName = "Monique",
                            LastName = "Moran",
                            Password = "(4#GAV_hYb",
                            PhoneNumber = "0118807176",
                            SubCategory = "civil",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1958, 2, 13, 22, 49, 1, 0, DateTimeKind.Utc),
                            Category = "Business",
                            Email = "mgoodman@mccall.com",
                            FirstName = "Christine",
                            LastName = "Pena",
                            Password = "U9G5v(tt_l",
                            PhoneNumber = "001-516-329-1903x568",
                            SubCategory = "Boss",
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1928, 11, 22, 9, 15, 30, 0, DateTimeKind.Utc),
                            Category = "Business",
                            Email = "howardmichele@hotmail.com",
                            FirstName = "Benjamin",
                            LastName = "Nichols",
                            Password = "&9U*Soq(Xe",
                            PhoneNumber = "805-736-4268x6968",
                            SubCategory = "Client",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("RecruitmentTask.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategory", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 2,
                            Name = "Boss"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Name = "Client"
                        });
                });

            modelBuilder.Entity("RecruitmentTask.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "test@test.com",
                            Password = "$2a$11$CcoleKoLGIDchqqPt3P6i.mQFy4X/UilynKTnOIbTt8zXtuVYVyae",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("RecruitmentTask.Models.Contact", b =>
                {
                    b.HasOne("RecruitmentTask.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecruitmentTask.Models.SubCategory", b =>
                {
                    b.HasOne("RecruitmentTask.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RecruitmentTask.Models.Category", b =>
                {
                    b.Navigation("SubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
