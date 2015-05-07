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
    class Bullet:MoveableGamePiece
    {
        //constructor
        public Bullet(Vector2 pos, Rectangle cd, int dir)
            : base(pos, cd, dir)
        {
            isActive = false;
        }

        public override void Move()
        {
            //Breaks out of method if bullet is not active
            if (!this.isActive) return;

            //moves bullet based on direction
            switch (direction)
            {
                case 0: //up
                    position.Y -= 10; break;
                case 1: //right
                    position.X += 10; break;
                case 2: //down
                    position.Y += 10; break;
                case 3: //left
                    position.X -= 10; break;
            }

            //checks to see if it has gone off the edge
            if (position.X > GameVariables.WINDOW_WIDTH || position.Y > GameVariables.WINDOW_HEIGHT || position.X < 0 || position.Y < 0)
            {
                this.isActive = false;
            }
        }

        //draws the bullet
        public override void Draw(Texture2D sprite, SpriteBatch sb)
        {

            //does nothing if bullet is not active
            if (!this.isActive) return;

            sb.Begin();
            switch (direction)
            {
                case 0:
                    sb.Draw(sprite, position, new Rectangle(0, 0, sprite.Width, sprite.Height), Color.White, (float)(Math.PI / 2), position, 0.03f, SpriteEffects.None, 0);
                    break;
                case 1:
                    sb.Draw(sprite, position, new Rectangle(0, 0, sprite.Width, sprite.Height), Color.White, (float)(Math.PI), position, 0.03f, SpriteEffects.None, 0);
                    break;
                case 2:
                    sb.Draw(sprite, position, new Rectangle(0, 0, sprite.Width, sprite.Height), Color.White, (float)(1.5 * Math.PI), position, 0.03f, SpriteEffects.None, 0);
                    break;
                case 3:
                    sb.Draw(sprite, position, new Rectangle(0, 0, sprite.Width, sprite.Height), Color.White, 0, position, 0.03f, SpriteEffects.None, 0);
                    break;
            }
            sb.End();

        }
    }
}
