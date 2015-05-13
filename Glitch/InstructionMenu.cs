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
    class InstructionMenu
    {
        //attribute for the keyboard input
        KeyboardState kState;

        //draws text for instructions
        protected void DrawText(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(font,
                "Instructions:",
                new Vector2(295, 50),
                Color.Black,
                0f,
                new Vector2(0, 0),
                1.5f,
                SpriteEffects.None,
                0);

            spriteBatch.DrawString(font,
                "Move with WASD",
                new Vector2(50, 175),
                Color.Black,
                0f,
                new Vector2(0, 0),
                1.25f,
                SpriteEffects.None,
                0);

            spriteBatch.DrawString(font,
               "P to Pause",
               new Vector2(320, 275),
               Color.Black,
               0f,
               new Vector2(0, 0),
               1.25f,
               SpriteEffects.None,
               0);

            spriteBatch.DrawString(font,
                "Shoot with Space",
                new Vector2(475, 175),
                Color.Black,
                0f,
                new Vector2(0, 0),
                1.25f,
                SpriteEffects.None,
                0);

            spriteBatch.DrawString(font,
                "Destroy All the Enemies",
                new Vector2(225, 370),
                Color.Black,
                0f,
                new Vector2(0, 0),
                1.25f,
                SpriteEffects.None,
                0);

            spriteBatch.DrawString(font,
                "on the Floor to Win!",
                new Vector2(250, 400),
                Color.Black,
                0f,
                new Vector2(0, 0),
                1.25f,
                SpriteEffects.None,
                0);

            spriteBatch.End();
        }

        //draws the menu on screen
        public void DrawMenu(SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D texture)
        {
            DrawText(spriteBatch, spriteFont);
        }

        //bool used to switch game states
        public bool DoneWithInstructions()
        {
            if (kState.GetPressedKeys().Length > 0)
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
