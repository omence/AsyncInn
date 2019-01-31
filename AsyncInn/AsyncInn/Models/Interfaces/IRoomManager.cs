using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomManager
    {
        Task CreateRoom(Room room);

        Task<IEnumerable<Room>> GetRooms();

        Task<Room> GetOneRoom(int id);

        Task<Room> UpdateOne(int id);

        Task UpdateRoom(Room room);

        Task<Room> DeleteOne(int id);

        Task DeleteRoom(int id);

        bool RoomExist(int id);

        Task<IEnumerable<Room>> SearchRooms(string SearchString);
    }
}
