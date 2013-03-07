namespace MW2_4D1_External_ESP
{
    partial class FormMain
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxPlanes = new System.Windows.Forms.CheckBox();
            this.checkBoxHelicopters = new System.Windows.Forms.CheckBox();
            this.checkBoxTurrets = new System.Windows.Forms.CheckBox();
            this.checkBoxCrosshair = new System.Windows.Forms.CheckBox();
            this.checkBoxOnlyHostilePlayers = new System.Windows.Forms.CheckBox();
            this.checkBoxHostilePlayerWarning = new System.Windows.Forms.CheckBox();
            this.checkBoxDistanceToPlayer = new System.Windows.Forms.CheckBox();
            this.checkBoxPlayerName = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonFeet = new System.Windows.Forms.RadioButton();
            this.radioButtonMeter = new System.Windows.Forms.RadioButton();
            this.checkBoxDeadPlayers = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxPlanes);
            this.groupBox1.Controls.Add(this.checkBoxHelicopters);
            this.groupBox1.Controls.Add(this.checkBoxTurrets);
            this.groupBox1.Controls.Add(this.checkBoxCrosshair);
            this.groupBox1.Controls.Add(this.checkBoxOnlyHostilePlayers);
            this.groupBox1.Controls.Add(this.checkBoxHostilePlayerWarning);
            this.groupBox1.Controls.Add(this.checkBoxDistanceToPlayer);
            this.groupBox1.Controls.Add(this.checkBoxPlayerName);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.checkBoxDeadPlayers);
            this.groupBox1.ForeColor = System.Drawing.Color.Lime;
            this.groupBox1.Location = new System.Drawing.Point(12, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 228);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // checkBoxPlanes
            // 
            this.checkBoxPlanes.AutoSize = true;
            this.checkBoxPlanes.Checked = true;
            this.checkBoxPlanes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPlanes.Location = new System.Drawing.Point(10, 179);
            this.checkBoxPlanes.Name = "checkBoxPlanes";
            this.checkBoxPlanes.Size = new System.Drawing.Size(94, 17);
            this.checkBoxPlanes.TabIndex = 11;
            this.checkBoxPlanes.Text = "Display planes";
            this.checkBoxPlanes.UseVisualStyleBackColor = true;
            this.checkBoxPlanes.CheckedChanged += new System.EventHandler(this.checkBoxPlanes_CheckedChanged);
            // 
            // checkBoxHelicopters
            // 
            this.checkBoxHelicopters.AutoSize = true;
            this.checkBoxHelicopters.Checked = true;
            this.checkBoxHelicopters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHelicopters.Location = new System.Drawing.Point(10, 156);
            this.checkBoxHelicopters.Name = "checkBoxHelicopters";
            this.checkBoxHelicopters.Size = new System.Drawing.Size(114, 17);
            this.checkBoxHelicopters.TabIndex = 10;
            this.checkBoxHelicopters.Text = "Display helicopters";
            this.checkBoxHelicopters.UseVisualStyleBackColor = true;
            this.checkBoxHelicopters.CheckedChanged += new System.EventHandler(this.checkBoxHelicopters_CheckedChanged);
            // 
            // checkBoxTurrets
            // 
            this.checkBoxTurrets.AutoSize = true;
            this.checkBoxTurrets.Checked = true;
            this.checkBoxTurrets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTurrets.Location = new System.Drawing.Point(10, 133);
            this.checkBoxTurrets.Name = "checkBoxTurrets";
            this.checkBoxTurrets.Size = new System.Drawing.Size(92, 17);
            this.checkBoxTurrets.TabIndex = 9;
            this.checkBoxTurrets.Text = "Display turrets";
            this.checkBoxTurrets.UseVisualStyleBackColor = true;
            this.checkBoxTurrets.CheckedChanged += new System.EventHandler(this.checkBoxTurrets_CheckedChanged);
            // 
            // checkBoxCrosshair
            // 
            this.checkBoxCrosshair.AutoSize = true;
            this.checkBoxCrosshair.Checked = true;
            this.checkBoxCrosshair.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrosshair.Location = new System.Drawing.Point(10, 110);
            this.checkBoxCrosshair.Name = "checkBoxCrosshair";
            this.checkBoxCrosshair.Size = new System.Drawing.Size(105, 17);
            this.checkBoxCrosshair.TabIndex = 8;
            this.checkBoxCrosshair.Text = "Display crosshair";
            this.checkBoxCrosshair.UseVisualStyleBackColor = true;
            this.checkBoxCrosshair.CheckedChanged += new System.EventHandler(this.checkBoxCrosshair_CheckedChanged);
            // 
            // checkBoxOnlyHostilePlayers
            // 
            this.checkBoxOnlyHostilePlayers.AutoSize = true;
            this.checkBoxOnlyHostilePlayers.Location = new System.Drawing.Point(10, 64);
            this.checkBoxOnlyHostilePlayers.Name = "checkBoxOnlyHostilePlayers";
            this.checkBoxOnlyHostilePlayers.Size = new System.Drawing.Size(151, 17);
            this.checkBoxOnlyHostilePlayers.TabIndex = 7;
            this.checkBoxOnlyHostilePlayers.Text = "Display only hostile players";
            this.checkBoxOnlyHostilePlayers.UseVisualStyleBackColor = true;
            this.checkBoxOnlyHostilePlayers.CheckedChanged += new System.EventHandler(this.checkBoxOnlyHostilePlayers_CheckedChanged);
            // 
            // checkBoxHostilePlayerWarning
            // 
            this.checkBoxHostilePlayerWarning.AutoSize = true;
            this.checkBoxHostilePlayerWarning.Checked = true;
            this.checkBoxHostilePlayerWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHostilePlayerWarning.Location = new System.Drawing.Point(10, 202);
            this.checkBoxHostilePlayerWarning.Name = "checkBoxHostilePlayerWarning";
            this.checkBoxHostilePlayerWarning.Size = new System.Drawing.Size(129, 17);
            this.checkBoxHostilePlayerWarning.TabIndex = 6;
            this.checkBoxHostilePlayerWarning.Text = "Hostile player warning";
            this.checkBoxHostilePlayerWarning.UseVisualStyleBackColor = true;
            this.checkBoxHostilePlayerWarning.CheckedChanged += new System.EventHandler(this.checkBoxHostilePlayerWarning_CheckedChanged);
            // 
            // checkBoxDistanceToPlayer
            // 
            this.checkBoxDistanceToPlayer.AutoSize = true;
            this.checkBoxDistanceToPlayer.Checked = true;
            this.checkBoxDistanceToPlayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDistanceToPlayer.Location = new System.Drawing.Point(10, 41);
            this.checkBoxDistanceToPlayer.Name = "checkBoxDistanceToPlayer";
            this.checkBoxDistanceToPlayer.Size = new System.Drawing.Size(146, 17);
            this.checkBoxDistanceToPlayer.TabIndex = 5;
            this.checkBoxDistanceToPlayer.Text = "Display distance to player";
            this.checkBoxDistanceToPlayer.UseVisualStyleBackColor = true;
            this.checkBoxDistanceToPlayer.CheckedChanged += new System.EventHandler(this.checkBoxDistanceToPlayer_CheckedChanged);
            // 
            // checkBoxPlayerName
            // 
            this.checkBoxPlayerName.AutoSize = true;
            this.checkBoxPlayerName.Checked = true;
            this.checkBoxPlayerName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPlayerName.Location = new System.Drawing.Point(10, 18);
            this.checkBoxPlayerName.Name = "checkBoxPlayerName";
            this.checkBoxPlayerName.Size = new System.Drawing.Size(120, 17);
            this.checkBoxPlayerName.TabIndex = 4;
            this.checkBoxPlayerName.Text = "Display player name";
            this.checkBoxPlayerName.UseVisualStyleBackColor = true;
            this.checkBoxPlayerName.CheckedChanged += new System.EventHandler(this.checkBoxPlayerName_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonFeet);
            this.groupBox2.Controls.Add(this.radioButtonMeter);
            this.groupBox2.ForeColor = System.Drawing.Color.Lime;
            this.groupBox2.Location = new System.Drawing.Point(250, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(139, 41);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Distance ESP";
            // 
            // radioButtonFeet
            // 
            this.radioButtonFeet.AutoSize = true;
            this.radioButtonFeet.Location = new System.Drawing.Point(83, 16);
            this.radioButtonFeet.Name = "radioButtonFeet";
            this.radioButtonFeet.Size = new System.Drawing.Size(46, 17);
            this.radioButtonFeet.TabIndex = 1;
            this.radioButtonFeet.Text = "Feet";
            this.radioButtonFeet.UseVisualStyleBackColor = true;
            this.radioButtonFeet.CheckedChanged += new System.EventHandler(this.radioButtonFeet_CheckedChanged);
            // 
            // radioButtonMeter
            // 
            this.radioButtonMeter.AutoSize = true;
            this.radioButtonMeter.Checked = true;
            this.radioButtonMeter.Location = new System.Drawing.Point(12, 16);
            this.radioButtonMeter.Name = "radioButtonMeter";
            this.radioButtonMeter.Size = new System.Drawing.Size(57, 17);
            this.radioButtonMeter.TabIndex = 0;
            this.radioButtonMeter.TabStop = true;
            this.radioButtonMeter.Text = "Meters";
            this.radioButtonMeter.UseVisualStyleBackColor = true;
            this.radioButtonMeter.CheckedChanged += new System.EventHandler(this.radioButtonMeter_CheckedChanged);
            // 
            // checkBoxDeadPlayers
            // 
            this.checkBoxDeadPlayers.AutoSize = true;
            this.checkBoxDeadPlayers.Checked = true;
            this.checkBoxDeadPlayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeadPlayers.Location = new System.Drawing.Point(10, 87);
            this.checkBoxDeadPlayers.Name = "checkBoxDeadPlayers";
            this.checkBoxDeadPlayers.Size = new System.Drawing.Size(123, 17);
            this.checkBoxDeadPlayers.TabIndex = 0;
            this.checkBoxDeadPlayers.Text = "Display dead players";
            this.checkBoxDeadPlayers.UseVisualStyleBackColor = true;
            this.checkBoxDeadPlayers.CheckedChanged += new System.EventHandler(this.checkBoxDeadPlayers_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelStatus);
            this.groupBox3.ForeColor = System.Drawing.Color.Lime;
            this.groupBox3.Location = new System.Drawing.Point(12, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 38);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(6, 15);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(377, 18);
            this.labelStatus.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.ForeColor = System.Drawing.Color.Lime;
            this.textBox1.Location = new System.Drawing.Point(12, 82);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(389, 59);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "The game has to run in windowed mode in order for the ESP to function.\r\n\r\nType th" +
    "e following in the IW4 Console to run the game in windowed mode:\r\n/r_fullscreen " +
    "0; r_noborder 0; vid_restart";
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.Color.Black;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.advancedSettingsToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStripMain.Size = new System.Drawing.Size(413, 25);
            this.menuStripMain.TabIndex = 4;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.infoToolStripMenuItem.ForeColor = System.Drawing.Color.Lime;
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // advancedSettingsToolStripMenuItem
            // 
            this.advancedSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.Lime;
            this.advancedSettingsToolStripMenuItem.Name = "advancedSettingsToolStripMenuItem";
            this.advancedSettingsToolStripMenuItem.Size = new System.Drawing.Size(126, 21);
            this.advancedSettingsToolStripMenuItem.Text = "Advanced settings";
            this.advancedSettingsToolStripMenuItem.Click += new System.EventHandler(this.advancedSettingsToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(413, 387);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MW2 4D1 ESP By MaxSvett";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxDeadPlayers;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonFeet;
        private System.Windows.Forms.RadioButton radioButtonMeter;
        private System.Windows.Forms.CheckBox checkBoxDistanceToPlayer;
        private System.Windows.Forms.CheckBox checkBoxPlayerName;
        private System.Windows.Forms.CheckBox checkBoxHostilePlayerWarning;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBoxOnlyHostilePlayers;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedSettingsToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxCrosshair;
        private System.Windows.Forms.CheckBox checkBoxPlanes;
        private System.Windows.Forms.CheckBox checkBoxHelicopters;
        private System.Windows.Forms.CheckBox checkBoxTurrets;
    }
}

