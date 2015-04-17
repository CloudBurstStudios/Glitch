using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Glitch
{
    //loads in the information from the external tool and uses it to change Game Variables in GameVariables.cs
    class ToolLoader
    {
        //attributes
        Stream str;
        BinaryReader input;
        int numRooms = 0;
        int numEnemies = 0;
        int trapDensity = 0;

        //reads in the information from the binary file
        public void ReadData()
        {
            //opens a new stream with the file
            try
            {
                str = File.OpenRead("ExternalData.dat");
                input = new BinaryReader(str);

                //saves all of the file values to data
                numRooms = input.ReadInt32();
                numEnemies = input.ReadInt32();
                trapDensity = input.ReadInt32();
            }
            //prints error message to console (debugging purposes)
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //saves the data values to the game variables class
            finally
            {
                GameVariables.NUMBER_OF_ROOMS = numRooms;
                GameVariables.NUMBER_OF_ENEMIES = numEnemies;
                GameVariables.DENSITY_OF_TRAPS = trapDensity;
            }
        }
    }
}
