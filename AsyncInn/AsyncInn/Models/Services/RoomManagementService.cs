using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models.Interfaces;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class RoomManagementService : IRoomManager
    {
        /// <summary>
        /// connects to DB
        /// </summary>
        private AsyncInnDbContext _context { get; }

        public RoomManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates new instance of Rooms
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public async Task CreateRoom(Room room)
        {

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all the rooms and send to view
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Room>> GetRooms()
        {
            var count = await _context.Rooms.ToListAsync();
            foreach (var i in count)
            {
                i.amenitiesCount = _context.RoomAmenities.Where(r => r.RoomID == i.ID).Count();
            }

            return count;
        }

        /// <summary>
        /// update view
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
         /// <summary>
         /// Updat a rooms properties
         /// </summary>
         /// <param name="id"></param>
         /// <returns></returns>
        public async Task<Room> GetOneRoom(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.ID == id);
        }


        /// <summary>
        /// Sets up udate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Room> UpdateOne(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<Room> DeleteOne(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(m => m.ID == id);
        }


        /// <summary>
        /// Deletes a room and all children
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            var children = _context.HotelRooms.Where(f => f.RoomID == id);
            foreach (var i in children)
            {
                _context.HotelRooms.Remove(i);
            }

            var children2 = _context.RoomAmenities.Where(f => f.RoomID == id);
            foreach (var j in children2)
            {
                _context.RoomAmenities.Remove(j);
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if room exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RoomExist(int id)
        {
            return _context.Rooms.Any(e => e.ID == id);
        }

        /// <summary>
        /// Filters rooms by name
        /// </summary>
        /// <param name="SearchString"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Room>> SearchRooms(string SearchString)
        {
            return await _context.Rooms.Where(c => c.Name.ToLower() == SearchString.ToLower()).ToListAsync();

        }
    }

}
