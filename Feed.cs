using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WealthFront
{
    public partial class Feed : Form
    {
        public Feed()
        {
            InitializeComponent();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Feed_Load(object sender, EventArgs e)
        {
            


        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
         

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form7 form = new Form7();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form8 form = new Form8();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form9 form = new Form9();
            form.Show();
        }
    }
}
