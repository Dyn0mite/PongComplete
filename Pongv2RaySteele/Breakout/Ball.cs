/*{ -----------------------------------------------------------------------------------------
			Pong Ball Class
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

 
 ------------------------------------------------------------------------------------------
			Code space
 ------------------------------------------------------------------------------------------}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Breakout
{
    class Ball
    {
        private int x, y, width, height;
        private int xspeed, yspeed;
        private Random randSpeed;

        private Image ballImage;
        private Rectangle ballRec;

        private Size clientSize;

        public Ball(Size clientSize)
        {// ball constructor


            x = clientSize.Width / 2;
            y = clientSize.Height / 2;
            width = 10;
            height = 10;

            randSpeed = new Random();
            xspeed = randSpeed.Next(1, 5);
            yspeed = randSpeed.Next(1, 5);
            this.clientSize = clientSize;

            // file extn 
            ballImage = Image.FromFile(@"c:\\Users\Chuck\Desktop\School\Programming 2\Pongv2\Breakout\Resources\Circle.png");

            ballRec = new Rectangle(x, y, width, height);
        }

        //method draws ball on Graphics 'paper'
        public void DrawBall(Graphics paper)
        {
            paper.DrawImage(ballImage, ballRec);
        }

        //method moves ball
        public void MoveBall()
        {// 
            ballRec.X += xspeed;
            ballRec.Y += yspeed;

        }

        //method bounces ball off bottom and top walls.
        public void CollideWall(Rectangle ballRec)
        {
            //if (ballRec.X < 0 || ballRec.X + ballRec.Width > clientSize.Width)
            //{
            //    xspeed *= -1;
            //}
            if (ballRec.Y < 0 || ballRec.Y + ballRec.Height > clientSize.Height)
            {//for top wall         for 'bottom' wall
                yspeed *= -1;
            }
        
        }

        //method bounces ball off paddle.
        public void HitPaddle(Rectangle paddleRec)
        {
            if (paddleRec.IntersectsWith(ballRec))
            {
                yspeed *= -1;
                xspeed *= -1;
            }

        }

        //ppty to read
         public Rectangle BallRec
        {
            get { return ballRec; }

        }
        
        //set get xspeed and yspeed? to send to engine
        
        
        
     
    }
}
