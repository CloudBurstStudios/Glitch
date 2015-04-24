using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Glitch
{
    //represents a wall
    class Wall : GamePiece
    {
        //constructor
        public Wall(Vector2 pos, Rectangle cd) : base(pos, cd)
        { }


        public override void Draw(Texture2D sprite, SpriteBatch sb)
        {
            sb.Begin();

            sb.End();
        }
    }
}
