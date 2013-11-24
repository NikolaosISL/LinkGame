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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player myPlayer;
        Ground myGround;
        CollisionCheck myCollisionCheck;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Tools.Content = this.Content;
            Tools.spriteBatch = this.spriteBatch;

            myCollisionCheck = new CollisionCheck();

            List<Animation> animations = new List<Animation>();
            List<string> names = new List<string>();
            animations.Add(new Animation("PlayerSprites", "Contra_stand", new Rectangle(200, 100, 25, 40), new Rectangle(0, 0, 0, 0), 0.0f, new Vector2(0, 0), SpriteEffects.None, 10));
            animations.Add(new Animation("PlayerSprites", "Contra_run", new Rectangle(200, 100, 25, 40), new Rectangle(0, 0, 0, 0), 0.0f, new Vector2(0, 0), SpriteEffects.None, 10));
            animations.Add(new Animation("PlayerSprites", "Contra_jump", new Rectangle(200, 100, 23, 23), new Rectangle(0, 0, 0, 0), 0.0f, new Vector2(0, 0), SpriteEffects.None, 10));
            names.Add("stand");
            names.Add("run");
            names.Add("jump");

            myPlayer = new Player(animations, names);
            myGround = new Ground();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            Tools.keyBoardState = Keyboard.GetState();
            myCollisionCheck.CheckGround_Player(myPlayer, myGround);
            myPlayer.Update();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            myGround.Draw();
            myPlayer.Animate();

            base.Draw(gameTime);
        }
    }
}
