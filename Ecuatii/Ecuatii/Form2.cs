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
    public partial class FormE1 : Form
    {
        float va, vb;
        
        public FormE1()
        {
            InitializeComponent();
        }

        private void CalcRad_Click(object sender, EventArgs e)
        {
            va = Convert.ToSingle(a.Text);
            vb = Convert.ToSingle(b.Text);
            mesaj.Visible = true;
            if(va!=0)
            {
                float x = (-1) * vb / va;
                mesaj.Text = "Intersecția cu axa Ox este " + x.ToString() + "\nIntersecția cu axa Oy este " + vb.ToString();
            }
            else
            {
                mesaj.Text = "Graficul funcției nu intersectează axa Ox\nIntersecția cu Oy este " + vb.ToString();
            }
            faGf.Visible = true;
        }

        private void FaGf_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            mesaj.Visible = false;
            a.Visible = false;
            b.Visible = false;
            faGf.Visible = false;
            calcRad.Visible = false;

            timer1.Start();
        }

        void faGrafic()
        {
            progressBar1.Visible = false;
            label4.Visible = false;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            panel1.Visible = true;
            panel1.Bounds = this.Bounds;

            Graphics g = panel1.CreateGraphics();
            System.Drawing.Pen p;
            p = new System.Drawing.Pen(System.Drawing.Color.Red, 1);

            va = Convert.ToSingle(a.Text);
            vb = Convert.ToSingle(b.Text);
            if(va==0)
            {
                label5.Visible = true;
                label5.Location = new Point(panel1.Width / 2, panel1.Height / 2 - Convert.ToInt32(vb));
                label5.Text = vb.ToString();
                desen();
                g.DrawLine(p, new PointF(panel1.Left, panel1.Height / 2 - vb), new PointF(panel1.Right, panel1.Height / 2 - vb));
            }
            else
            {
                float x = (-1) * vb / va;
                float y = vb;
                int auxx = Convert.ToInt32(x);   //aproximam
                int auxy = Convert.ToInt32(y);
                label5.Visible = label6.Visible = true;
                if(va>0)
                {
                    if (y <= 0 && x >= 0)
                    {
                        label6.Location = new Point(panel1.Width / 2 + 10, panel1.Height / 2 - auxy + 10);
                        label6.Text = y.ToString();
                        label5.Location = new Point(panel1.Width / 2 + auxx + 10, panel1.Height / 2 - 10);
                        label5.Text = x.ToString();
                        desen();
                        g.DrawLine(p, new PointF(panel1.Left, panel1.Bottom), new PointF(panel1.Width / 2, panel1.Height / 2 - y));
                        g.DrawLine(p, new PointF(panel1.Width / 2, panel1.Height / 2 - y), new PointF(panel1.Width / 2 + x, panel1.Height / 2));
                        g.DrawLine(p, new PointF(panel1.Width / 2 + x, panel1.Height / 2), new PointF(panel1.Right, panel1.Top));

                    }
                    else//y>0 x<0
                    {
                        label6.Location = new Point(panel1.Width / 2 + 10, panel1.Height / 2 - auxy - 10);
                        label6.Text = y.ToString();
                        label5.Location = new Point(panel1.Width / 2 + auxx - 10, panel1.Height / 2 + 10);
                        label5.Text = x.ToString();
                        desen();
                        g.DrawLine(p, new PointF(panel1.Left, panel1.Bottom), new PointF(panel1.Width / 2 + x, panel1.Height / 2));
                        g.DrawLine(p, new PointF(panel1.Width / 2 + x, panel1.Height / 2), new PointF(panel1.Width / 2, panel1.Height / 2 - y));
                        g.DrawLine(p, new PointF(panel1.Width / 2, panel1.Height / 2 - y), new PointF(panel1.Right, panel1.Top));
                    }
                }
                else if(va<0)
                {
                    if (y >= 0 && x >= 0)
                    {
                        label6.Location = new Point(panel1.Width / 2 + 10, panel1.Height / 2 - auxy - 10);
                        label6.Text = y.ToString();
                        label5.Location = new Point(panel1.Width / 2 + auxx - 10, panel1.Height / 2 + 10);
                        label5.Text = x.ToString();
                        desen();
                        g.DrawLine(p, new PointF(panel1.Left, panel1.Top), new PointF(panel1.Width / 2, panel1.Height / 2 - y));
                        g.DrawLine(p, new PointF(panel1.Width / 2, panel1.Height / 2 - y), new PointF(panel1.Width / 2 + x, panel1.Height / 2));
                        g.DrawLine(p, new PointF(panel1.Width / 2 + x, panel1.Height / 2), new PointF(panel1.Right, panel1.Bottom));
                    }
                    else //y<0 x<0
                    {
                        label6.Location = new Point(panel1.Width / 2 + 10, panel1.Height / 2 - auxy - 10);
                        label6.Text = y.ToString();
                        label5.Location = new Point(panel1.Width / 2 + auxx - 10, panel1.Height / 2 + 10);
                        label5.Text = x.ToString();
                        desen();
                        g.DrawLine(p, new PointF(panel1.Left, panel1.Top), new PointF(panel1.Width / 2 + x, panel1.Height / 2));
                        g.DrawLine(p, new PointF(panel1.Width / 2 + x, panel1.Height / 2), new PointF(panel1.Width / 2, panel1.Height / 2 - y));
                        g.DrawLine(p, new PointF(panel1.Width / 2, panel1.Height / 2 - y), new PointF(panel1.Right, panel1.Bottom));
                    }
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            label4.Visible = true;
            progressBar1.Increment(1);
            label4.Text = progressBar1.Value.ToString() + "%";
            if (label4.Text == "100%")
            {
                faGrafic();
                timer1.Stop();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        void desen()
        {
            Graphics g = panel1.CreateGraphics();
            System.Drawing.Pen p;
            p = new System.Drawing.Pen(System.Drawing.Color.Black, 1);
            g.DrawLine(p, new Point(panel1.Width / 2, 0), new Point(panel1.Width / 2, panel1.Bottom));
            g.DrawLine(p, new Point(0, panel1.Height / 2), new Point(panel1.Right, panel1.Height / 2));

            g.DrawLine(p, new Point(panel1.Width / 2, 0), new Point(panel1.Width / 2 - 10, 10));
            g.DrawLine(p, new Point(panel1.Width / 2, 0), new Point(panel1.Width / 2 + 10, 10));

            g.DrawLine(p, new Point(panel1.Right - 10, panel1.Height / 2 - 10), new Point(panel1.Right, panel1.Height / 2));
            g.DrawLine(p, new Point(panel1.Right - 10, panel1.Height / 2 + 10), new Point(panel1.Right, panel1.Height / 2));
        }
    }
}
