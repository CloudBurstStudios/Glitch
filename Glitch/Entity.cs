﻿using System;
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
    abstract class Entity:MoveableGamePiece
    {
        //attributes
        protected int health;
        protected int lives;

        //properties
        public int Health
        {
            get { return health; }
            set { health = value < 0 ? 0 : value; }
        }

        public int Lives
        {
            get { return lives; }
            set { lives = value < 0 ? 0 : value; }
        }

        //constructor
        public Entity(Vector2 pos, int dir, int hth, int lvs, int dam):base(pos, dir)
        {
            health = hth;
            lives = lvs;
        }

        public abstract override void Move();
        public abstract override void Draw(Texture2D sprite, SpriteBatch sb);

    }
}