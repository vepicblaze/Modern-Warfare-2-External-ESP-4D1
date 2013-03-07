namespace MW2_4D1_External_ESP
{
    partial class FormAdvancedSettings
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
            this.labelNameColor = new System.Windows.Forms.Label();
            this.labelDistanceColor = new System.Windows.Forms.Label();
            this.labelDeadColor = new System.Windows.Forms.Label();
            this.labelFriendlyColor = new System.Windows.Forms.Label();
            this.labelHostileColor = new System.Windows.Forms.Label();
            this.buttonNameColor = new System.Windows.Forms.Button();
            this.buttonDistanceColor = new System.Windows.Forms.Button();
            this.buttonDeadColor = new System.Windows.Forms.Button();
            this.buttonFriendlyColor = new System.Windows.Forms.Button();
            this.buttonHostileColor = new System.Windows.Forms.Button();
            this.buttonDefaultColor = new System.Windows.Forms.Button();
            this.labelRenderLoopSleepTime = new System.Windows.Forms.Label();
            this.numericUpDownRenderSleep = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRenderSleep)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNameColor
            // 
            this.labelNameColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelNameColor.ForeColor = System.Drawing.Color.Lime;
            this.labelNameColor.Location = new System.Drawing.Point(12, 12);
            this.labelNameColor.Name = "labelNameColor";
            this.labelNameColor.Size = new System.Drawing.Size(259, 23);
            this.labelNameColor.TabIndex = 0;
            this.labelNameColor.Text = "Player name Color";
            this.labelNameColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDistanceColor
            // 
            this.labelDistanceColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDistanceColor.ForeColor = System.Drawing.Color.Lime;
            this.labelDistanceColor.Location = new System.Drawing.Point(12, 41);
            this.labelDistanceColor.Name = "labelDistanceColor";
            this.labelDistanceColor.Size = new System.Drawing.Size(259, 23);
            this.labelDistanceColor.TabIndex = 1;
            this.labelDistanceColor.Text = "Distance to player Color";
            this.labelDistanceColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDeadColor
            // 
            this.labelDeadColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDeadColor.ForeColor = System.Drawing.Color.Lime;
            this.labelDeadColor.Location = new System.Drawing.Point(12, 70);
            this.labelDeadColor.Name = "labelDeadColor";
            this.labelDeadColor.Size = new System.Drawing.Size(259, 23);
            this.labelDeadColor.TabIndex = 2;
            this.labelDeadColor.Text = "Dead player Color";
            this.labelDeadColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFriendlyColor
            // 
            this.labelFriendlyColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelFriendlyColor.ForeColor = System.Drawing.Color.Lime;
            this.labelFriendlyColor.Location = new System.Drawing.Point(12, 99);
            this.labelFriendlyColor.Name = "labelFriendlyColor";
            this.labelFriendlyColor.Size = new System.Drawing.Size(259, 23);
            this.labelFriendlyColor.TabIndex = 3;
            this.labelFriendlyColor.Text = "Friendly player Color";
            this.labelFriendlyColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelHostileColor
            // 
            this.labelHostileColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelHostileColor.ForeColor = System.Drawing.Color.Lime;
            this.labelHostileColor.Location = new System.Drawing.Point(12, 128);
            this.labelHostileColor.Name = "labelHostileColor";
            this.labelHostileColor.Size = new System.Drawing.Size(259, 23);
            this.labelHostileColor.TabIndex = 4;
            this.labelHostileColor.Text = "Hostile player Color";
            this.labelHostileColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonNameColor
            // 
            this.buttonNameColor.Location = new System.Drawing.Point(277, 12);
            this.buttonNameColor.Name = "buttonNameColor";
            this.buttonNameColor.Size = new System.Drawing.Size(92, 23);
            this.buttonNameColor.TabIndex = 5;
            this.buttonNameColor.Text = "Pick a Color";
            this.buttonNameColor.UseVisualStyleBackColor = true;
            this.buttonNameColor.Click += new System.EventHandler(this.buttonNameColor_Click);
            // 
            // buttonDistanceColor
            // 
            this.buttonDistanceColor.Location = new System.Drawing.Point(277, 41);
            this.buttonDistanceColor.Name = "buttonDistanceColor";
            this.buttonDistanceColor.Size = new System.Drawing.Size(92, 23);
            this.buttonDistanceColor.TabIndex = 6;
            this.buttonDistanceColor.Text = "Pick a Color";
            this.buttonDistanceColor.UseVisualStyleBackColor = true;
            this.buttonDistanceColor.Click += new System.EventHandler(this.buttonDistanceColor_Click);
            // 
            // buttonDeadColor
            // 
            this.buttonDeadColor.Location = new System.Drawing.Point(277, 70);
            this.buttonDeadColor.Name = "buttonDeadColor";
            this.buttonDeadColor.Size = new System.Drawing.Size(92, 23);
            this.buttonDeadColor.TabIndex = 7;
            this.buttonDeadColor.Text = "Pick a Color";
            this.buttonDeadColor.UseVisualStyleBackColor = true;
            this.buttonDeadColor.Click += new System.EventHandler(this.buttonDeadColor_Click);
            // 
            // buttonFriendlyColor
            // 
            this.buttonFriendlyColor.Location = new System.Drawing.Point(277, 99);
            this.buttonFriendlyColor.Name = "buttonFriendlyColor";
            this.buttonFriendlyColor.Size = new System.Drawing.Size(92, 23);
            this.buttonFriendlyColor.TabIndex = 8;
            this.buttonFriendlyColor.Text = "Pick a Color";
            this.buttonFriendlyColor.UseVisualStyleBackColor = true;
            this.buttonFriendlyColor.Click += new System.EventHandler(this.buttonFriendlyColor_Click);
            // 
            // buttonHostileColor
            // 
            this.buttonHostileColor.Location = new System.Drawing.Point(277, 128);
            this.buttonHostileColor.Name = "buttonHostileColor";
            this.buttonHostileColor.Size = new System.Drawing.Size(92, 23);
            this.buttonHostileColor.TabIndex = 9;
            this.buttonHostileColor.Text = "Pick a Color";
            this.buttonHostileColor.UseVisualStyleBackColor = true;
            this.buttonHostileColor.Click += new System.EventHandler(this.buttonHostileColor_Click);
            // 
            // buttonDefaultColor
            // 
            this.buttonDefaultColor.Location = new System.Drawing.Point(12, 158);
            this.buttonDefaultColor.Name = "buttonDefaultColor";
            this.buttonDefaultColor.Size = new System.Drawing.Size(357, 23);
            this.buttonDefaultColor.TabIndex = 10;
            this.buttonDefaultColor.Text = "Change to default colors";
            this.buttonDefaultColor.UseVisualStyleBackColor = true;
            this.buttonDefaultColor.Click += new System.EventHandler(this.buttonDefaultColor_Click);
            // 
            // labelRenderLoopSleepTime
            // 
            this.labelRenderLoopSleepTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelRenderLoopSleepTime.ForeColor = System.Drawing.Color.Lime;
            this.labelRenderLoopSleepTime.Location = new System.Drawing.Point(12, 187);
            this.labelRenderLoopSleepTime.Name = "labelRenderLoopSleepTime";
            this.labelRenderLoopSleepTime.Size = new System.Drawing.Size(259, 23);
            this.labelRenderLoopSleepTime.TabIndex = 11;
            this.labelRenderLoopSleepTime.Text = "Render loop sleep time (Milliseconds)";
            this.labelRenderLoopSleepTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownRenderSleep
            // 
            this.numericUpDownRenderSleep.Location = new System.Drawing.Point(277, 189);
            this.numericUpDownRenderSleep.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownRenderSleep.Name = "numericUpDownRenderSleep";
            this.numericUpDownRenderSleep.Size = new System.Drawing.Size(92, 20);
            this.numericUpDownRenderSleep.TabIndex = 12;
            this.numericUpDownRenderSleep.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownRenderSleep.ValueChanged += new System.EventHandler(this.numericUpDownRenderSleep_ValueChanged);
            // 
            // FormAdvancedSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(381, 221);
            this.Controls.Add(this.numericUpDownRenderSleep);
            this.Controls.Add(this.labelRenderLoopSleepTime);
            this.Controls.Add(this.buttonDefaultColor);
            this.Controls.Add(this.buttonHostileColor);
            this.Controls.Add(this.buttonFriendlyColor);
            this.Controls.Add(this.buttonDeadColor);
            this.Controls.Add(this.buttonDistanceColor);
            this.Controls.Add(this.buttonNameColor);
            this.Controls.Add(this.labelHostileColor);
            this.Controls.Add(this.labelFriendlyColor);
            this.Controls.Add(this.labelDeadColor);
            this.Controls.Add(this.labelDistanceColor);
            this.Controls.Add(this.labelNameColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormAdvancedSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MW2 4D1 ESP: Advanced Settings";
            this.Load += new System.EventHandler(this.FormAdvancedSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRenderSleep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelNameColor;
        private System.Windows.Forms.Label labelDistanceColor;
        private System.Windows.Forms.Label labelDeadColor;
        private System.Windows.Forms.Label labelFriendlyColor;
        private System.Windows.Forms.Label labelHostileColor;
        private System.Windows.Forms.Button buttonNameColor;
        private System.Windows.Forms.Button buttonDistanceColor;
        private System.Windows.Forms.Button buttonDeadColor;
        private System.Windows.Forms.Button buttonFriendlyColor;
        private System.Windows.Forms.Button buttonHostileColor;
        private System.Windows.Forms.Button buttonDefaultColor;
        private System.Windows.Forms.Label labelRenderLoopSleepTime;
        private System.Windows.Forms.NumericUpDown numericUpDownRenderSleep;
    }
}