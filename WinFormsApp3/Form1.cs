using System.Net.Http.Headers;
using System;
using System.Runtime.InteropServices;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            [DllImport("user32.dll")]
            static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtrainfo);
            const uint LEFTDOWN = 0x0002;
            const uint LEFTUP = 0x0004;

            InitializeComponent();
            this.Text = "ClickMasters";
            this.BackColor = Color.FromArgb(30,30,30);
            int click = 0;
            int timer = 0;

            Button btnStart = new Button();
            btnStart.Text = "Запустить";
            btnStart.Location = new Point(50, 200);
            btnStart.Size = new Size(100, 30);
            btnStart.BackColor = Color.White;
            this.Controls.Add(btnStart);

            Button btnStop = new Button();
            btnStop.Text = "Стоп";
            btnStop.Location = new Point(300,200);
            btnStop.Size = new Size(100, 30);
            btnStop.BackColor = Color.White;
            this.Controls.Add(btnStop);

            Label lblTimer = new Label();
            lblTimer.Location = new Point(30,50);
            lblTimer.AutoSize = false;
            lblTimer.Size = new Size(100, 30);
            lblTimer.ForeColor = Color.White;
            this.Controls.Add(lblTimer);

            Label lblClick = new Label();
            lblClick.Location = new Point(30, 100);
            lblClick.AutoSize = false;
            lblClick.Size = new Size(100, 30);
            lblClick.ForeColor = Color.White;
            this.Controls.Add(lblClick);

            System.Windows.Forms.Timer timerClick = new System.Windows.Forms.Timer();
            timerClick.Interval = 100;

            System.Windows.Forms.Timer timerTime = new System.Windows.Forms.Timer();
            timerTime.Interval = 1000;

            btnStart.Click += (sender, e) =>
            {
                lblTimer.Text = "";
                lblClick.Text = "";
                timerClick.Start();
                timerTime.Start();
                click = 0;
                timer = 0;
            };

            btnStop.Click += (sender, e) =>
            {
                lblTimer.Text = "";
                lblClick.Text = "";
                timerClick.Stop();
                timerTime.Stop();
                click = 0;
                timer = 0;
            };

            timerClick.Tick += (sender, e) =>
            {
                click++;
                lblClick.Text = "Кликов: " + click;
                mouse_event(LEFTDOWN,0,0,0,0);
                mouse_event(LEFTUP,0,0,0,0);
            };

            timerTime.Tick += (sender, e) =>
            {
                timer++;
                lblTimer.Text = "Секунд: " + timer;
            };

        }
    }
}
