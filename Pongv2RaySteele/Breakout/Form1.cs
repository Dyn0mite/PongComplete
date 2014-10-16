/*{ -----------------------------------------------------------------------------------------
			Pong Form Class
 ------------------------------------------------------------------------------------------

 Program name: 		<<Programming Pong Assignment>>
 Project file name:
 Author:		Raymond S
 Date:	        27/09/2014
 Language:		C#
 Platform:		Microsoft Visual Studio 2010
 Purpose:		<<This game simulates table tennis by using a ball and two paddles. A player scores a point by
 *                  getting the ball to hit the opposite vertical side of the form.>>
 Description:		<<A detailed description of what the program does>>
 Known Bugs:		No known bugs.
 Additional Features:

 
 ------------------------------------------------------------------------------------------
			Code space
 ------------------------------------------------------------------------------------------}
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Breakout
{
    public partial class Form1 : Form
    {
        private Graphics paper;

        private Engine engine;
        
        private Ball ball;//extra func, ball array for multi balls?

        public Form1()
        {
            InitializeComponent();

            engine = new Engine(ClientSize);
            
            ball = new Ball(ClientSize);
        }
        // to paint paddle and ball on form 
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;

            engine.Draw(paper);
        }
        //method used to move paddle on Y axis with mouse.
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            engine.MovePaddle2(e.Y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            engine.Run();
            CheckScore();
            PrintScore();
            this.Invalidate();
        }
        //method below takes score of user and computer and converts it to string and prints it in label to represent score.
        public void PrintScore()
        {
            label1.Text = Convert.ToString(engine.Cscore);
            label2.Text = Convert.ToString(engine.Pscore);
        }
        //method below checks scores and if = 10, turns 'off' timer to stop game.
        public void CheckScore()
        {
           
            if (engine.Cscore == 10)    
            {
                timer1.Enabled = false;
                MessageBox.Show("Computer Wins");
                

            }

            if (engine.Pscore == 10)
            {
                timer1.Enabled = false;
                MessageBox.Show("You Win!");
                
            }

            
        }
        //button to reset game so user can play again.
        private void button1_Click(object sender, EventArgs e)
        {
            
            engine = new Engine(ClientSize);
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
