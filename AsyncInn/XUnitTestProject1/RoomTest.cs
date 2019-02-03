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
    public class RoomTest
    {
        //GET
        [Fact]
        public void RoomProperties()
        {
            //Arrange
            Room room = new Room();
            room.Name = "quiller";
            room.Layout = 1;

            //
            Assert.Equal("quiller", room.Name);
        }

        [Fact]
        public void RoomPropertiesWorks()
        {
            //Arrange
            Room room = new Room();
            room.Name = "quiller";
            room.Layout = 1;

            //
            Assert.Equal(1, room.Layout);
        }

        //SET
        [Fact]
        public void SetRoomProperties()
        {
            //Arrange
            Room room = new Room();
            room.Name = "quiller";
            room.Name = "quillers";

            //
            Assert.Equal("quillers", room.Name);
        }

        [Fact]
        public async void CreateRoomWorks()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("CreateRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // arrange
                Room room = new Room();
                room.ID = 1;
                room.Name = "quiller";
                room.Layout = 1;

                // Act
                RoomManagementService service = new RoomManagementService(context);

                await service.CreateRoom(room);
                var created = context.Rooms.FirstOrDefault(r => r.ID == room.ID);

                // Assert
                Assert.Equal(room, created);

            }
        }

        [Fact]
        public async void CreateRoomWorksAgain()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("CreateRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // arrange
                Room room = new Room();
                room.ID = 2;
                room.Name = "quillers";
                room.Layout = 1;

                // Act
                RoomManagementService service = new RoomManagementService(context);

                await service.CreateRoom(room);
                var created = context.Rooms.FirstOrDefault(r => r.ID == room.ID);

                // Assert
                Assert.Equal(room, created);

            }
        }
        [Fact]
        public async void DeleteRoomWorks()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("DeleteRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // arrange
                Room room = new Room();
                room.ID = 1;
                room.Name = "quiller";
                room.Layout = 1;

                // Act
                RoomManagementService service = new RoomManagementService(context);

                await service.CreateRoom(room);

                await service.DeleteRoom(1);
                var deleted = context.Rooms.FirstOrDefault(r => r.ID == room.ID);

                // Assert
                Assert.Null(deleted);

            }
        }

        [Fact]
        public async void DeleteRoomWorksAgain()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("DeleteRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // arrange
                Room room = new Room();
                room.ID = 2;
                room.Name = "quillers";
                room.Layout = 1;

                // Act
                RoomManagementService service = new RoomManagementService(context);

                await service.CreateRoom(room);

                await service.DeleteRoom(2);
                var deleted = context.Rooms.FirstOrDefault(r => r.ID == room.ID);

                // Assert
                Assert.Null(deleted);

            }
        }


        [Fact]
        public async void UpdateRoomWorks()
        {
            DbContextOptions<AsyncInnDbContext> options =
                new DbContextOptionsBuilder<AsyncInnDbContext>
                ().UseInMemoryDatabase("UpdateRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // arrange
                Room room = new Room();
                room.ID = 1;
                room.Name = "quiller";
                room.Layout = 1;

                // Act
                RoomManagementService service = new RoomManagementService(context);

                await service.CreateRoom(room);
                room.Name = "quillers";

                // Assert
                Assert.Equal("quillers", room.Name);

            }
        }
    }
}
