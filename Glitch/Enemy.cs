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
using System.Diagnostics;

namespace Glitch
{
    class Enemy : Entity
    {
        //attributes
        private Bullet enemyBullet;
        private List<Vector2> enemyPositions = new List<Vector2>();
        private Tuple<int, int> roomNo;
        private Random rgen = new Random();
        private int speed;

        //properties

        public Tuple<int, int> RoomNo
        {
            get { return roomNo; }
        }



        // property
        public Bullet EnemyBullet
        {
            get { return enemyBullet; }
            set { enemyBullet = value; }
        }

        //constructor
        public Enemy(Vector2 pos, Rectangle cd, int dir, Bullet b, Tuple<int,int> room, int spd)
            : base(pos, cd, dir)
        {
            roomNo = room;
            enemyBullet = b;
            isActive = true;
            direction = dir;
            speed = spd;
        }

        public override void Move()
        {
            switch (direction)
            {
                case 0: //up
                    position.Y -= speed;
                    break;
                case 1: //right
                    position.X += speed;
                    break;
                case 2: //down
                    position.Y += speed;
                    break;
                case 3: //left
                    position.X -= speed;
                    break;
            }

            if (position.Y < 20)
            {
                direction = 2;
            }

            if (position.Y > 345)
            {
                direction = 0;
            }

            if (position.X < 65)
            {
                direction = 1;
            }

            if (position.X > 680)
            {
                direction = 3;
            }


            

        }

        public void Fire()
        {
            if (!enemyBullet.IsActive)
            {
                enemyBullet.Direction = this.Direction;
                enemyBullet.Position = this.Position;
                enemyBullet.IsActive = true;
            }
        }

        public override void Draw(Texture2D sprite, SpriteBatch sb)
        {
                sb.Begin();
                    //sb.Draw(sprite, position, new Rectangle(0, 0, sprite.Width, sprite.Height), Color.White, 0, position, 0.1f, spriteEffects, 0);
                sb.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, (int)(sprite.Width * 0.1), (int)(sprite.Height * 0.1)), Color.White);
                sb.End();
        }
    }
}
