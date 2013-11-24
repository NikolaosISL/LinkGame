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
    class Ground
    {
        Texture2D texture;
        public List<Rectangle> rectangleList = new List<Rectangle>();

        public Ground()
        {
            string spriteName = "Contra_top_block";
            string floorName = "GameSprites";
            texture = Tools.Content.Load<Texture2D>(floorName + "/" + spriteName);

            Rectangle rectangle = new Rectangle(0, 300, 200, 1);
            rectangleList.Add(rectangle);

            rectangle = new Rectangle(250, 200, 200, 1);
            rectangleList.Add(rectangle);
        }

        public void Draw()
        {
            Tools.spriteBatch.Begin();
            foreach (Rectangle rec in rectangleList)
            {
                for (int i = rec.X; i < rec.Width + rec.X; i += texture.Width)
                {
                    Tools.spriteBatch.Draw(texture, new Rectangle(i, rec.Y, texture.Width, texture.Height), new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0.0f);
                }
            }

            Tools.spriteBatch.End();
        }
    }
}
