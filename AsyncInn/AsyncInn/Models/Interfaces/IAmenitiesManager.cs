using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        //Create instance of amenities
        Task CreateAmeneties(Amenities amenities);

        //gets all ameities
        Task<IEnumerable<Amenities>> GetAmeneties();

        //Gets details of amenitites
        Task<Amenities> GetOneAmenety(int id);

        //displays update view
        Task<Amenities> UpdateOne(int id);

        //allows properties to be updated
        Task UpdateAmeneties(Amenities amenities);

        //Displays delete view
        Task<Amenities> DeleteOne(int id);

        //Deletes selected 
        Task DeleteAmenities(int id);

        //checks if instance exists
        bool AmenitiesExist(int id);

        //Searches based on name
        Task<IEnumerable<Amenities>> SearchAmenities(string SearchString);
    }
}
