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
    public partial class Login : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;

        OleDbConnection con2;
        OleDbCommand cmd2;
        OleDbDataReader dr2;

        int Count = 3;

        public Login()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String SelectedAccType = cmboxLoginType.SelectedItem as String;
            bool blnValidInput = true;
            blnValidInput=ValidateForm(blnValidInput);
            // MessageBox.Show(SelectedAccType);
            if (blnValidInput == true)
            {
                con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");
                con.Open();
                string sql = "SELECT * FROM UserLogin WHERE UserID = ? AND [Password] = ? AND AccType = ?";
                cmd = new OleDbCommand(sql, con);
                cmd.Parameters.AddWithValue("UserID", txtUserID.Text);
                cmd.Parameters.AddWithValue("Password", txtPass.Text);
                cmd.Parameters.AddWithValue("AccType", SelectedAccType);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (SelectedAccType == "Student")
                    {
                        //MessageBox.Show("Login Successful");
                       // LoginID iD = new LoginID();
                        // iD.SetID(Convert.ToInt32(txtUserID.Text));
                        LoginID.ID = Convert.ToInt32(txtUserID.Text);
                        LoginID.AccType = "Student";
                        StudentDashboard dashboard = new StudentDashboard();
                        this.Visible = false;
                        dashboard.ShowDialog();

                    }
                    else if (SelectedAccType == "Admin")
                    {
                       // MessageBox.Show("Login Successful");
                        LoginID iD = new LoginID();
                       // iD.SetID(Convert.ToInt32(txtUserID.Text));
                       LoginID.ID=Convert.ToInt32(txtUserID.Text);
                        LoginID.AccType = "Admin";
                        AdminDashboard adminDashboard = new AdminDashboard();
                        this.Visible = false;
                        adminDashboard.ShowDialog();    
                    }
                    else if (SelectedAccType == "Lecturer")
                    {
                      // MessageBox.Show("Login Successful");
                        LoginID iD = new LoginID();
                        LoginID.AccType = "Lecturer"
;                        //  iD.SetID(Convert.ToInt32(txtUserID.Text));
                        LoginID.ID = Convert.ToInt32(txtUserID.Text);
                        LecturerDashboard dashboard = new LecturerDashboard();
                        this.Visible = false;
                        dashboard.ShowDialog();

                       
                    }
                    else
                    {
                        MessageBox.Show("Invalid Account Type!");
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Credentials, Please Re-Enter");
                }

                con.Close();
            }
            else {
                Count--;
                if (Count == 0) {
                    MessageBox.Show("You have made 3 mistakes! ;)","Oops...GoodBye!");
                    Application.Exit();
                }
            }


        }

        private Boolean ValidateForm(bool blnValidInput) {
            blnValidInput = true;
            String SelectedAccType = cmboxLoginType.SelectedItem as String;

            if (txtUserID.Text=="") {
                blnValidInput = false;
                MessageBox.Show("Please Enter UserID!","Error");
            }
            if (txtPass.Text == "")
            {
                blnValidInput= false;
                MessageBox.Show("Please Enter Password!", "Error");
            }
            if (SelectedAccType=="") {
                blnValidInput = false;
                MessageBox.Show("Please Select Account Type!", "Error");
            }

            return blnValidInput;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserID.Text = "";
            txtPass.Text = "";

        }
    }
}
