using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace LinkGame
{
    class CollisionCheck
    {


        public CollisionCheck()
        {

        }

        public void CheckGround_Player(Player myPlayer, Ground myGround)
        {
            myPlayer.isFalling = true;

            foreach (Rectangle rec in myGround.rectangleList)
            {
                if (myPlayer.position.X > rec.X && (myPlayer.position.X < rec.X + rec.Width))
                {
                    if (rec == myGround.rectangleList[1])
                    {

                    }
                    if (myPlayer.position.Y > rec.Top)
                    {
                        myPlayer.isFalling = false;
                        myPlayer.direction.Y = 0;
                    }
                }
            }

        }

    }
}
