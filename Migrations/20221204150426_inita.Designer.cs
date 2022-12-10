﻿// <auto-generated />
using ClimbingInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClimbingInfo.Migrations
{
    [DbContext(typeof(ClimbingContext))]
    [Migration("20221204150426_inita")]
    partial class inita
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClimbingInfo.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExperienceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("freq")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("years")
                        .HasColumnType("int");

                    b.HasKey("ExperienceId");

                    b.ToTable("Experience");

                    b.HasData(
                        new
                        {
                            ExperienceId = 1,
                            ExperienceName = "Gregs exp",
                            freq = "2-3 days a week!",
                            years = 1
                        },
                        new
                        {
                            ExperienceId = 2,
                            ExperienceName = "More exp",
                            freq = "twice a week.",
                            years = 5
                        },
                        new
                        {
                            ExperienceId = 3,
                            ExperienceName = "Others sxp",
                            freq = "7 days a week!",
                            years = 1
                        },
                        new
                        {
                            ExperienceId = 4,
                            ExperienceName = "Mine exp",
                            freq = "1 day a month.",
                            years = 20
                        });
                });

            modelBuilder.Entity("ClimbingInfo.Models.Gear", b =>
                {
                    b.Property<int>("GearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Chalk_Bag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Harness")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SetupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shoes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GearId");

                    b.ToTable("Gear");

                    b.HasData(
                        new
                        {
                            GearId = 1,
                            Chalk_Bag = "Custom",
                            Harness = "Black Diamond Momentum",
                            SetupName = "Fun setup",
                            Shoes = "Scarpa Helix"
                        },
                        new
                        {
                            GearId = 2,
                            Chalk_Bag = "Cotopaxi",
                            Harness = "Mammut Ophir",
                            SetupName = "Mitch",
                            Shoes = "La Sportiva Tarantulace"
                        },
                        new
                        {
                            GearId = 3,
                            Chalk_Bag = "Kavu Peak Seeker",
                            Harness = "petzl Corax",
                            SetupName = "Berrygood",
                            Shoes = "evolv Shaman"
                        },
                        new
                        {
                            GearId = 4,
                            Chalk_Bag = "Static Waxed",
                            Harness = "Wild Country Session",
                            SetupName = "aggressive set",
                            Shoes = "Black Diamond Momentum"
                        },
                        new
                        {
                            GearId = 5,
                            Chalk_Bag = "8BPLUS Lilly",
                            Harness = "Arc'teryx Konseal",
                            SetupName = "Medium setup",
                            Shoes = "Butora Gomi"
                        });
                });

            modelBuilder.Entity("ClimbingInfo.Models.Members", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExperienceId")
                        .HasColumnType("int");

                    b.Property<int>("GearId")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("cell")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnName("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("zip")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.HasIndex("ExperienceId");

                    b.HasIndex("GearId");

                    b.ToTable("Membership");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ExperienceId = 1,
                            GearId = 1,
                            address = "555 madeup Street",
                            cell = "231-360-5236",
                            city = "Traverse City",
                            email = "greengregsandham@gmail.com",
                            gender = "male",
                            name = "Greg",
                            state = "MI",
                            zip = "49684"
                        },
                        new
                        {
                            ID = 2,
                            ExperienceId = 2,
                            GearId = 2,
                            address = "555 madeup Street",
                            cell = "231-360-5236",
                            city = "Traverse City",
                            email = "Bobbytown@bob.com",
                            gender = "male",
                            name = "Bob",
                            state = "MI",
                            zip = "49684"
                        },
                        new
                        {
                            ID = 3,
                            ExperienceId = 1,
                            GearId = 3,
                            address = "555 madeup Street",
                            cell = "231-360-5236",
                            city = "Traverse City",
                            email = "dontditchmitch@gmail.com",
                            gender = "wizard",
                            name = "Mitch",
                            state = "MI",
                            zip = "49684"
                        },
                        new
                        {
                            ID = 4,
                            ExperienceId = 3,
                            GearId = 5,
                            address = "555 madeup Street",
                            cell = "231-360-5236",
                            city = "Traverse City",
                            email = "Utridisavalidname@gmail.com",
                            gender = "female",
                            name = "Utrid",
                            state = "MI",
                            zip = "49684"
                        },
                        new
                        {
                            ID = 5,
                            ExperienceId = 2,
                            GearId = 1,
                            address = "555 madeup Street",
                            cell = "231-360-5236",
                            city = "Traverse City",
                            email = "JamwithJamalle@gmail.com",
                            gender = "undisclosed",
                            name = "Jamalle",
                            state = "MI",
                            zip = "49684"
                        },
                        new
                        {
                            ID = 6,
                            ExperienceId = 1,
                            GearId = 1,
                            address = "555 madeup Street",
                            cell = "231-360-5236",
                            city = "Traverse City",
                            email = "greengregggggsandham@gmail.com",
                            gender = "male",
                            name = "Gregggggg",
                            state = "MI",
                            zip = "49684"
                        },
                        new
                        {
                            ID = 7,
                            ExperienceId = 1,
                            GearId = 1,
                            address = "555 madeup Street",
                            cell = "231-360-5236",
                            city = "Traverse City",
                            email = "Lucy2022@gmail.com",
                            gender = "female",
                            name = "Lucy",
                            state = "MI",
                            zip = "49684"
                        },
                        new
                        {
                            ID = 8,
                            ExperienceId = 4,
                            GearId = 3,
                            address = "555 madeup Street",
                            cell = "231-360-5236",
                            city = "Traverse City",
                            email = "Craigisloud@gmail.com",
                            gender = "male",
                            name = "Craig",
                            state = "MI",
                            zip = "49684"
                        });
                });

            modelBuilder.Entity("ClimbingInfo.Models.Members", b =>
                {
                    b.HasOne("ClimbingInfo.Models.Experience", "Experience")
                        .WithMany()
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClimbingInfo.Models.Gear", "Gear")
                        .WithMany()
                        .HasForeignKey("GearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
