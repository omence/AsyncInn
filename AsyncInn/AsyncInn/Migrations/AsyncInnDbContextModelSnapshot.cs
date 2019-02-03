﻿// <auto-generated />
using System;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    partial class AsyncInnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInn.Models.Amenities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Microwave"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Iron"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Bar"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Hair Dryer"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Fridge"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int>("RoomCount");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "Seattle",
                            Name = "Seattle Async",
                            Phone = "2065555550",
                            RoomCount = 0
                        },
                        new
                        {
                            ID = 2,
                            Address = "Tacoma",
                            Name = "Tacoma Async",
                            Phone = "2065555550",
                            RoomCount = 0
                        },
                        new
                        {
                            ID = 3,
                            Address = "Kent",
                            Name = "Kent Async",
                            Phone = "2065555550",
                            RoomCount = 0
                        },
                        new
                        {
                            ID = 4,
                            Address = "Renton, wa",
                            Name = "Renton Async",
                            Phone = "2065555550",
                            RoomCount = 0
                        },
                        new
                        {
                            ID = 5,
                            Address = "Shoreline, wa",
                            Name = "Shoreline Async",
                            Phone = "2065555550",
                            RoomCount = 0
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelID");

                    b.Property<int>("RoomNumber");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("Rate");

                    b.Property<decimal>("RoomID");

                    b.Property<int?>("RoomID1");

                    b.HasKey("HotelID", "RoomNumber");

                    b.HasIndex("RoomID1");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("amenitiesCount");

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Layout = 0,
                            Name = "Small",
                            amenitiesCount = 0
                        },
                        new
                        {
                            ID = 2,
                            Layout = 1,
                            Name = "Meduium",
                            amenitiesCount = 0
                        },
                        new
                        {
                            ID = 3,
                            Layout = 2,
                            Name = "Large",
                            amenitiesCount = 0
                        },
                        new
                        {
                            ID = 4,
                            Layout = 0,
                            Name = "Small Room",
                            amenitiesCount = 0
                        },
                        new
                        {
                            ID = 5,
                            Layout = 1,
                            Name = "Medium Room",
                            amenitiesCount = 0
                        },
                        new
                        {
                            ID = 6,
                            Layout = 2,
                            Name = "Large Room",
                            amenitiesCount = 0
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("AmenitiesID");

                    b.Property<int>("RoomID");

                    b.HasKey("AmenitiesID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.HasOne("AsyncInn.Models.Hotel", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("HotelRoom")
                        .HasForeignKey("RoomID1");
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.HasOne("AsyncInn.Models.Amenities", "Amenities")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenitiesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
