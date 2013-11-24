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
    class Player
    {
        public Vector2 position;
        public Vector2 direction;
        Dictionary<string, Animation> animations;
        public Animation currentAnimation;

        int timePassed = 0;
        public bool isFalling = false;

        public Player()
        {
            animations = new Dictionary<string, Animation>();
            direction = new Vector2(0, 0);
            position = new Vector2(200, 200);
        }

        public Player(List<Animation> animationList, List<string> nameList)
        {
            animations = new Dictionary<string, Animation>();
            direction = new Vector2(0, 0);
            position = new Vector2(50, 50);


            for (int i = 0; i < animationList.Count; i++)
            {
                animations.Add(nameList[i], animationList[i]);
            }
        }

        public void Update()
        {
            UpdateMovement();
            UpdateAnimation();
            timePassed = 0;
            if(isFalling) Gravity();

            position += direction;

            timePassed++;
        }

        public void UpdateMovement()
        {
            if(Tools.keyBoardState.IsKeyDown(Keys.Right))
            {
                direction.X = 5;
            }
            else if(Tools.keyBoardState.IsKeyDown(Keys.Left))
            {
                direction.X = -5;
            }
            else
            {
                direction.X = 0;
            }

            if(Tools.keyBoardState.IsKeyDown(Keys.Up) && !isFalling)
            {
                direction.Y = -20;
            }
        }

        public void UpdateAnimation()
        {
            if(isFalling)
            {
                currentAnimation = animations["jump"];
            }
            else if (direction.X == 0)
            {
                currentAnimation = animations["stand"];
            }
            else if (direction.X > 0)
            {
                currentAnimation = animations["run"];
                foreach (Animation animation in animations.Values.ToArray<Animation>())
                {
                    animation.effects = SpriteEffects.None;
                }
            }
            else if (direction.X < 0)
            {
                currentAnimation = animations["run"];
                foreach (Animation animation in animations.Values.ToArray<Animation>())
                {
                    animation.effects = SpriteEffects.FlipHorizontally;
                }
            }
        }

        public void Gravity()
        {
            direction.Y += 1;
        }

        public void Animate()
        {
            currentAnimation.destinationRectangle.X = (int)position.X;
            currentAnimation.destinationRectangle.Y = (int)position.Y;

            currentAnimation.Animate();
        }
    }
}
