using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class HotelManagementService : IHotelManager
    {
        private AsyncInnDbContext _context { get; }

        public HotelManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Confirms that you really want to delete items
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Hotel> DeleteOne(int id)
        {
          return await _context.Hotels.FirstOrDefaultAsync(m => m.ID == id);
        }

        /// <summary>
        /// Deletes the hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);

            _context.Hotels.Remove(hotel);

            var children = _context.HotelRooms.Where(f => f.HotelID == id);

            foreach(var i in children)
            {
                _context.HotelRooms.Remove(i);
            }

            await _context.SaveChangesAsync();
           
        }

        /// <summary>
        /// Gets all hotels
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            var count = await _context.Hotels.ToListAsync();
            foreach (var i in count)
            {
                i.RoomCount = _context.HotelRooms.Where(r => r.HotelID == i.ID).Count();
            }

            return count;
        }

        /// <summary>
        /// Shows detail of one hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Hotel> GetOneHotel(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(h => h.ID == id);
        }

        /// <summary>
        /// Lets user updat hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Hotel> UpdateOne(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        /// <summary>
        /// Second update method
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public async Task Updatehotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Creat a new instance of hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks to see in hotel exists in DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool HotelExist(int id)
        {
            return _context.Hotels.Any(e => e.ID == id);
        }

        /// <summary>
        /// Filters hotels based on city
        /// </summary>
        /// <param name="SearchString"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Hotel>> SearchHotels(string SearchString)
        {
            return await _context.Hotels.Where(c => c.Address.ToLower() == SearchString.ToLower()).ToListAsync();
            
        }

        /// <summary>
        /// Counts the number of Hotel Rooms
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RoomsCount(int id)
        {
            int rooms = _context.HotelRooms.Where(r => r.HotelID == id).Count();
            return rooms;
        }
    }

}
