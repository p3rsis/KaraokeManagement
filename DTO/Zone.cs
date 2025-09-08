using System.Data;

namespace DTO
{
    public class Zone
    {
        public Zone(DataRow row)
        {
            this.RoomId = (byte)row["roomid"];
            this.RoomName = row["roomname"].ToString(); ;
            this.ZoneName = row["zonename"].ToString(); ;
            this.RoomStatus = (byte)row["roomstatus"]; ;
            this.PricePh = (decimal)row["priceperhour"]; ;
            this.CpuModel = row["cpumodel"].ToString(); ;
            this.Gpumodel = row["gpumodel"].ToString(); ;
            this.HddModel = row["hddmodel"].ToString(); ;
            this.SsdModel = row["ssdmodel"].ToString(); ;
            this.MouseModel = row["mousemodel"].ToString(); ;
            this.KeyboardModel = row["keyboardmodel"].ToString(); ;
            this.MonitorModel = row["monitormodel"].ToString(); ;
        }

        private byte roomId;
        private string roomName;
        private string zoneName;
        private byte roomStatus;
        private decimal pricePh;
        private string cpuModel;
        private string gpumodel;
        private string hddModel;
        private string ssdModel;
        private string mouseModel;
        private string keyboardModel;
        private string monitorModel;


        public string RoomName { get => roomName; set => roomName = value; }
        public byte RoomId { get => roomId; set => roomId = value; }
        public byte RoomStatus { get => roomStatus; set => roomStatus = value; }
        public decimal PricePh { get => pricePh; set => pricePh = value; }
        public string ZoneName { get => zoneName; set => zoneName = value; }
        public string CpuModel { get => cpuModel; set => cpuModel = value; }
        public string HddModel { get => hddModel; set => hddModel = value; }
        public string SsdModel { get => ssdModel; set => ssdModel = value; }
        public string MouseModel { get => mouseModel; set => mouseModel = value; }
        public string KeyboardModel { get => keyboardModel; set => keyboardModel = value; }
        public string MonitorModel { get => monitorModel; set => monitorModel = value; }
        public string Gpumodel { get => gpumodel; set => gpumodel = value; }
    }
    public static class RoomZone
    {
        public static byte zoneId { get; set; }
    }
}
