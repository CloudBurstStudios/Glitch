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
    //Represents a GamePiece which can also move
    abstract class MoveableGamePiece:GamePiece
    {
        //Direction attribute and property
        protected int direction;

        public int Direction
        {
            get { return direction; }
            set { 
                if (value <= 3 && value >= 0)
                {
                direction = value;
                }
                }
        }

        //constructor
        public MoveableGamePiece(Vector2 pos, int dir):base(pos)
        {
            direction = dir;
        }

        //Method for moving the GamePiece
        public abstract void Move();

    }
}
