using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomManager
    {
        //Creates new instance of room
        Task CreateRoom(Room room);

        //displays all rooms
        Task<IEnumerable<Room>> GetRooms();

        //displays details page
        Task<Room> GetOneRoom(int id);

        //displays update view
        Task<Room> UpdateOne(int id);

        //updates room
        Task UpdateRoom(Room room);

        //displays delete view
        Task<Room> DeleteOne(int id);

        //Deletes room
        Task DeleteRoom(int id);

        //does instance exist
        bool RoomExist(int id);

        //searches by name
        Task<IEnumerable<Room>> SearchRooms(string SearchString);
    }
}
