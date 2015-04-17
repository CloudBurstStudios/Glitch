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
    //Player Class, used for current player
    class Player : Entity
    {
        //attributes
        private int laserCharge;
        protected bool hasKey;
        private Bullet playerBullet;
        private Texture2D playerFaceUp;
        private Texture2D playerFaceDown;
        private Texture2D playerFaceRight;
        private Texture2D playerFaceLeft;


        //properties
        public int LaserCharge
        {
            get { return laserCharge; }
            private set { laserCharge = value < 0 ? 0 : value; }
        }

        public bool HasKey
        {
            get { return hasKey; }
            set { hasKey = value; }
        }

        public Bullet Bullet
        {
            get { return playerBullet; }
            set { playerBullet = value; }
        }
        //constructor
        public Player(Vector2 pos, Rectangle cd, int dir, int hth, int lvs, int dam, Bullet b, Texture2D fd, Texture2D fu, Texture2D fl, Texture2D fr)
            : base(pos, cd, dir, hth, lvs, dam)
        {
            laserCharge = 100;
            playerBullet = b;
            hasKey = false;
            playerFaceDown = fd;
            playerFaceUp = fu;
            playerFaceLeft = fl;
            playerFaceRight = fr;
        }

        //player fires the laser
        public void Fire()
        {
            if (!playerBullet.IsActive)
            {
                playerBullet.Direction = this.Direction;
                playerBullet.Position = this.Position;
                playerBullet.IsActive = true;
            }
        }

        //Moves the player based on direction
        public override void Move()
        {
            switch (direction)
            {
                case 0: //up
                    position.Y -= 5; break;
                case 1: //right
                    position.X += 5; break;
                case 2: //down
                    position.Y += 5; break;
                case 3: //left
                    position.X -= 5; break;
            }
            // Check the edges
            if (position.X < 75)
                position.X = 75;

            if (position.X >= 920)
                position.X = 920;

            if (position.Y < 20)
                position.Y = 20;

            if (position.Y >= 475)
                position.Y = 475;

        }

        //draws the player
        public override void Draw(Texture2D sprite, SpriteBatch sb)
        {
            sb.Begin();
            //switch statement for player movement
            switch (Direction)
            {
                case 0: //up
                    sb.Draw(playerFaceUp, position, null, Color.White, 0, position, 0.25f, SpriteEffects.None, 0);
                    break;
                case 1: //right
                    sb.Draw(playerFaceRight, position, null, Color.White, 0, position, 0.25f, SpriteEffects.None, 0);
                    break;
                case 2: //down
                    sb.Draw(playerFaceDown, position, null, Color.White, 0, position, 0.25f, SpriteEffects.None, 0);
                    break;
                case 3: //left
                    sb.Draw(playerFaceLeft, position, null, Color.White, 0, position, 0.25f, SpriteEffects.None, 0);
                    break;
            }

            sb.End();
        }
    }
}
