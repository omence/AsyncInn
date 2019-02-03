using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Composite key associations
            modelBuilder.Entity<HotelRoom>().HasKey(ce => new { ce.HotelID, ce.RoomNumber });
            modelBuilder.Entity<RoomAmenities>().HasKey(ce => new { ce.AmenitiesID, ce.RoomID });

            //Seeds the DB with info
            modelBuilder.Entity<Hotel>().HasData(
            new Hotel
            {
                ID = 1,
                Name = "Seattle Async",
                Address = "Seattle",
                Phone = "2065555550"
            },
            new Hotel
            {
                ID = 2,
                Name = "Tacoma Async",
                Address = "Tacoma",
                Phone = "2065555550"
            },
            new Hotel
            {
                ID = 3,
                Name = "Kent Async",
                Address = "Kent",
                Phone = "2065555550"
            },
            new Hotel
            {
                ID = 4,
                Name = "Renton Async",
                Address = "Renton, wa",
                Phone = "2065555550"
            },
            new Hotel
            {
                ID = 5,
                Name = "Shoreline Async",
                Address = "Shoreline, wa",
                Phone = "2065555550"
            }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Small",
                    Layout = 0
                },
                 new Room
                 {
                     ID = 2,
                     Name = "Meduium",
                     Layout = 1
                 },
                  new Room
                  {
                      ID = 3,
                      Name = "Large",
                      Layout = 2
                  },
                   new Room
                   {
                       ID = 4,
                       Name = "Small Room",
                       Layout = 0
                   },
                    new Room
                    {
                        ID = 5,
                        Name = "Medium Room",
                        Layout = 1
                    },
                     new Room
                     {
                         ID = 6,
                         Name = "Large Room",
                         Layout = 2
                     }
                );

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Microwave"
                },
                 new Amenities
                 {
                     ID = 2,
                     Name = "Iron"
                 },
                  new Amenities
                  {
                      ID = 3,
                      Name = "Bar"
                  },
                   new Amenities
                   {
                       ID = 4,
                       Name = "Hair Dryer"
                   },
                    new Amenities
                    {
                        ID = 5,
                        Name = "Fridge"
                    }
                );


        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }

    }
}
