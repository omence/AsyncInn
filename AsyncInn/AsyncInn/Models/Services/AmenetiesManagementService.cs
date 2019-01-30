using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models.Interfaces;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class AmenetiesManagementService : IAmenitiesManager
    {
        private AsyncInnDbContext _context { get; }

        public AmenetiesManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmeneties(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Amenities>> GetAmeneties()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetOneAmenety(int id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(h => h.ID == id);
        }

        public async Task UpdateAmeneties(Amenities amenities)
        {
            _context.Amenities.Update(amenities);
            await _context.SaveChangesAsync();
        }

        public async Task<Amenities> UpdateOne(int id)
        {
            return await _context.Amenities.FindAsync(id);
        }

        public async Task<Amenities> DeleteOne(int id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task DeleteAmenities(int id)
        {
            var amenities = await _context.Amenities.FindAsync(id);
            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();
        }

        public bool AmenitiesExist(int id)
        {
            return _context.Amenities.Any(e => e.ID == id);
        }
    }


}
