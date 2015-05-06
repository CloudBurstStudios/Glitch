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
        protected Vector2 p1 = new Vector2(500, 340);
        protected Vector2 p2 = new Vector2(200, 300);
        protected Vector2 p3 = new Vector2(120, 152);
        protected Vector2 p4 = new Vector2(300, 68);
        protected Vector2 p5 = new Vector2(570, 88);

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
            sb.Draw(sprite, p1, Color.White);
            sb.Draw(sprite, p2, Color.White);
            sb.Draw(sprite, p3, Color.White);
            sb.Draw(sprite, p4, Color.White);
            sb.Draw(sprite, p5, Color.White);
            sb.End();
        }
    }
}
