#region Using Statements
using System;
using System.Diagnostics;
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
        //attributes
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState kState;
        Texture2D playerFaceUp;
        Texture2D playerFaceRight;
        Texture2D playerFaceDown;
        Texture2D playerFaceLeft;
        Texture2D bullet;
        Texture2D enemyFaceLeft;
        Texture2D enemyFaceRight;
        Texture2D enemyFaceUp;
        Texture2D enemyFaceDown;
        Texture2D gameWall;
        Texture2D gameWallBotLeftCorner;
        Texture2D gameWallBotRightCorner;
        Texture2D gameWallBotOnly;
        Texture2D gameWallBotTri;
        Texture2D gameWallHorizontal;
        Texture2D gameWallLeftOnly;
        Texture2D gameWallLeftTri;
        Texture2D gameWallRightOnly;
        Texture2D gameWallRightTri;
        Texture2D gameWallTopLeftCorner;
        Texture2D gameWallTopOnly;
        Texture2D gameWallTopRightCorner;
        Texture2D gameWallTopTriangle;
        Texture2D gameWallVertical;
        Texture2D trap;
        Texture2D line;
        Random rgen;
        SpriteFont menuFont;
        Player p1;
        Bullet b1;
        Rectangle pRect;
        Rectangle eRect;
        Rectangle bRect;
        StartMenu sMenu;
        PauseMenu pMenu;
        GameMenu gMenu;
        WinMenu wMenu;
        InstructionMenu iMenu;
        LoseMenu lMenu;
        WorldGeneration worldGen;
        ToolLoader tLoader;

        //constructor
        public Game1()
            : base()
        {
            //setting up the graphics
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            //setting content folder
            Content.RootDirectory = "Content";

            //initializing the menus
            sMenu = new StartMenu();
            pMenu = new PauseMenu();
            gMenu = new GameMenu();
            wMenu = new WinMenu();
            iMenu = new InstructionMenu();
            lMenu = new LoseMenu();

            //creating a new random object to be used for random number generations
            rgen = new Random();

            //initializes the lists in GameVariables
            GameVariables.ENEMIES = new List<Enemy>();
            GameVariables.TRAPS = new List<Trap>();
            GameVariables.ENEMYPOS = new List<Vector2>();

            //initializing the bullet and player
            b1 = new Bullet(new Vector2(20, 20), bRect, 0);
            bRect = new Rectangle((int)b1.Position.X, (int)b1.Position.Y, (int)GameVariables.BULLET_DIMENSIONS.X, (int)GameVariables.BULLET_DIMENSIONS.Y);
            p1 = new Player(new Vector2(500, 175), pRect, 0, 100, b1);
            pRect = new Rectangle((int)p1.Position.X, (int)p1.Position.Y, (int)GameVariables.PLAYER_DIMENSIONS.X, (int)GameVariables.PLAYER_DIMENSIONS.Y);

            //initializing the tool loader and world generation
            tLoader = new ToolLoader();
            worldGen = new WorldGeneration(b1, eRect);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            //gets the initial state of the keyboard
            kState = Keyboard.GetState();

            //sets the window width and height to be used in other classes
            GameVariables.WINDOW_HEIGHT = GraphicsDevice.Viewport.Height;
            GameVariables.WINDOW_WIDTH = GraphicsDevice.Viewport.Width;

            //reads information from the external tool
            tLoader.ReadData();

            //generates the world
            worldGen.GenerateWorld();
            
            //sets player health to the initial value passed in through the tool
            p1.Health = GameVariables.INITIAL_HEALTH;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //texture to make lines around menu selection
            line = new Texture2D(GraphicsDevice, 1, 1);
            line.SetData<Color>(new Color[] { Color.White });   // fill the texture with white

            //Loading textures to use in game
            menuFont = this.Content.Load<SpriteFont>("mainFont");
            bullet = this.Content.Load<Texture2D>("playerbullet");
            enemyFaceLeft = this.Content.Load<Texture2D>("enemyFaceLeft");
            enemyFaceRight = this.Content.Load<Texture2D>("enemyFaceRight");
            enemyFaceUp = this.Content.Load<Texture2D>("enemyFaceUp");
            enemyFaceDown = this.Content.Load<Texture2D>("enemyFaceDown");
            playerFaceDown = this.Content.Load<Texture2D>("player_down");
            playerFaceUp = this.Content.Load<Texture2D>("player_up");
            playerFaceRight = this.Content.Load<Texture2D>("player_right");
            playerFaceLeft = this.Content.Load<Texture2D>("player_left");
            trap = this.Content.Load<Texture2D>("trap");
            gameWall = this.Content.Load<Texture2D>("Labratory");
            gameWallBotLeftCorner = this.Content.Load<Texture2D>("Labratory_BotLeftCorner");
            gameWallBotRightCorner = this.Content.Load<Texture2D>("Labratory_BotRightCorner");
            gameWallBotOnly = this.Content.Load<Texture2D>("Labratory_BottomOnly");
            gameWallBotTri = this.Content.Load<Texture2D>("Labratory_BottomTriangle");
            gameWallHorizontal = this.Content.Load<Texture2D>("Labratory_Horizontal");
            gameWallLeftOnly = this.Content.Load<Texture2D>("Labratory_LeftOnly");
            gameWallLeftTri = this.Content.Load<Texture2D>("Labratory_LeftTriangle");
            gameWallRightOnly = this.Content.Load<Texture2D>("Labratory_RightOnly");
            gameWallRightTri = this.Content.Load<Texture2D>("Labratory_RightTriangle");
            gameWallTopLeftCorner = this.Content.Load<Texture2D>("Labratory_TopLeftCorner");
            gameWallTopOnly = this.Content.Load<Texture2D>("Labratory_TopOnly");
            gameWallTopRightCorner = this.Content.Load<Texture2D>("Labratory_TopRightCorner");
            gameWallTopTriangle = this.Content.Load<Texture2D>("Labratory_TopTriangle");
            gameWallVertical = this.Content.Load<Texture2D>("Labratory_Vertical");

            //Setting up dimensions in GameVariables
            GameVariables.PLAYER_DIMENSIONS = new Vector2(playerFaceUp.Width, playerFaceUp.Height);
            GameVariables.ENEMY_DIMENSIONS = new Vector2(enemyFaceUp.Width, enemyFaceUp.Height);
            GameVariables.TRAP_DIMENSIONS = new Vector2(trap.Width, trap.Height);
            GameVariables.BULLET_DIMENSIONS = new Vector2(bullet.Width, bullet.Height);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            //nothing is to be unloaded
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

            //if start game is not selected, update the menu
            if (sMenu.StartGame() == false && GameVariables.ENEMIES_REMAINING > 0 && p1.Health > 0)
            {
                kState = Keyboard.GetState();
                sMenu.UpdateMenu();
            }
            //if the directions menu is selected, update the instuctions menu
            if (sMenu.Instructions() == true)
            {
                kState = Keyboard.GetState();
                    if (iMenu.DoneWithInstructions() == true)
                    {
                        kState = Keyboard.GetState();
                        sMenu.UpdateMenu();
                    }
            }

            //if start game is selected, run the game logic
            if (sMenu.StartGame() == true && kState.IsKeyDown(Keys.P) == false && GameVariables.ENEMIES_REMAINING > 0 && p1.Health > 0)
            {
                RunUpdateGame();
            }
            if (kState.IsKeyDown(Keys.P) == true && sMenu.StartGame() == true && GameVariables.ENEMIES_REMAINING > 0 && p1.Health > 0)
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

            if (GameVariables.ENEMIES_REMAINING == 0)
            {
                kState = Keyboard.GetState();
                wMenu.UpdateMenu();

                if (wMenu.EndGame() == true)
                {
                    Exit();
                }

                if (wMenu.StartGame() == true)
                {
                    kState = Keyboard.GetState();
                    ResetGame();
                    RunUpdateGame();
                }
            }

            if (p1.Health <= 0)
            {
                kState = Keyboard.GetState();
                lMenu.UpdateMenu();

                if (lMenu.StartGame() == true)
                {
                    kState = Keyboard.GetState();
                    ResetGame();
                    RunUpdateGame();
                }

                if (lMenu.EndGame() == true)
                {
                    Exit();
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

            //while there are still enemies left
            if (GameVariables.ENEMIES_REMAINING > 0)
            {
                sMenu.DrawMenu(spriteBatch, menuFont, line);
            }

            //if the instructions are being shown
            if (sMenu.Instructions() == true)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                iMenu.DrawMenu(spriteBatch, menuFont, line);

                if (iMenu.DoneWithInstructions() == true)
                {
                    GraphicsDevice.Clear(Color.CornflowerBlue);
                    sMenu.DrawMenu(spriteBatch, menuFont, line);
                }
            }

            //if the start game option is selected, run this code
            if (sMenu.StartGame() == true && GameVariables.ENEMIES_REMAINING > 0)
            {
                RunDrawGame();
            }

            if (kState.IsKeyDown(Keys.P) == true && sMenu.StartGame() == true && GameVariables.ENEMIES_REMAINING > 0)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                pMenu.DrawMenu(spriteBatch, menuFont, line);
            }

            //if there are no enemies remaining
            if (GameVariables.ENEMIES_REMAINING == 0)
            {
                wMenu.DrawMenu(spriteBatch, menuFont, line);

                if (wMenu.EndGame() == true)
                {
                    Exit();
                }

                if (wMenu.StartGame() == true)
                {
                    RunDrawGame();
                }
            }

            if (p1.Health <= 0)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                lMenu.DrawMenu(spriteBatch, menuFont, line);
            }

            base.Draw(gameTime);
        }

        //processes the keystrokes of the user input
        public void ProcessInput(KeyboardState kstate)
        {
            //processes these keyboard inputs only during the game
            if (sMenu.StartGame() == true)
            {
                GraphicsDevice.Clear(Color.Black);

                //WASD used to navigate / move
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

                //space key used to fire
                if (kstate.IsKeyDown(Keys.Space))
                {
                    p1.Fire();
                }
            }
        }

        //method to detect collisions
        public void DetectCollisions()
        {
            //Setting up rectangles for Collision Detection
            p1.CollDetect = new Rectangle(0, 0, (int)(playerFaceDown.Width * GameVariables.PLAYER_SCALE), (int)(playerFaceDown.Height * GameVariables.PLAYER_SCALE));
            p1.PlayerBullet.CollDetect = new Rectangle(0, 0, (int)(bullet.Width * GameVariables.BULLET_SCALE), (int)(bullet.Height * GameVariables.BULLET_SCALE));
            foreach (Enemy e in GameVariables.ENEMIES)
            {
                e.CollDetect = new Rectangle(0, 0, (int)(enemyFaceDown.Width * GameVariables.ENEMY_SCALE), (int)(enemyFaceDown.Height * GameVariables.ENEMY_SCALE));
            }
            foreach (Trap t in GameVariables.TRAPS)
            {
                t.CollDetect = new Rectangle(0, 0, trap.Width, trap.Height);
            }

            //player collides with an enemy or enemy bullet
            foreach (Enemy e in GameVariables.ENEMIES)
            {
                //if the player is colliding with an enemy
                if (p1.CheckCollision(e))
                {
                    //decrement the health
                    p1.Health--;
                    //write the collision (debugging purposes
                    Console.WriteLine("Player and Enemy");
                    
                    e.IsActive = false;
                }

                //if the enemy is colliding with the player bullet
                if (e.CheckCollision(p1.PlayerBullet))
                {
                    //sets the "isDead" of enemy to false so it will no longer be used
                    e.IsDead = true;
                    e.IsActive = false;

                    //increments the score
                    gMenu.Score++;

                    //deactivates the bullet
                    p1.PlayerBullet.IsActive = false;

                    //decrements the "enemies remaining" attribute
                    GameVariables.ENEMIES_REMAINING--;
                }
            }

            //player collides with a trap
            foreach (Trap t in GameVariables.TRAPS)
            {
                if (p1.CheckCollision(t))
                {
                    //decrement the health
                    p1.Health--;
                    //write the collision (debugging purposes)
                    Console.WriteLine("Player and Trap");
                }
            }
        }

        //Runs the update logic while the game is being played
        public void RunUpdateGame()
        {
            //gets a keyboard state and processes it 
            kState = Keyboard.GetState();
            this.ProcessInput(kState);

            //moves the bullet
            p1.PlayerBullet.Move();

            //moves the enemies if they are active
            foreach (Enemy e in GameVariables.ENEMIES)
            {
                if (e.IsActive)
                {
                    e.Move();
                    //writes the enemy position (debugging purposes)
                    Console.WriteLine(e.Position.X + " " + e.Position.Y);
                }
            }

            //detects collisions
            DetectCollisions();

            //activates a stopwatch and generates integers for random time and direction
            Stopwatch watch = new Stopwatch();
            Random rgen = new Random();
            int randTime = rgen.Next(0, 26);
            int randDirection = rgen.Next(0, 4);

            watch.Start();

            //if random times match, change the direction of a random enemy to a random direction
            if (watch.ElapsedMilliseconds == randTime)
            {
                GameVariables.ENEMIES[rgen.Next(0, GameVariables.ENEMIES.Count)].Direction = randDirection;
                watch.Reset();
            }
        }

        //Runs the logic to draw the game if it is being played
        public void RunDrawGame()
        {
            //draw the background
            this.DrawBackground();

            //draw the HUD
            spriteBatch.Begin();
            spriteBatch.DrawString(menuFont, "" + p1.Health, new Vector2(120, 25), Color.Black);
            spriteBatch.End();

            gMenu.DrawText(spriteBatch, menuFont);

            //Draws the traps to the screen
            foreach (Trap t in GameVariables.TRAPS)
            {
                //If the room coordinates match the current room, draw it
                if (GameVariables.CURRENT_ROOM.PosX == t.Room.Item1 && GameVariables.CURRENT_ROOM.PosY == t.Room.Item2)
                {
                    t.Draw(trap, spriteBatch);
                    t.IsActive = true;
                }
                else
                {
                    t.IsActive = false;
                }
            }

            //Does the same as the above logic for traps, but with enemies
            foreach (Enemy e in GameVariables.ENEMIES)
            {
                if (e.IsDead) continue;

                if (GameVariables.CURRENT_ROOM.PosX == e.RoomNo.Item1 && GameVariables.CURRENT_ROOM.PosY == e.RoomNo.Item2)
                {
                    e.IsActive = true;

                    switch (e.Direction)
                    {
                        case 0: //up
                            e.Draw(enemyFaceUp, spriteBatch);
                            break;
                        case 1: //right
                            e.Draw(enemyFaceRight, spriteBatch);
                            break;
                        case 2: //down
                            e.Draw(enemyFaceDown, spriteBatch);
                            break;
                        case 3: //left
                            e.Draw(enemyFaceLeft, spriteBatch);
                            break;
                    }
                }
                else
                {
                    e.IsActive = false;
                }
            }

            //draws player based on direction
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

            //drawing the bullets
            p1.PlayerBullet.Draw(bullet, spriteBatch);
        }

        //resets the game after the player has lost or won
        public void ResetGame()
        {
            //Clears all the enemies, traps, and rooms
            GameVariables.ENEMIES.Clear();
            GameVariables.TRAPS.Clear();
            GameVariables.ROOT_ROOM.Down = null;
            GameVariables.ROOT_ROOM.Up = null;
            GameVariables.ROOT_ROOM.Left = null;
            GameVariables.ROOT_ROOM.Right = null;

            //resets back to the root room and gives the player full health
            GameVariables.CURRENT_ROOM = GameVariables.ROOT_ROOM;
            p1.Health = GameVariables.INITIAL_HEALTH;

            //resets the score
            gMenu.Score = 0;

            //re-generates the world
            worldGen.GenerateWorld();
        }

        //draws the background based on the adjacent rooms
        public void DrawBackground()
        {
            spriteBatch.Begin();
            //All 4 Rooms Open
            if (GameVariables.CURRENT_ROOM.Down != null && GameVariables.CURRENT_ROOM.Right != null && GameVariables.CURRENT_ROOM.Left != null && GameVariables.CURRENT_ROOM.Up != null)
            {
                spriteBatch.Draw(gameWall, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            //Left and Down Open
            if (GameVariables.CURRENT_ROOM.Left != null && GameVariables.CURRENT_ROOM.Down != null && GameVariables.CURRENT_ROOM.Right == null && GameVariables.CURRENT_ROOM.Up == null)
            {
                spriteBatch.Draw(gameWallBotLeftCorner, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            //Right and Down Open
            if (GameVariables.CURRENT_ROOM.Left == null && GameVariables.CURRENT_ROOM.Down != null && GameVariables.CURRENT_ROOM.Right != null && GameVariables.CURRENT_ROOM.Up == null)
            {
                spriteBatch.Draw(gameWallBotRightCorner, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            //Only Down Open
            if (GameVariables.CURRENT_ROOM.Left == null && GameVariables.CURRENT_ROOM.Down != null && GameVariables.CURRENT_ROOM.Right == null && GameVariables.CURRENT_ROOM.Up == null)
            {
                spriteBatch.Draw(gameWallBotOnly, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            //Down, Right, and Left Open
            if (GameVariables.CURRENT_ROOM.Left != null && GameVariables.CURRENT_ROOM.Down != null && GameVariables.CURRENT_ROOM.Right != null && GameVariables.CURRENT_ROOM.Up == null)
            {
                spriteBatch.Draw(gameWallBotTri, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            //Right and Left Open
            if (GameVariables.CURRENT_ROOM.Left != null && GameVariables.CURRENT_ROOM.Down == null && GameVariables.CURRENT_ROOM.Right != null && GameVariables.CURRENT_ROOM.Up == null)
            {
                spriteBatch.Draw(gameWallHorizontal, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            //Only Left Open
            if (GameVariables.CURRENT_ROOM.Left != null && GameVariables.CURRENT_ROOM.Down == null && GameVariables.CURRENT_ROOM.Right == null && GameVariables.CURRENT_ROOM.Up == null)
            {
                spriteBatch.Draw(gameWallLeftOnly, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            //Left, Top, and Down Open
            if (GameVariables.CURRENT_ROOM.Left != null && GameVariables.CURRENT_ROOM.Down != null && GameVariables.CURRENT_ROOM.Right == null && GameVariables.CURRENT_ROOM.Up != null)
            {
                spriteBatch.Draw(gameWallLeftTri, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            //Only Right Open
            if (GameVariables.CURRENT_ROOM.Left == null && GameVariables.CURRENT_ROOM.Down == null && GameVariables.CURRENT_ROOM.Right != null && GameVariables.CURRENT_ROOM.Up == null)
            {
                spriteBatch.Draw(gameWallRightOnly, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            //Right, Top, and Down Open
            if (GameVariables.CURRENT_ROOM.Left == null && GameVariables.CURRENT_ROOM.Down != null && GameVariables.CURRENT_ROOM.Right != null && GameVariables.CURRENT_ROOM.Up != null)
            {
                spriteBatch.Draw(gameWallRightTri, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            //Top and Left Open
            if (GameVariables.CURRENT_ROOM.Left != null && GameVariables.CURRENT_ROOM.Down == null && GameVariables.CURRENT_ROOM.Right == null && GameVariables.CURRENT_ROOM.Up != null)
            {
                spriteBatch.Draw(gameWallTopLeftCorner, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            //Only Top Open
            if (GameVariables.CURRENT_ROOM.Left == null && GameVariables.CURRENT_ROOM.Down == null && GameVariables.CURRENT_ROOM.Right == null && GameVariables.CURRENT_ROOM.Up != null)
            {
                spriteBatch.Draw(gameWallTopOnly, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            //Top and Right Open
            if (GameVariables.CURRENT_ROOM.Left == null && GameVariables.CURRENT_ROOM.Down == null && GameVariables.CURRENT_ROOM.Right != null && GameVariables.CURRENT_ROOM.Up != null)
            {
                spriteBatch.Draw(gameWallTopRightCorner, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            //Top, Right, and Left Open
            if (GameVariables.CURRENT_ROOM.Left != null && GameVariables.CURRENT_ROOM.Down == null && GameVariables.CURRENT_ROOM.Right != null && GameVariables.CURRENT_ROOM.Up != null)
            {
                spriteBatch.Draw(gameWallTopTriangle, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            //Top and Down Open
            if (GameVariables.CURRENT_ROOM.Left == null && GameVariables.CURRENT_ROOM.Down != null && GameVariables.CURRENT_ROOM.Right == null && GameVariables.CURRENT_ROOM.Up != null)
            {
                spriteBatch.Draw(gameWallVertical, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Silver);
                spriteBatch.End();
                return;
            }
            spriteBatch.End();
        }
      }
    }
