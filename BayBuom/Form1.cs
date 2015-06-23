using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BayBuom
{
    public partial class Form1 : Form
    {

        int i = 0, j = 0, x = 197, y = 260, yy = -30, xx, yy1 = -30, xx1, toa_do_buom_x = 178;
        int x_buom_dem = 1;
        bool xd_qua_lai = true;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            this.pictureBox2.Hide();
            this.pictureBox3.Hide();
            this.pictureBox4.Hide();
            this.pictureBox1.Location = new Point(x, y);
        }
        private void Ongkhoi(ref int xx, ref int yy)
        {
            this.pictureBox3.Show();
            this.pictureBox3.Location = new Point(xx, yy);
            this.pictureBox3.BackColor = Color.Transparent;
        }
        private void Ongkhoi1(ref int xx1, ref int yy1)
        {
            this.pictureBox4.Show();
            this.pictureBox4.Location = new Point(xx1, yy1);
        }
        public void Khoitao(ref int i, ref int j, ref int x, ref int y, ref int yy, ref int yy1, ref int x_buom_dem)
        {
            i = 0;
            j = 0;
            x = 197;
            y = 153;
            yy = -30;
            yy1 = -30;
            x_buom_dem = 1;
            this.pictureBox2.Hide();
            this.pictureBox3.Hide();
            this.pictureBox4.Hide();
        }
        public void Gameover()
        {
            this.timer1.Enabled = false;
            this.timer2.Enabled = false;
            MessageBox.Show("Chết queo rồi cưng :D", "Chơi ngu", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            x_buom_dem++;
            Random rNum = new Random();
            int a = rNum.Next(0, 10);


            if (a % 2 != 0)
                a = -a;
            x_buom_dem += 2;
            if (xd_qua_lai == true)
                x -= x_buom_dem;
            else if (xd_qua_lai == false)
                x += x_buom_dem;
            if (x <= 8 || x >= 380)
            {
                if (xd_qua_lai == false)
                    x = 370;
                else if (xd_qua_lai == true)
                    x = 0;
                Gameover();
            }
            if (Form.ModifierKeys == Keys.Control) {
                //x = 0;
                xd_qua_lai = !xd_qua_lai;
                x_buom_dem = 1;
            }
            if ((yy < 285 && yy > 235) && (x < xx + 200 || x > xx + 420)) {
                if (xd_qua_lai == false)
                    x = xx + 400;
                else if (xd_qua_lai == true)
                    x = xx + 200;
                Gameover();
            }
            if ((yy1 < 285 && yy1 > 235) && (x < xx1 + 200 || x > xx1 + 420))
            {
                if (xd_qua_lai == false)
                    x = xx + 400;
                else if (xd_qua_lai == true)
                    x = xx + 200;
                Gameover();
            }
            if (i > 9999)
            {
                if (xd_qua_lai == false)
                    x = xx + 450;
                else if (xd_qua_lai == true)
                    x = xx + 200;
                Gameover();
            }
            this.label1.Text = Convert.ToString(x);
            this.label2.Text = Convert.ToString(y);
            this.label5.Text = Convert.ToString(i);
            if (i % 2 == 0)
            {
                this.pictureBox1.Hide();
                this.pictureBox2.Show();
                this.pictureBox2.Location = new Point(x, 260);
            }
            else if (i % 2 != 0)
            {
                this.pictureBox2.Hide();
                this.pictureBox1.Show();
                this.pictureBox1.Location = new Point(x, 260);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.timer2.Enabled = true;
            Khoitao(ref i,ref j,ref x,ref y,ref yy,ref yy1, ref x_buom_dem);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            j++;
            Random rNum = new Random();
            if (yy == -30)
                xx = rNum.Next(-150, -20);
            yy += 2;
            if (yy > 300)
                yy = -30;
            Ongkhoi(ref xx, ref yy);
            if (j > 80)
            {
                if (yy1 == -30)
                    xx1 = rNum.Next(-150, -20);
                yy1 += 2;
                Ongkhoi1(ref xx1, ref yy1);
                if (yy1 > 300)
                    yy1 = -30;
            }
        }
    }
}
