using System;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;

namespace WindowsFormsApp2
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Ася готова к работе")
            {
              label1.Text = "Сейчас Ася отдыхает";
              pictureBox1.Visible = false;
                Form1.determinant.RecognizeAsyncStop();
            }
            else
            {
                label1.Text = "Ася готова к работе";
                pictureBox1.Visible = true;
                Form1.determinant.SetInputToDefaultAudioDevice();
                Form1.determinant.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

    }
}
