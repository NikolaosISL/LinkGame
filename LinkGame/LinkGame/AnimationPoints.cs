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
    class AnimationPoints
    {
        public Texture2D texture;
        public List<int> xDotsPositions = new List<int>();
        public List<Rectangle> sourceRectangles = new List<Rectangle>();
        public List<Vector2> origins = new List<Vector2>();
        public List<Vector2> flippedOrigins = new List<Vector2>();
        
        public AnimationPoints(Texture2D texture)
        {
            this.texture = texture;
            Initialize();
        }

        public void Initialize()
        {
            FindDots();
            FindRectangles();
            FindOrigins();
            MakeTransparent();
        }

        private void FindDots()
        {
            Color[] colors = new Color[texture.Width];
            Rectangle lowestRectangle = new Rectangle(0, texture.Height - 1, texture.Width, 1);

            texture.GetData<Color>(0, lowestRectangle, colors, 0, texture.Width);

            for (int i = 0; i < texture.Width; i++)
            {
                if (colors[i] == colors[0]) xDotsPositions.Add(i);
            }

        }

        private void FindRectangles()
        {
            Rectangle currentRectangle;

            for (int i = 0; i < xDotsPositions.Count - 2; i += 2)
            {
                currentRectangle = new Rectangle(xDotsPositions[i], 0, xDotsPositions[i + 2] - xDotsPositions[i], texture.Height - 1);
                sourceRectangles.Add(currentRectangle);
            }
        }

        private void FindOrigins()
        {
            Vector2 currentOrigin;

            for (int i = 0; i < xDotsPositions.Count - 2; i += 2)
            {
                currentOrigin = new Vector2(xDotsPositions[i + 1] - xDotsPositions[i], texture.Height - 1);
                origins.Add(currentOrigin);

                currentOrigin = new Vector2(xDotsPositions[i + 2] - xDotsPositions[i + 1], texture.Height - 1);
                flippedOrigins.Add(currentOrigin);
            }
        }

        private void MakeTransparent()
        {
            Color[] colors = new Color[texture.Width * texture.Height];
            texture.GetData<Color>(colors);

            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == colors[0]) colors[i] = Color.Transparent;
            }

            texture.SetData<Color>(colors);
        }

    }
}
