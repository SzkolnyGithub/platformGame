using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Timers;

namespace platformowkaBadowski4c
{
    public partial class Form1 : Form
    {
        List<string> ruchy = new List<string>();
        bool lewo = false, prawo = false, gora = false, dol = false;
        int graczX = 5, graczY = 5, speed = 5;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                lewo = true;
                if (graczX >= this.Width)
                {
                    return;
                }
                gracz.Enabled = true;
                graczX -= speed;
                gracz.Image = Image.FromFile(ruchy[1]);
                gracz.Location = new Point(graczX, graczY);
            }
            if (e.KeyCode == Keys.W)
            {
                gora = true;
                if (graczY >= this.Height)
                {
                    return;
                }
                gracz.Enabled = true;
                graczY -= speed;
                gracz.Location = new Point(graczX, graczY);
            }
            if (e.KeyCode == Keys.D)
            {
                prawo = true;
                if (graczX >= this.Width)
                {
                    return;
                }
                gracz.Enabled = true;
                graczX += speed;
                gracz.Location = new Point(graczX, graczY);
            }
            if (e.KeyCode == Keys.S)
            {
                dol = true;
                if (graczY >= this.Width)
                {
                    return;
                }
                gracz.Enabled = true;
                graczY += speed;
                gracz.Location = new Point(graczX, graczY);
            }
        }

        PictureBox[] pola = new PictureBox[200];
        PictureBox gracz = new PictureBox();

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
            {
                gracz.Enabled = false;
            }
        }

        private void setup()
        {
            panel1.Width = this.Width;
            panel1.Height = this.Height;
            panel1.Location = new Point(0, 0);
            int x = 0, y = 0, count = 0;
            for(int i = 0; i < 200; i++)
            {
                pola[i] = new PictureBox();
                pola[i].Width = 60;
                pola[i].Height = 60;
                pola[i].Location = new Point(x, y);
                pola[i].Tag = "puste";
                pola[i].BorderStyle = BorderStyle.FixedSingle;
                // pola[i].GetChildAtPoint(pt); Point pt;
                panel1.Controls.Add(pola[i]);
                x += 60;
                count++;
                if(count == 20)
                {
                    x = 0;
                    y += 60;
                    count = 0;
                }
            }
            ruchy = Directory.GetFiles("./", "*.gif").ToList(); // left 0, right 1
            gracz.Width = 50;
            gracz.Height = 50;
            gracz.Location = new Point(5, 5);
            gracz.SizeMode = PictureBoxSizeMode.StretchImage;
            gracz.BackColor = Color.Black;
            gracz.Image = Image.FromFile(ruchy[0]);
            gracz.Enabled = false;
            panel1.Controls.Add(gracz);
            gracz.BringToFront();
        }

        public Form1()
        {
            InitializeComponent();
            setup();
        }

    }
}
