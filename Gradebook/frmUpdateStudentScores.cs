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
    public partial class frmUpdateStudentScores : Form
    {
        public frmUpdateStudentScores()
        {
            InitializeComponent();
        }

        private Student student = null;

        public Student GetNewStudent()
        {
            this.ShowDialog();
            return student;
        }

        private void frmUpdateStudentScores_Load(object sender, EventArgs e)
        {
            string[] scoresArray = frmStudentScores.updateStudent.Split('|');
            txtName.Text = scoresArray[0];
            lstScores.Items.Clear();
            for (int i = 1; i < scoresArray.Length; ++i)
            {
                lstScores.Items.Add(scoresArray[i]);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form AddScoreForm = new frmAddScore();
            DialogResult selectedButton = AddScoreForm.ShowDialog();
            if (selectedButton == DialogResult.OK)
                lstScores.Items.Add(AddScoreForm.Tag.ToString());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int i = lstScores.SelectedIndex;
            Form UpdateScoreForm = new frmUpdateScore();
            DialogResult selectedButton = UpdateScoreForm.ShowDialog();
            if (selectedButton == DialogResult.OK)
            {
                lstScores.Items.RemoveAt(i);
                lstScores.Items.Insert(i, UpdateScoreForm.Tag.ToString());
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int i = lstScores.SelectedIndex;
            if (i != -1)
            {
                lstScores.Items.RemoveAt(lstScores.SelectedIndex);
            }
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            lstScores.Items.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string studentName = txtName.Text;
            string[] studentScores = new string[lstScores.Items.Count];
            for (int i = 0; i < lstScores.Items.Count; i++)
                studentScores[i] = lstScores.Items[i].ToString();
            string namePlusScores = studentName + "|" +
                string.Join("|", studentScores);
            if (namePlusScores.EndsWith("|"))
                namePlusScores = namePlusScores.Substring(0, namePlusScores.Length - 1);
            student = new Student(namePlusScores);
            this.Close();
        }
    }
}
