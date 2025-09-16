using DAL; 
using DTO; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KaraokeManagement
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            LoadCom();
        }

        void LoadCom()
        {
            List<Computer> listCom = ComputerDAL.Instance.LoadFullCom();
            int online = 0;
            int offline = 0;
            int error = 0;

            foreach (Computer com in listCom)
            {
                switch (com.ComStatus)
                {
                    case 0:
                        offline++;
                        break;
                    case 1:
                        online++;
                        break;
                    default:
                        error++;
                        break;
                }
            }

            txtAvailable.Text = offline.ToString();
            txtUsing.Text = online.ToString();
            txtError.Text = error.ToString();
        }


        private Dictionary<string, decimal> GetTotalRevenueByMonth(DateTime startDate, DateTime endDate)
        {
            Dictionary<string, decimal> revenueByMonth = new Dictionary<string, decimal>();

            try
            {
                // Lấy danh sách hóa đơn trong khoảng thời gian (đã lọc BType = 1 trong BillingDAL)
                List<Billing> bills = BillingDAL.Instance.loadBillListDashboard(startDate, endDate);

                // Nhóm theo tháng và năm, tính tổng FCost + SCost
                foreach (Billing bill in bills)
                {
                    string monthKey = $"{bill.BDate:MM/yyyy}"; // Định dạng MM/yyyy (ví dụ: 09/2025)
                    decimal totalRevenue = bill.FCost + bill.SCost; // Tổng doanh thu = FCost + SCost

                    if (revenueByMonth.ContainsKey(monthKey))
                    {
                        revenueByMonth[monthKey] += totalRevenue;
                    }
                    else
                    {
                        revenueByMonth[monthKey] = totalRevenue;
                    }
                }

                // Đảm bảo tất cả các tháng trong khoảng thời gian đều có dữ liệu (0 nếu không có hóa đơn)
                for (DateTime date = new DateTime(startDate.Year, startDate.Month, 1); date <= endDate; date = date.AddMonths(1))
                {
                    string monthKey = $"{date:MM/yyyy}";
                    if (!revenueByMonth.ContainsKey(monthKey))
                    {
                        revenueByMonth[monthKey] = 0;
                    }
                }

                return revenueByMonth;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu doanh thu: {ex.Message}");
                return new Dictionary<string, decimal>();
            }
        }

        private Dictionary<string, int> GetFoodCountByCategory()
        {
            Dictionary<string, int> categoryCounts = new Dictionary<string, int>();
            try
            {
                DataTable categories = AddFoodDAL.Instance.GetCategories();
                foreach (DataRow categoryRow in categories.Rows)
                {
                    string categoryName = categoryRow["CategoryName"].ToString();
                    int categoryId = Convert.ToInt32(categoryRow["CategoryID"]);
                    string query = "SELECT SUM(fd.Count) FROM FoodDetail fd " +
                                  "JOIN Food f ON f.FoodID = fd.FoodID " +
                                  "JOIN Billing b ON b.BillingID = fd.BillingID " +
                                  "WHERE f.CategoryID = @CategoryID AND b.billingtype = 1";
                    object result = Database.Instance.ExecuteScalar(query, new object[] { categoryId });
                    int count = result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    categoryCounts.Add(categoryName, count);
                }
                return categoryCounts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu: {ex.Message}");
                return new Dictionary<string, int>();
            }
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            // Thiết lập mặc định cho DateTimePicker
            dtpStartDate.Value = DateTime.Now.AddMonths(-6); // 6 tháng trước
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.CalendarMonthBackground = Color.FromArgb(37, 42, 64); // nền lịch
            dtpStartDate.CalendarForeColor = Color.White;

            // Vẽ biểu đồ
            DrawTotalRevenueByMonthChart();

            // Vẽ biểu đồ tròn
            DrawFoodByCategoryPieChart();
        }

        private void btnRefreshChart_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!");
                return;
            }
            DrawTotalRevenueByMonthChart();
        }

        private void DrawTotalRevenueByMonthChart()
        {
            try
            {
                // Lấy dữ liệu
                Dictionary<string, decimal> data = GetTotalRevenueByMonth(dtpStartDate.Value, dtpEndDate.Value);

                // Xóa series cũ
                chartTotalRevenueByMonth.Series.Clear();

                // Tạo series mới
                Series series = new Series("Tổng doanh thu");
                series.ChartType = SeriesChartType.Column;

                // Thêm dữ liệu vào series (sắp xếp theo tháng/năm)
                foreach (var item in data.OrderBy(x => DateTime.ParseExact(x.Key, "MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)))
                {
                    series.Points.AddXY(item.Key, item.Value);
                }

                // Thêm series vào chart
                chartTotalRevenueByMonth.Series.Add(series);

                // Cấu hình trục
                chartTotalRevenueByMonth.ChartAreas[0].AxisX.Title = "Tháng";
                chartTotalRevenueByMonth.ChartAreas[0].AxisY.Title = "Tổng doanh thu (VND)";
                chartTotalRevenueByMonth.ChartAreas[0].AxisX.Interval = 1;
                chartTotalRevenueByMonth.ChartAreas[0].AxisX.LabelStyle.Angle = -45; // Nghiêng nhãn để dễ đọc

                // Cấu hình tiêu đề
                chartTotalRevenueByMonth.Titles.Clear();
                Title title = new Title($"Tổng doanh thu (Món ăn + Tiền giờ) ({dtpStartDate.Value.ToString("MM/yyyy")} - {dtpEndDate.Value.ToString("MM/yyyy")})");
                title.Font = new Font("Arial", 12, FontStyle.Bold);
                title.ForeColor = Color.White; // màu trắng cho tiêu đề
                chartTotalRevenueByMonth.Titles.Add(title);
                
                // Tùy chỉnh màu sắc
                series.Color = Color.Navy;
                series.BorderWidth = 2;
                series.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột
                series.LabelForeColor = Color.White; // chữ trên cột màu trắng
                chartTotalRevenueByMonth.BackColor = Color.FromArgb(37, 42, 64);
                chartTotalRevenueByMonth.ChartAreas[0].BackColor = Color.FromArgb(37, 42, 64);
                chartTotalRevenueByMonth.Legends[0].BackColor = Color.FromArgb(37, 42, 64);
                chartTotalRevenueByMonth.Legends[0].ForeColor = Color.White; // chữ sáng hơn cho dễ đọc

                // Toàn bộ chữ -> trắng
                chartTotalRevenueByMonth.Legends[0].ForeColor = Color.White;
                chartTotalRevenueByMonth.ChartAreas[0].AxisX.TitleForeColor = Color.White;
                chartTotalRevenueByMonth.ChartAreas[0].AxisY.TitleForeColor = Color.White;
                chartTotalRevenueByMonth.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
                chartTotalRevenueByMonth.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
                chartTotalRevenueByMonth.ChartAreas[0].AxisX.LineColor = Color.White;
                chartTotalRevenueByMonth.ChartAreas[0].AxisY.LineColor = Color.White;
                chartTotalRevenueByMonth.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray; // lưới có thể để xám nhẹ
                chartTotalRevenueByMonth.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi vẽ biểu đồ: {ex.Message}");
            }
        }

        private void DrawFoodByCategoryPieChart()
        {
            try
            {
                // Lấy dữ liệu
                Dictionary<string, int> data = GetFoodCountByCategory();

                // Xóa series cũ
                chartFoodByCategory.Series.Clear();

                // Tạo series mới cho biểu đồ tròn
                Series series = new Series("Số lượng món ăn");
                series.ChartType = SeriesChartType.Pie;

                // Thêm dữ liệu vào series
                foreach (var item in data)
                {
                    if (item.Value > 0) // Chỉ thêm danh mục có món ăn
                    {
                        DataPoint point = new DataPoint();
                        point.SetValueXY(item.Key, item.Value);
                        point.Label = $"{item.Key}: {item.Value}";
                        series.Points.Add(point);
                    }
                }

                // Thêm series vào chart
                chartFoodByCategory.Series.Add(series);

                // Cấu hình biểu đồ
                chartFoodByCategory.ChartAreas[0].Area3DStyle.Enable3D = false; // Hiệu ứng 3D (tùy chọn)
                chartFoodByCategory.ChartAreas[0].Area3DStyle.Inclination = 30; // Góc nghiêng 3D
                chartFoodByCategory.ChartAreas[0].Area3DStyle.Rotation = 30; // Góc xoay 3D

                // Cấu hình tiêu đề
                chartFoodByCategory.Titles.Clear();
                Title title = new Title("Tỷ lệ số lượng món ăn theo danh mục");
                title.Font = new Font("Arial", 12, FontStyle.Bold);
                chartFoodByCategory.Titles.Add(title);
                title.ForeColor = Color.White; // màu trắng cho tiêu đề

                // Tùy chỉnh nhãn và màu sắc
                series.IsValueShownAsLabel = true; // Hiển thị nhãn trên mỗi phần
                series.LabelForeColor = Color.White; // Màu chữ nhãn
                series.Font = new Font("Arial", 10);
                chartFoodByCategory.BackColor = Color.FromArgb(37, 42, 64);
                chartFoodByCategory.ChartAreas[0].BackColor = Color.FromArgb(37, 42, 64);
                chartFoodByCategory.Legends[0].BackColor = Color.FromArgb(37, 42, 64);
                chartFoodByCategory.Legends[0].ForeColor = Color.White; // chữ sáng hơn cho dễ đọc

                // Gán màu ngẫu nhiên cho mỗi phần (tùy chọn)
                Random rand = new Random();
                for (int i = 0; i < series.Points.Count; i++)
                {
                    series.Points[i].Color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi vẽ biểu đồ: {ex.Message}");
            }
        }
    }
}
