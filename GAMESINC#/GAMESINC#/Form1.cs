using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAMESINC_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }
        int ballX = 4;
        int ballY = 4;
        int points = 0;
        private void ball_method()
        {
            ball.Left += ballX;
            ball.Top += ballY;
            if(ball.Left+ball.Width > ClientSize.Width || ball.Left < 0)
            {
                ballX = -ballX;
            }
            if(ball.Bounds.IntersectsWith(player.Bounds) || ball.Top<0)
            {

                ballY = -ballY;
            }
            if (ball.Bounds.IntersectsWith(Bl.Bounds) || ball.Bounds.IntersectsWith(pictureBox21.Bounds)
              || ball.Bounds.IntersectsWith(pictureBox22.Bounds)|| ball.Bounds.IntersectsWith(pictureBox23.Bounds))
            {
                ballY=-ballY;
            }
        }
        private void end_msg()
        {
            if(ball.Top+ball.Height >ClientSize.Height)
            {
                timer1.Stop();
                MessageBox.Show("Try AGain :( ");

            }
        }
        private void box_functions()
        {
            foreach(Control control in this.Controls) { 
                if(control is PictureBox && control.Tag == "block")
                {
                    if (ball.Bounds.IntersectsWith(control.Bounds))
                    {
                      Controls.Remove(control);
                        points++;
                        label1.Text = "Points: " + points;
                        if (points == 20)
                        {
                            timer1.Stop();
                            MessageBox.Show("WINNER ");
                        }
                    }
                }
            
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && player.Left >0) {
                player.Left -=8 ;
            
            }
            if (e.KeyCode == Keys.Right && player.Right < 360)
            {
                player.Left += 8;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball_method();
            box_functions();
            end_msg();
        }
    }
}
