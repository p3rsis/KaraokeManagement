using System;
using System.Data;

namespace DTO
{
    public class UsageSession
    {
        public UsageSession(DataRow row)
        {
            this.RoomName = row["roomname"].ToString();
            this.RoomStatus = (byte)row["roomstatus"];
            var thoigianTemp = row["starttime"];
            if (thoigianTemp.ToString() != "")
            {
                this.STime = (DateTime?)thoigianTemp;
            }
            var billidTemp = row["billingid"];
            if (billidTemp.ToString() != "")
            {
                this.BillId = (int)billidTemp;
            }
        }

        private int billId;
        private string roomName;
        private byte roomStatus;
        private DateTime? sTime;

        public string RoomName { get => roomName; set => roomName = value; }
        public int BillId { get => billId; set => billId = value; }
        public byte RoomStatus { get => roomStatus; set => roomStatus = value; }
        public DateTime? STime { get => sTime; set => sTime = value; }
    }
}
