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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OMNIConnect
{
    public partial class CreateStudentProfile : Form
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
                OleDbCommand cmd = new OleDbCommand("SELECT Year_of_Study, Degree,First_Name,Last_Name,Email,Gender FROM Students where Student_ID=@1", conn);
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
                    string yearOfStudy = reader["Year_of_Study"].ToString();
                    string degree = reader["Degree"].ToString();
                    string fname = reader["First_Name"].ToString();
                    string lname = reader["Last_Name"].ToString();
                    string email = reader["Email"].ToString();
                    string sex = reader["Gender"].ToString() ;

                    if (sex=="Male") { 
                        cmbSex.SelectedIndex = 0; 
                    } else if (sex=="Female") {
                        cmbSex.SelectedIndex = 1;

                    } else if (sex == "Other") {
                        cmbSex.SelectedIndex = 2;
                    }
                    // Add yearOfStudy and degree to your lists
                    yearOfStudyList.Add(yearOfStudy);
                    degreeList.Add(degree);

                    lblDegree.Text = degree;
                    lblStudID.Text = id.ToString();
                    lblYOS.Text = yearOfStudy;   
                    txtFName.Text = fname;
                    txtLname.Text = lname;
                    txtEMail.Text = email;
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


        public CreateStudentProfile()
        {
            InitializeComponent();
           //    MessageBox.Show("ID :"+ LoginID.ID.ToString(),"");
            lblStudID.Text = id.ToString();

            GetData();
        }

        private void CreateStudentProfile_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool blnValid = true;
            blnValid=validateInput(blnValid);
            if (blnValid==true)
            {
                String Gender = cmbSex.SelectedItem as String;
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("update Students set First_Name = @1,Last_Name=@2,Gender=@3,Email=@4 where Student_ID = @5", conn);
                cmd.Parameters.AddWithValue("@1", txtFName.Text);
                cmd.Parameters.AddWithValue("@2", txtLname.Text);
                cmd.Parameters.AddWithValue("@3", Gender);
                cmd.Parameters.AddWithValue("@4",txtEMail.Text );
                cmd.Parameters.AddWithValue("@5", LoginID.ID.ToString());

                cmd.ExecuteNonQuery();
                conn.Close();
                // refreshGrid();
                MessageBox.Show("1 record updated");
            }
            else {
                MessageBox.Show("Update Aborted!");
            }

        }

        public Boolean validateInput(bool blnValidInut) {
            blnValidInut = true;
            String Gender = cmbSex.SelectedItem as String;

            if (txtFName.Text=="") {
                blnValidInut = false;
                MessageBox.Show("First Name cannot be a Null OR Empty","ERROR");
            }
            if (txtLname.Text == "")
            {
                blnValidInut = false;
                MessageBox.Show("Last Name cannot be a Null OR Empty", "ERROR");
            }
            if (txtEMail.Text == "")
            {
                blnValidInut = false;
                MessageBox.Show("Email cannot be a Null OR Empty", "ERROR");
            }
            if (Gender==null || Gender=="") { 
                blnValidInut=false;
                MessageBox.Show("Gender Must be Selected!","ERROR");
            }

            return blnValidInut;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            StudentDashboard studentDashboard = new StudentDashboard();
            this.Visible= false;
            studentDashboard.ShowDialog();
        }
    }
}
