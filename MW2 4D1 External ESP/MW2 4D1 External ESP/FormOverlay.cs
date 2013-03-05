using Microsoft.DirectX.Direct3D;
using System;
using System.Drawing;
using System.Threading;
using Font = Microsoft.DirectX.Direct3D.Font;
using System.Windows.Forms;
using Microsoft.DirectX;
using MW2_4D1_External_ESP.Properties;

namespace MW2_4D1_External_ESP
{
    public partial class FormOverlay : Form
    {
        public static volatile bool IsRunning;

        private Thread renderThread;
        private volatile Device device;
        private volatile PresentParameters pp;
        private volatile Sprite sprite;
        private volatile Font smallFont;
        private volatile Font largeFont;
        private volatile Line line;

        public FormOverlay()
        {
            InitializeComponent();
            SetCustomStyle();
        }

        private void FormOverlay_Load(object sender, EventArgs e)
        {
            renderThread = new Thread(() => Render());

            pp = new PresentParameters()
            {
                Windowed = true,
                SwapEffect = SwapEffect.Discard,
                BackBufferFormat = Format.A8R8G8B8
            };

            device = new Device(0, DeviceType.Hardware, this.Handle, CreateFlags.HardwareVertexProcessing, pp);

            sprite = new Sprite(device);
            smallFont = new Font(device, 14, 0, FontWeight.Normal, 0, false, CharacterSet.Ansi, Precision.Default,
                FontQuality.ClearType, PitchAndFamily.DefaultPitch, "Segoe UI");
            largeFont = new Font(device, 28, 0, FontWeight.Bold, 0, false, CharacterSet.Ansi, Precision.Default,
                FontQuality.ClearType, PitchAndFamily.DefaultPitch, "Segoe UI");
            line = new Line(device);
            line.Antialias = false;

            IsRunning = true;
            renderThread.Start();
        }

        private void FormOverlay_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsRunning = false;
            renderThread.Abort();

            if (!device.Disposed)
                device.Dispose();
            if (!sprite.Disposed)
                sprite.Dispose();
            if (!smallFont.Disposed)
                smallFont.Dispose();
            if (!largeFont.Disposed)
                largeFont.Dispose();
            if (!line.Disposed)
                line.Dispose();

            Game.CloseProcess();
        }

