using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class ZoneDAL
    {
        private static ZoneDAL instance;

        public static ZoneDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ZoneDAL();
                }
                return ZoneDAL.instance;
            }
            private set { ZoneDAL.instance = value; }
        }

        private ZoneDAL() { }

        public static int RoomWidth = 150;
        public static int RoomHeight = 100;


        public List<Zone> loadRoom(byte zoneid)
        {
            List<Zone> lc = new List<Zone>();
            string query = "GetRoomDetailsByZone @zoneid";
            DataTable dt = Database.Instance.ExecuteQuery(query, new object[] { zoneid });
            foreach (DataRow dr in dt.Rows)
            {
                Zone room = new Zone(dr);
                lc.Add(room);
            }
            return lc;
        }

        public DataTable getZones()
        {
            return Database.Instance.ExecuteQuery("Select ZoneID, ZoneName from Zone");
        }

    }
}
