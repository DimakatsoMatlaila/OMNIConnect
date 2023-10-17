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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace OMNIConnect
{
    public partial class ManageUsers : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");
        List<string> LecturerIDs = new List<string>();
        List<string> StudentIDs = new List<string>();
        bool isSearched = false;
        bool isSearching = false;
        public ManageUsers()
        {
            InitializeComponent();
            GetLecturerIDs();
            GetStudentIDs();

        }


        public void GetLecturerIDs()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT lecturer_id From Lecturers", conn);
                LoginID loginID = new LoginID();

                // cmd.Parameters.AddWithValue("@1", id.ToString());
                // cmd.Parameters.AddWithValue("@2", textBox1.Text);
                OleDbDataReader reader = cmd.ExecuteReader();



                while (reader.Read())
                {

                    //string courseID = reader["Course_ID"].ToString();
                    string lecturerID = reader["lecturer_id"].ToString();

                    //LecturerIDs.Add(courseID);
                    LecturerIDs.Add(lecturerID);
                    // LecturerID = lecturerID;
                    PopulateLComboBox();


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
        private void PopulateLComboBox()
        {
            cbcLectIDs.Items.Clear();
            // Clear the ComboBox in case it already has items
            //tems.Clear();

            // Add each element from the CourseIDs list to the ComboBox
            foreach (string courseId in LecturerIDs)
            {
                cbcLectIDs.Items.Add(courseId);
            }
        }


        public void GetStudentIDs()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT Student_ID From Students", conn);
                LoginID loginID = new LoginID();

                // cmd.Parameters.AddWithValue("@1", id.ToString());
                // cmd.Parameters.AddWithValue("@2", textBox1.Text);
                OleDbDataReader reader = cmd.ExecuteReader();



                while (reader.Read())
                {

                    //string courseID = reader["Course_ID"].ToString();
                    string lecturerID = reader["Student_ID"].ToString();

                    //LecturerIDs.Add(courseID);
                    StudentIDs.Add(lecturerID);
                    PopulateSComboBox();
                    // LecturerID = lecturerID;


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

        private void PopulateSComboBox()
        {
            cbxStudentIds.Items.Clear();
            // Clear the ComboBox in case it already has items
            //tems.Clear();

            // Add each element from the CourseIDs list to the ComboBox
            foreach (string courseId in StudentIDs)
            {
                cbxStudentIds.Items.Add(courseId);
            }
        }




        public void GetStudentData()
        { String StudID = cbxStudentIds.SelectedItem as String;
            bool blnValidSearch = true;
            blnValidSearch = ValidateSearch(blnValidSearch);
           
            if (blnValidSearch == true) {
                isSearched = true;
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT Year_of_Study, Degree,First_Name,Last_Name,Email,Gender FROM Students where Student_ID=@1", conn);
                    LoginID loginID = new LoginID();

                    cmd.Parameters.AddWithValue("@1", StudID);
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
                        string sex = reader["Gender"].ToString();

                        if (yearOfStudy == "1") {
                            cmbYOS.SelectedIndex = 0;
                        } else if (yearOfStudy == "2")
                        {
                            cmbYOS.SelectedIndex = 1;
                        } else if (yearOfStudy == "3") {
                            cmbYOS.SelectedIndex = 2;
                        } else if (yearOfStudy == "4")
                        {
                            cmbYOS.SelectedIndex = 3;
                        } else if (yearOfStudy == "5")
                        {
                            cmbYOS.SelectedIndex = 4;
                        } else if (yearOfStudy == "6")
                        {
                            cmbYOS.SelectedIndex = 5;
                        }


                        if (sex == "Male")
                        {
                            cbcStudentGender.SelectedIndex = 0;
                        }
                        else if (sex == "Female")
                        {
                            cbcStudentGender.SelectedIndex = 1;

                        }
                        else if (sex == "Other")
                        {
                            cbcStudentGender.SelectedIndex = 2;
                        }
                        // Add yearOfStudy and degree to your lists
                        yearOfStudyList.Add(yearOfStudy);
                        degreeList.Add(degree);

                        txtDegree.Text = degree;
                        // lblStudID.Text = id.ToString();
                        //lblYOS.Text = yearOfStudy;
                        txtStudentFname.Text = fname;
                        txtStudentLname.Text = lname;
                        txtStudentEmail.Text = email;
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
        }


        private void btnSearchStudents_Click(object sender, EventArgs e)
        {
            GetStudentData();
        }

        private bool ValidateSearch(bool blnValidateSearch) {
            String StudID = cbxStudentIds.SelectedItem as String;
            blnValidateSearch = true;

            if (StudID == null) {
                blnValidateSearch = false;
                MessageBox.Show("Please select one Student ID", "Search Error!");
            }

            return blnValidateSearch;

        }

        public bool ValiddateStudentUpgate(bool blnValidSerched) { 
            blnValidSerched = true;

            String StudID = cbxStudentIds.SelectedItem as String;
            if (StudID==null) {
                blnValidSerched = false;
                MessageBox.Show("Student ID not selected!", "Error");

            }
            if (isSearched==false) {
                blnValidSerched=false;
                MessageBox.Show("No Student was specified!","Error");
            }

            return blnValidSerched;
            
        }

        public Boolean validateStudentFormInput(bool blnValidInut)
        {
            blnValidInut = true;
            String Gender = cbcStudentGender.SelectedItem as String;
            String YOS =cmbYOS.SelectedItem as String;
           // txtStudentFname.Text = fname;
           // txtStudentLname.Text = lname;
          //  txtStudentEmail.Text = email;

            if (txtStudentFname.Text == "")
            {
                blnValidInut = false;
                MessageBox.Show("First Name cannot be a Null OR Empty", "ERROR");
            }
            if (txtStudentLname.Text == "")
            {
                blnValidInut = false;
                MessageBox.Show("Last Name cannot be a Null OR Empty", "ERROR");
            }
            if (txtDegree.Text=="") {
                blnValidInut = false;
                MessageBox.Show("Please enter the name of the degree!", "ERROR");
            }
            if (txtStudentEmail.Text == "")
            {
                blnValidInut = false;
                MessageBox.Show("Email cannot be a Null OR Empty", "ERROR");
            }
            if (YOS == null) {
                blnValidInut = false;
                MessageBox.Show("Please select the Year of Study!", "ERROR");
            }
            if (Gender == null || Gender == "")
            {
                blnValidInut = false;
                MessageBox.Show("Gender Must be Selected!", "ERROR");
            }

            return blnValidInut;
        }

        private void btnUpdateStudents_Click(object sender, EventArgs e)
        {
            bool blnValid = true;
           bool blnValidFormInput = true;
            blnValidFormInput = validateStudentFormInput(blnValidFormInput);
           blnValid = ValiddateStudentUpgate(blnValid);


            if (blnValid == true && blnValidFormInput==true)
            {
                String Gender = cbcStudentGender.SelectedItem as String;
                String studid = cbxStudentIds.SelectedItem as String;
                String YOS = cmbYOS.SelectedItem as String; 
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("update Students set First_Name = @1,Last_Name=@2,Gender=@3,Email=@4,Year_of_Study=@5,Degree=@6 where Student_ID = @7", conn);
                cmd.Parameters.AddWithValue("@1", txtStudentFname.Text);
                cmd.Parameters.AddWithValue("@2", txtStudentLname.Text);
                cmd.Parameters.AddWithValue("@3", Gender);
                cmd.Parameters.AddWithValue("@4", txtStudentEmail.Text);
                cmd.Parameters.AddWithValue("@5", YOS);
                cmd.Parameters.AddWithValue("@6", txtDegree.Text);
                cmd.Parameters.AddWithValue("@7", studid);

                cmd.ExecuteNonQuery();
                conn.Close();
                // refreshGrid();
                MessageBox.Show("Student record updated");
            }
            else
            {
                MessageBox.Show("Update Aborted!");
            }
        }

        private void btnCloseS_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            this.Visible = false;
            adminDashboard.ShowDialog();
        }





        public void GetLecturerData()
        {
            String lectID = cbcLectIDs.SelectedItem as String;  
            try
            {
                isSearching = true;
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT First_Name, Last_Name,Department_Name,Rank,Email_Address,Tell_No,Office_Number,Gender FROM Lecturers where lecturer_id=@1", conn);
                LoginID loginID = new LoginID();

                cmd.Parameters.AddWithValue("@1", lectID);
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
                    string dept = reader["Department_Name"].ToString();
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

                    string searchStringDept = dept;
                    int selectedIndex = -1; // Initialize with -1 to indicate no match by default

                    // Loop through the items in the ComboBox
                    for (int i = 0; i < cmbDept.Items.Count; i++)
                    {
                        string itemText = cmbDept.Items[i].ToString();

                        // Compare the string with the ComboBox item
                        if (itemText.Equals(searchStringDept, StringComparison.OrdinalIgnoreCase)) // Use StringComparison.OrdinalIgnoreCase for a case-insensitive comparison
                        {
                            selectedIndex = i; // Set the index if a match is found
                            break; // Exit the loop since a match is found
                        }
                    }

                    // Select the item if a match was found
                    if (selectedIndex >= 0)
                    {
                        cmbDept.SelectedIndex = selectedIndex;
                    }

                    string searchStringRank= rank;
                    int selectedIndexR = -1; // Initialize with -1 to indicate no match by default

                    // Loop through the items in the ComboBox
                    for (int i = 0; i < cmbRank.Items.Count; i++)
                    {
                        string itemText = cmbRank.Items[i].ToString();

                        // Compare the string with the ComboBox item
                        if (itemText.Equals(searchStringRank, StringComparison.OrdinalIgnoreCase)) // Use StringComparison.OrdinalIgnoreCase for a case-insensitive comparison
                        {
                            selectedIndexR = i; // Set the index if a match is found
                            break; // Exit the loop since a match is found
                        }
                    }

                    // Select the item if a match was found
                    if (selectedIndexR >= 0)
                    {
                        cmbRank.SelectedIndex = selectedIndexR;
                    }


                    // lblDep.Text = dept;
                    // lblID.Text = id.ToString();
                    txtOfficeNum.Text = office;
                    //txt.Text = rank;
                    txtEMail.Text = email;
                    txtFName.Text = fname;
                    txtLName.Text = lname;
                    txtPhone.Text = "0" + tell;
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

        private void btnSearchLect_Click(object sender, EventArgs e)
        {
            String isSelected = cbcLectIDs.SelectedItem as String;
            if (isSelected == null)
            {
                MessageBox.Show("Please Select a Lecturer ID!", "Error");
            }
            else
            {
                GetLecturerData();
            }
        }

        private void btnCloseL_Click(object sender, EventArgs e)
        {
            btnCloseS_Click(sender,  e);
        }

        private void btnUpdateLect_Click(object sender, EventArgs e)
        {
            bool blnValid = true;
           

            if (isSearching == true)
            {
                blnValid = ValidateInput(blnValid);
                if (blnValid == true)
                {
                    String Gender = cmbSex.SelectedItem as String;
                    String lectid = cbcLectIDs.SelectedItem as String;
                    String rank = cmbRank.SelectedItem as String;
                    String dept = cmbDept.SelectedItem as String;

                   // MessageBox.Show(Gender+" "+lectid+" "+rank+" "+dept);

                   conn.Open();
                    OleDbCommand cmd = new OleDbCommand("update Lecturers set First_Name = @1,Last_Name=@2,Gender=@3,Email_Address=@4,Tell_No=@5,Rank=@6,Department_Name=@7,Office_Number=@8 where lecturer_id = @9", conn);
                    cmd.Parameters.AddWithValue("@1", txtFName.Text);
                    cmd.Parameters.AddWithValue("@2", txtLName.Text);
                    cmd.Parameters.AddWithValue("@3", Gender);
                    cmd.Parameters.AddWithValue("@4", txtEMail.Text);
                    cmd.Parameters.AddWithValue("@5", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@6", rank);
                    cmd.Parameters.AddWithValue("@7", dept);
                    cmd.Parameters.AddWithValue("@8", txtOfficeNum.Text);
                    cmd.Parameters.AddWithValue("@9", lectid);

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
            else
            {
                MessageBox.Show("Please Search For A lecturer's details first!","Error");
            }
            
        }


        public Boolean ValidateInput(Boolean blnValid)
        {
            blnValid = true;
            String Sex = cmbSex.SelectedItem as String;

            String lectid = cbcLectIDs.SelectedItem as String;
            String rank = cmbRank.SelectedItem as String;
            String dept = cmbDept.SelectedItem as String;

            if (Sex == null)
            {
                MessageBox.Show("Please Select Gender!", "Input Error: ");
                blnValid = false;
            }
            if (lectid==null) {
                MessageBox.Show("Please Select Lecturer ID!", "Input Error: ");
                blnValid = false;
            }
            if(rank==null) {
                MessageBox.Show("Please Select Rank!", "Input Error: ");
                blnValid = false;
            }
            if (dept==null) {
                MessageBox.Show("Please Select Department!", "Input Error: ");
                blnValid = false;
            }
            if (txtFName.Text == "")
            {
                MessageBox.Show("Please Enter First Name!", "Input Error: ");
                blnValid = false;
            }
            if (txtLName.Text == "")
            {
                MessageBox.Show("Please Enter Last Name!", "Input Error: ");
                blnValid = false;
            }
            if (txtPhone.Text == "")
            {
                MessageBox.Show("Please Enter Tellphone number!", "Input Error: ");
                blnValid = false;
            }
            if (txtEMail.Text == "")
            {
                MessageBox.Show("Please Enter Email Address!", "Input Error: ");
                blnValid = false;
            }

            return blnValid;
        }

    }
}
