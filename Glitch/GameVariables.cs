using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Glitch
{
    //A class which contains game variables that are used throughout the program
    static class GameVariables
    {
        //static game attributes
        public static int WINDOW_WIDTH;
        public static int WINDOW_HEIGHT;
        public static int NUMBER_OF_ROOMS;
        public static int NUMBER_OF_ENEMIES;
        public static int DENSITY_OF_TRAPS;
        public static Room ROOT_ROOM;
        public static Room CURRENT_ROOM;
        public static List<Enemy> ENEMIES;
        public static List<Trap> TRAPS;

    }
}
