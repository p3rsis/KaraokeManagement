using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QLquannet
{
    public partial class frmMaintainance : Form
    {
        byte cid;
        int bid;
        string[] baotri = { "Bàn", "Loa", "Micro", "Tivi", "Ghế Sofa" };
        public frmMaintainance()
        {
            InitializeComponent();
            LoadRoom();
            txtNhanvien.Text = Employee.fullName;
            cbBaotri.DataSource = baotri;
            txtTotal.KeyPress += new KeyPressEventHandler(txtTotal_KeyPress);
        }

        #region Events
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Room room = btn.Tag as Room;
            cid = room.RoomId;
            if (room.RoomStatus == 0)
            {
                txtTT.Text = "Offline";
            }
            else if (room.RoomStatus == 1)
            {
                txtTT.Text = "Online";
            }
            else
            {
                txtTT.Text = "Error";
            }
            gbMay.Text = room.RoomName;
            LoadMaintainanceDetail(cid);
            ChangeColorRoomBtn(btn, null);
            ResetValue();
        }
        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            if (txtTT.Text == "Online" || txtTT.Text == "Offline")
            {
                MessageBox.Show("Máy này không bảo trì!");
            }
            else if (gbMay.Text == "")
            {
                MessageBox.Show("Chưa chọn máy!");
            }
            else if (txtTotal.Text == "")
            {
                MessageBox.Show("Chưa báo giá bảo trì!");
            }
            else
            {
                BillingDAL.Instance.CheckOutMaintainance(bid, Employee.emId, Convert.ToDecimal(txtTotal.Text), cid);
                LoadRoom();
                LoadMaintainanceDetail(cid);
                ResetValue();
            }
        }

        private void btnBaoloi_Click(object sender, EventArgs e)
        {
            if (txtTT.Text == "Online")
            {
                MessageBox.Show("Máy đang online!");
            }
            else if (gbMay.Text == "")
            {
                MessageBox.Show("Chưa chọn máy!");
            }
            else if (cbBaotri.Text == "")
            {
                MessageBox.Show("Chưa chọn bộ phận cần bảo trì!");
            }
            else
            {
                if (MaintainanceDAL.Instance.GetUnCheckOutMaintainance(cid) == -1)
                {
                    MaintainanceDAL.Instance.StartMaintainance(cid);
                    MaintainanceDAL.Instance.AddMaintainanceDetail(MaintainanceDAL.Instance.GetMaintainanceIDMAX(), cbBaotri.Text, txtDetail.Text);
                }
                else
                {
                    MaintainanceDAL.Instance.AddMaintainanceDetail(MaintainanceDAL.Instance.GetUnCheckOutMaintainance(cid), cbBaotri.Text, txtDetail.Text);

                }
                LoadRoom();
                LoadMaintainanceDetail(cid);
                ResetValue();
            }
        }
        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Methods
        void LoadRoom()
        {
            flpRoom.Controls.Clear();
            List<Room> listRoom = RoomDAL.Instance.LoadFullRoom();
            int online = 0;
            int offline = 0;
            int error = 0;
            foreach (Room room in listRoom)
            {
                Button btn = new Button()
                {
                    Width = RoomDAL.RoomWidth,
                    Height = RoomDAL.RoomHeight,
                };

                btn.Click += btn_Click;

                btn.FlatStyle = FlatStyle.Flat;

                btn.Tag = room;

                switch (room.RoomStatus)
                {
                    case 0:
                        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 200, 100);
                        btn.BackColor = Color.LightGray;
                        btn.Text = room.RoomName + Environment.NewLine + "Offline";
                        offline++;
                        break;

                    case 1:
                        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 228, 178);
                        btn.BackColor = Color.Aqua;
                        btn.Text = room.RoomName + Environment.NewLine + "Online";
                        online++;
                        break;
                    default:
                        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(228, 135, 50);
                        btn.BackColor = Color.OrangeRed;
                        btn.Text = room.RoomName + Environment.NewLine + "Error";
                        error++;
                        break;
                }
                flpRoom.Controls.Add(btn);
                txtAvailable.Text = offline.ToString();
                txtUsing.Text = online.ToString();
                txtError.Text = error.ToString();
                ResetValue();
            }
        }

        void ChangeColorRoomBtn(object sender, EventArgs e)
        {
            foreach (Control c in flpRoom.Controls)
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

        void LoadMaintainanceDetail(byte roomid)
        {
            lvMaintain.Items.Clear();
            List<Maintainance> ml = MaintainanceDAL.Instance.GetListMaintainance(roomid);
            foreach (Maintainance m in ml)
            {
                ListViewItem lvi = new ListViewItem(m.Component.ToString());
                if (m.Description != null)
                {
                    lvi.SubItems.Add(m.Description.ToString());
                }
                lvMaintain.Items.Add(lvi);
                bid = m.BillingId;
            }
        }

        void ResetValue()
        {
            cbBaotri.Text = "";
            txtDetail.Text = "";
            txtTotal.Text = "";
        }
        #endregion

    }
}
