﻿using System;
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
    public partial class ListLecturersAdmin : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");
        public void refreshGrid()
        {
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from Lecturers", conn);
                da.Fill(dt);

                dgw.DataSource = dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Connection:" + e);
            }
            finally
            {
                conn.Close();
            }
        }
        public ListLecturersAdmin()
        {
            InitializeComponent();
            refreshGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            this.Visible = false;
            adminDashboard.ShowDialog();
        }
    }
}
