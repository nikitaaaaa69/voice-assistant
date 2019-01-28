using System;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using System.IO;
using System.Globalization;

namespace WindowsFormsApp2
{
    public partial class Micro : UserControl
    {
        SpeechRecognitionEngine determinant_ = new SpeechRecognitionEngine(new CultureInfo("ru-RU"));
        static short i = 1;
        static float conconfidence1, conconfidence2;

        public Micro()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "               Откалибровать")
            {
                button5.Text = "                     Отмена";

                Form1.button1.Enabled = false;
                Form1.button2.Enabled = false;
                Form1.button3.Enabled = false;
                Form1.button4.Enabled = false;
                Form1.button5.Enabled = false;

                determinant_.SetInputToDefaultAudioDevice();
                determinant_.LoadGrammar(new Grammar(new GrammarBuilder("калькулятор, дисретчер задач, редактор реестра")));

                determinant_.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Determinant_SpeechRecognized_);

                determinant_.RecognizeAsync(RecognizeMode.Multiple);
            }
            else
            {
                button5.Text = "               Откалибровать";

                determinant_.RecognizeAsyncStop();

                Form1.button1.Enabled = true;
                Form1.button2.Enabled = true;
                Form1.button3.Enabled = true;
                Form1.button4.Enabled = true;
                Form1.button5.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = "";
            timer1.Stop();
        }

        private void Determinant_SpeechRecognized_(object sender, SpeechRecognizedEventArgs e)
        {
              switch (i)
            {
                case 1:
                    conconfidence1 = e.Result.Confidence;
                    label5.Text = "✓";
                    i = 2;
                    break;
                case 2:
                    conconfidence2 = e.Result.Confidence;
                    label6.Text = "✓";
                    i = 3;
                    break;
                case 3:
                    conconfidence1 = ((conconfidence1 + conconfidence2 + e.Result.Confidence) / 3) - 0.09f;
                    determinant_.RecognizeAsyncStop();
                    button5.Text = "               Откалибровать";
                    label7.Text = "✓";
                    i = 0;

                    Form1.confidence = conconfidence1;
                    File.WriteAllText(@"C:\VoiceAssistant\\confidenceresult.txt", conconfidence1.ToString());

                    Form1.button1.Enabled = true;
                    Form1.button2.Enabled = true;
                    Form1.button3.Enabled = true;
                    Form1.button4.Enabled = true;
                    Form1.button5.Enabled = true;

                    label5.Text = "";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "Микрофон успешно откалиброван";

                    timer1.Start();
                    break;
            }
        }

    }
}
