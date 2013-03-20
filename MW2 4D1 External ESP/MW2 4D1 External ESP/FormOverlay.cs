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
            smallFont = new Font(device, 15, 0, FontWeight.Normal, 0, false, CharacterSet.Ansi, Precision.Default,
                FontQuality.ClearType, PitchAndFamily.DefaultPitch, "Courier New");
            largeFont = new Font(device, 28, 0, FontWeight.Bold, 0, false, CharacterSet.Ansi, Precision.Default,
                FontQuality.ClearType, PitchAndFamily.DefaultPitch, "Courier New");
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

                Thread.Sleep(Settings.Default.RenderSleep);

                if (Game.IsGameRunning()) {
                    Game.OpenProcess();
                    Game.ReadGame();

                    MoveWindow();

                    if (Game.IsGameWindowInForeground()) {
                        device.BeginScene();
                        {
                            DrawEspVersion();

                            if (Game.IsPlayerInGame()) {
                                EspStatus.CurrentStatus = EspStatus.ESP_RUNNING;

                                DrawLobbyInfo();
                                DrawCrosshair();

                                foreach (var player in Game.Players)
                                    DrawPlayerESP(player);
                                foreach (var turret in Game.Turrets)
                                    DrawTurretESP(turret);
                                foreach (var heli in Game.Helis)
                                    DrawHelicopterESP(heli);
                                foreach (var plane in Game.Planes)
                                    DrawPlaneESP(plane);
                                foreach (var item in Game.Items)
                                    DrawExplosivesESP(item);
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
            // Don't draw the ESP if the other vector is very close
            if (Vector.Distance(player.Origin, Game.ViewOrigin) < 80.0f)
                return;

            if (Settings.Default.OnlyHostilePlayers && player.Team == PlayerTeam.Friendly)
                return;

            string name = string.Format("#{0}{{{1}}}", player.Rank, player.Name);

            Color color;
            if (player.Team == PlayerTeam.Friendly) {
                color = Settings.Default.FriendlyColor;
            } else {
                color = Settings.Default.HostileColor;
            }
            if (!player.IsAlive) {
                if (!Settings.Default.DeadPlayers)
                    return;

                name = string.Format("DEAD{{{0}}}", player.Name);
                color = Settings.Default.DeadPlayerColor;
            }

            PointF feetPoint, headPoint;
            if (MathHelper.WorldToScreen(player.Origin, out feetPoint)) {
                MathHelper.WorldToScreen(player.Origin + new Vector(0f, 0f, 63f), out headPoint);
            } else {
                return;
            }

            var drawPoint = new PointF();
            drawPoint.Y = feetPoint.Y - headPoint.Y;

            if (drawPoint.Y < 10.0f)
                drawPoint.Y = 10.0f;

            if ((player.Flag & Flags.Crouched) != 0) {
                drawPoint.Y /= 1.4f;
                drawPoint.X = drawPoint.Y / 1.5f;
            } else if ((player.Flag & Flags.Prone) != 0) {
                drawPoint.Y /= 3.0f;
                drawPoint.X = drawPoint.Y * 2.0f;
            } else {
                drawPoint.X = drawPoint.Y / 2.75f;
            }

            var boundingBox = new RectangleF();
            boundingBox.X = feetPoint.X - (drawPoint.X / 2.0f);
            boundingBox.Y = feetPoint.Y;
            boundingBox.Width = drawPoint.X;
            boundingBox.Height = -drawPoint.Y;

            var namePoint = new PointF();
            namePoint.X = boundingBox.X + boundingBox.Width + 5.0f;
            namePoint.Y = feetPoint.Y - drawPoint.Y - 2.8f;

            var distancePoint = new PointF();
            distancePoint.X = boundingBox.X + boundingBox.Width + 5.0f;
            distancePoint.Y = Settings.Default.PlayerName ? feetPoint.Y - drawPoint.Y + 9.8f : namePoint.Y;
            Distance distanceType = Settings.Default.DistanceType == 0 ? Distance.Meter() : Distance.Feet();
            float baseDistance = Vector.Distance(Game.LocalPlayer.Origin, player.Origin);
            float distance = (float)Math.Round((double)baseDistance * distanceType.Const);
            string distanceString = string.Format("➔{0}{1}", distance, distanceType.Suffix);

            DrawRect(boundingBox, 2f, color);

            if (Settings.Default.PlayerName)
                DrawSmallText(name, namePoint, Settings.Default.PlayerNameColor);
            if (Settings.Default.DistanceToPlayer)
                DrawSmallText(distanceString, distancePoint, Settings.Default.DistanceToPlayerColor);
            if (Settings.Default.HostilePlayerWarning)
                DrawHostilePlayerWarning(player, baseDistance);
        }

        private void DrawTurretESP(Turret turret)
        {
            if (!Settings.Default.Turrets)
                return;

            // Don't draw the ESP if the other vector is very close
            if (Vector.Distance(turret.Origin, Game.ViewOrigin) < 80.0f)
                return;

            PointF botPoint, topPoint;
            if (MathHelper.WorldToScreen(turret.Origin, out botPoint)) {
                MathHelper.WorldToScreen(turret.Origin + new Vector(0f, 0f, 55f), out topPoint);
            } else {
                return;
            }

            var drawPoint = new PointF();
            drawPoint.Y = botPoint.Y - topPoint.Y;
            drawPoint.X = drawPoint.Y / 2.75f;

            var boundingBox = new RectangleF();
            boundingBox.X = botPoint.X - (drawPoint.X / 2.0f);
            boundingBox.Y = botPoint.Y;
            boundingBox.Width = drawPoint.X;
            boundingBox.Height = -drawPoint.Y;

            var namePoint = new PointF();
            namePoint.X = boundingBox.X + boundingBox.Width + 5.0f;
            namePoint.Y = botPoint.Y - drawPoint.Y - 2.8f;

            DrawRect(boundingBox, 2.0f, Color.Purple);
            DrawSmallText(Turret.NAME, namePoint, Color.White);
        }

        private void DrawHelicopterESP(Helicopter heli)
        {
            if (!Settings.Default.Helicopters)
                return;

            PointF pos;
            if (!MathHelper.WorldToScreen(heli.Origin, out pos))
                return;

            var boundingBox = new RectangleF();
            boundingBox.X = pos.X - 15f;
            boundingBox.Y = pos.Y - 15f;
            boundingBox.Width = 30f;
            boundingBox.Height = 30f;

            var namePoint = new PointF();
            namePoint.X = boundingBox.X + boundingBox.Width + 5.0f;
            namePoint.Y = boundingBox.Y - 1.4f;

            DrawRect(boundingBox, 3.0f, Color.Purple);
            DrawSmallText(Helicopter.NAME, namePoint, Color.White);
        }

        private void DrawPlaneESP(Plane plane)
        {
            if (!Settings.Default.Planes)
                return;

            PointF pos;
            if (!MathHelper.WorldToScreen(plane.Origin, out pos))
                return;

            var boundingBox = new RectangleF();
            boundingBox.X = pos.X - 15f;
            boundingBox.Y = pos.Y - 15f;
            boundingBox.Width = 30f;
            boundingBox.Height = 30f;

            var namePoint = new PointF();
            namePoint.X = boundingBox.X + boundingBox.Width + 5.0f;
            namePoint.Y = boundingBox.Y - 1.4f;

            DrawRect(boundingBox, 3.0f, Color.Purple);
            DrawSmallText(Plane.NAME, namePoint, Color.White);
        }

        private void DrawExplosivesESP(Explosive explosive)
        {
            PointF pos;
            if (!MathHelper.WorldToScreen(explosive.Origin, out pos))
                return;

            var rect = new RectangleF();
            rect.X = pos.X - 3.5f;
            rect.Y = pos.Y - 3.5f;
            rect.Width = 7f;
            rect.Height = 7f;

            var namePoint = new PointF();
            namePoint.X = rect.X - 25f;
            namePoint.Y = rect.Y + 5f;

            FillRect(rect, Color.Brown);
            DrawSmallText(Explosive.NAME, namePoint, Color.White);
        }

        private void DrawHostilePlayerWarning(Player player, float baseDistance)
        {
            if (player.Team == PlayerTeam.Hostile && player.IsAlive && baseDistance < 400) {
                FillRect(new RectangleF(this.Width * 0.35f - 5f, this.Height * 0.7f + 1f, 320f, 25f), Color.FromArgb(140, 0, 0, 0));
                DrawLargeText("Hostile player nearby!", new PointF(this.Width * 0.35f, this.Height * 0.7f), Color.Red);
            }
        }

        private void DrawEspVersion()
        {
            FillRect(new RectangleF(this.Width * 0.13f - 2.0f, 5.0f, 450f, 25f), Color.FromArgb(140, 0, 0, 0));
            DrawLargeText(string.Format("[MW2 4D1 External ESP: v{0}]",
                                FormMain.ProductVersion()),
                                new PointF(this.Width * 0.13f, 4.0f), Color.Lime);
        }

        private void DrawLobbyInfo()
        {
            var rect = new RectangleF();
            rect.X = this.Width * 0.13f - 2.0f;
            rect.Y = 40f;
            rect.Width = 160f;
            rect.Height = 62f;
            FillRect(rect, Color.FromArgb(140, 0, 0, 0));
            var info = string.Format("Player count: {0}\nTurret count: {1}\nHelicopter count: {2}\nPlane count: {3}",
                                    Game.Players.Count, Game.Turrets.Count, Game.Helis.Count, Game.Planes.Count);
            DrawSmallText(info, new PointF(this.Width * 0.13f + 2f, 40.0f), Color.Lime);
        }

        private void DrawCrosshair()
        {
            if (!Settings.Default.Crosshair)
                return;

            float thickness = 2f;
            float width = 20f;

            PointF center = Game.ScreenCenter();
            
            var horizontalPt1 = new PointF();
            horizontalPt1.X = center.X - (width / 2f);
            horizontalPt1.Y = center.Y;
            var horizontalPt2 = new PointF();
            horizontalPt2.X = center.X + (width / 2f);
            horizontalPt2.Y = center.Y;
            
            var verticalPt1 = new PointF();
            verticalPt1.X = center.X;
            verticalPt1.Y = center.Y - (width / 2f);
            var verticalPt2 = new PointF();
            verticalPt2.X = center.X;
            verticalPt2.Y = center.Y + (width / 2f);

            DrawLine(horizontalPt1, horizontalPt2, thickness, Color.LightGray);
            DrawLine(verticalPt1, verticalPt2, thickness, Color.LightGray);
        }

        private void DrawSmallText(string text, PointF pos, Color color)
        {
            sprite.Begin(SpriteFlags.AlphaBlend);
            {
                smallFont.DrawText(sprite, text, new Point((int)pos.X, (int)pos.Y), color);
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

        private void DrawRect(RectangleF rect, float width, Color color)
        {
            line.Width = width;

            Vector2[] vertexList1 = new Vector2[4];
            vertexList1[0] = new Vector2(rect.X, rect.Y);
            vertexList1[1] = new Vector2(rect.X + rect.Width, rect.Y);
            vertexList1[2] = new Vector2(rect.X, rect.Y);
            vertexList1[3] = new Vector2(rect.X, rect.Y + rect.Height);

            Vector2[] vertexList2 = new Vector2[4];
            vertexList2[0] = new Vector2(rect.X + rect.Width, rect.Y);
            vertexList2[1] = new Vector2(rect.X + rect.Width, rect.Y + rect.Height);
            vertexList2[2] = new Vector2(rect.X, rect.Y + rect.Height);
            vertexList2[3] = new Vector2(rect.X + rect.Width, rect.Y + rect.Height);

            line.Draw(vertexList1, color);
            line.Draw(vertexList2, color);
        }

        private void FillRect(RectangleF rect, Color color)
        {
            var vertecies = new CustomVertex.TransformedColored[4];

            vertecies[0].Position = new Vector4(rect.X, rect.Y + rect.Height, 0, 0.5f);
            vertecies[1].Position = new Vector4(rect.X, rect.Y, 0, 0.5f);
            vertecies[2].Position = new Vector4(rect.X + rect.Width, rect.Y + rect.Height, 0, 0.5f);
            vertecies[3].Position = new Vector4(rect.X + rect.Width, rect.Y, 0, 0.5f);

            vertecies[0].Color = color.ToArgb();
            vertecies[1].Color = color.ToArgb();
            vertecies[2].Color = color.ToArgb();
            vertecies[3].Color = color.ToArgb();

            device.VertexFormat = CustomVertex.TransformedColored.Format;
            device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, vertecies);
        }

        private void DrawLine(PointF pt1, PointF pt2, float width, Color color)
        {
            line.Width = width;

            var vertexList = new Vector2[2];
            vertexList[0] = new Vector2(pt1.X, pt1.Y);
            vertexList[1] = new Vector2(pt2.X, pt2.Y);
            line.Draw(vertexList, color);
        }

        // Moves/Resizes window and resizes backbuffer (when needed)
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

        // Makes the window transparent (amongst other things)
        private void SetCustomStyle()
        {
            Native.SetWindowLong(this.Handle, Native.GWL_STYLE,
                Native.WS_VISIBLE | Native.WS_POPUP | Native.WS_MAXIMIZE);
            Native.SetWindowLong(this.Handle, Native.GWL_EXSTYLE,
                Native.GetWindowLong(this.Handle, Native.GWL_EXSTYLE) | Native.WS_EX_LAYERED | Native.WS_EX_TRANSPARENT);

            Native.Margins margins;
            margins.cxLeftWidth = -1;
            margins.cxRightWidth = -1;
            margins.cyTopHeight = -1;
            margins.cyBottomHeight = -1;
            Native.DwmExtendFrameIntoClientArea(this.Handle, ref margins);
        }
    }
}
