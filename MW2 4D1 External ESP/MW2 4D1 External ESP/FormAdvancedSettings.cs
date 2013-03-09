using MW2_4D1_External_ESP.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MW2_4D1_External_ESP
{
    public partial class FormAdvancedSettings : Form
    {
        public FormAdvancedSettings()
        {
            InitializeComponent();
        }

        private void FormAdvancedSettings_Load(object sender, EventArgs e)
        {
            UpdateUiElements();
        }

        private void UpdateUiElements()
        {
            labelNameColor.Text = string.Format("Player name Color: {0}", Settings.Default.PlayerNameColor.Name.ToUpper());
            labelDistanceColor.Text = string.Format("Distance to player Color: {0}", Settings.Default.DistanceToPlayerColor.Name.ToUpper());
            labelDeadColor.Text = string.Format("Dead player Color: {0}", Settings.Default.DeadPlayerColor.Name.ToUpper());
            labelFriendlyColor.Text = string.Format("Friendly player Color: {0}", Settings.Default.FriendlyColor.Name.ToUpper());
            labelHostileColor.Text = string.Format("Hostile player Color: {0}", Settings.Default.HostileColor.Name.ToUpper());
            numericUpDownRenderSleep.Value = Convert.ToDecimal(Settings.Default.RenderSleep);
        }

        private void buttonNameColor_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                Settings.Default.PlayerNameColor = dialog.Color;
            Settings.Default.Save();

            UpdateUiElements();
        }

        private void buttonDistanceColor_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                Settings.Default.DistanceToPlayerColor = dialog.Color;
            Settings.Default.Save();

            UpdateUiElements();
        }

        private void buttonDeadColor_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                Settings.Default.DeadPlayerColor = dialog.Color;
            Settings.Default.Save();

            UpdateUiElements();
        }

        private void buttonFriendlyColor_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                Settings.Default.FriendlyColor = dialog.Color;
            Settings.Default.Save();

            UpdateUiElements();
        }

        private void buttonHostileColor_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                Settings.Default.HostileColor = dialog.Color;
            Settings.Default.Save();

            UpdateUiElements();
        }

        private void buttonDefaultColor_Click(object sender, EventArgs e)
        {
            Settings.Default.PlayerNameColor = Color.White;
            Settings.Default.DistanceToPlayerColor = Color.White;
            Settings.Default.DeadPlayerColor = Color.Gray;
            Settings.Default.FriendlyColor = Color.Blue;
            Settings.Default.HostileColor = Color.Red;
            Settings.Default.Save();

            UpdateUiElements();
        }

        private void numericUpDownRenderSleep_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.RenderSleep = Convert.ToInt32(numericUpDownRenderSleep.Value);
            Settings.Default.Save();
        }
    }
}
