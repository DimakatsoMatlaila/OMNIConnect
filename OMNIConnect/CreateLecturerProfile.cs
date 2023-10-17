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
    public partial class CreateLecturerProfile : Form
    {
        LoginID loginID = new LoginID();
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");
        String lblYOSs;
        String lblStudIDs;
        String lblDeg;
        int id = LoginID.ID;
        public void GetData()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT First_Name, Last_Name,Department_Name,Rank,Email_Address,Tell_No,Office_Number,Gender FROM Lecturers where lecturer_id=@1", conn);
                LoginID loginID = new LoginID();

                cmd.Parameters.AddWithValue("@1", id.ToString());
                // cmd.Parameters.AddWithValue("@2", textBox1.Text);
                OleDbDataReader reader = cmd.ExecuteReader();

                List<string> yearOfStudyList = new List<string>();
                List<string> degreeList = new List<string>();

                while (reader.Read())
                {
                    // Read the data and store it in variables
                    // string fName = reader["FName"].ToString();
                    // string lName = reader["LName"].ToString();
                  //  string yearOfStudy = reader["Year_of_Study"].ToString();
                    //string degree = reader["Degree"].ToString();
                    string fname = reader["First_Name"].ToString();
                    string lname = reader["Last_Name"].ToString();
                    string dept = reader["Department_Name"].ToString() ;
                    string rank = reader["Rank"].ToString();
                    string email = reader["Email_Address"].ToString();
                    string tell = reader["Tell_No"].ToString();
                    string office = reader["Office_Number"].ToString();
                    string sex = reader["Gender"].ToString();

                    if (sex == "Male")
                    {
                        cmbSex.SelectedIndex = 0;
                    }
                    else if (sex == "Female")
                    {
                        cmbSex.SelectedIndex = 1;

                    }
                    else if (sex == "Other")
                    {
                        cmbSex.SelectedIndex = 2;
                    }
                    // Add yearOfStudy and degree to your lists
                    //yearOfStudyList.Add(yearOfStudy);
                    // degreeList.Add(degree);
                    lblDep.Text = dept;
                    lblID.Text =id.ToString();
                    lblOfficeNum.Text = office;
                    lblRank.Text = rank;
                    txtEMail.Text = email;
                    txtFName.Text = fname;
                    txtLName.Text = lname;
                    txtPhone.Text = "0"+tell;
                    // You can do something with fName and lName here if needed
                }

                // Close the data reader and connection
                reader.Close();
                conn.Close();

                // Now you have the yearOfStudyList and degreeList with the values you need
                // You can use these lists as needed without refreshing the DataGridView
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Connection: " + e);
            }
            finally
            {
                conn.Close();
            }
        }

        public CreateLecturerProfile()
        {
            InitializeComponent();
            GetData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool blnValid = true;
            blnValid = ValidateInput(blnValid);

            if (blnValid == true)
            {
                String Gender = cmbSex.SelectedItem as String;
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("update Lecturers set First_Name = @1,Last_Name=@2,Gender=@3,Email_Address=@4,Tell_No=@5 where lecturer_id = @6", conn);
                cmd.Parameters.AddWithValue("@1", txtFName.Text);
                cmd.Parameters.AddWithValue("@2", txtLName.Text);
                cmd.Parameters.AddWithValue("@3", Gender);
                cmd.Parameters.AddWithValue("@4", txtEMail.Text);
                cmd.Parameters.AddWithValue("@5",txtPhone.Text );
                cmd.Parameters.AddWithValue("@6", LoginID.ID.ToString());

                cmd.ExecuteNonQuery();
                conn.Close();
                // refreshGrid();
                MessageBox.Show("1 record updated");
            }
            else
            {
                MessageBox.Show("Update Aborted!");
            }
        }

        public Boolean ValidateInput(Boolean blnValid) {
            blnValid = true;
            String Sex = cmbSex.SelectedItem as String;

            if (Sex==null) {
                MessageBox.Show("Please Select Gender!","Input Error: ");
            blnValid=false;
            }
            if (txtFName.Text=="") {
                MessageBox.Show("Please Enter First Name!", "Input Error: ");
                blnValid = false;
            }
            if (txtLName.Text=="") {
                MessageBox.Show("Please Enter Last Name!", "Input Error: ");
                blnValid = false;
            }
            if (txtPhone.Text=="") {
                MessageBox.Show("Please Enter Tellphone number!", "Input Error: ");
                blnValid = false;
            }
            if (txtEMail.Text=="") {
                MessageBox.Show("Please Enter Email Address!", "Input Error: ");
                blnValid = false;
            }

            return blnValid;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            LecturerDashboard lecturerDashboard = new LecturerDashboard();
            this.Visible = false;
            lecturerDashboard.ShowDialog();
        }
    }
}
