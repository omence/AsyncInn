using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelManager
    {
        Task CreateHotel(Hotel hotel);

        Task<IEnumerable<Hotel>> GetHotels();

        Task<Hotel> GetOneHotel(int id);

        Task<Hotel> UpdateOne(int id);

        Task Updatehotel(Hotel hotel);

        Task<Hotel> DeleteOne(int id);

        Task DeleteHotel(int ID);

        bool HotelExist(int id);

        Task<IEnumerable<Hotel>> SearchHotels(string SearchString);
    }
}
