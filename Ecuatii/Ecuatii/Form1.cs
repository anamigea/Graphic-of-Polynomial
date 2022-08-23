using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecuatii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.SlateGray;
        }

        private void enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.BurlyWood;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FormE1 form = new FormE1();
            form.Show();
            this.Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FormE2 form = new FormE2();
            form.Show();
            this.Visible = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.DeepPink;
        }

    }
}
