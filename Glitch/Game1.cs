#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Glitch
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        

        //Attributes
        KeyboardState kState;
        Texture2D playerFaceUp;
        Texture2D playerFaceRight;
        Texture2D playerFaceDown;
        Texture2D playerFaceLeft;
        Texture2D playerBullet;
        Texture2D enemyBullet;
        Texture2D enemy;
        Texture2D gameWall;
        Texture2D trap;
        Texture2D line;
        SpriteFont menuFont;
        Trap t;
        // trap rectangle
        Rectangle tRect;
        Player p1;
        // player rectangleft
        Rectangle p1Rect;
        Enemy e1;
        // enemy rectangle
        Rectangle e1Rect;
        Bullet b1;
        Bullet b2;

        // bullet rectangles
        Rectangle b1Rect;
        Rectangle b2Rect;
        //List<Wall> walls;
        //List<Enemy> enemyList;
        //List<Trap> trapList;
        //List<Wall> walls;

        StartMenu sMenu;
        PauseMenu pMenu;
        GameMenu gMenu;
        WorldGeneration worldGen;
        ToolLoader tLoader;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            sMenu = new StartMenu();
            pMenu = new PauseMenu();
            gMenu = new GameMenu();

            worldGen = new WorldGeneration();
            tLoader = new ToolLoader();
            GameVariables.ENEMIES = new List<Enemy>();
            GameVariables.TRAPS = new List<Trap>();

            
            //for later usage
            //walls = new List<Wall>();
         

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            kState = Keyboard.GetState();
            //to be able to use the window width and height in other classes
            GameVariables.WINDOW_HEIGHT = GraphicsDevice.Viewport.Height;
            GameVariables.WINDOW_WIDTH = GraphicsDevice.Viewport.Width;

            //Reading the information from the external tool
            tLoader.ReadData();

            //World generation call
            worldGen.GenerateWorld();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //Loads all texure and spritefonts here
            //texture to make lines around menu selection
            line = new Texture2D(GraphicsDevice, 1, 1);
            line.SetData<Color>(new Color[] { Color.White });// fill the texture with white


            menuFont = this.Content.Load<SpriteFont>("mainFont");

            enemyBullet = this.Content.Load<Texture2D>("playerbullet");
            Rectangle b2Rect = new Rectangle(20, 20, enemyBullet.Width, enemyBullet.Height);
            b2 = new Bullet(new Vector2(20, 20), b2Rect, 0, false);
            // b2 = bullet obj (enemy)

            enemy = this.Content.Load<Texture2D>("enemy");

            e1 = new Enemy(new Vector2(0, 250), new Rectangle(0, 250, enemy.Width, enemy.Height), 3, 100, 1, 25, b2, enemy);
            // e1 = enemy obj
            //enemyList.Add(e1);
            // Rectangle
            e1Rect = new Rectangle((int)e1.Position.X, (int)e1.Position.Y, enemy.Width, enemy.Height);

            playerBullet = this.Content.Load<Texture2D>("playerbullet");
            // Rectangle
            b1Rect = new Rectangle(20, 20, playerBullet.Width, playerBullet.Height);
            b1 = new Bullet(new Vector2(20, 20), b1Rect, 0, true);
            // b1 = bullet obj (player)

            playerFaceDown = this.Content.Load<Texture2D>("player_down");
            // Rectangle
            p1Rect = new Rectangle(250, 250, playerFaceDown.Width, playerFaceDown.Height);
            playerFaceUp = this.Content.Load<Texture2D>("player_up");
            //Rectangle p1Rect = new Rectangle((int)p1.Position.X, (int)p1.Position.Y, playerFaceUp.Width, playerFaceUp.Height);
            playerFaceRight = this.Content.Load<Texture2D>("player_right");
            //Rectangle p1Rect = new Rectangle((int)p1.Position.X, (int)p1.Position.Y, playerFaceRight.Width, playerFaceRight.Height);
            playerFaceLeft = this.Content.Load<Texture2D>("player_left");
            //Rectangle p1Rect = new Rectangle((int)p1.Position.X, (int)p1.Position.Y, playerFaceLeft.Width, playerFaceLeft.Height);
            p1 = new Player(new Vector2(250, 250), p1Rect, 2, 200, 3, 25, b1, playerFaceDown, playerFaceUp, playerFaceLeft, playerFaceRight);
            // p1 = player obj


            trap = this.Content.Load<Texture2D>("trap");
            // Rectangle
            tRect = new Rectangle(1, 1, trap.Width, trap.Height);
            gameWall = this.Content.Load<Texture2D>("Labratory");
            t = new Trap(new Vector2(0,0), tRect);
            // t = trap obj

            gameWall = this.Content.Load<Texture2D>("Labratory");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if you press the escape key or you press enter at 
            //the start menu while highlighting "quit game", you exit the program
            if (sMenu.EndGame() == true || kState.IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //if start game is not selected, update the menu
            if (sMenu.StartGame() == false)
            {
                kState = Keyboard.GetState();
                sMenu.UpdateMenu();
            }

            //if start game is selected, run the game logic
            if (sMenu.StartGame() == true && kState.IsKeyDown(Keys.P) == false)
            {
                kState = Keyboard.GetState();
                this.ProcessInput(kState);

                b1.Move();
                b2.Move();

                if (e1.Position.X == 765)
                {
                    e1.Fire();
                }


            }
            if (kState.IsKeyDown(Keys.P) == true && sMenu.StartGame() == true)
            {
                KeyboardState kstate = Keyboard.GetState();
                pMenu.UpdateMenu();

                if (pMenu.ContinueGame() == true)
                {
                    kState = Keyboard.GetState();
                    sMenu.StartGame();
                }
                if (pMenu.QuitGame() == true || kstate.IsKeyDown(Keys.Escape) == true)
                {
                    Exit();
                }
            }

            // collision detection 

            //player collides with an enemy or enemy bullet
            foreach (Enemy e in GameVariables.ENEMIES)
            {
                //if the player is colliding with an enemy
                if (p1.CheckCollision(e))
                {
                    p1.Health--;
                    e.IsAlive = false;
                }
                if (p1.CheckCollision(e.EnemyBullet))
                {
                    p1.Health--;
                }

                if (e.CheckCollision(p1.Bullet))
                {
                    e.IsAlive = false;
                }
            }

            //player collides with a trap
            foreach (Trap t in GameVariables.TRAPS)
            {
                if (p1.CheckCollision(t))
                {
                    p1.Health--;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //clear the screen
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here

            sMenu.DrawMenu(spriteBatch, menuFont, line);

            //if the start game option is selected, run this code
            if (sMenu.StartGame() == true)
            {
                //draw the background
                spriteBatch.Begin();
                spriteBatch.Draw(gameWall, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                //draw the traps
                t.Draw(trap, spriteBatch);

                gMenu.DrawText(spriteBatch, menuFont);

                //switch statement for player movement
                switch (p1.Direction)
                {
                    case 0: //up
                        p1.Draw(playerFaceUp, spriteBatch);
                        break;
                    case 1: //right
                        p1.Draw(playerFaceRight, spriteBatch);
                        break;
                    case 2: //down
                        p1.Draw(playerFaceDown, spriteBatch);
                        break;
                    case 3: //left
                        p1.Draw(playerFaceLeft, spriteBatch);
                        break;
                }

                //switch statement for enemy movement
                switch (e1.Direction)
                {
                    case 1: //right
                        e1.Draw(enemy, spriteBatch);
                        e1.Move();
                        break;
                    case 3: //left
                        e1.Draw(enemy, spriteBatch);
                        e1.Move();
                        break;
                }

                //drawing the bullets
                b1.Draw(playerBullet, spriteBatch);
                b2.Draw(enemyBullet, spriteBatch);

                //drawing the walls
                /*foreach (Wall wall in walls)
                {
                    wall.Draw(gameWall, spriteBatch);
                }*/
            }

            if (kState.IsKeyDown(Keys.P) == true && sMenu.StartGame() == true)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                pMenu.DrawMenu(spriteBatch, menuFont, line);
            }

            base.Draw(gameTime);
        }

        //processes the keystrokes of the input
        public void ProcessInput(KeyboardState kstate)
        {
            //processes these keyboard inputs only during the game
            if (sMenu.StartGame() == true)
            {
                GraphicsDevice.Clear(Color.Black);
                if (kstate.IsKeyDown(Keys.W))
                {
                    p1.Direction = 0;
                    p1.Move();
                }
                if (kstate.IsKeyDown(Keys.A))
                {
                    p1.Direction = 3;
                    p1.Move();
                }
                if (kstate.IsKeyDown(Keys.S))
                {
                    p1.Direction = 2;
                    p1.Move();
                }
                if (kstate.IsKeyDown(Keys.D))
                {
                    p1.Direction = 1;
                    p1.Move();
                }
                if (kstate.IsKeyDown(Keys.Space))
                {
                    p1.Fire();
                }
            }
        }

        //method stub to detect collisions (code will be moved here later)
        public void DetectCollisions()
        {

        }
      }
    }
