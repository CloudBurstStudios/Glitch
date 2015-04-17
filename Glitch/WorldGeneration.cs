using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glitch
{
    //Class to generate the world when the level is first initialized
    class WorldGeneration
    {
        //attributes
        Random rgen = new Random();
        int[,] roomID = new int[GameVariables.NUMBER_OF_ROOMS, GameVariables.NUMBER_OF_ROOMS];

        //adds a room to the level
        public void AddRoomToDungeon(bool root)
        {

        }
        public void AddRoomToDungeon(int dir, Room current)
        {
            switch (dir)
            {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            }
        }
    }
}
