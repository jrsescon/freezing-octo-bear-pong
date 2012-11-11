using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace myPong
{
    class Ball
    {
        public int defX;
        public int defY;
        public int curX;
        public int curY;
        public int vX;
        public int vY;
        public Rectangle rec;

        public Ball(int dx, int dy)
        {
            defX = dx;
            defY = dy;
            curX = defX;
            curY = defY;
            vY = 1;
            vX = 1;
            rec = new Rectangle(curX, curY, 10, 10);

        }

        public void reset()
        {
            curX = defX;
            curY = defY;
            vY = 1;
            vX = 1;
        }

        public void update()
        {

            curX = curX + vX;
            curY = curY + vY;

            rec.X = curX;
            rec.Y = curY;
        }

        public void relfectX()
        {
            vX = -vX;
        }

        public void reflectY()
        {
            vY = -vY;
        }

        public Rectangle getRectangle()
        {
            return rec;
        }
    }
}
