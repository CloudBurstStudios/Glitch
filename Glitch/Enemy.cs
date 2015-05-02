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
    class Enemy : Entity
    {
        //attributes
        private Bullet enemyBullet;
        private SpriteEffects spriteEffects;
        private List<Vector2> enemyPositions = new List<Vector2>();
        private Tuple<int, int> roomNo;
        private Random rgen = new Random();

        private bool isAlive;

        //properties
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

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
        public Enemy(Vector2 pos, Rectangle cd, int dir, Bullet b, Tuple<int,int> room)
            : base(pos, cd, dir)
        {
            roomNo = room;
            enemyBullet = b;
            isAlive = true;
        }

        public override void Move()
        {
            if (position.X <= 75)
            {
                direction = 1;
                position.X++;
            }
            if (position.X >= 920)
            {
                direction = 3;
                position.X--;
            }

            switch (direction)
            {
                case 1: //right
                    position.X += 5;
                    spriteEffects = SpriteEffects.None;
                    break;
                case 3: //left
                    position.X -= 5;
                    spriteEffects = SpriteEffects.FlipHorizontally;
                    break;
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
                    sb.Draw(sprite, position, new Rectangle(0, 0, sprite.Width, sprite.Height), Color.White, 0, position, 0.1f, spriteEffects, 0);
                sb.End();
        }
    }
}
