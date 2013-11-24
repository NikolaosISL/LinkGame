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

#region short cuts
using SB = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using CM = Microsoft.Xna.Framework.Content.ContentManager;
using GD = Microsoft.Xna.Framework.Graphics.GraphicsDevice;
using KS = Microsoft.Xna.Framework.Input.KeyboardState;
#endregion

namespace LinkGame
{
    class Tools
    {
        public static SB spriteBatch;
        public static CM Content;
        public static KS keyBoardState;
    }
}
