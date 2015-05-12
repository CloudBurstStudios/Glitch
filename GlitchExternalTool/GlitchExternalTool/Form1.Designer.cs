namespace GlitchExternalTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.numRoomsText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numEnemiesText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.densityTrapsText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.commitButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.initHealthText = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.minESpeed = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.maxESpeed = new System.Windows.Forms.TextBox();
            this.initHealth = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(7, 83);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(759, 56);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Value = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(10, 155);
            this.trackBar2.Maximum = 30;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(759, 56);
            this.trackBar2.TabIndex = 5;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(12, 218);
            this.trackBar3.Maximum = 100;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(759, 56);
            this.trackBar3.TabIndex = 6;
            this.trackBar3.ValueChanged += new System.EventHandler(this.trackBar3_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Number of Rooms:";
            // 
            // numRoomsText
            // 
            this.numRoomsText.AutoSize = true;
            this.numRoomsText.Location = new System.Drawing.Point(145, 68);
            this.numRoomsText.Name = "numRoomsText";
            this.numRoomsText.Size = new System.Drawing.Size(16, 17);
            this.numRoomsText.TabIndex = 8;
            this.numRoomsText.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Enemies Per Level:";
            // 
            // numEnemiesText
            // 
            this.numEnemiesText.AutoSize = true;
            this.numEnemiesText.Location = new System.Drawing.Point(145, 133);
            this.numEnemiesText.Name = "numEnemiesText";
            this.numEnemiesText.Size = new System.Drawing.Size(16, 17);
            this.numEnemiesText.TabIndex = 10;
            this.numEnemiesText.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Density of Traps:";
            // 
            // densityTrapsText
            // 
            this.densityTrapsText.AutoSize = true;
            this.densityTrapsText.Location = new System.Drawing.Point(145, 194);
            this.densityTrapsText.Name = "densityTrapsText";
            this.densityTrapsText.Size = new System.Drawing.Size(80, 17);
            this.densityTrapsText.TabIndex = 12;
            this.densityTrapsText.Text = "0 Per Level";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(693, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Please make your selections for each category.  When you are finished, click on t" +
    "he submit button to commit ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "the changes into the game!";
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(590, 420);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(145, 23);
            this.commitButton.TabIndex = 15;
            this.commitButton.Text = "COMMIT CHANGES";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(336, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Initial Player Health (Minimum 10, Maximum 10,000):";
            // 
            // initHealthText
            // 
            this.initHealthText.AutoSize = true;
            this.initHealthText.Location = new System.Drawing.Point(152, 268);
            this.initHealthText.Name = "initHealthText";
            this.initHealthText.Size = new System.Drawing.Size(24, 17);
            this.initHealthText.TabIndex = 18;
            this.initHealthText.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 314);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Enemy Speed Min/Max(1-15):";
            // 
            // minESpeed
            // 
            this.minESpeed.Location = new System.Drawing.Point(213, 314);
            this.minESpeed.Name = "minESpeed";
            this.minESpeed.Size = new System.Drawing.Size(100, 22);
            this.minESpeed.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(319, 317);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "/";
            // 
            // maxESpeed
            // 
            this.maxESpeed.Location = new System.Drawing.Point(337, 314);
            this.maxESpeed.Name = "maxESpeed";
            this.maxESpeed.Size = new System.Drawing.Size(100, 22);
            this.maxESpeed.TabIndex = 22;
            // 
            // initHealth
            // 
            this.initHealth.Location = new System.Drawing.Point(355, 268);
            this.initHealth.Name = "initHealth";
            this.initHealth.Size = new System.Drawing.Size(100, 22);
            this.initHealth.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 455);
            this.Controls.Add(this.initHealth);
            this.Controls.Add(this.maxESpeed);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.minESpeed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.initHealthText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.densityTrapsText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numEnemiesText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numRoomsText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Name = "Form1";
            this.Text = "Glitch Tool - World Editor";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label numRoomsText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label numEnemiesText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label densityTrapsText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button commitButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label initHealthText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox minESpeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox maxESpeed;
        private System.Windows.Forms.TextBox initHealth;
    }
}

