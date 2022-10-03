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
    [Migration("20221003232958_SecondCreate")]
    partial class SecondCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClimbingInfo.Models.Experience", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MembersID")
                        .HasColumnType("int");

                    b.Property<string>("freq")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("years")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MembersID");

                    b.ToTable("Experience");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            MembersID = 1,
                            freq = "2-3 days a week!",
                            years = 1
                        });
                });

            modelBuilder.Entity("ClimbingInfo.Models.Members", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("cell")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("zip")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.ToTable("Membership");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            address = "555 madeup Street",
                            cell = "231-360-5236",
                            city = "Traverse City",
                            email = "greengregsandham@gmail.com",
                            gender = "male",
                            name = "Greg",
                            state = "MI",
                            zip = "49684"
                        });
                });

            modelBuilder.Entity("ClimbingInfo.Models.Experience", b =>
                {
                    b.HasOne("ClimbingInfo.Models.Members", "Members")
                        .WithMany()
                        .HasForeignKey("MembersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}