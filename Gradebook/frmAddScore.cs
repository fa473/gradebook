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
    public partial class frmAddScore : Form
    {
        public frmAddScore()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newScore = txtScore.Text;
            this.Tag = newScore;
            this.DialogResult = DialogResult.OK;
        }
    }
}
