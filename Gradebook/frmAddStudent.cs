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
    public partial class frmAddStudent : Form
    {
        public frmAddStudent()
        {
            InitializeComponent();
        }

        List<int> studentScores = new List<int>();

        private Student student = null;

        public Student GetNewStudent()
        {
            this.ShowDialog();
            return student;
        }

        private void btnAddScore_Click(object sender, EventArgs e)
        {
            int score = 0;
            if (txtScore.Text == "")
                MessageBox.Show("Please enter a score", "Entry Error");
            else if(!(Int32.TryParse(txtScore.Text, out score)))
                MessageBox.Show("Please enter a integer", "Entry Error");
            else if(Int16.Parse(txtScore.Text) < 0 || Int16.Parse(txtScore.Text) > 100)
                MessageBox.Show("Please enter a score from 0-100", "Entry Error");
            else
            {
                studentScores.Add(Convert.ToInt16(txtScore.Text));
                txtScores.Text = string.Join(" ", studentScores);
                txtScore.Text = "";
                txtScore.Focus();
            }
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            studentScores.Clear();
            txtScores.Text = "";
            txtScore.Text = "";
            txtScore.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
                MessageBox.Show("Please enter a name.", "Entry Error");
            else
            {
                string studentName = txtName.Text;
                string namePlusScores = studentName + "|" +
                    string.Join("|", studentScores);
                if (namePlusScores.EndsWith("|"))
                    namePlusScores = namePlusScores.Substring(0, namePlusScores.Length - 1);
                student = new Student(namePlusScores);
                this.Close();
            }
        }
    }
}
