﻿using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace QLquannet
{
    public partial class frmRoom : Form
    {
        byte cid;
        int bid;
        public frmRoom()
        {
            InitializeComponent();
            txtNhanvien.Text = Employee.fullName;
            LoadZone(1);
            ChangeColorZoneBtn(btnZone1, null);
        }

        #region Events
        private void btnZone1_Click(object sender, EventArgs e)
        {
            LoadZone(1);
            ChangeColorZoneBtn(btnZone1, null);
        }

        private void btnZone2_Click(object sender, EventArgs e)
        {
            LoadZone(2);
            ChangeColorZoneBtn(btnZone2, null);
        }

        private void btnZone3_Click(object sender, EventArgs e)
        {
            LoadZone(3);
            ChangeColorZoneBtn(btnZone3, null);
        }

        private void btnZone4_Click(object sender, EventArgs e)
        {
            LoadZone(4);
            ChangeColorZoneBtn(btnZone4, null);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            cid = ((sender as Button).Tag as Zone).RoomId;

            ChangeColorComBtn((sender as Button), null);
            LoadUsageSession(cid);
            LoadFoodDetail(cid);

        }
        private void btnBatmay_Click(object sender, EventArgs e)
        {
            if (txtTT.Text == "Online")
            {
                MessageBox.Show("Máy đang online!");
            }
            else if (txtTT.Text == "Error")
            {
                MessageBox.Show("Máy đang bảo trì!");
            }
            else if (gbMay.Text == "")
            {
                MessageBox.Show("Chưa chọn máy!");
            }
            else
            {
                UsageSessionDAL.Instance.StartSession(cid);
                LoadUsageSession(cid);
                LoadZone(RoomZone.zoneId);
            }
        }
        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            int billid = UsageSessionDAL.Instance.GetUnCheckOutSession(cid);
            if (txtTT.Text == "Offline" || txtTT.Text == "Error")
            {
                MessageBox.Show(gbMay.Text + " đang offline!");
            }
            else if (gbMay.Text == "")
            {
                MessageBox.Show("Chưa chọn máy!");
            }
            else
            {
                if (billid != -1)
                {
                    UsageSessionDAL.Instance.EndSesion(billid);
                    BillingDAL.Instance.CheckOut(billid, Employee.emId);
                    LoadZone(RoomZone.zoneId);
                    MessageBox.Show("Thanh toán thành công cho " + gbMay.Text);
                    LoadUsageSession(cid);
                    LoadFoodDetail(cid);

                }

            }
        }
        #endregion

        #region Methods
        void LoadZone(byte zoneid)
        {
            flpCom.Controls.Clear();
            RoomZone.zoneId = zoneid;
            List<Zone> listCom = ZoneDAL.Instance.loadRoom(zoneid);
            int online = 0;
            int offline = 0;
            int error = 0;
            foreach (Zone com in listCom)
            {
                Button btn = new Button()
                {
                    Width = ZoneDAL.RoomWidth,
                    Height = ZoneDAL.RoomHeight,
                };

                btn.Click += btn_Click;

                btn.FlatStyle = FlatStyle.Flat;

                btn.Tag = com;

                switch (com.RoomStatus)
                {
                    case 0:
                        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 200, 100);
                        btn.BackColor = Color.LightGray;
                        btn.Text = com.RoomName + Environment.NewLine + "Offline";
                        offline++;
                        break;

                    case 1:
                        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 228, 178);
                        btn.BackColor = Color.Aqua;
                        btn.Text = com.RoomName + Environment.NewLine + "Online";
                        online++;
                        break;
                    default:
                        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(228, 135, 50);
                        btn.BackColor = Color.OrangeRed;
                        btn.Text = com.RoomName + Environment.NewLine + "Error";
                        error++;
                        break;
                }
                flpCom.Controls.Add(btn);

                gbZone.Text = com.ZoneName;
                txtPrice.Text = com.PricePh.ToString();
                txtAvailable.Text = offline.ToString();
                txtUsing.Text = online.ToString();
                txtError.Text = error.ToString();
                txtCPU.Text = com.CpuModel;
                txtGPU.Text = com.Gpumodel;
                txtHDD.Text = com.HddModel;
                txtSSD.Text = com.SsdModel;
                txtMouse.Text = com.MouseModel;
                txtKey.Text = com.KeyboardModel;
                txtMonitor.Text = com.MonitorModel;

            }
        }
        void LoadUsageSession(byte comid)
        {
            UsageSession us = UsageSessionDAL.Instance.GetUsageSessionDetails(comid);

            gbMay.Text = us.RoomName;
            if (us.STime.HasValue)
            {
                tpStime.Value = us.STime.Value;
            }
            else
            {
                tpStime.Value = DateTime.Now;
            }
            TimeSpan duration = DateTime.Now - tpStime.Value;
            string formatDuration = string.Format("{0:D2}:{1:D2}", (int)duration.TotalHours, duration.Minutes);
            txtTime.Text = formatDuration;

            int hours = int.Parse(formatDuration.Split(':')[0]);
            int minutes = int.Parse(formatDuration.Split(':')[1]);
            decimal tamTinh = (hours + (minutes / 60.0m)) * decimal.Parse(txtPrice.Text);
            txtTamtinh.Text = Math.Round(tamTinh, 2).ToString();

            if (us.RoomStatus == 0)
            {
                txtTT.Text = "Offline";
            }
            else if (us.RoomStatus == 1)
            {
                txtTT.Text = "Online";
            }
            else
            {
                txtTT.Text = "Error";
            }
            bid = us.BillId;
        }
        void LoadFoodDetail(byte comid)
        {
            lvFood.Items.Clear();
            List<Food> fl = FoodDAL.Instance.GetFoodDetail(comid);
            decimal fcost = 0m;
            foreach (Food f in fl)
            {
                ListViewItem lvi = new ListViewItem(f.FoodName.ToString());
                lvi.SubItems.Add(f.Price.ToString());
                lvi.SubItems.Add(f.Count.ToString());
                lvi.SubItems.Add(f.Cost.ToString());

                fcost += f.Cost;
                lvFood.Items.Add(lvi);
            }
            txtFcost.Text = fcost.ToString();
            CultureInfo ct = new CultureInfo("vi-VN");
            txtTotal.Text = (decimal.Parse(txtTamtinh.Text) + decimal.Parse(txtFcost.Text)).ToString("c", ct);
        }
        void ChangeColorZoneBtn(object sender, EventArgs e)
        {
            foreach (Control c in pnlZone.Controls)
            {
                c.BackColor = Color.FromArgb(37, 42, 64);
            }
            Control cl = (Control)sender;
            cl.BackColor = Color.FromArgb(0, 126, 249);

        }
        void ChangeColorComBtn(object sender, EventArgs e)
        {
            foreach (Control c in flpCom.Controls)
            {
                if (c.Text.Contains("Online"))
                {
                    c.BackColor = Color.Aqua;
                }
                if (c.Text.Contains("Offline"))
                {
                    c.BackColor = Color.LightGray;
                }
                if (c.Text.Contains("Error"))
                {
                    c.BackColor = Color.OrangeRed;
                }

            }
            Control cl = (Control)sender;
            if (cl.Text.Contains("Online"))
            {
                cl.BackColor = Color.FromArgb(100, 228, 178);
            }
            if (cl.Text.Contains("Offline"))
            {
                cl.BackColor = Color.FromArgb(200, 200, 100);
            }
            if (cl.Text.Contains("Error"))
            {
                cl.BackColor = Color.FromArgb(228, 135, 50);
            }
        }

        #endregion

    }
}
