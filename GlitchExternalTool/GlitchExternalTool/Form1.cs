using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GlitchExternalTool
{
    public partial class Form1 : Form
    {
        //attributes
        BinaryWriter output = null;
        Stream str = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        //USER CHANGES NUMBER OF ROOMS
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            numRoomsText.Text = trackBar1.Value.ToString();
        }

        //USER CHANGES NUMBER OF ENEMIES PER LEVEL
        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            numEnemiesText.Text = trackBar2.Value.ToString();
        }

        //USER CHANGES NUMBER OF TRAPS PER LEVEL
        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            densityTrapsText.Text = trackBar3.Value.ToString() + " per level";
        }


        //COMMITS THE CHANGES TO THE BINARY FILE
        private void CommitChangesToFile()
        {
            //opens a new stream and binary writer
            str = File.OpenWrite("ExternalData.dat");
            output = new BinaryWriter(str);

            try
            {
                //writes the information contained in the sliders to a file
                output.Write(trackBar1.Value);
                output.Write(trackBar2.Value);
                output.Write(trackBar3.Value);
                MessageBox.Show("Operation Complete.  Changes have been saved.");
            }
                //reports any problems with the writing of the files
            catch (Exception e)
            {
                MessageBox.Show("Error!  " + e.Message);
            }
                //closes the stream and binaryReader
            finally
            {
                str.Close();
                output.Close();
            }
        }

        //Commit changes button is clicked
        private void commitButton_Click(object sender, EventArgs e)
        {
            this.CommitChangesToFile();
        }
    }
}
