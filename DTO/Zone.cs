using System.Data;

namespace DTO
{
    public class Zone
    {
        public Zone(DataRow row)
        {
            this.ComId = (byte)row["computerid"];
            this.ComName = row["computername"].ToString(); ;
            this.ZoneName = row["zonename"].ToString(); ;
            this.ComStatus = (byte)row["computerstatus"]; ;
            this.PricePh = (decimal)row["priceperhour"]; ;
            
        }

        private byte comId;
        private string comName;
        private string zoneName;
        private byte comStatus;
        private decimal pricePh;
        


        public string ComName { get => comName; set => comName = value; }
        public byte ComId { get => comId; set => comId = value; }
        public byte ComStatus { get => comStatus; set => comStatus = value; }
        public decimal PricePh { get => pricePh; set => pricePh = value; }
        public string ZoneName { get => zoneName; set => zoneName = value; }
        
    }
    public static class ComputerZone
    {
        public static byte zoneId { get; set; }
    }
}
