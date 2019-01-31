using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelManager
    {
        //Creates new instance of hotel
        Task CreateHotel(Hotel hotel);

        //displays all hotels
        Task<IEnumerable<Hotel>> GetHotels();

        //Displays details of hotel
        Task<Hotel> GetOneHotel(int id);

        //displays update view
        Task<Hotel> UpdateOne(int id);

        //allows user to update properties
        Task Updatehotel(Hotel hotel);

        //displays delete view
        Task<Hotel> DeleteOne(int id);

        //deletes hotel and all children
        Task DeleteHotel(int ID);

        //checks if instance exists
        bool HotelExist(int id);

        //searches based on room count
        Task<IEnumerable<Hotel>> SearchHotels(string SearchString);

        //counts rooms
        int RoomsCount(int id);
    }
}
