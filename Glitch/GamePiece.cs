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
    abstract class GamePiece
    {
        //attributes
        protected Vector2 position;

        //properties
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        //constructor
        public GamePiece(Vector2 pos)
        {
            position = pos;
        }

        //Method that gets whether the GamePiece is colliding with another
        public bool IsColliding(GamePiece gp)
        {
            return gp.Position == this.Position;
        }

        //Abstract method for drawing GamePieces
        public abstract void Draw(Texture2D sprite, SpriteBatch sb);
    }
}
