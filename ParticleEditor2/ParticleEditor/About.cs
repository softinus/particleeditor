using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParticleEditor
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void lb_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lb_cancle_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lb_cancle_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
