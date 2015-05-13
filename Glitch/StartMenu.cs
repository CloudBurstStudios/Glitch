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
    class StartMenu
    {
        //attributes
        KeyboardState kState;
        Color color1 = Color.White;
        Color color2 = Color.Black;
        Color color3 = Color.Black;
        int x1 = 280;
        int x2 = 485;
        int y1 = 200;
        int y2 = 240;
        SpriteEffects spritEffects = SpriteEffects.None;
        bool[] dir = { false, false };

        //updates the menu
        public void UpdateMenu()
        {
            // sets up and down directions for keyboard
            kState = Keyboard.GetState();
            dir[0] = kState.IsKeyDown(Keys.W);
            dir[1] = kState.IsKeyDown(Keys.S);

            //if statements used to
            //switch between new game and quit game
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
        }

        //draws the text on screen
        protected void DrawText(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font,
                "gLiTcH",
                new Vector2(325, 50),
                Color.Black,
                0f,
                new Vector2(0, 0),
                1.5f,
                spritEffects,
                0);

            spriteBatch.DrawString(font,
                "New Game",
                new Vector2(300, 200),
                color1,
                0f,
                new Vector2(0, 0),
                1.25f,
                spritEffects,
                0);

            spriteBatch.DrawString(font,
                "Instructions",
                new Vector2(295, 275),
                color2,
                0f,
                new Vector2(0, 0),
                1.25f,
                spritEffects,
                0);

            spriteBatch.DrawString(font,
                "Quit Game",
                new Vector2(300, 350),
                color3,
                0f,
                new Vector2(0, 0),
                1.25f,
                spritEffects,
                0);

            spriteBatch.End();
        }

        //draws the selection lines on screen
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

        //method to draw line
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

        //draws the entire menu
        public void DrawMenu(SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D texture)
        {
            DrawText(spriteBatch,spriteFont);
            DrawLine(spriteBatch, texture);
        }

        //bool used to start the game
        public bool StartGame()
        {
            if (kState.IsKeyDown(Keys.Space) == true && y1 == 200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //bool used to show instructions
        public bool Instructions()
        {
            if (kState.IsKeyDown(Keys.Space) == true && y1 == 275)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //used to quit the game
        public bool EndGame()
        {
            if (kState.IsKeyDown(Keys.Space) == true && y1 == 350)
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
