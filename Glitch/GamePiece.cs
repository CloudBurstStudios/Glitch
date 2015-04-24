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
        //collision rectangle x, y, width, height
        Rectangle colldetect;

        //properties
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Rectangle CollDetect
        {
            get { return colldetect; }
            set { colldetect = value; }
        }

        //constructor                                                                         
        public GamePiece(Vector2 pos, Rectangle cd)
        {
            position = pos;
            colldetect = cd;
        }

        //Method to check for collisions between game pieces
        public bool CheckCollision(GamePiece other)
        {
            if (this.CollDetect.Intersects(other.CollDetect))
            {
                return true;
            }
            return false;
        }


        //Abstract method for drawing GamePieces
        public abstract void Draw(Texture2D sprite, SpriteBatch sb);

        public override string ToString()
        {
            return "rectangle: " + colldetect;
        }

    }
}

