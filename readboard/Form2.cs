﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace readboard
{
    public partial class Form2 : Form
    {
        int x1, y1, x2, y2, width, height;
        //int hwnd;
        Boolean isMouthDown = false;
        Graphics g;
        MagnifierForm form5;
        Boolean needMag;


        public Form2(Boolean needMag)
        {
            InitializeComponent();
          //  int SH = Screen.PrimaryScreen.Bounds.Height;
         //   int SW = Screen.PrimaryScreen.Bounds.Width;
          //  this.Size = new Size(SW+160,SH+160);
          //  this.Location = new Point(-80, -80);
         
            this.needMag = needMag;
            if (Program.useMag && needMag)
            {
                form5 = new MagnifierForm();
                form5.StartPosition = FormStartPosition.Manual;
                int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;
                form5.Location = new Point(0, iActulaHeight-200);
                form5.Show();
            }
            //   x1 = Form1.ox1;
            //  y1 = Form1.oy1;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = MousePosition.X;
            y1 = MousePosition.Y;
            isMouthDown = true;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouthDown)
            {
                width = Math.Abs(MousePosition.X - x1);
                height = Math.Abs(MousePosition.Y - y1);
                g = CreateGraphics();
                g.Clear(BackColor);
                g.FillRectangle(Brushes.DarkBlue, x1<MousePosition.X?x1:MousePosition.X, y1<MousePosition.Y?y1:MousePosition.Y, width + 1, height + 1);
            }




            //form5.setPic((int)x, (int)y);
            //form5.Show();
            if (Program.useMag&& needMag)
            {
                form5.setPic(e.X, e.Y);
            }
        }

        //private void setPic(int x, int y)
        //{

        //    System.Drawing.Bitmap bitmap = new Bitmap(100, 100);
        //    using (System.Drawing.Graphics graphics = Graphics.FromImage(bitmap))
        //    {
        //        graphics.CopyFromScreen(x - 50, y - 50, 0, 0, new System.Drawing.Size(100, 100));

        //    }

        //    pictureBox1.Image = bitmap;

        //   // Size newSize = new Size(pictureBox1.Size.Width + 20, pictureBox1.Size.Height + 50);
        //   // this.Size = newSize;
        //}

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            x2 = MousePosition.X + 1;
            y2 = MousePosition.Y + 1;
            if (Program.useMag && needMag)
            {                
                form5.Hide();
                form5.Close();
            }
            this.Hide();
            this.Close();
            
            //formMain.pcurrentWin.Snap(x < nowX ? x : nowX, y < nowY ? y : nowY, Math.Abs(nowX - x), Math.Abs(nowY - y));
            MainForm.pcurrentWin.Snap(x1,y1,x2,y2);
            MainForm.pcurrentWin.Show();
           
        }

    }
}
