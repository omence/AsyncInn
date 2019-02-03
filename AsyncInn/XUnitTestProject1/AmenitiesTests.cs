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
    public class AmenitiesTests
    {
        //GET
        [Fact]
        public void AmenitiesProperties()
        {
            //Arrange
            Amenities amenities = new Amenities();
            amenities.Name = "Iron";
            amenities.ID = 1;

            //
            Assert.Equal("Iron", amenities.Name);
        }

        [Fact]
        public void AmenitiesPropertiesWork()
        {
            //Arrange
            Amenities amenities = new Amenities();
            amenities.Name = "Iron";
            amenities.ID = 1;

            //
            Assert.Equal(1, amenities.ID);
        }

        //SET
        [Fact]
        public void SetAmenitiesPropertiesWork()
        {
            //Arrange
            Amenities amenities = new Amenities();
            amenities.Name = "Iron";
            amenities.Name = "Bar";

            //
            Assert.Equal("Bar", amenities.Name);
        }

        [Fact]
        public async void CreateAmenitiesWorks()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("CreateAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // arrange
                Amenities amenities = new Amenities();
                amenities.Name = "Iron";
                amenities.ID = 1;

                // Act
                AmenetiesManagementService service = new AmenetiesManagementService(context);

                await service.CreateAmeneties(amenities);
                var created = context.Amenities.FirstOrDefault(a => a.ID == amenities.ID);

                // Assert
                Assert.Equal(amenities, created);

            }
        }

        [Fact]
        public async void CreateAmenitiesWorksAgain()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("CreateAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // arrange
                Amenities amenities = new Amenities();
                amenities.Name = "Bar";
                amenities.ID = 2;

                // Act
                AmenetiesManagementService service = new AmenetiesManagementService(context);

                await service.CreateAmeneties(amenities);
                var created = context.Amenities.FirstOrDefault(a => a.ID == amenities.ID);

                // Assert
                Assert.Equal(amenities, created);

            }
        }

        [Fact]
        public async void DeleteAmenitiesWorks()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("DeleteAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // arrange
                Amenities amenities = new Amenities();
                amenities.Name = "Iron";
                amenities.ID = 1;

                // Act
                AmenetiesManagementService service = new AmenetiesManagementService(context);

                await service.CreateAmeneties(amenities);

                await service.DeleteAmenities(1);
                var deleted = context.Amenities.FirstOrDefault(r => r.ID == amenities.ID);

                // Assert
                Assert.Null(deleted);

            }
        }

        [Fact]
        public async void DeleteAmenitiesWorksAgain()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("DeleteAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // arrange
                Amenities amenities = new Amenities();
                amenities.Name = "Bar";
                amenities.ID = 2;

                // Act
                AmenetiesManagementService service = new AmenetiesManagementService(context);

                await service.CreateAmeneties(amenities);

                await service.DeleteAmenities(2);
                var deleted = context.Amenities.FirstOrDefault(r => r.ID == amenities.ID);

                // Assert
                Assert.Null(deleted);

            }
        }


        [Fact]
        public async void UpdateAmenitiesWorks()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("UpdateAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // arrange
                Amenities amenities = new Amenities();
                amenities.Name = "Iron";
                amenities.ID = 1;

                // Act
                AmenetiesManagementService service = new AmenetiesManagementService(context);

                await service.CreateAmeneties(amenities);
                amenities.Name = "Bar";
                await service.UpdateAmeneties(amenities);
                // Assert
                Assert.Equal("Bar", amenities.Name);

            }
        }
    }
}
