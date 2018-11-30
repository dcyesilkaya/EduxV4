using EduxV4.Data;
using EduxV4.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> roomRepository;
        public RoomService(IRepository<Room> roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public void DeleteRoom(string id)
        {
            Room room = GetRoom(id);
            roomRepository.Remove(room);
            roomRepository.SaveChanges();
        }

        public Room GetRoom(string id)
        {
            return roomRepository.Get(id);
        }

        public IEnumerable<Room> GetRooms()
        {
            return roomRepository.GetAll();
        }

        public void InsertRoom(Room room)
        {
            roomRepository.Insert(room);
        }

        public void UpdateRoom(Room room)
        {
            roomRepository.Update(room);
        }
    }

    public interface IRoomService
    {
        IEnumerable<Room> GetRooms();
        Room GetRoom(string id);
        void InsertRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(string id);

    }
}
