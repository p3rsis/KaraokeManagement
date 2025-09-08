using DTO;
using System.Data;

namespace DAL
{
    public class UsageSessionDAL
    {
        private static UsageSessionDAL instance;

        public static UsageSessionDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UsageSessionDAL();
                }
                return UsageSessionDAL.instance;
            }
            private set { UsageSessionDAL.instance = value; }
        }

        private UsageSessionDAL() { }

        public UsageSession GetUsageSessionDetails(byte roomid)
        {
            DataTable dt = Database.Instance.ExecuteQuery("GetUsageSessionDetails @roomid", new object[] { roomid });
            DataRow row = dt.Rows[0];
            return new UsageSession(row);

        }
        public int GetUnCheckOutSession(byte roomid)
        {
            DataTable dt = Database.Instance.ExecuteQuery("GetUnCheckOutSession @roomid", new object[] { roomid });
            if (dt.Rows.Count > 0)
            {
                UsageSession us = new UsageSession(dt.Rows[0]);
                return us.BillId;
            }
            return -1;
        }
        public void StartSession(byte roomId)
        {
            Database.Instance.ExecuteNonQuery("ProcBillingINIT @Billingtype", new object[] { 1 });
            Database.Instance.ExecuteNonQuery("ProcUsageSessionINIT @RoomID", new object[] { roomId });

        }
        public void EndSesion(int billid)
        {
            string query = string.Format("ProcEndSession @billingid ");
            Database.Instance.ExecuteNonQuery(query, new object[] { billid });
        }
    }
}
