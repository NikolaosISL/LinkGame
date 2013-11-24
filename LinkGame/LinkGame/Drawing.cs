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
    class Drawing
    {
        protected Texture2D texture;
        public Rectangle destinationRectangle;
        protected Rectangle sourceRectangle;
        protected Vector2 origin;
        public SpriteEffects effects;
        protected float rotation;

        public Drawing(string floorName, string spriteName, Rectangle destinationRectangle, Rectangle sourceRectangle, float rotation, Vector2 origin, SpriteEffects effects)
        {
            texture = Tools.Content.Load<Texture2D>(floorName + "/" + spriteName);
            this.destinationRectangle = destinationRectangle;
            this.sourceRectangle = sourceRectangle;
            this.rotation = rotation;
            this.origin = origin;
            this.effects = effects;
        }

        public void Draw()
        {
            Tools.spriteBatch.Begin();
            Tools.spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, rotation, origin, effects, 0.0f);
            Tools.spriteBatch.End();
        }
    }
}
