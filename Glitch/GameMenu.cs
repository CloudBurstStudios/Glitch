using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Glitch
{
    class GameMenu
    {
        
        SpriteEffects spritEffects = SpriteEffects.None;
        bool[] dir = { false, false };
        private int score = 0;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        /*public void UpdateMenu()
        {
            kState = Keyboard.GetState();
            dir[0] = kState.IsKeyDown(Keys.Up);
            dir[1] = kState.IsKeyDown(Keys.Down);
            if (y1 == 200)
            {
                if (dir[1])
                {
                    x1 = 280;
                    x2 = 485;
                    y1 = 275;
                    y2 = 325;
                    color1 = Color.Black;
                    color2 = Color.White;
                    Thread.Sleep(100);
                }
            }

            else if (y1 == 275)
            {
                if (dir[0])
                {
                    x1 = 280;
                    x2 = 485;
                    y1 = 200;
                    y2 = 240;
                    color2 = Color.Black;
                    color1 = Color.White;
                    Thread.Sleep(100);
                }
                else if (dir[1])
                {
                    x1 = 280;
                    x2 = 485;
                    y1 = 350;
                    y2 = 400;
                    color2 = Color.Black;
                    color3 = Color.White;
                    Thread.Sleep(100);
                }
            }

            else if (y1 == 350)
            {
                if (dir[0])
                {
                    x1 = 280;
                    x2 = 485;
                    y1 = 275;
                    y2 = 325;
                    color3 = Color.Black;
                    color2 = Color.White;
                    Thread.Sleep(100);
                }
            }
        }*/

        public void DrawText(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font,
                "Health: ",
                new Vector2(25, 25),
                Color.Black,
                0f,
                new Vector2(0, 0),
                1f,
                spritEffects,
                0);

            /*spriteBatch.DrawString(font,
                "Laser Charge:",
                new Vector2(25, 400),
                Color.Black,
                0f,
                new Vector2(0, 0),
                1f,
                spritEffects,
                0);*/

            spriteBatch.DrawString(font,
                "Score: " + score,
                new Vector2(600, 25),
                Color.Black,
                0f,
                new Vector2(0, 0),
                1f,
                spritEffects,
                0);

            spriteBatch.End();
        }
    }
}
