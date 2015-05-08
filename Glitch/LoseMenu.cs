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
using System.Threading;

namespace Glitch
{
    class LoseMenu
    {
        KeyboardState kState;
        Color color1 = Color.White;
        Color color2 = Color.Black;
        int x1 = 280;
        int x2 = 485;
        int y1 = 260;
        int y2 = 310;
        SpriteEffects spritEffects = SpriteEffects.None;
        bool[] dir = { false, false };

        public void UpdateMenu()
        {
            kState = Keyboard.GetState();
            dir[0] = kState.IsKeyDown(Keys.W);
            dir[1] = kState.IsKeyDown(Keys.S);

            if (y1 == 260)
            {
                if (dir[1])
                {
                    x1 = 280;
                    x2 = 485;
                    y1 = 365;
                    y2 = 415;
                    color1 = Color.Black;
                    color2 = Color.White;
                    Thread.Sleep(100);
                }
            }

            else if (y1 == 365)
            {
                if (dir[0])
                {
                    x1 = 280;
                    x2 = 485;
                    y1 = 260;
                    y2 = 310;
                    color2 = Color.Black;
                    color1 = Color.White;
                    Thread.Sleep(100);
                }
            }
        }

        protected void DrawText(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font,
                "You Lose...",
                new Vector2(265, 50),
                Color.Black,
                0f,
                new Vector2(0, 0),
                2f,
                spritEffects,
                0);

            spriteBatch.DrawString(font,
                "Play Again?",
                new Vector2(285, 160),
                Color.Black,
                0f,
                new Vector2(0, 0),
                1.5f,
                spritEffects,
                0);

            spriteBatch.DrawString(font,
                "New Game",
                new Vector2(300, 260),
                color1,
                0f,
                new Vector2(0, 0),
                1.25f,
                spritEffects,
                0);

            spriteBatch.DrawString(font,
                "Quit Game",
                new Vector2(300, 365),
                color2,
                0f,
                new Vector2(0, 0),
                1.25f,
                spritEffects,
                0);

            spriteBatch.End();
        }

        protected void DrawLine(SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Begin();

            Line(spriteBatch, //draw line
           new Vector2(x1, y1), //start of line
           new Vector2(x2, y1), //end of line
               texture
           );

            Line(spriteBatch, //draw line
           new Vector2(x2, y1), //start of line
           new Vector2(x2, y2), //end of line
           texture
           );

            Line(spriteBatch, //draw line
           new Vector2(x1, y2), //start of line
           new Vector2(x2, y2), //end of line
           texture
           );

            Line(spriteBatch, //draw line
           new Vector2(x1, y1), //start of line
           new Vector2(x1, y2), //end of line
           texture
           );

            spriteBatch.End();
        }

        void Line(SpriteBatch sb, Vector2 start, Vector2 end, Texture2D t)
        {
            Vector2 edge = end - start;
            // calculate angle to rotate line
            float angle =
                (float)Math.Atan2(edge.Y, edge.X);


            sb.Draw(t,
                new Rectangle(// rectangle defines shape of line and position of start of line
                    (int)start.X,
                    (int)start.Y,
                    (int)edge.Length(), //sb will strech the texture to fill this rectangle
                    1), //width of line, change this to make thicker line
                null,
                Color.White, //colour of line
                angle,     //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);
        }

        public void DrawMenu(SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D texture)
        {
            DrawText(spriteBatch, spriteFont);
            DrawLine(spriteBatch, texture);
        }

        public bool StartGame()
        {
            if (kState.IsKeyDown(Keys.Space) == true && y1 == 260)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EndGame()
        {
            if (kState.IsKeyDown(Keys.Space) == true && y1 == 365)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
