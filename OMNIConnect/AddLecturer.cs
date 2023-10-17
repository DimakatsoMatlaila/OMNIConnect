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
    public partial class AddLecturer : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");
        public AddLecturer()
        {
            InitializeComponent();
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            bool blnValid = true;
            String SelectedDep = cmbDept.Text as String;
            String SelectedRank = cmbRank.Text as String;

            String Fname = txtFName.Text;
            String Lname = txtLName.Text;
            String SEX=cmbSex.Text as String;
            String Email =txtEMail.Text;
            String TellNo= txtPhone.Text;

            if (Fname=="") {
                Fname = "NotSet";

            }
            if (Lname=="") {
                Lname = "NotSet";
            }
            if (Email=="") {
                Email = "NotSet";
            }
            if (TellNo=="") {
                TellNo = "0";
            }
            if (SEX==null) {
                SEX = "NotSet";
            }
            //  String LecID=txtID.Text;
            blnValid = ValidateInput(blnValid);

            if (blnValid == true)
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO Lecturers (lecturer_id, First_Name, Last_Name, Rank, Department_Name, Office_Number,Tell_No, Email_Address,Gender) values (@1,@2,@3,@4,@5,@6,@7,@8,@9)", conn);
                    cmd.Parameters.AddWithValue("@1", txtID.Text);
                    cmd.Parameters.AddWithValue("@2", Fname);
                    cmd.Parameters.AddWithValue("@3", Lname);
                    cmd.Parameters.AddWithValue("@4", SelectedRank);
                    cmd.Parameters.AddWithValue("@5", SelectedDep);
                    cmd.Parameters.AddWithValue("@6", txtOfficeNum.Text);
                    cmd.Parameters.AddWithValue("@7", TellNo);
                    cmd.Parameters.AddWithValue("@8", Email);
                    cmd.Parameters.AddWithValue("@9", SEX);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    SetDefaulLogin();
                    ClearForm();
                    MessageBox.Show("User Successfully added", "Success!");
                }
                catch {
                    MessageBox.Show("User ID already exists! Try A different ID","Database Error:");
                }
            }
        }

        private void SetDefaulLogin()
        {
            string DefaultPass = "12345";
            string AccountType = "Lecturer";
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("INSERT INTO UserLogin (UserID, AccType) values (@1, @2)", conn);
            cmd.Parameters.AddWithValue("@1", txtID.Text);
            // cmd.Parameters.AddWithValue("@2", DefaultPass);
            cmd.Parameters.AddWithValue("@2", AccountType);
            //  Console.WriteLine(cmd.CommandText);

            cmd.ExecuteNonQuery();
            conn.Close();



        }
        public void ClearForm() {
            txtEMail.Text = "";
            txtFName.Text = "";
            txtLName.Text = "";
            txtID.Text = "";
            txtOfficeNum.Text = "";
            txtPhone.Text = "";
            cmbDept.SelectedIndex = -1;
            cmbRank.SelectedIndex = -1;
            cmbSex.SelectedIndex = -1;
            txtID.Focus();
        }

        public Boolean ValidateInput(bool blnValid) {
            blnValid = true;
            String SelectedDep = cmbDept.Text as String;
            String SelectedRank = cmbRank.Text as String;

            if (SelectedDep==null) {
                MessageBox.Show("Department Must be selected!","Input Error:");
                blnValid = false;
            }
            if (SelectedRank==null) {
                MessageBox.Show("Rank Must be selected!", "Input Error:");
                blnValid = false;
            }
            if (txtID.Text=="") {
                MessageBox.Show("Please Assign the Lecturer an ID", "Input Error:");
                blnValid =false;
            }
            if (txtOfficeNum.Text=="") {
                MessageBox.Show("Please Enter Office Number!","Input Error:");
                blnValid = false;
            }
         //   if (txt) { }


            return blnValid;    
        }
        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void cmbSch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            this.Visible = false;
            adminDashboard.ShowDialog();
        }
    }
}
