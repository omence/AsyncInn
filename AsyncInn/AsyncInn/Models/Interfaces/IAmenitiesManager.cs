using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        Task CreateAmeneties(Amenities amenities);

        Task<IEnumerable<Amenities>> GetAmeneties();

        Task<Amenities> GetOneAmenety(int id);

        Task<Amenities> UpdateOne(int id);

        Task UpdateAmeneties(Amenities amenities);

        Task<Amenities> DeleteOne(int id);

        Task DeleteAmenities(int id);

        bool AmenitiesExist(int id);

        Task<IEnumerable<Amenities>> SearchAmenities(string SearchString);
    }
}
