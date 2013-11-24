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
    class Animation:Drawing
    {
        protected AnimationPoints points;
        int frame = 0;
        int frequencyChanged;
        int lastChanged = 0;


        public Animation(string floorName, string spriteName, Rectangle destinationRectangle, Rectangle sourceRectangle, float rotation, Vector2 origin, SpriteEffects effects, int frequencyChanged)
            : base(floorName, spriteName, destinationRectangle, sourceRectangle, rotation, origin, effects)
        {
            this.frequencyChanged = frequencyChanged;

            Initialize();
        }

        public void Initialize()
        {
            points = new AnimationPoints(base.texture);
            lastChanged = frequencyChanged - 1;
        }

        public void Initialize(Texture2D texture)
        {
            points = new AnimationPoints(texture);
            lastChanged = frequencyChanged - 1;
        }

        public void Update()
        {
            lastChanged++;

            if (lastChanged == frequencyChanged)
            {
                frame++;

                frame = frame % (points.sourceRectangles.Count);

                sourceRectangle = points.sourceRectangles[frame];

                if(effects == SpriteEffects.None) origin = points.origins[frame];
                else origin = points.flippedOrigins[frame];

                lastChanged = 0;
            }
        }

        public void Animate()
        {
            Update();

            base.Draw();
        }
    }
}
