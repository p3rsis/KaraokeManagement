namespace KaraokeManagement
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlMovable = new System.Windows.Forms.Panel();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlMenubar = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIntake = new System.Windows.Forms.Button();
            this.btnMaintain = new System.Windows.Forms.Button();
            this.bthLogout = new System.Windows.Forms.Button();
            this.btnBill = new System.Windows.Forms.Button();
            this.btnFood = new System.Windows.Forms.Button();
            this.btnRoom = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pnlMovable.SuspendLayout();
            this.pnlMenubar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMovable
            // 
            this.pnlMovable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlMovable.Controls.Add(this.pnlStatus);
            this.pnlMovable.Controls.Add(this.panel2);
            this.pnlMovable.Controls.Add(this.button5);
            this.pnlMovable.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMovable.Location = new System.Drawing.Point(0, 0);
            this.pnlMovable.Name = "pnlMovable";
            this.pnlMovable.Size = new System.Drawing.Size(1193, 30);
            this.pnlMovable.TabIndex = 0;
            this.pnlMovable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMovable_MouseDown);
            this.pnlMovable.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMovable_MouseMove);
            this.pnlMovable.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlMovable_MouseUp);
            // 
            // pnlStatus
            // 
            this.pnlStatus.Location = new System.Drawing.Point(60, 30);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(1133, 46);
            this.pnlStatus.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(59, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1134, 50);
            this.panel2.TabIndex = 2;
            // 
            // pnlMenubar
            // 
            this.pnlMenubar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.pnlMenubar.Controls.Add(this.label1);
            this.pnlMenubar.Controls.Add(this.pictureBox1);
            this.pnlMenubar.Controls.Add(this.btnDashboard);
            this.pnlMenubar.Controls.Add(this.btnIntake);
            this.pnlMenubar.Controls.Add(this.btnMaintain);
            this.pnlMenubar.Controls.Add(this.bthLogout);
            this.pnlMenubar.Controls.Add(this.btnBill);
            this.pnlMenubar.Controls.Add(this.btnFood);
            this.pnlMenubar.Controls.Add(this.btnRoom);
            this.pnlMenubar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenubar.Location = new System.Drawing.Point(0, 30);
            this.pnlMenubar.Name = "pnlMenubar";
            this.pnlMenubar.Size = new System.Drawing.Size(128, 618);
            this.pnlMenubar.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.pnlMain.Location = new System.Drawing.Point(128, 30);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1065, 618);
            this.pnlMain.TabIndex = 4;
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.OldLace;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(3, 167);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(122, 50);
            this.btnDashboard.TabIndex = 6;
            this.btnDashboard.Text = "DASHBOARD";
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Zilla Slab", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Karaoke";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KaraokeManagement.Properties.Resources._6dc69448c474747f1fe3e314b46b472f_removebg_preview__2_;
            this.pictureBox1.Location = new System.Drawing.Point(14, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 86);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnIntake
            // 
            this.btnIntake.FlatAppearance.BorderSize = 0;
            this.btnIntake.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIntake.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIntake.ForeColor = System.Drawing.Color.White;
            this.btnIntake.Image = global::KaraokeManagement.Properties.Resources.shopping_cart;
            this.btnIntake.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIntake.Location = new System.Drawing.Point(3, 447);
            this.btnIntake.Name = "btnIntake";
            this.btnIntake.Size = new System.Drawing.Size(122, 50);
            this.btnIntake.TabIndex = 5;
            this.btnIntake.Text = "      NHẬP HÀNG";
            this.btnIntake.UseVisualStyleBackColor = true;
            this.btnIntake.Click += new System.EventHandler(this.btnIntake_Click);
            // 
            // btnMaintain
            // 
            this.btnMaintain.FlatAppearance.BorderSize = 0;
            this.btnMaintain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMaintain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaintain.ForeColor = System.Drawing.Color.White;
            this.btnMaintain.Image = ((System.Drawing.Image)(resources.GetObject("btnMaintain.Image")));
            this.btnMaintain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaintain.Location = new System.Drawing.Point(3, 391);
            this.btnMaintain.Name = "btnMaintain";
            this.btnMaintain.Size = new System.Drawing.Size(122, 50);
            this.btnMaintain.TabIndex = 4;
            this.btnMaintain.Text = " BẢO TRÌ";
            this.btnMaintain.UseVisualStyleBackColor = true;
            this.btnMaintain.Click += new System.EventHandler(this.btnMaintain_Click);
            // 
            // bthLogout
            // 
            this.bthLogout.FlatAppearance.BorderSize = 0;
            this.bthLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bthLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bthLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.bthLogout.Image = ((System.Drawing.Image)(resources.GetObject("bthLogout.Image")));
            this.bthLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bthLogout.Location = new System.Drawing.Point(3, 568);
            this.bthLogout.Name = "bthLogout";
            this.bthLogout.Size = new System.Drawing.Size(125, 50);
            this.bthLogout.TabIndex = 3;
            this.bthLogout.Text = "     ĐĂNG XUẤT";
            this.bthLogout.UseVisualStyleBackColor = true;
            this.bthLogout.Click += new System.EventHandler(this.bthLogout_Click);
            // 
            // btnBill
            // 
            this.btnBill.FlatAppearance.BorderSize = 0;
            this.btnBill.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBill.ForeColor = System.Drawing.Color.White;
            this.btnBill.Image = ((System.Drawing.Image)(resources.GetObject("btnBill.Image")));
            this.btnBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBill.Location = new System.Drawing.Point(3, 335);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(122, 50);
            this.btnBill.TabIndex = 2;
            this.btnBill.Text = "   HÓA ĐƠN";
            this.btnBill.UseVisualStyleBackColor = true;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // btnFood
            // 
            this.btnFood.FlatAppearance.BorderSize = 0;
            this.btnFood.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFood.ForeColor = System.Drawing.Color.White;
            this.btnFood.Image = ((System.Drawing.Image)(resources.GetObject("btnFood.Image")));
            this.btnFood.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFood.Location = new System.Drawing.Point(3, 279);
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(122, 50);
            this.btnFood.TabIndex = 1;
            this.btnFood.Text = "    THỰC ĐƠN";
            this.btnFood.UseVisualStyleBackColor = true;
            this.btnFood.Click += new System.EventHandler(this.btnFood_Click);
            // 
            // btnRoom
            // 
            this.btnRoom.FlatAppearance.BorderSize = 0;
            this.btnRoom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoom.ForeColor = System.Drawing.Color.White;
            this.btnRoom.Image = global::KaraokeManagement.Properties.Resources.pen;
            this.btnRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoom.Location = new System.Drawing.Point(3, 223);
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Size = new System.Drawing.Size(122, 50);
            this.btnRoom.TabIndex = 0;
            this.btnRoom.Text = "    ĐẶT PHÒNG";
            this.btnRoom.UseVisualStyleBackColor = true;
            this.btnRoom.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = global::KaraokeManagement.Properties.Resources.close__1_;
            this.button5.Location = new System.Drawing.Point(1163, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 30);
            this.button5.TabIndex = 0;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1193, 648);
            this.Controls.Add(this.pnlMenubar);
            this.Controls.Add(this.pnlMovable);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.pnlMovable.ResumeLayout(false);
            this.pnlMenubar.ResumeLayout(false);
            this.pnlMenubar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMovable;
        private System.Windows.Forms.Panel pnlMenubar;
        private System.Windows.Forms.Button btnFood;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Button bthLogout;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnRoom;
        private System.Windows.Forms.Button btnMaintain;
        private System.Windows.Forms.Button btnIntake;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}