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

        public async Task<Hotel> DeleteOne(int id)
        {
          return await _context.Hotels.FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetOneHotel(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(h => h.ID == id);
        }

        public async Task<Hotel> UpdateOne(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public async Task Updatehotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public bool HotelExist(int id)
        {
            return _context.Hotels.Any(e => e.ID == id);
        }

        public async Task<IEnumerable<Hotel>> SearchHotels(string SearchString)
        {
            return await _context.Hotels.Where(c => c.Address.ToLower() == SearchString.ToLower()).ToListAsync();
            
        }
    }

}
