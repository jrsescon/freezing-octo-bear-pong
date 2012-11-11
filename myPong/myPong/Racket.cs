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
    class Racket
    {
        public int x;
        public int y;
        public int speed;
        public int upLim;
        public int botLim;
        public Rectangle rec;

        public Racket(int ex, int ey, int espeed, int euLim, int ebLim)
        {
            x = ex;
            y = ey;
            speed = espeed;
            upLim = euLim;
            botLim = ebLim;
            rec = new Rectangle(x, y, 20, 60);
        }

        public void moveUp()
        {
            if (y > upLim)
            {
                y = y - speed;
                rec.Y = y;
            }
        }

        public void moveDown()
        {
            if (y+50 < botLim)
            {
                y = y + speed;
                rec.Y = y;
            }
        }

        public Rectangle getRectangle()
        {
            return rec;
        }
    }
}
