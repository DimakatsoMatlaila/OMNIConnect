using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMNIConnect
{
    public partial class ReportsAdmin : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");
        List<double> PieElems = new List<double>();
        List<string> PieElemsS = new List<string>();
        public ReportsAdmin()
        {
            InitializeComponent();
            refreshGrid();
            DrawGraph();
        }
        // public void GetData()
        public void refreshGrid()
        {
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(
                    "SELECT 'Available_Slots' AS Slot_Type, SUM(IIf([Slot_Status]='A', 1, 0)) AS Slot_Count FROM Timeslots " +
                    "UNION ALL " +
                    "SELECT 'Booked_Slots' AS Slot_Type, SUM(IIf([Slot_Status]='B', 1, 0)) AS Slot_Count FROM Timeslots " +
                    "UNION ALL " +
                    "SELECT 'Total_Slots' AS Slot_Type, Count(*) AS Slot_Count FROM Timeslots " +
                    "UNION ALL " +
                    "SELECT 'Available_Percentage' AS Slot_Type, Format(SUM(IIf([Slot_Status]='A', 1, 0)) / Count(*), '0.00%') AS Slot_Count FROM Timeslots " +
                    "UNION ALL " +
                    "SELECT 'Booked_Percentage' AS Slot_Type, Format(SUM(IIf([Slot_Status]='B', 1, 0)) / Count(*), '0.00%') AS Slot_Count FROM Timeslots;",
                    conn
                );

                da.Fill(dt);
                dgw.DataSource = dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Connection: " + e.Message); // Display the error message from the exception.
            }
            finally
            {
                conn.Close();
            }
        }


        public void DrawGraph()
        {

            double Aslots = 0, Bslots = 0, Tslots = 0;

            (Aslots, Bslots, Tslots) = GetSlotsData();

            chart1.Series["Available Slots"].Points.AddXY(1, Aslots);
            chart1.Series["Booked Slots"].Points.AddXY(2, Bslots);
            chart1.Series["Total Slots"].Points.AddXY(3, Tslots);

            double avilable = Aslots / Tslots;
            double booked = (Bslots / Tslots) ;

           // MessageBox.Show(avilable.ToString());

            PieElems.Add(avilable);
            PieElems.Add(booked);

            PieElemsS.Add("Available");
            PieElemsS.Add("Booked");
            LiveCharts.WinForms.PieChart pieChart = new LiveCharts.WinForms.PieChart();

           // LiveCharts.WinForms.CartesianChart

            pieChart.Width = 200;
            pieChart.Height = 200;
            Random rnd = new Random();
            SeriesCollection sers = new SeriesCollection();
            for (int n = 0; n < 2; n++)
            {
                PieSeries ser = new PieSeries();
                ser.Values = new ChartValues<double> { Math.Round(PieElems[n], 2) };
                ser.Title = PieElemsS[n];
                ser.DataLabels = true;
                sers.Add(ser);
            }

            pieChart.Series = sers;
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(pieChart);
        



    }

        public (double availableSlots, double bookedSlots, double totalSlots) GetSlotsData()
        {
            double availableSlots = 0;
            double bookedSlots = 0;
            double totalSlots = 0;

            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(
                    "SELECT " +
                    "SUM(IIf([Slot_Status]='A', 1, 0)) AS Available_Slots, " +
                    "SUM(IIf([Slot_Status]='B', 1, 0)) AS Booked_Slots, " +
                    "Count(*) AS Total_Slots " +
                    "FROM Timeslots",
                    conn
                );

                da.Fill(dt);

                // Check if there's at least one row in the result.
                if (dt.Rows.Count > 0)
                {
                    availableSlots = Convert.ToInt32(dt.Rows[0]["Available_Slots"]);
                    bookedSlots = Convert.ToInt32(dt.Rows[0]["Booked_Slots"]);
                    totalSlots = Convert.ToInt32(dt.Rows[0]["Total_Slots"]);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Connection: " + e.Message);
            }
            finally
            {
                conn.Close();
            }

            return (availableSlots, bookedSlots, totalSlots);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            this.Visible = false;
            adminDashboard.ShowDialog();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
