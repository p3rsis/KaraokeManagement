﻿using System.Data;

namespace DTO
{
    public class Computer
    {

        private byte comId;
        private string comName;
        private byte comStatus;
        public Computer(DataRow row)
        {
            this.ComId = (byte)row["computerid"];
            this.ComName = row["computername"].ToString(); ;
            this.ComStatus = (byte)row["computerstatus"]; ;

        }

        public byte ComId { get => comId; set => comId = value; }
        public string ComName { get => comName; set => comName = value; }
        public byte ComStatus { get => comStatus; set => comStatus = value; }
    }
}
