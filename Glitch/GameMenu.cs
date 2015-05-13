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
