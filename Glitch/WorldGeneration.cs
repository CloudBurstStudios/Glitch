﻿using System;
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
        private Rectangle eRect;
        private int enemiesLeftToAdd;
        private int trapsLeftToAdd;
        private Bullet defaultBullet;
        private int enemiesUpper;
        private int enemiesLower;
        private int trapsUpper;
        private int trapsLower;

        //constructor
        public WorldGeneration(Bullet bl, Rectangle rect)
        {
            defaultBullet = bl;
            eRect = rect;
        }

        //method that is called by the program to generate the world
        public void GenerateWorld()
        {
            //preparing to generate
            currentRoom = root;
            Room newRoom;
            enemiesLeftToAdd = GameVariables.NUMBER_OF_ENEMIES;
            trapsLeftToAdd = GameVariables.DENSITY_OF_TRAPS;

            //deciding the upper and lower bounds of enemies/traps allowed per room
            enemiesLower = GameVariables.NUMBER_OF_ENEMIES / GameVariables.NUMBER_OF_ROOMS;
            trapsLower = GameVariables.DENSITY_OF_TRAPS / GameVariables.NUMBER_OF_ROOMS;

            //if enemies do not divide evenly into rooms, set upper bound 1 above lower
            if (GameVariables.NUMBER_OF_ENEMIES % GameVariables.NUMBER_OF_ROOMS != 0)
            {
                enemiesUpper = enemiesLower + 1;
            }
            else
            {
                enemiesUpper = enemiesLower;
            }

            //if traps do not divide evenly into rooms, set upper bound 1 above lower
            if (GameVariables.DENSITY_OF_TRAPS % GameVariables.NUMBER_OF_ROOMS != 0)
            {
                trapsUpper = trapsLower + 1;
            }
            else
            {
                trapsUpper = trapsLower;
            }

            //Adding rooms to the level
            for (int i = 0; i < GameVariables.NUMBER_OF_ROOMS; i++)
            {
                //creates a new room and sets it equal to the current room
                newRoom = this.AddRoomToDungeon(rgen.Next(0, 4), currentRoom);
                currentRoom = newRoom;

                //adding enemies and traps to the current room
                this.AddEnemies(currentRoom);
                this.AddTraps(currentRoom);
            }
            
            //saving the completed room layout to the GameVariables class
            GameVariables.ROOT_ROOM = root;
            GameVariables.CURRENT_ROOM = GameVariables.ROOT_ROOM;
            GameVariables.ENEMIES_REMAINING = GameVariables.NUMBER_OF_ENEMIES;
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
                    this.AddEnemies(current.Up.Up);
                    this.AddTraps(current.Up.Up);
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
                    this.AddEnemies(current.Right.Right);
                    this.AddTraps(current.Right.Right);
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
                    this.AddEnemies(current.Down.Down);
                    this.AddTraps(current.Down.Down);
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
                    this.AddEnemies(current.Left.Left);
                    this.AddTraps(current.Left.Left);
                }
                return current.Left;
            }
            return null;
        }

        //adds enemies to the world
        public void AddEnemies(Room currentRoom)
        {
            foreach (Enemy e in GameVariables.ENEMIES)
            {
                if (e.RoomNo.Item1 == currentRoom.PosX && e.RoomNo.Item2 == currentRoom.PosY) return;
            }

            for (int i = 0; i < rgen.Next(enemiesLower, enemiesUpper + 1); i++)
            {
                if (enemiesLeftToAdd > 0)
                {
                    GameVariables.ENEMIES.Add(
                        new Enemy (
                            new Vector2(rgen.Next(65, 681), rgen.Next(20, 346)),
                                new Rectangle(0,0,0,0),
                                1, defaultBullet,
                                new Tuple<int,int>(currentRoom.PosX, currentRoom.PosY),
                                rgen.Next(GameVariables.MIN_ENEMY_SPEED, GameVariables.MAX_ENEMY_SPEED + 1)));
                    enemiesLeftToAdd--;
                }
            }
        }

        //adds traps to the world
        public void AddTraps(Room currentRoom)
        {
            Vector2 sizeOfRoom = new Vector2(680 - 65, 345 - 20);
            int numTrapsInRoom = rgen.Next(trapsLower, trapsUpper + 1);
            float spaceOfTraps = sizeOfRoom.X / numTrapsInRoom;

            foreach (Trap t in GameVariables.TRAPS)
            {
                if (t.Room.Item1 == currentRoom.PosX && t.Room.Item2 == currentRoom.PosY) return;
            }

            for (int i = 0; i < numTrapsInRoom; i++)
            {
                if (trapsLeftToAdd > 0)
                {
                    GameVariables.TRAPS.Add(
                        new Trap(
                            new Vector2((spaceOfTraps * (i + 1)), rgen.Next(60, 351)),
                            new Rectangle(0,0,0,0),
                            new Tuple<int, int>(currentRoom.PosX, currentRoom.PosY)
                            ));
                    trapsLeftToAdd--;
                }
            }
        }
    }
}
