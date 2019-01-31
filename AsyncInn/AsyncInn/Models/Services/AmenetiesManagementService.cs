using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Models.Interfaces;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    /// <summary>
    /// connects to DB
    /// </summary>
    public class AmenetiesManagementService : IAmenitiesManager
    {
        private AsyncInnDbContext _context { get; }

        public AmenetiesManagementService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new instance of amenities
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns></returns>
        public async Task CreateAmeneties(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all amenities and sends to view
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Amenities>> GetAmeneties()
        {
            return await _context.Amenities.ToListAsync();
        }

        /// <summary>
        /// Shoes details of amenities
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Amenities> GetOneAmenety(int id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(h => h.ID == id);
        }

        /// <summary>
        /// Updates the details of amenities
        /// </summary>
        /// <param name="amenities"></param>
        /// <returns></returns>
        public async Task UpdateAmeneties(Amenities amenities)
        {
            _context.Amenities.Update(amenities);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Displays update view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Amenities> UpdateOne(int id)
        {
            return await _context.Amenities.FindAsync(id);
        }

        /// <summary>
        /// displays delete view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Amenities> DeleteOne(int id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(m => m.ID == id);
        }

        /// <summary>
        /// Deletes amenities instance and all it children
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAmenities(int id)
        {
            var amenities = await _context.Amenities.FindAsync(id);
            _context.Amenities.Remove(amenities);
            var children = _context.RoomAmenities.Where(f => f.AmenitiesID == id);
            foreach (var i in children)
            {
                _context.RoomAmenities.Remove(i);
            }
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Checks to see if amenities exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool AmenitiesExist(int id)
        {
            return _context.Amenities.Any(e => e.ID == id);
        }


        /// <summary>
        /// Filters based on name
        /// </summary>
        /// <param name="SearchString"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Amenities>> SearchAmenities(string SearchString)
        {
            return await _context.Amenities.Where(c => c.Name.ToLower() == SearchString.ToLower()).ToListAsync();
        }
    }


}
