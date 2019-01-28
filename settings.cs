using System;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;
using System.Globalization;

namespace WindowsFormsApp2
{
    public partial class settings : UserControl
    {
        static SpeechSynthesizer synthesizer_ = new SpeechSynthesizer();

        public settings()
        {
            InitializeComponent();

            trackBar1.Minimum = 0;
            trackBar1.Maximum = 100;
            trackBar1.Value = vocicevalue();
            label4.Text = trackBar1.Value.ToString();

            var voices = synthesizer_.GetInstalledVoices(new CultureInfo("ru-RU"));

            foreach (var voice in voices)
                comboBox1.Items.Add(voice.VoiceInfo.Name);

            if (File.ReadAllText(@"C:\VoiceAssistant\\voicedefault.txt") == "")
                comboBox1.Text = synthesizer_.GetInstalledVoices(new CultureInfo("ru-RU"))[0].VoiceInfo.Name;
            else
                comboBox1.Text = File.ReadAllText(@"C:\VoiceAssistant\\voicedefault.txt");

            if (File.ReadAllText(@"C:\VoiceAssistant\\search.txt") == "")
                radioButton2.Checked = true;
            else if (File.ReadAllText(@"C:\VoiceAssistant\\search.txt") == "https://yandex.ru/search/?text=")
                radioButton1.Checked = true;
            else
                radioButton3.Checked = true;
        }

        private int vocicevalue()
        {
            StreamReader sr = new StreamReader(@"C:\VoiceAssistant\\voicevalue.txt", Encoding.Default);
            string result = sr.ReadLine();

            sr.Close();

            if (result == null)
                return 70;
            else
                return Convert.ToInt32(result);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\VoiceAssistant\\voicedefault.txt", comboBox1.Text, Encoding.Default);
            Form1.synthesizer.SelectVoice(comboBox1.Text);
            
            var voices = synthesizer_.GetInstalledVoices(new CultureInfo("ru-RU"));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            synthesizer_.SelectVoice(comboBox1.Text);
            synthesizer_.SpeakAsync(textBox1.Text);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar == (Char)Keys.Space) && (textBox1.Text[textBox1.Text.Length - 1] != (Char)Keys.Space)) ;
                else if ((e.KeyChar < 1040 || e.KeyChar > 1103) && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }
            catch
            {
                e.Handled = true;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar1.Value.ToString();

            File.WriteAllText(@"C:\VoiceAssistant\\voicevalue.txt", trackBar1.Value.ToString(), Encoding.Default);

            Form1.synthesizer.Volume = trackBar1.Value;
            synthesizer_.Volume = trackBar1.Value;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\VoiceAssistant\\search.txt", "https://yandex.ru/search/?text=", Encoding.Default);
            Form1.search_def = "https://yandex.ru/search/?text=";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\VoiceAssistant\\search.txt", null, Encoding.Default);
            Form1.search_def = "https://www.google.ru/search?newwindow=1&source=hp&ei=q5XEW8uiE-j6qwGI4q34AQ&q=";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\VoiceAssistant\\search.txt", "https://www.bing.com/search?q=", Encoding.Default);
            Form1.search_def = "https://www.bing.com/search?q=";
        }

    }
}
