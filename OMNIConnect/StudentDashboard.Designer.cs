namespace OMNIConnect
{
    partial class StudentDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentDashboard));
            this.tslogin = new System.Windows.Forms.ToolStripButton();
            this.ListLecturersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddLecturerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frmLecturer = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsUser = new System.Windows.Forms.ToolStripButton();
            this.ListOfSubjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCourses = new System.Windows.Forms.ToolStripDropDownButton();
            this.ListOfStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frmStudent = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsReport = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tslogin
            // 
            this.tslogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tslogin.Name = "tslogin";
            this.tslogin.Size = new System.Drawing.Size(620, 24);
            this.tslogin.Text = "Logout";
            this.tslogin.Click += new System.EventHandler(this.tslogin_Click_1);
            // 
            // ListLecturersToolStripMenuItem
            // 
            this.ListLecturersToolStripMenuItem.Name = "ListLecturersToolStripMenuItem";
            this.ListLecturersToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.ListLecturersToolStripMenuItem.Text = "My Consultations";
            this.ListLecturersToolStripMenuItem.Click += new System.EventHandler(this.ListLecturersToolStripMenuItem_Click);
            // 
            // AddLecturerToolStripMenuItem
            // 
            this.AddLecturerToolStripMenuItem.Name = "AddLecturerToolStripMenuItem";
            this.AddLecturerToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.AddLecturerToolStripMenuItem.Text = "Book a Consultation";
            this.AddLecturerToolStripMenuItem.Click += new System.EventHandler(this.AddLecturerToolStripMenuItem_Click);
            // 
            // frmLecturer
            // 
            this.frmLecturer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddLecturerToolStripMenuItem,
            this.ListLecturersToolStripMenuItem});
            this.frmLecturer.Image = ((System.Drawing.Image)(resources.GetObject("frmLecturer.Image")));
            this.frmLecturer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.frmLecturer.Name = "frmLecturer";
            this.frmLecturer.Size = new System.Drawing.Size(620, 54);
            this.frmLecturer.Text = "Consultations";
            // 
            // tsUser
            // 
            this.tsUser.Image = ((System.Drawing.Image)(resources.GetObject("tsUser.Image")));
            this.tsUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUser.Name = "tsUser";
            this.tsUser.Size = new System.Drawing.Size(620, 54);
            this.tsUser.Text = "My Profile";
            this.tsUser.Click += new System.EventHandler(this.tsUser_Click);
            // 
            // ListOfSubjectsToolStripMenuItem
            // 
            this.ListOfSubjectsToolStripMenuItem.Name = "ListOfSubjectsToolStripMenuItem";
            this.ListOfSubjectsToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.ListOfSubjectsToolStripMenuItem.Text = "List of Courses";
            this.ListOfSubjectsToolStripMenuItem.Click += new System.EventHandler(this.ListOfSubjectsToolStripMenuItem_Click);
            // 
            // tsCourses
            // 
            this.tsCourses.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListOfSubjectsToolStripMenuItem});
            this.tsCourses.Image = ((System.Drawing.Image)(resources.GetObject("tsCourses.Image")));
            this.tsCourses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCourses.Name = "tsCourses";
            this.tsCourses.Size = new System.Drawing.Size(620, 54);
            this.tsCourses.Text = "Courses";
            this.tsCourses.Click += new System.EventHandler(this.tsCourses_Click);
            // 
            // ListOfStudentToolStripMenuItem
            // 
            this.ListOfStudentToolStripMenuItem.Name = "ListOfStudentToolStripMenuItem";
            this.ListOfStudentToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.ListOfStudentToolStripMenuItem.Text = "View Students";
            this.ListOfStudentToolStripMenuItem.Click += new System.EventHandler(this.ListOfStudentToolStripMenuItem_Click);
            // 
            // frmStudent
            // 
            this.frmStudent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListOfStudentToolStripMenuItem});
            this.frmStudent.Image = ((System.Drawing.Image)(resources.GetObject("frmStudent.Image")));
            this.frmStudent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.frmStudent.Name = "frmStudent";
            this.frmStudent.Size = new System.Drawing.Size(620, 54);
            this.frmStudent.Text = "Students";
            // 
            // tsReport
            // 
            this.tsReport.Image = ((System.Drawing.Image)(resources.GetObject("tsReport.Image")));
            this.tsReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsReport.Name = "tsReport";
            this.tsReport.Size = new System.Drawing.Size(620, 54);
            this.tsReport.Text = "My Notes";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.AutoSize = false;
            this.ToolStrip1.BackColor = System.Drawing.Color.White;
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frmStudent,
            this.frmLecturer,
            this.tsCourses,
            this.tsUser,
            this.tsReport,
            this.tslogin});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(622, 575);
            this.ToolStrip1.Stretch = true;
            this.ToolStrip1.TabIndex = 2;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // StudentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 575);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "StudentDashboard";
            this.Text = "StudentDashboard";
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStripButton tslogin;
        internal System.Windows.Forms.ToolStripMenuItem ListLecturersToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem AddLecturerToolStripMenuItem;
        internal System.Windows.Forms.ToolStripDropDownButton frmLecturer;
        internal System.Windows.Forms.ToolStripButton tsUser;
        internal System.Windows.Forms.ToolStripMenuItem ListOfSubjectsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripDropDownButton tsCourses;
        internal System.Windows.Forms.ToolStripMenuItem ListOfStudentToolStripMenuItem;
        internal System.Windows.Forms.ToolStripDropDownButton frmStudent;
        internal System.Windows.Forms.ToolStripButton tsReport;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
    }
}