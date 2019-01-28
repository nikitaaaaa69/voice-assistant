using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        private int x;
        private int y;
        private bool mouse_move;
        public static byte commands;

        public Form2(byte x)
        {
            InitializeComponent();
            commands = x;
        }

        public void timer_start()
        {
            timer1.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            x = Cursor.Position.X;
            y = Cursor.Position.Y;
            mouse_move = true;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_move)
            {
                this.Left = this.Left + (Cursor.Position.X - x);
                this.Top = this.Top + (Cursor.Position.Y - y);

                x = Cursor.Position.X;
                y = Cursor.Position.Y;
            }
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            mouse_move = false;
        }

        private void run()
        {
            switch (commands)
            {
                case 1:
                    var p = new ProcessStartInfo("cmd", "/r shutdown -f -s -t 0") { CreateNoWindow = true };
                    Process.Start(p);
                    break;
                case 2:
                    var r = new ProcessStartInfo("cmd", "/c restart -s -t 00") { CreateNoWindow = true };
                    Process.Start(r);
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label3.Text == "1")
                run();
            else
                label3.Text = (Convert.ToInt32(label3.Text) - 1).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label3.Text = "10";
            this.Close();
        }

    }
}
