using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class RoomDAL
    {
        private static RoomDAL instance;

        public static RoomDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoomDAL();
                }
                return RoomDAL.instance;
            }
            private set { RoomDAL.instance = value; }
        }

        public static int RoomWidth = 83;
        public static int RoomHeight = 83;

        private RoomDAL() { }

        public List<Room> LoadFullRoom()
        {
            List<Room> room = new List<Room>();
            DataTable dt = Database.Instance.ExecuteQuery("select roomid, roomname, roomstatus from room");
            foreach (DataRow dr in dt.Rows)
            {
                Room ban = new Room(dr);
                room.Add(ban);
            }
            return room;
        }

        public DataTable GetRooms(byte zoneid)
        {
            return Database.Instance.ExecuteQuery($"Select roomid, roomname from Room where zoneid = {zoneid}");
        }
    }
}
