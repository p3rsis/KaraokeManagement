using System.Data;

namespace DTO
{
    public class Room
    {

        private byte roomId;
        private string roomName;
        private byte roomStatus;
        public Room(DataRow row)
        {
            this.RoomId = (byte)row["roomid"];
            this.RoomName = row["roomname"].ToString(); ;
            this.RoomStatus = (byte)row["roomstatus"]; ;

        }

        public byte RoomId { get => roomId; set => roomId = value; }
        public string RoomName { get => roomName; set => roomName = value; }
        public byte RoomStatus { get => roomStatus; set => roomStatus = value; }
    }
}
