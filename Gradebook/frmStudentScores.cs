using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3
{
    public partial class frmStudentScores : Form
    {
        public frmStudentScores()
        {
            InitializeComponent();
        }

        private StudentList students = new StudentList();

        public static string updateStudent;

        private void frmStudentScores_Load(object sender, EventArgs e)
        {
            students.Fill();
            FillStudentListBox();
        }

        private void FillStudentListBox()
        {
            lstStudents.Items.Clear();
            foreach (Student s in students)
                lstStudents.Items.Add(s.ToString());
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddStudent newForm = new frmAddStudent();
            Student student = newForm.GetNewStudent();
            if (student != null)
            {
                students.Add(student);
                students.Save();
                FillStudentListBox();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstStudents.SelectedIndex;
            if (i != -1)
            {
                Student student = students[i];
                string message = "Are you sure you want to delete?";
                DialogResult button = MessageBox.Show(message,
                    "Confirm Delete", MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    students.Remove(student);
                    students.Save();
                    FillStudentListBox();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalculateScores(object sender, EventArgs e)
        {
            updateStudent = lstStudents.SelectedItem.ToString();
            decimal total = 0;
            string student;
            if (lstStudents.SelectedItem != null)
            {
                student = lstStudents.SelectedItem.ToString();
            }
            else
                student = "";
            string[] scoresArray = student.Split('|');
            decimal count = scoresArray.Length - 1;
            for (int i = 1; i < scoresArray.Length; ++i)
            {
                total += Convert.ToDecimal(scoresArray[i]);
            }
            decimal averageScore;
            if (count > 0)
            {
                averageScore = total / count;
            }
            else
                averageScore = 0;

            txtScoreTotal.Text = total.ToString();
            txtScoreCount.Text = count.ToString();
            txtAverage.Text = Decimal.Round(averageScore,2).ToString();

            if (lstStudents.Items.Count == 0)
            {
                txtAverage.Text = "";
                txtScoreCount.Text = "";
                txtScoreTotal.Text = "";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int i = lstStudents.SelectedIndex;
            if (i != -1)
            {
                frmUpdateStudentScores newForm = new frmUpdateStudentScores();
                Student student = newForm.GetNewStudent();
                if (student != null)
                {
                    students.Remove(students[i]);
                    students.Insert(i, student);
                    students.Save();
                    FillStudentListBox();
                }
            }
        } 
    }
}
