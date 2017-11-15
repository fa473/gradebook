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
    public partial class frmUpdateScore : Form
    {
        public frmUpdateScore()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Tag = txtScore.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
