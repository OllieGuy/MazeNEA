namespace Maze_NEA
{
    partial class SettingsTab
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
            this.SubmitX = new System.Windows.Forms.Button();
            this.NewX = new System.Windows.Forms.TextBox();
            this.LabelX = new System.Windows.Forms.TextBox();
            this.LabelY = new System.Windows.Forms.TextBox();
            this.NewY = new System.Windows.Forms.TextBox();
            this.submitY = new System.Windows.Forms.Button();
            this.DefaultStart = new System.Windows.Forms.CheckBox();
            this.RandomStart = new System.Windows.Forms.CheckBox();
            this.RandStartOption = new System.Windows.Forms.TextBox();
            this.RandEndOption = new System.Windows.Forms.TextBox();
            this.RandomEnd = new System.Windows.Forms.CheckBox();
            this.DefaultEnd = new System.Windows.Forms.CheckBox();
            this.BotControlLabel = new System.Windows.Forms.TextBox();
            this.BotDifficulty = new System.Windows.Forms.TrackBar();
            this.MenuButton = new System.Windows.Forms.Button();
            this.ControlsDisplay = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.BotDifficulty)).BeginInit();
            this.SuspendLayout();
            // 
            // SubmitX
            // 
            this.SubmitX.Location = new System.Drawing.Point(224, 12);
            this.SubmitX.Name = "SubmitX";
            this.SubmitX.Size = new System.Drawing.Size(77, 20);
            this.SubmitX.TabIndex = 1;
            this.SubmitX.Text = "submit";
            this.SubmitX.UseVisualStyleBackColor = true;
            this.SubmitX.Click += new System.EventHandler(this.SubmitX_Click);
            // 
            // NewX
            // 
            this.NewX.Location = new System.Drawing.Point(118, 12);
            this.NewX.Name = "NewX";
            this.NewX.Size = new System.Drawing.Size(100, 20);
            this.NewX.TabIndex = 2;
            // 
            // LabelX
            // 
            this.LabelX.BackColor = System.Drawing.SystemColors.Control;
            this.LabelX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LabelX.Location = new System.Drawing.Point(12, 16);
            this.LabelX.Name = "LabelX";
            this.LabelX.ReadOnly = true;
            this.LabelX.Size = new System.Drawing.Size(100, 13);
            this.LabelX.TabIndex = 3;
            this.LabelX.Text = "Grid Size (X)";
            // 
            // LabelY
            // 
            this.LabelY.BackColor = System.Drawing.SystemColors.Control;
            this.LabelY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LabelY.Location = new System.Drawing.Point(12, 42);
            this.LabelY.Name = "LabelY";
            this.LabelY.ReadOnly = true;
            this.LabelY.Size = new System.Drawing.Size(100, 13);
            this.LabelY.TabIndex = 6;
            this.LabelY.Text = "Grid Size (Y)";
            // 
            // NewY
            // 
            this.NewY.Location = new System.Drawing.Point(118, 38);
            this.NewY.Name = "NewY";
            this.NewY.Size = new System.Drawing.Size(100, 20);
            this.NewY.TabIndex = 5;
            // 
            // submitY
            // 
            this.submitY.Location = new System.Drawing.Point(224, 38);
            this.submitY.Name = "submitY";
            this.submitY.Size = new System.Drawing.Size(77, 20);
            this.submitY.TabIndex = 4;
            this.submitY.Text = "submit";
            this.submitY.UseVisualStyleBackColor = true;
            this.submitY.Click += new System.EventHandler(this.SubmitY_Click);
            // 
            // DefaultStart
            // 
            this.DefaultStart.AutoSize = true;
            this.DefaultStart.Location = new System.Drawing.Point(32, 102);
            this.DefaultStart.Name = "DefaultStart";
            this.DefaultStart.Size = new System.Drawing.Size(134, 17);
            this.DefaultStart.TabIndex = 7;
            this.DefaultStart.Text = "Default Start (Top Left)";
            this.DefaultStart.UseVisualStyleBackColor = true;
            this.DefaultStart.CheckedChanged += new System.EventHandler(this.DefaultStart_CheckedChanged);
            // 
            // RandomStart
            // 
            this.RandomStart.AutoSize = true;
            this.RandomStart.Location = new System.Drawing.Point(32, 125);
            this.RandomStart.Name = "RandomStart";
            this.RandomStart.Size = new System.Drawing.Size(66, 17);
            this.RandomStart.TabIndex = 8;
            this.RandomStart.Text = "Random";
            this.RandomStart.UseVisualStyleBackColor = true;
            this.RandomStart.CheckedChanged += new System.EventHandler(this.RandomStart_CheckedChanged);
            // 
            // RandStartOption
            // 
            this.RandStartOption.BackColor = System.Drawing.SystemColors.Control;
            this.RandStartOption.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RandStartOption.Location = new System.Drawing.Point(12, 83);
            this.RandStartOption.Name = "RandStartOption";
            this.RandStartOption.ReadOnly = true;
            this.RandStartOption.Size = new System.Drawing.Size(100, 13);
            this.RandStartOption.TabIndex = 9;
            this.RandStartOption.Text = "Start Of Maze:";
            // 
            // RandEndOption
            // 
            this.RandEndOption.BackColor = System.Drawing.SystemColors.Control;
            this.RandEndOption.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RandEndOption.Location = new System.Drawing.Point(12, 148);
            this.RandEndOption.Name = "RandEndOption";
            this.RandEndOption.ReadOnly = true;
            this.RandEndOption.Size = new System.Drawing.Size(100, 13);
            this.RandEndOption.TabIndex = 12;
            this.RandEndOption.Text = "End Of Maze:";
            // 
            // RandomEnd
            // 
            this.RandomEnd.AutoSize = true;
            this.RandomEnd.Location = new System.Drawing.Point(32, 190);
            this.RandomEnd.Name = "RandomEnd";
            this.RandomEnd.Size = new System.Drawing.Size(66, 17);
            this.RandomEnd.TabIndex = 11;
            this.RandomEnd.Text = "Random";
            this.RandomEnd.UseVisualStyleBackColor = true;
            this.RandomEnd.CheckedChanged += new System.EventHandler(this.RandomEnd_CheckedChanged);
            // 
            // DefaultEnd
            // 
            this.DefaultEnd.AutoSize = true;
            this.DefaultEnd.Location = new System.Drawing.Point(32, 167);
            this.DefaultEnd.Name = "DefaultEnd";
            this.DefaultEnd.Size = new System.Drawing.Size(152, 17);
            this.DefaultEnd.TabIndex = 10;
            this.DefaultEnd.Text = "Default End (Bottom Right)\r\n";
            this.DefaultEnd.UseVisualStyleBackColor = true;
            this.DefaultEnd.CheckedChanged += new System.EventHandler(this.DefaultEnd_CheckedChanged);
            // 
            // BotControlLabel
            // 
            this.BotControlLabel.BackColor = System.Drawing.SystemColors.Control;
            this.BotControlLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BotControlLabel.Location = new System.Drawing.Point(12, 228);
            this.BotControlLabel.Name = "BotControlLabel";
            this.BotControlLabel.ReadOnly = true;
            this.BotControlLabel.Size = new System.Drawing.Size(100, 13);
            this.BotControlLabel.TabIndex = 13;
            this.BotControlLabel.Text = "Bot Difficulty";
            // 
            // BotDifficulty
            // 
            this.BotDifficulty.Location = new System.Drawing.Point(12, 247);
            this.BotDifficulty.Name = "BotDifficulty";
            this.BotDifficulty.Size = new System.Drawing.Size(206, 45);
            this.BotDifficulty.TabIndex = 14;
            this.BotDifficulty.Scroll += new System.EventHandler(this.BotDifficulty_Scroll);
            // 
            // MenuButton
            // 
            this.MenuButton.Location = new System.Drawing.Point(499, 394);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(289, 44);
            this.MenuButton.TabIndex = 15;
            this.MenuButton.Text = "Back To Menu";
            this.MenuButton.UseVisualStyleBackColor = true;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // ControlsDisplay
            // 
            this.ControlsDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.ControlsDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ControlsDisplay.Location = new System.Drawing.Point(499, 12);
            this.ControlsDisplay.Multiline = true;
            this.ControlsDisplay.Name = "ControlsDisplay";
            this.ControlsDisplay.ReadOnly = true;
            this.ControlsDisplay.Size = new System.Drawing.Size(289, 107);
            this.ControlsDisplay.TabIndex = 16;
            this.ControlsDisplay.Text = "Controls:\r\n\r\n↑    Move Up\r\n↓    Move Down\r\n→   Move Left\r\n←   Move Right\r\n\r\nEsc  " +
    "               Quit";
            // 
            // SettingsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ControlsDisplay);
            this.Controls.Add(this.MenuButton);
            this.Controls.Add(this.BotDifficulty);
            this.Controls.Add(this.BotControlLabel);
            this.Controls.Add(this.RandEndOption);
            this.Controls.Add(this.RandomEnd);
            this.Controls.Add(this.DefaultEnd);
            this.Controls.Add(this.RandStartOption);
            this.Controls.Add(this.RandomStart);
            this.Controls.Add(this.DefaultStart);
            this.Controls.Add(this.LabelY);
            this.Controls.Add(this.NewY);
            this.Controls.Add(this.submitY);
            this.Controls.Add(this.LabelX);
            this.Controls.Add(this.NewX);
            this.Controls.Add(this.SubmitX);
            this.Name = "SettingsTab";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsTab_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BotDifficulty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SubmitX;
        private System.Windows.Forms.TextBox NewX;
        private System.Windows.Forms.TextBox LabelX;
        private System.Windows.Forms.TextBox LabelY;
        private System.Windows.Forms.TextBox NewY;
        private System.Windows.Forms.Button submitY;
        private System.Windows.Forms.CheckBox DefaultStart;
        private System.Windows.Forms.CheckBox RandomStart;
        private System.Windows.Forms.TextBox RandStartOption;
        private System.Windows.Forms.TextBox RandEndOption;
        private System.Windows.Forms.CheckBox RandomEnd;
        private System.Windows.Forms.CheckBox DefaultEnd;
        private System.Windows.Forms.TextBox BotControlLabel;
        private System.Windows.Forms.TrackBar BotDifficulty;
        private System.Windows.Forms.Button MenuButton;
        private System.Windows.Forms.TextBox ControlsDisplay;
    }
}