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
    class Trap : GamePiece
    {
        private Tuple<int, int> room;

        public Tuple<int,int> Room
        {
            get { return room; }
        }

        //constructor
        public Trap(Vector2 pos, Rectangle cd, Tuple<int,int> roomNo):base(pos, cd)
        {
            position = pos;
            room = roomNo;
        }

        public override void Draw(Texture2D sprite, SpriteBatch sb)
        {
            sb.Begin();
            sb.Draw(sprite, position, Color.White);
            sb.End();
        }
    }
}
