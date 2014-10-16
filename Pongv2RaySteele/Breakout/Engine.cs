/*{ -----------------------------------------------------------------------------------------
			Pong Engine Class
 ------------------------------------------------------------------------------------------

 Program name: 		<<Programming Pong Assignment>>
 Project file name:
 Author:		Raymond S
 Date:	 
 Language:		C#
 Platform:		Microsoft Visual Studio 2010
 Purpose:		<<This game simulates table tennis by using a ball and two paddles. A player scores a point by
 *                  getting the ball to hit the opposite vertical side of the form.>>
 Description:		<<A detailed description of what the program does>>
 Known Bugs:		<<Must be commented out, your program MUST compile>>
 Additional Features:
        use for as much as you can instead of form.
 
 ------------------------------------------------------------------------------------------
			Code space
 ------------------------------------------------------------------------------------------}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Breakout
{

    public class Engine
    {
        private int pscore, cscore = 0;

        private Paddle paddle1, paddle2;
        private Ball ball;//extra func, ball array for multi balls?
        private Size clientSize;

        public Engine(Size clientSize)
        {
            this.clientSize = clientSize;
            paddle1 = new Paddle(0, 0, 7, 60);
            paddle2 = new Paddle((clientSize.Width - 6), (clientSize.Height - 6), 7, 60);
            ball = new Ball(clientSize);
        }

        //follows ball, lame a.i
        public void MovePaddle1()
        {
            
            paddle1.MovePaddle(ball.BallRec.Y); 
        }

        //lets user move paddle on right side to deflect ball
        public void MovePaddle2(int mouseY)
        {
            paddle2.MovePaddle(mouseY);
        }

        //main method that calls methods from other classes
        public void Run()
        {
            ball.MoveBall();
            ball.CollideWall(ball.BallRec);
            MovePaddle1();
            ball.HitPaddle(paddle1.PaddleRec);
            ball.HitPaddle(paddle2.PaddleRec);
            AddPoint(ball.BallRec);
        }

        //method below draws paddles, ball and halfwayline to form
        public void Draw(Graphics paper)
        {
            paddle1.DrawPaddle(paper);
            paddle2.DrawPaddle(paper);
            ball.DrawBall(paper);

            paper.DrawLine(Pens.Red, new Point(clientSize.Width/2, 10), new Point(clientSize.Width/2, clientSize.Height-10));//halfway line, ball object goes 
            //behind.
        }

        //method below checks if ball has passed sides of form, if ball has, point awarded and new ball from middle.
        public void AddPoint(Rectangle ballRec)
        {
            if (ballRec.X < 0)
            {
                pscore = pscore +1;
                ball = new Ball(clientSize);
            }

            if (ballRec.X + ballRec.Width> clientSize.Width)
            {
                cscore = cscore + 1;
                ball = new Ball(clientSize);
            }
        }

        //ppty for computer score
        public int Cscore
        {
            get { return cscore; }
            set { cscore = value; }
        }
        //ppty for player score
        public int Pscore
        {
            get { return pscore; }
            set { pscore = value; }
        }
    }
}
