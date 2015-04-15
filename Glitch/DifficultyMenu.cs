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
    class DifficultyMenu
    {
        KeyboardState kState;
        Color color1 = Color.White;
        Color color2 = Color.Black;
        Color color3 = Color.Black;
        int x1 = 300;
        int x2 = 475;
        int y1 = 190;
        int y2 = 250;
        SpriteEffects spritEffects = SpriteEffects.None;
        bool[] dir = { false, false };

        public void UpdateMenu()
        {
            kState = Keyboard.GetState();
            dir[0] = kState.IsKeyDown(Keys.Up);
            dir[1] = kState.IsKeyDown(Keys.Down);
            if (y1 == 190)
            {
                if (dir[1])
                {
                    y1 = 265;
                    y2 = 325;
                    color1 = Color.Black;
                    color2 = Color.White;
                    Thread.Sleep(100);
                }
            }

            else if (y1 == 265)
            {
                if (dir[0])
                {
                    y1 = 190;
                    y2 = 250;
                    color2 = Color.Black;
                    color1 = Color.White;
                    Thread.Sleep(100);
                }
                else if (dir[1])
                {
                    y1 = 340;
                    y2 = 400;
                    color2 = Color.Black;
                    color3 = Color.White;
                    Thread.Sleep(100);
                }
            }

            else if (y1 == 340)
            {
                if (dir[0])
                {
                    y1 = 265;
                    y2 = 325;
                    color3 = Color.Black;
                    color2 = Color.White;
                    Thread.Sleep(100);
                }
            }
        }

        protected void DrawText(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font,
                "Difficulty",
                new Vector2(300, 50),
                Color.Black,
                0f,
                new Vector2(0, 0),
                1.5f,
                spritEffects,
                0);

            spriteBatch.DrawString(font,
                "Easy",
                new Vector2(345, 200),
                color1,
                0f,
                new Vector2(0, 0),
                1.25f,
                spritEffects,
                0);


            spriteBatch.DrawString(font,
                "Medium",
                new Vector2(325, 275),
                color2,
                0f,
                new Vector2(0, 0),
                1.25f,
                spritEffects,
                0);

            spriteBatch.DrawString(font,
                "Hard",
                new Vector2(345, 350),
                color3,
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

        public bool SelectDifficulty()
        {
            if (kState.IsKeyDown(Keys.Enter) == true && (y1 == 340 || y1 == 265 || y1 ==190))
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
