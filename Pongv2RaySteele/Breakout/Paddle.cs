/*{ -----------------------------------------------------------------------------------------
			Pong Paddle Class
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
    class Paddle
    {
        //const

        //private cont int PHEIGHT = 60;
        //private cont int BHEIGHT = 60;

        private int x, y, width, height;

        private Image paddleImage;
        private Rectangle paddleRec;


        public Paddle(int x, int y, int width, int height)
        {//paddle constructor
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            y = 0;//changes y position of paddle 
            width = 7;  //turn to const
            height = 60; //turn to const
            // file extn 
            paddleImage = Image.FromFile(@"c:\\Users\Chuck\Desktop\School\Programming 2\Pongv2\Breakout\Resources\Paddle.png");

            paddleRec = new Rectangle(x, y, width, height);
        }

        //method draws paddle to send to engine                
        public void DrawPaddle(Graphics paper)
        {
            paper.DrawImage(paddleImage, paddleRec);
        }

        //method moves paddle                         
        public void MovePaddle(int mouseY)
        {
            paddleRec.Y = mouseY - (paddleRec.Height / 2);

        
        }
        //pptys
        //so can be accessed in form
        public Rectangle PaddleRec
        {
            get { return paddleRec; }
            set { paddleRec = value; }

        }
    }
}
