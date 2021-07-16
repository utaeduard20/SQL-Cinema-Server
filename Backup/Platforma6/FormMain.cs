using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Platforma6
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void moviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.MdiParent = this;
            f.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form3();
            f.MdiParent = this;
            f.Show();
        }

        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Form4();
            f.MdiParent = this;
            f.Show();
        }
    }
}
