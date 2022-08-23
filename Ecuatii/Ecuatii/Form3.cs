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
    public partial class FormE2 : Form
    {
        float va, vb, vc, x1, x2, y, d;

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            label6.Visible = true;
            progressBar1.Increment(1);
            label6.Text = progressBar1.Value.ToString() + "%";
            if (label6.Text == "100%")
            {
                faGrafic();
                timer1.Stop();
            }
        }

        void faGrafic()
        {
            progressBar1.Visible = false;
            label6.Visible = false;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            panel1.Visible = true;
            panel1.Bounds = this.Bounds;

            Graphics g = panel1.CreateGraphics();
            System.Drawing.Pen p;
            p = new System.Drawing.Pen(System.Drawing.Color.Red, 2);

            float xvf = (-1) * vb / 2 * va;
            float yvf = va * xvf * xvf + vb * xvf + vc;
            float modul = 0;

            if(va>0)
            {
                if (x1 <= 0 && x2 >= 0)
                    modul = Math.Abs(x1) + x2;
                else if (x1 <= 0 && x2 <= 0)
                    modul = (-1) * (x1 - x2);
                else if (x1 >= 0 && x2 >= 0)
                    modul = x2 - x1;
                desen();
                if (d == 0)
                {
                    if(xvf>0)
                    {
                        g.DrawArc(p, panel1.Width / 2, panel1.Height / 2 - 2 * y, 2 * xvf, 2 * y, 0, 180);
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2 - y, panel1.Width / 2 - xvf, panel1.Top);
                        g.DrawLine(p, panel1.Width / 2 + 2 * xvf, panel1.Height / 2 - y, panel1.Width / 2 + 2 * xvf + xvf, panel1.Top);
                        //g.DrawLine(p, panel1.Width / 2 + x1, panel1.Height / 2, panel1.Width / 2 + x1, panel1.Height/2-y);
                    }
                    else if(xvf<0)
                    {
                        g.DrawArc(p, panel1.Width / 2+2*xvf, panel1.Height / 2 - 2 * y, (-2) * xvf, 2 * y, 0, 180);
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2 - y, panel1.Width / 2 - xvf, panel1.Top);
                        g.DrawLine(p, panel1.Width / 2 + 2 * xvf, panel1.Height / 2 - y, panel1.Width / 2 + 2 * xvf + xvf, panel1.Top);
                    }
                    else
                    {
                        g.DrawArc(p, panel1.Width / 2 - va, 0 - panel1.Height / 2, 2 * va, panel1.Height, 0, 180);
                    }
                }
                else if (d < 0)
                {
                    if(xvf>0)
                    {
                        g.DrawArc(p, panel1.Width / 2, panel1.Height / 2 - 2 * (y - yvf) - yvf, 2 * xvf, 2 * (y - yvf), 0, 180);
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2 - y, panel1.Width / 2 - xvf, panel1.Top);
                        g.DrawLine(p, panel1.Width / 2 + 2 * xvf, panel1.Height / 2 - y, panel1.Width / 2 + 2 * xvf + xvf, panel1.Top);
                        //g.DrawLine(p, panel1.Width / 2 + xvf, panel1.Height / 2 - y, panel1.Width / 2 + xvf, panel1.Height / 2 - yvf);
                    }
                    else if(xvf<0)
                    {
                        g.DrawArc(p, panel1.Width / 2 + 2 * xvf, panel1.Height / 2 - 2 * (y - yvf) - yvf, (-2) * xvf, 2 * (y - yvf), 0, 180);
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2 - y, panel1.Width / 2 - xvf, panel1.Top);
                        g.DrawLine(p, panel1.Width / 2 + 2 * xvf, panel1.Height / 2 - y, panel1.Width / 2 + 2 * xvf + xvf, panel1.Top);
                        //g.DrawLine(p, panel1.Width / 2 + xvf, panel1.Height / 2 - y, panel1.Width / 2 + xvf, panel1.Height / 2 - yvf);
                    }
                }
                else
                {
                    g.DrawArc(p, panel1.Width / 2 + x1, panel1.Height / 2 + yvf, modul, (-2) * yvf, 0, 180);
                    //g.DrawLine(p, panel1.Width / 2 + xvf, panel1.Height / 2 - yvf, panel1.Width / 2 + xvf, panel1.Height / 2);
                    if (x1 > 0 && x2 > 0)
                    {
                        g.DrawLine(p, panel1.Width / 2 + x1, panel1.Height / 2, panel1.Width / 2, panel1.Height / 2 - y);
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2 - y, panel1.Width / 2 - x1, panel1.Top);
                        g.DrawLine(p, panel1.Width / 2 + x2, panel1.Height / 2, panel1.Width / 2 + x2 + x1, panel1.Top);
                    }
                    if (x1 < 0 && x2 < 0)
                    {
                        g.DrawLine(p, panel1.Width / 2 + x1, panel1.Height / 2, panel1.Width / 2 + x1 + x2, panel1.Top);
                        g.DrawLine(p, panel1.Width / 2 + x2, panel1.Height / 2, panel1.Width / 2, panel1.Height / 2 - y);
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2 - y, panel1.Width / 2 - x2, panel1.Top);
                    }
                    if (x1 < 0 && x2 > 0)
                    {
                        g.DrawLine(p, panel1.Width / 2 + x1, panel1.Height / 2, panel1.Width / 2 + x1 - x2, panel1.Top);
                        g.DrawLine(p, panel1.Width / 2 + x2, panel1.Height / 2, panel1.Width / 2 - x1 + x2, panel1.Top);
                    }
                    if(x1<0 && x2==0)
                    {
                        g.DrawLine(p, panel1.Width / 2 + x1, panel1.Height / 2, panel1.Width / 2 + x1 + x1, panel1.Top);
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2, panel1.Width / 2 - x1, panel1.Top);
                    }
                    if(x1==0 && x2>0)
                    {
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2, panel1.Width / 2 - x2, panel1.Top);
                        g.DrawLine(p, panel1.Width / 2 + x2, panel1.Height / 2, panel1.Width / 2 + x2 + x2, panel1.Top);
                    }
                }
            }
            else
            {
                if (x2 <= 0 && x1 >= 0)
                    modul = Math.Abs(x2) + x1;
                else if (x1 <= 0 && x2 <= 0)
                    modul = (-1) * (x2 - x1);
                else if (x1 >= 0 && x2 >= 0)
                    modul = x1 - x2;
                desen();
                if(d==0)
                {
                    if(xvf>0)
                    {
                        g.DrawArc(p, panel1.Width / 2, panel1.Height / 2, 2 * xvf, (-2) * y, 0, -180);
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2 - y, panel1.Width / 2 - xvf, panel1.Bottom);
                        g.DrawLine(p, panel1.Width / 2 + 2 * xvf, panel1.Height / 2 - y, panel1.Width / 2 + 2 * xvf + xvf, panel1.Bottom);
                        //g.DrawLine(p, panel1.Width / 2 + xvf, panel1.Height / 2, panel1.Width / 2 + xvf, panel1.Height / 2 - y);
                    }
                    else if(xvf<0)
                    {
                        g.DrawArc(p, panel1.Width / 2 + 2 * xvf, panel1.Height / 2, (-2) * xvf, (-2) * y, 0, -180);
                        g.DrawLine(p, panel1.Width / 2 + 2 * xvf, panel1.Height / 2 - y, panel1.Width / 2 + 2 * xvf + xvf, panel1.Bottom);
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2 - y, panel1.Width / 2 - xvf, panel1.Bottom);
                        //g.DrawLine(p, panel1.Width / 2 + xvf, panel1.Height / 2, panel1.Width / 2 + xvf, panel1.Height / 2 - y);
                    }
                    else
                    {
                        g.DrawArc(p, panel1.Width / 2 + va, panel1.Height / 2, (-2) * va, panel1.Height, 0, -180);
                    }
                }
                else if(d<0)
                {
                    if(xvf>0)
                    {
                        g.DrawArc(p, panel1.Width / 2, panel1.Height / 2 - yvf, 2 * xvf, (-2) * (y - yvf), 0, -180);
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2 - y, panel1.Width / 2 - xvf, panel1.Bottom);
                        g.DrawLine(p, panel1.Width / 2 + 2 * xvf, panel1.Height / 2 - y, panel1.Width / 2 + 2 * xvf + xvf, panel1.Bottom);
                        //g.DrawLine(p, panel1.Width / 2 + xvf, panel1.Height / 2 - y, panel1.Width / 2 + xvf, panel1.Height / 2 - yvf);
                    }
                    else if(xvf<0)
                    {
                        g.DrawArc(p, panel1.Width / 2 + 2 * xvf, panel1.Height / 2 - yvf, (-2) * xvf, (-2) * (y - yvf), 0, -180);
                        g.DrawLine(p, panel1.Width / 2 + 2 * xvf, panel1.Height / 2 - y, panel1.Width / 2 + 2 * xvf + xvf, panel1.Bottom);
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2 - y, panel1.Width / 2 - xvf, panel1.Bottom);
                    }
                }
                else
                {
                    g.DrawArc(p, panel1.Width / 2 + x2, panel1.Height / 2 - yvf, modul, 2 * yvf, 0, -180);
                    if (x2 < 0 && x1 > 0)
                    {
                        g.DrawLine(p, panel1.Width / 2 + x2, panel1.Height / 2, panel1.Width / 2 + x2 - x1, panel1.Bottom);
                        g.DrawLine(p, panel1.Width / 2 + x1, panel1.Height / 2, panel1.Width / 2 - x2 + x1, panel1.Bottom);
                    }
                    if (x2 < 0 && x1 < 0)
                    {
                        g.DrawLine(p, panel1.Width / 2 + x2, panel1.Height / 2, panel1.Width / 2 + x1 + x2, panel1.Bottom);
                        g.DrawLine(p, panel1.Width / 2 + x1, panel1.Height / 2, panel1.Width / 2, panel1.Height / 2 - y);
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2 - y, panel1.Width / 2 - x1, panel1.Bottom);
                    }
                    if (x2 > 0 && x1 > 0)
                    {
                        g.DrawLine(p, panel1.Width / 2 + x2, panel1.Height / 2, panel1.Width / 2, panel1.Height / 2 - y);
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2 - y, panel1.Width / 2 - x2, panel1.Bottom);
                        g.DrawLine(p, panel1.Width / 2 + x1, panel1.Height / 2, panel1.Width / 2 + x1 + x2, panel1.Bottom);
                    }
                    if (x1 == 0 && x2 < 0)
                    {
                        g.DrawLine(p, panel1.Width / 2 + x2, panel1.Height / 2, panel1.Width / 2 + x2 + x2, panel1.Bottom);
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2, panel1.Width / 2 - x2, panel1.Bottom);
                    }
                    if (x1 > 0 && x2 == 0)
                    {
                        g.DrawLine(p, panel1.Width / 2, panel1.Height / 2, panel1.Width / 2 - x1, panel1.Bottom);
                        g.DrawLine(p, panel1.Width / 2 + x1, panel1.Height / 2, panel1.Width / 2 + x1 + x1, panel1.Bottom);
                    }
                }
                
            }
        }

        private void FaGf_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            mesaj.Visible = false;
            a.Visible = false;
            b.Visible = false;
            c.Visible = false;
            faGf.Visible = false;
            calc.Visible = false;

            timer1.Start();
        }

        public FormE2()
        {
            InitializeComponent();
        }

        private void Calc_Click(object sender, EventArgs e)
        {
            va = Convert.ToSingle(a.Text);
            vb = Convert.ToSingle(b.Text);
            vc = Convert.ToSingle(c.Text);
            mesaj.Visible = true;
            if(va==0)
            {
                mesaj.Text = "Aceasta este o funcție de gradul I.\nMergi înapoi și apasă pe butonul 'Gradul I'";
            }
            else
            {
                d = vb * vb - 4 * va * vc;          
                faGf.Visible = true;
            }

            if (d > 0)
            {
                double sq = Math.Sqrt(d);
                float dsq = Convert.ToSingle(sq);
                x1 = ((-1) * vb - dsq) / (2 * va);
                x2 = ((-1) * vb + dsq) / (2 * va);
                y = vc;
                mesaj.Text = "Intersecțiile cu axa Ox sunt " + x1.ToString() + ", " + x2.ToString() + "\nIntersecția cu axa Oy este " + y.ToString();
            }
            else if (d == 0 && va!=0)
            {
                x1 = (-1) * vb / 2 * va;
                y = vc;
                mesaj.Text = "Pătrat perfect\nIntersecția cu axa Ox este " + x1.ToString() + "\nIntersecția cu axa Oy este " + y.ToString();
            }
            else if (d < 0)
            {
                mesaj.Text = "Ecuația nu are soluții reale";
                y = vc;
            }
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
