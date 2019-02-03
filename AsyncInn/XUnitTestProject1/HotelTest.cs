using System;
using Xunit;
using AsyncInn.Controllers;
using AsyncInn.Models;
using AsyncInn.Data;
using AsyncInn.Models.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestProject1
{
    public class HotelTest
    {
        //GET
        [Fact]
        public void HotelProperties()
        {
            //Arrange
            Hotel hotel = new Hotel();
            hotel.Name = "quiller";
            hotel.Address = "Seattle";
            hotel.Phone = "206-555-5551";

            //
            Assert.Equal("quiller", hotel.Name);
        }

        [Fact]
        public void HotelPropertiesWorks()
        {
            //Arrange
            Hotel hotel = new Hotel();
            hotel.Name = "quiller";
            hotel.Address = "Seattle";
            hotel.Phone = "206-555-5551";

            //
            Assert.Equal("Seattle", hotel.Address);
        }

        [Fact]
        public void HotelPropertiesWorksAgain()
        {
            //Arrange
            Hotel hotel = new Hotel();
            hotel.Name = "quiller";
            hotel.Address = "Seattle";
            hotel.Phone = "206-555-5551";

            //
            Assert.Equal("206-555-5551", hotel.Phone);
        }

        //SET
        [Fact]
        public void SetHotelPropertiesWorksAgain()
        {
            //Arrange
            Hotel hotel = new Hotel();
            hotel.Name = "quiller";
            hotel.Name = "quillers";

            //
            Assert.Equal("quillers", hotel.Name);
        }

        [Fact]
        public async void CreateHotelWorks()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "quiller";
                hotel.Address = "Seattle";
                hotel.Phone = "206-555-5551";

                // Act
                HotelManagementService service = new HotelManagementService(context);

                await service.CreateHotel(hotel);
                var created = context.Hotels.FirstOrDefault(h => h.ID == hotel.ID);

                // Assert
                Assert.Equal(hotel, created);

            }
        }

        [Fact]
        public async void CreateHotelWorksAgain()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // arrange
                Hotel hotel = new Hotel();
                hotel.ID = 2;
                hotel.Name = "quillers";
                hotel.Address = "Seattle";
                hotel.Phone = "206-555-5551";

                // Act
                HotelManagementService service = new HotelManagementService(context);

                await service.CreateHotel(hotel);
                var created = context.Hotels.FirstOrDefault(h => h.ID == hotel.ID);

                // Assert
                Assert.Equal(hotel, created);

            }
        }

        [Fact]
        public async void DeleteHotelWorks()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("DeleteHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "quiller";
                hotel.Address = "Seattle";
                hotel.Phone = "206-555-5551";

                Hotel hotel2 = new Hotel();
                hotel2.ID = 2;
                hotel2.Name = "quillers";
                hotel2.Address = "Seattle";
                hotel2.Phone = "206-555-5552";

                // Act
                HotelManagementService service = new HotelManagementService(context);

                await service.CreateHotel(hotel2);

                await service.DeleteHotel(2);
                var deleted = context.Hotels.FirstOrDefault(r => r.ID == hotel2.ID);
               
                // Assert
                Assert.Null(deleted);

            }
        }

        [Fact]
        public async void DeleteHotelWorksAgain()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("DeleteHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {

                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "quillers";
                hotel.Address = "Seattle";
                hotel.Phone = "206-555-5552";

                // Act
                HotelManagementService service = new HotelManagementService(context);

                await service.CreateHotel(hotel);

                await service.DeleteHotel(1);
                var deleted = context.Hotels.FirstOrDefault(r => r.ID == hotel.ID);

                // Assert
                Assert.Null(deleted);

            }
        }

        [Fact]
        public async void UpdateHotelWorks()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("UpdateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "quiller";
                hotel.Address = "Seattle";
                hotel.Phone = "206-555-5551";

                // Act
                HotelManagementService service = new HotelManagementService(context);

                await service.CreateHotel(hotel);
                hotel.Address = "Tacoma";
                await service.Updatehotel(hotel);
                // Assert
                Assert.Equal("Tacoma", hotel.Address);

            }
        }
    }
    
}
