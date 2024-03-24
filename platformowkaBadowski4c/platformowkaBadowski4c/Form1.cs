﻿using System;
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
        List<int> sciany = new List<int> { 3, 8, 9, 10, 12, 13, 14, 16, 17, 19, 23, 26, 28, 29, 30, 32, 33, 34, 36, 37, 39, 43, 44, 45, 46, 48, 49, 50, 52, 53, 54, 56, 57, 59, 60, 61, 63, 68, 69, 70, 72, 73, 74, 77, 79, 88, 89, 90, 92, 93, 94, 99, 100, 101, 104, 117, 118, 119, 120, 121, 122, 124, 125, 133, 144, 145, 149, 153, 156, 158, 164, 165, 166, 169, 173, 176, 184, 189, 193, 196 };
        List<int> czachy = new List<int> { 66, 77, 102, 130, 147, 159, 161, 162, 174, 188, 192, 197 };
        List<int> coiny = new List<int> { 11, 18, 25, 80, 180, 185, 195 };
        List<int> fakeWalls = new List<int> { 31, 51, 71 };
        int tag = 0;
        int coinAmount = 0;
        int keyAmount = 0;
        List<string> miscellaneous = new List<string>();
        List<string> pngs = new List<string>();
        int graczX = 0, graczY = 0, speed = 30;

        PictureBox[] pola = new PictureBox[200];
        PictureBox gracz = new PictureBox();

        private void setup()
        {
            miscellaneous = Directory.GetFiles("./", "*1.png").ToList();
            panel1.Width = 600;
            panel1.Height = 300;
            panel1.Location = new Point(0, 0);
            int x = 0, y = 0, count = 0;
            for (int i = 0; i < 200; i++)
            {
                pola[i] = new PictureBox();
                pola[i].Width = 30;
                pola[i].Height = 30;
                pola[i].Location = new Point(x, y);
                pola[i].Tag = i;
                pola[i].Name = "empty";
                pola[i].BackColor = Color.LightGray;
                if (sciany.Contains(i))
                {
                    pola[i].BackColor = Color.Gray;
                    pola[i].Name = "wall";
                }
                if (czachy.Contains(i))
                {
                    pola[i].Image = Image.FromFile(miscellaneous[1]);
                    pola[i].Name = "ded";
                }
                if (coiny.Contains(i))
                {
                    pola[i].Image = Image.FromFile(miscellaneous[0]);
                    pola[i].Name = "coin";
                }
                if (fakeWalls.Contains(i))
                {
                    pola[i].Image = Image.FromFile(miscellaneous[3]);
                    pola[i].Name = "fakewall";
                }
                pola[i].BorderStyle = BorderStyle.FixedSingle;
                // pola[i].GetChildAtPoint(pt); Point pt;
                panel1.Controls.Add(pola[i]);
                x += 30;
                count++;
                if (count == 20)
                {
                    x = 0;
                    y += 30;
                    count = 0;
                }
            }
            pola[199].Image = Image.FromFile(miscellaneous[2]);
            pola[199].Name = "end";
            pola[91].Image = Image.FromFile(miscellaneous[5]);
            pola[155].Image = Image.FromFile(miscellaneous[5]);
            pola[91].Name = "lock";
            pola[155].Name = "lock";
            pola[15].Image = Image.FromFile(miscellaneous[4]);
            pola[171].Image = Image.FromFile(miscellaneous[4]);
            pola[15].Name = "key";
            pola[171].Name = "key";
            pngs = Directory.GetFiles("./", "gracz*.png").ToList();
            gracz.Width = 30;
            gracz.Height = 30;
            gracz.Location = new Point(0, 0);
            gracz.SizeMode = PictureBoxSizeMode.StretchImage;
            gracz.BackColor = Color.Black;
            gracz.Tag = tag;
            gracz.Image = Image.FromFile(pngs[0]);
            panel1.Controls.Add(gracz);
            gracz.BringToFront();
        }

        public Form1()
        {
            InitializeComponent();
            setup();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().ToUpper() == Keys.A.ToString())
            {
                if (graczX - speed < 0)
                {
                    return;
                }
                graczX -= speed;
                gracz.Tag = tag - 1;
                tag -= 1;
                if (check(tag) == "nuh-uh")
                {
                    graczX += speed;
                    gracz.Tag = tag + 1;
                    tag += 1;
                    return;
                }
                gracz.Image = Image.FromFile(pngs[1]);
                gracz.Location = new Point(graczX, graczY);
                ruch();
            }
            if (e.KeyChar.ToString().ToUpper() == Keys.W.ToString())
            {
                if (graczY - speed < 0)
                {
                    return;
                }
                graczY -= speed;
                gracz.Tag = tag - 20;
                tag -= 20;
                if (check(tag) == "nuh-uh")
                {
                    graczY += speed;
                    gracz.Tag = tag + 20;
                    tag += 20;
                    return;
                }
                gracz.Image = Image.FromFile(pngs[1]);
                gracz.Location = new Point(graczX, graczY);
                ruch();
            }
            if (e.KeyChar.ToString().ToUpper() == Keys.D.ToString())
            {
                if (graczX + speed >= panel1.Width)
                {
                    return;
                }
                graczX += speed;
                gracz.Tag = tag + 1;
                tag += 1;
                if (check(tag) == "nuh-uh")
                {
                    graczX -= speed;
                    gracz.Tag = tag - 1;
                    tag -= 1;
                    return;
                }
                gracz.Image = Image.FromFile(pngs[2]);
                gracz.Location = new Point(graczX, graczY);
                ruch();
            }
            if (e.KeyChar.ToString().ToUpper() == Keys.S.ToString())
            {
                if (graczY + speed >= panel1.Height)
                {
                    return;
                }
                graczY += speed;
                gracz.Tag = tag + 20;
                tag += 20;
                if (check(tag) == "nuh-uh")
                {
                    graczY -= speed;
                    gracz.Tag = tag - 20;
                    tag -= 20;
                    return;
                }
                gracz.Image = Image.FromFile(pngs[2]);
                gracz.Location = new Point(graczX, graczY);
                ruch();
            }
            gracz.Image = Image.FromFile(pngs[0]);
        }
        private string check(int next)
        {
            if (pola[next].Name == "wall")
            {
                return "nuh-uh";
            }
            if (pola[next].Name == "coin")
            {
                pola[next].Image = null;
                pola[next].BackColor = Color.LightGray;
                coinAmount++;
                coins.Text = "Monety: " + coinAmount;
                return "coin:peepohappy:";
            }
            if (pola[next].Name == "end")
            {
                if(coinAmount == 7)
                {
                    MessageBox.Show("Jako jedynemu udało ci się opuścić te katakumby z życiem!", "Gratulacje!");
                    return "happyEnd";
                } else
                {
                    return "nuh-uh";
                }
            }
            if (pola[next].Name == "key")
            {
                pola[next].Image = null;
                pola[next].BackColor = Color.LightGray;
                keyAmount++;
                keys.Text = "Klucze: " + keyAmount;
                return "key:peepohappy:";
            }
            if (pola[next].Name == "lock")
            {
                pola[next].Image = null;
                pola[next].BackColor = Color.LightGray;
                /*if(keyAmount == 1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (pola[i].Name == "fakewall")
                        {
                            pola[i].Image = null;
                            pola[i].BackColor = Color.LightGray;
                        }
                    }
                }*/
            }
            return "ok";
        }
        private void ruch()
        {
            for (int i = 0; i < 200; i++)
            {
                if ((int)pola[i].Tag == (int)gracz.Tag)
                {
                    //coins.Text = pola[i].Tag.ToString();
                    // pola[i].BackColor = Color.White;
                }
            }
        }
    }
}