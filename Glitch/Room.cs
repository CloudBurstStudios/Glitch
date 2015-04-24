using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glitch
{
    //Represents an individual room in the level
    class Room
    {
        //attributes
        private Room left;
        private Room right;
        private Room up;
        private Room down;
        private int posX;
        private int posY;

        //properties
        public Room Left
        {
            get { return left; }
            set { left = value; }
        }

        public Room Right
        {
            get { return right; }
            set { right = value; }
        }

        public Room Up
        {
            get { return up; }
            set { up = value; }
        }

        public Room Down
        {
            get { return down; }
            set { down = value; }
        }

        public int PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        public int PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        //constructor
        public Room(int pX, int pY)
        {
            up = null;
            down = null;
            left = null;
            right = null;
            posX = pX;
            posY = pY;
        }
    }
}