        private void Render()
        {
            while (IsRunning) {
                device.Clear(ClearFlags.Target, Color.FromArgb(0, 0, 0, 0), 1.0f, 0);

                Thread.Sleep(16);

                if (Game.IsGameRunning()) {
                    Game.OpenProcess();
                    Game.ReadGame();

                    MoveWindow();

                    if (Game.IsGameWindowInForeground()) {
                        device.BeginScene();
                        {
                            DrawLargeText(string.Format("[MW2 4D1 External ESP: v{0}]", 
                                FormMain.ProductVersion()), 
                                new PointF(this.Width * 0.15f, 4.0f), Color.Lime);

                            if (Game.IsPlayerInGame()) {
                                EspStatus.CurrentStatus = EspStatus.ESP_RUNNING;

                                foreach (var player in Game.Players) {
                                    DrawPlayerESP(player);
                                }
                            } else {
                                EspStatus.CurrentStatus = EspStatus.ESP_NOT_RUNNING;
                            }
                        }
                        device.EndScene();
                    } else {
                        if (Game.IsPlayerInGame())
                            EspStatus.CurrentStatus = EspStatus.ESP_RUNNING;
                        else
                            EspStatus.CurrentStatus = EspStatus.ESP_NOT_RUNNING;
                    }

                } else {
                    EspStatus.CurrentStatus = EspStatus.SEARCHING_GAME;
                }

                try {
                    device.Present();
                } catch (DeviceLostException) {
                    MessageBox.Show("ESP Crashed, do not use this program while entering a Full screen application.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EspStatus.CurrentStatus = EspStatus.DEVICE_ERROR;
                    IsRunning = false;
                }
            }
        }

        private void DrawPlayerESP(Player player)
        {
            if (player.ClientNum == Game.LocalPlayer.ClientNum)
                return;

            if (!player.IsValid)
                return;

            // Don't draw the ESP if the other vector is very close
            if (Vector.Distance(player.Origin, Game.ViewOrigin) < 80.0f)
                return;

            if (Settings.Default.OnlyHostilePlayers && player.Team == PlayerTeam.Friendly)
                return;

            player.Name = string.Format("|{0}| {1}", player.Rank, player.Name);

            Color color;
            if (player.Team == PlayerTeam.Friendly) {
                color = Settings.Default.FriendlyColor;
            } else {
                color = Settings.Default.HostileColor;
            }
            if (!player.IsAlive) {
                color = Settings.Default.DeadPlayerColor;
                player.Name += " [DEAD]";

                if (!Settings.Default.DeadPlayers)
                    return;
            }

            PointF feetPoint, headPoint;
            if (MathHelper.WorldToScreen(player.Origin, out feetPoint)) {
                MathHelper.WorldToScreen(player.Origin + new Vector(0f, 0f, 62f), out headPoint);
            } else {
                return;
            }

            var drawPoint = new PointF();
            drawPoint.Y = feetPoint.Y - headPoint.Y;

            if (drawPoint.Y < 10.0f)
                drawPoint.Y = 10.0f;

            if ((player.Flag & Flags.Crouched) == Flags.Crouched) {
                drawPoint.Y /= 1.5f;
                drawPoint.X = drawPoint.Y / 1.5f;
            } else if ((player.Flag & Flags.Prone) == Flags.Prone) {
                drawPoint.Y /= 3.0f;
                drawPoint.X = drawPoint.Y * 2.0f;
            } else {
                drawPoint.X = drawPoint.Y / 2.75f;
            }

            var boundingBox = new RectF();
            boundingBox.X = feetPoint.X - (drawPoint.X / 2.0f);
            boundingBox.Y = feetPoint.Y;
            boundingBox.W = drawPoint.X;
            boundingBox.H = -drawPoint.Y;

            var namePoint = new PointF();
            namePoint.X = boundingBox.X + boundingBox.W + 5.0f;
            namePoint.Y = feetPoint.Y - drawPoint.Y - 2.8f;

            var distancePoint = new PointF();
            distancePoint.X = boundingBox.X + boundingBox.W + 5.0f;
            distancePoint.Y = feetPoint.Y - drawPoint.Y + 9.8f;
            var distanceType = Settings.Default.DistanceType == 0 ? Distance.Meter() : Distance.Feet();
            float baseDistance = Vector.Distance(Game.LocalPlayer.Origin, player.Origin);
            float distance = (float)Math.Round((double)baseDistance * distanceType.Const, 1);

            if (baseDistance > 1200f) {
                DrawRect(boundingBox, 1f, color);
            } else {
                DrawRect(boundingBox, 2f, color);
            }

            if (Settings.Default.PlayerName)
                DrawSmallText(player.Name, namePoint, Settings.Default.PlayerNameColor);
            if (Settings.Default.DistanceToPlayer)
                DrawSmallText(distance + distanceType.Suffix, distancePoint, Settings.Default.DistanceToPlayerColor);

            if (Settings.Default.HostilePlayerWarning && player.Team == PlayerTeam.Hostile && player.IsAlive && baseDistance < 550)
                DrawLargeText("Hostile player nearby!", new PointF(this.Width * 0.35f, this.Height * 0.7f), Color.Red);
        }

        private void DrawSmallText(string text, PointF position, Color color)
        {
            sprite.Begin(SpriteFlags.AlphaBlend);
            {
                smallFont.DrawText(sprite, text, new Point((int)position.X, (int)position.Y), color);
            }
            sprite.End();
        }

        private void DrawLargeText(string text, PointF position, Color color)
        {
            sprite.Begin(SpriteFlags.AlphaBlend);
            {
                largeFont.DrawText(sprite, text, new Point((int)position.X, (int)position.Y), color);
            }
            sprite.End();
        }

        private void DrawRect(RectF rect, float width, Color color)
        {
            line.Width = width;

            Vector2[] vertexList1 = new Vector2[4];
            vertexList1[0] = new Vector2(rect.X, rect.Y);
            vertexList1[1] = new Vector2(rect.X + rect.W, rect.Y);
            vertexList1[2] = new Vector2(rect.X, rect.Y);
            vertexList1[3] = new Vector2(rect.X, rect.Y + rect.H);

            Vector2[] vertexList2 = new Vector2[4];
            vertexList2[0] = new Vector2(rect.X + rect.W, rect.Y);
            vertexList2[1] = new Vector2(rect.X + rect.W, rect.Y + rect.H);
            vertexList2[2] = new Vector2(rect.X, rect.Y + rect.H);
            vertexList2[3] = new Vector2(rect.X + rect.W, rect.Y + rect.H);

            line.Draw(vertexList1, color);
            line.Draw(vertexList2, color);
        }

        // Moves/Resizes window and resizes backbuffer
        private void MoveWindow()
        {
            if (!Game.IsGameRunning())
                return;

            Invoke((MethodInvoker)delegate()
            {
                try {
                    Point pointGame, pointThis;
                    Native.ClientToScreen(Game.hWnd, out pointGame);
                    Native.ClientToScreen(this.Handle, out pointThis);
                    Native.RECT rectGame, rectThis;
                    Native.GetClientRect(Game.hWnd, out rectGame);
                    Native.GetClientRect(this.Handle, out rectThis);

                    // If nothing has changed, do nothing
                    if (rectGame == rectThis && pointGame == pointThis)
                        return;

                    // If something has changed move/resize window and resize backbuffer
                    Native.SetWindowPos(this.Handle, IntPtr.Zero, pointGame.X, pointGame.Y, rectGame.right, rectGame.bottom, 0U);
                    pp = new PresentParameters()
                    {
                        Windowed = true,
                        SwapEffect = SwapEffect.Discard,
                        BackBufferFormat = Format.A8R8G8B8,
                        BackBufferWidth = this.Width,
                        BackBufferHeight = this.Height
                    };
                    device.Reset(pp);
                } catch { /* No point in handling exceptions from this method */ }
            });
        }

        // Makes the window transparent (amonst other things)
        private void SetCustomStyle()
        {
            Native.SetWindowLong(this.Handle, Native.GWL_STYLE,
                Native.WS_VISIBLE | Native.WS_POPUP | Native.WS_MAXIMIZE);
            Native.SetWindowLong(this.Handle, Native.GWL_EXSTYLE,
                Native.GetWindowLong(this.Handle, Native.GWL_EXSTYLE) | Native.WS_EX_LAYERED | Native.WS_EX_TRANSPARENT);

            Native.Margins margins;
            margins.cxLeftWidth = 0;
            margins.cxRightWidth = this.Width;
            margins.cyTopHeight = 0;
            margins.cyBottomHeight = this.Height;
            Native.DwmExtendFrameIntoClientArea(this.Handle, ref margins);
        }
    }
}
