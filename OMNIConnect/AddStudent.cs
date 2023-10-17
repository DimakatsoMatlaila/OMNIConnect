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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OMNIConnect
{
    public partial class AddStudent : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");
        public AddStudent()
        {
            InitializeComponent();
            MessageBox.Show("Student ID,Year of Study and the Degree Must be specified!", "NOTE:");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            bool blnValidInput = true;
            blnValidInput = ValidateFormInput(blnValidInput);
            String SelectedSex = cmbSex.SelectedItem as String;
            String SelectedYOS = cmbYOS.SelectedItem as String;

            //String fname = "";
            String Fname ="";
            String Lname = "";
            String Email = "";
            String SEX = "";

            if (SelectedSex == "" || SelectedSex ==null)
            {
                SEX = "NotSet";
            }
            else { 
            SEX = SelectedSex;    
            }

            if (txtFName.Text == "")
            {
                Fname = "NotSet";
            }
            else { Fname = txtFName.Text; }
            if (txtLname.Text == "")
            {
                Lname = "NotSet";
            }
            else { 
                Lname=txtLname.Text;
            }
            if (txtEMail.Text == "")
            {
                Email = "NotSet@gmail.com";
            }
            else {
                Email=txtEMail.Text;
            }



            if (blnValidInput == true) {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO Students (Student_ID, First_Name, Last_Name, Year_of_Study, Degree, Gender, Email) values (@1,@2,@3,@4,@5,@6,@7)", conn);
                    cmd.Parameters.AddWithValue("@1", txtStudID.Text);
                    cmd.Parameters.AddWithValue("@2", Fname);
                    cmd.Parameters.AddWithValue("@3", Lname);
                    cmd.Parameters.AddWithValue("@4", SelectedYOS);
                    cmd.Parameters.AddWithValue("@5", txtDegree.Text);
                    cmd.Parameters.AddWithValue("@6", SEX);
                    cmd.Parameters.AddWithValue("@7", Email);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    // conn.Open();

                    SetDefaulLogin();
                    // conn.Close();
                    ClearForm();

                    MessageBox.Show("User Successfully added.", "Success!");

                }
                catch {
                    MessageBox.Show("User ID already Exists, Try a different ID","Database Error:");
                }
            }
            //  refreshGrid();
        }




        private void SetDefaulLogin() {
            string DefaultPass = "12345";
            string AccountType = "Student";
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("INSERT INTO UserLogin (UserID, AccType) values (@1, @2)", conn);
            cmd.Parameters.AddWithValue("@1", txtStudID.Text);
          // cmd.Parameters.AddWithValue("@2", DefaultPass);
            cmd.Parameters.AddWithValue("@2", AccountType);
          //  Console.WriteLine(cmd.CommandText);

            cmd.ExecuteNonQuery();
            conn.Close();



        }

        public Boolean ValidateFormInput(bool blnValidInput)
        {
            blnValidInput = true;
            String SelectedYOS = cmbYOS.SelectedItem as String;

            if (txtDegree.Text == "")
            {
                blnValidInput = false;
                MessageBox.Show("Please Enter the Degree of study for the student!", "ERROR");
            }
                if (txtStudID.Text == "")
                {
                    blnValidInput = false;
                    MessageBox.Show("Please Assign the student with am ID", "ERROR");
                }
                if (SelectedYOS == ""||SelectedYOS==null)
                {
                    blnValidInput = false;
                    MessageBox.Show("Please Specify the Student's Year of Study!", "ERROR");
                }

                return blnValidInput;
            
        }

            private void ClearForm() {
                txtDegree.Text = "";
                txtStudID.Text = "";
                txtFName.Text = "";
                txtLname.Text = "";
                txtEMail.Text = "";
                cmbSex.SelectedIndex = -1;
                cmbYOS.SelectedIndex = -1;
                txtDegree.Focus();
            }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void txtEMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbSex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtStudID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

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

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbYOS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDegree_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtEMail_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void cmbSex_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void txtStudID_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Label10_Click_1(object sender, EventArgs e)
        {

        }

        private void Label8_Click_1(object sender, EventArgs e)
        {

        }

        private void Label11_Click_1(object sender, EventArgs e)
        {

        }

        private void Panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnImport_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            this.Visible = false;
            adminDashboard.ShowDialog();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SetDefaulLogin();
        }

        private void Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void cmbYOS_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void txtDegree_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtLname_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void Label5_Click_1(object sender, EventArgs e)
        {

        }

        private void Label4_Click_1(object sender, EventArgs e)
        {

        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {

        }
    }
    } 
