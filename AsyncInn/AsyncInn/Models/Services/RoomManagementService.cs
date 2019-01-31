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
        private AsyncInnDbContext _context { get; }

        public RoomManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetOneRoom(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.ID == id);
        }

        public async Task<Room> UpdateOne(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<Room> DeleteOne(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public bool RoomExist(int id)
        {
            return _context.Rooms.Any(e => e.ID == id);
        }

        public async Task<IEnumerable<Room>> SearchRooms(string SearchString)
        {
            return await _context.Rooms.Where(c => c.Name.ToLower() == SearchString.ToLower()).ToListAsync();

        }
    }

}
