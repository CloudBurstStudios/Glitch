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
    //Class to generate the world when the level is first initialized
    class WorldGeneration
    {
        //attributes
        private Random rgen = new Random();
        private Room root = new Room(0, 0);
        private Room currentRoom = null;
        private int enemiesLeftToAdd;
        private int enemiesPerRoom;
        private Enemy defaultEnemy;
        private Trap defaultTrap;
        private Bullet defaultBullet;
        private int enemiesUpper;
        private int enemiesLower;

        //constructor
        public WorldGeneration(Trap tr, Bullet bl)
        {
            defaultTrap = tr;
            defaultBullet = bl;
        }

        //method that is called by the program to generate the world
        public void GenerateWorld()
        {
            currentRoom = root;
            Room newRoom;
            enemiesLeftToAdd = GameVariables.NUMBER_OF_ENEMIES;

            //deciding the upper and lower bounds of enemies allowed per room
            enemiesLower = GameVariables.NUMBER_OF_ENEMIES / GameVariables.NUMBER_OF_ROOMS;

            //if the enemies do not divide evenly into the rooms
            if (GameVariables.NUMBER_OF_ENEMIES % GameVariables.NUMBER_OF_ROOMS != 0)
            {
                enemiesUpper = enemiesLower + 1;
            }
            else
            {
                enemiesUpper = enemiesLower;
            }

            //Adding rooms to the level
            for (int i = 0; i < GameVariables.NUMBER_OF_ROOMS; i++)
            {
                newRoom = this.AddRoomToDungeon(rgen.Next(0, 4), currentRoom);
                currentRoom = newRoom;
                this.AddEnemies(currentRoom);
            }
            
            //saving the completed room layout to the GameVariables class
            GameVariables.ROOT_ROOM = root;
            GameVariables.CURRENT_ROOM = GameVariables.ROOT_ROOM;

            //adding enemy positions to the room
            for (int i = 0; i < GameVariables.NUMBER_OF_ENEMIES; i++)
            {
                GameVariables.ENEMYPOS.Add(new Vector2(rgen.Next(75, 921), rgen.Next(20, 476)));
            }

        }

        //adds a room to the level
        public Room AddRoomToDungeon(int dir, Room current)
        {
            //places the room in the direction passed in
            switch (dir)
            {
            case 0: //up
                //if the room we're trying to place isn't already filled
                if (current.Up == null)
                {
                    //create the room
                    current.Up = new Room(current.PosX, current.PosY - 1);
                    current.Up.Down = current;

                    //assign surrounding rooms to link with new room
                    if (current.Right != null)
                    {
                        current.Up.Right = current.Right.Up;
                    }
                    if (current.Left != null)
                    {
                        current.Up.Left = current.Left.Up;
                    }
                }
                    //room is already full
                else
                {
                    //move into that room, try adding it again (Recursion)   
                    AddRoomToDungeon(0, current.Up);
                }
                return current.Up;
            case 1: //right
                //does the same thing as above, but for different direction
                if (current.Right == null)
                {
                    current.Right = new Room(current.PosX + 1, current.PosY);
                    current.Right.Left = current;

                    if (current.Up != null)
                    {
                        current.Right.Up = current.Up.Right;
                    }
                    if (current.Down != null)
                    {
                        current.Right.Down = current.Down.Right;
                    }
                }
                else
                {
                    AddRoomToDungeon(1, current.Right);
                }
                return current.Right;
            case 2: //down
                //does the same thing as above, but for different direction
                if (current.Down == null)
                {
                    current.Down = new Room(current.PosX, current.PosY + 1);
                    current.Down.Up = current;

                    if (current.Left != null)
                    {
                        current.Down.Left = current.Left.Down;
                    }
                    if (current.Right != null)
                    {
                        current.Down.Right = current.Right.Down;
                    }
                }
                else
                {
                    AddRoomToDungeon(2, current.Down);
                }
                return current.Down;
            case 3: //left
                //does the same thing as above, but for different direction
                if (current.Left == null)
                {
                    current.Left = new Room(current.PosX - 1, current.PosY);
                    current.Left.Right = current;

                    if (current.Up != null)
                    {
                        current.Left.Up = current.Up.Left;
                    }
                    if (current.Down != null)
                    {
                        current.Left.Down = current.Down.Left;
                    }
                }
                else
                {
                    AddRoomToDungeon(3, current.Left);
                }
                return current.Left;
            }
            return null;
        }

        //adds enemies to the world
        public void AddEnemies(Room currentRoom)
        {
            for (int i = 0; i < rgen.Next(enemiesLower, enemiesUpper + 1); i++)
            {
                if (enemiesLeftToAdd > 0)
                {
                    GameVariables.ENEMIES.Add(
                        new Enemy(
                            new Vector2(rgen.Next(75, 921), rgen.Next(20, 476)),
                                new Rectangle(),
                                0, defaultBullet,
                                new Tuple<int,int>(currentRoom.PosX, currentRoom.PosY)));
                    enemiesLeftToAdd--;
                }
            }
        }

        //adds traps to the world
        public void AddTraps()
        {

        }
    }
}
