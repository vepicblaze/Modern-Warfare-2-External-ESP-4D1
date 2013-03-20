using MW2_4D1_External_ESP.Properties;
using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace MW2_4D1_External_ESP
{
    public partial class FormMain : Form
    {
        private Thread statusThread;
        private FormOverlay formOverlay;

        public FormMain()
        {
            InitializeComponent();
            InitCheckboxes();

            statusThread = new Thread(() => StatusLoop());
            formOverlay = new FormOverlay();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            statusThread.Start();
            formOverlay.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            statusThread.Abort();
            formOverlay.Close();
        }

        public new static string ProductVersion()
        {
            return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
        }

        private string Status
        {
            get
            {
                return labelStatus.Text;
            }
            set
            {
                Invoke((MethodInvoker)delegate()
                {
                    labelStatus.Text = value;
                });
            }
        }

        // Called in StatusThread
        private void StatusLoop()
        {
            while (true) {
                this.Status = EspStatus.CurrentStatus;
                Thread.Sleep(200);
            }
        }

        private void InitCheckboxes()
        {
            this.checkBoxPlayerName.Checked = Settings.Default.PlayerName;
            this.checkBoxDistanceToPlayer.Checked = Settings.Default.DistanceToPlayer;
            this.checkBoxDeadPlayers.Checked = Settings.Default.DeadPlayers;
            this.checkBoxHostilePlayerWarning.Checked = Settings.Default.HostilePlayerWarning;
            this.checkBoxOnlyHostilePlayers.Checked = Settings.Default.OnlyHostilePlayers;

            if (Settings.Default.DistanceType == 0) {
                radioButtonMeter.Checked = true;
                radioButtonFeet.Checked = false;
            } else {
                radioButtonMeter.Checked = false;
                radioButtonFeet.Checked = true;
            }
        }

        private void checkBoxPlayerName_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.PlayerName = checkBoxPlayerName.Checked;
            Settings.Default.Save();
        }

        private void checkBoxDistanceToPlayer_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.DistanceToPlayer = checkBoxDistanceToPlayer.Checked;
            Settings.Default.Save();
        }

        private void checkBoxDeadPlayers_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.DeadPlayers = checkBoxDeadPlayers.Checked;
            Settings.Default.Save();
        }

        private void checkBoxHostilePlayerWarning_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.HostilePlayerWarning = checkBoxHostilePlayerWarning.Checked;
            Settings.Default.Save();
        }

        private void radioButtonMeter_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.DistanceType = 0;
            Settings.Default.Save();
        }

        private void radioButtonFeet_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.DistanceType = 1;
            Settings.Default.Save();
        }

        private void checkBoxOnlyHostilePlayers_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.OnlyHostilePlayers = checkBoxOnlyHostilePlayers.Checked;
            Settings.Default.Save();
        }

        private void checkBoxCrosshair_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Crosshair = checkBoxCrosshair.Checked;
            Settings.Default.Save();
        }

        private void checkBoxTurrets_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Turrets = checkBoxTurrets.Checked;
            Settings.Default.Save();
        }

        private void checkBoxHelicopters_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Helicopters = checkBoxHelicopters.Checked;
            Settings.Default.Save();
        }

        private void checkBoxPlanes_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Planes = checkBoxPlanes.Checked;
            Settings.Default.Save();
        }

        #region MenuStrip
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void advancedSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAdvancedSettings().ShowDialog();
        }
        #endregion
    }

    public class EspStatus
    {
        public const string SEARCHING_GAME = "Searching for game instance";
        public const string ESP_NOT_RUNNING = "Game instance found. Waiting for player to join a game";
        public const string ESP_RUNNING = "Game instance found. ESP is running";
        public const string DEVICE_ERROR = "A D3D Device error occured, restart the ESP.";

        public static string CurrentStatus = SEARCHING_GAME;
    }
}
