using System;
using System.Text;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using NAudio.Wave;
using System.Net;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public static SpeechRecognitionEngine determinant = new SpeechRecognitionEngine(new CultureInfo("ru-RU"));
        public static SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        public static float confidence = ConfidenceResult();
        private WaveIn waveIn;
        private WaveFileWriter writer;
        public static string voice = VoiceDefault();
        private int x, y;
        private bool mouse_move = false, recording = true;
        public static string search_def = Search();
        private byte timers = 3;

        public Form1()
        {
            InitializeComponent();
            home1.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                determinant.SetInputToDefaultAudioDevice();
                synthesizer.SelectVoice(voice);
                synthesizer.Volume = settings.trackBar1.Value;
                synthesizer.Rate = -1;
            }
            catch { }

            determinant.LoadGrammar(Grammar());
            determinant.LoadGrammar(Grammar1());
            determinant.LoadGrammar(Grammar2());
            determinant.LoadGrammar(Grammar3());
            determinant.LoadGrammar(Grammar4());

            determinant.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Determinant_SpeechRecognized);
            determinant.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(Determinant_SpeechHypothesized);

            determinant.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void Determinant_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            if (e.Result.Text == "Ася, найди в интернете" && e.Result.Confidence > confidence && recording)
            {
                this.Invoke(new Action(() => StartRecording1()));

                determinant.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(Determinant_SpeechDetected);

                recording = false;

                this.Invoke(new Action(() => timer1.Start())); 
            }    
        }

        private void Determinant_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            timers = 3;
        }


        private void Determinant_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence < confidence) return;

            string key = null, word = null;

            foreach (var item in e.Result.Semantics)
            {
                word = item.Value.Value.ToString();
                key = item.Key;
            }

            try
            {
                switch (key)
                {
                    case "открытие":
                        try
                        {
                            synthesizer.SpeakAsync("Открываю");
                            Process.Start(DefinitionProcess(word, 1));
                        }
                        catch
                        { MessageBox.Show(("Неверно указан процесс для ключевой фразы - " + "\"" + word + "\""), "Неверный процесс"); }
                        break;
                    case "закрытие":
                        synthesizer.SpeakAsync("Закрываю");
                        Process[] processes = Process.GetProcessesByName(DefinitionProcess(word, 2));
                        foreach (var x in processes)
                            x.Kill();
                        break;
                    case "время":
                        synthesizer.SpeakAsync(new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).ToString());
                        break;
                    case "компьютер":
                        byte commands = 0;
                        switch (word)
                        {
                            case "выключи компьютер":
                                commands = 1;
                                break;
                            case "перезагрузи компьютер":
                                commands = 2;
                                break;
                        }
                        Form2 form2 = new Form2(commands);
                        this.Invoke(new Action(() => form2.Show()));
                        this.Invoke(new Action(() => form2.timer_start()));
                        break;
                }
            }
            catch { }
        }

        private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private void StartRecording1()
        {
            try
            {
                waveIn = new WaveIn();
                waveIn.DeviceNumber = 0;
                waveIn.WaveFormat = new WaveFormat(8000, 1);
                writer = new WaveFileWriter(@"C:\VoiceAssistant\file.wav", waveIn.WaveFormat);
                waveIn.DataAvailable += waveIn_DataAvailable;
                waveIn.StartRecording();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void StopRecording()
        {
            this.Invoke(new Action(() => waveIn.Dispose()));
            waveIn = null;
            this.Invoke(new Action(() => writer.Close()));
            writer = null;
        }

        public SpeechRecognitionEngine determinant1
        {
            get { return determinant; }
        }

        private string DefinitionProcess(string word, int x)
        {
            string path = null;

            switch (x)
            {
                case 1:
                    path = @"C:\VoiceAssistant\commandsopen.txt";
                    break;
                case 2:
                    path = @"C:\VoiceAssistant\commandsclose.txt";
                    break;
            }

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string process = null;

                while (sr.Peek() != -1)
                {
                    if (word == sr.ReadLine())
                    {
                        process = sr.ReadLine();
                        break;
                    }
                    else
                        sr.ReadLine();
                }
                sr.Close();
                return process;
            }
        }

        private static string Search()
        {
            if (File.ReadAllText(@"C:\VoiceAssistant\\search.txt") == null)
                return "https://www.google.ru/search?newwindow=1&source=hp&ei=q5XEW8uiE-j6qwGI4q34AQ&q=";
            else 
                return File.ReadAllText(@"C:\VoiceAssistant\\search.txt");
        }

        public Grammar Grammar()
        {
            Choices words = new Choices();
            string[] choices = words_open_closed();

            for (int i = 0; i < File.ReadAllLines(@"C:\VoiceAssistant\\commandsclose.txt").Length / 2; i++)
                words.Add(choices[i]);

            Choices commands = new Choices("Ася, открой", "Ася, запусти");

            GrammarBuilder gb = new GrammarBuilder(commands);
            gb.Append(new SemanticResultKey("открытие", words));

            return new Grammar(gb);
        }

        public Grammar Grammar1()
        {
            Choices words = new Choices();
            string[] choices = words_open_closed();

            for (int i = 0; i < File.ReadAllLines(@"C:\VoiceAssistant\\commandsclose.txt").Length / 2; i++)
                words.Add(choices[i]);

            Choices commands = new Choices("Ася, закрой", "Ася, выключи");

            GrammarBuilder gb = new GrammarBuilder(commands);
            gb.Append(new SemanticResultKey("закрытие", words));

            return new Grammar(gb);
        }

        private Grammar Grammar2()
        { 
            Choices commands = new Choices("Ася, который час", "Ася, сколько времени");

            GrammarBuilder gb = new GrammarBuilder(new SemanticResultKey("время", commands));

            return new Grammar(gb);
        }

        private Grammar Grammar3()
        {
            return new Grammar(new GrammarBuilder("Ася, найди в интернете"));
        }

        private Grammar Grammar4()
        {
            Choices words = new Choices();

            words.Add("выключи компьютер");
            words.Add("перезагрузи компьютер");

            Choices commands = new Choices("Ася");

            GrammarBuilder gb = new GrammarBuilder(commands);
            gb.Append(new SemanticResultKey("компьютер", words));

            return new Grammar(gb);
        }

        private string[] words_open_closed()
        {
            string[] words = new string[(File.ReadAllLines(@"C:\VoiceAssistant\\commandsclose.txt").Length / 2)];

            using (StreamReader sr = new StreamReader(@"C:\VoiceAssistant\\commandsclose.txt", Encoding.Default))
            {
                int i = 0;
                while (sr.Peek() != -1)
                {
                    string word = sr.ReadLine();
                    sr.ReadLine();
                    words[i] = word;
                    i++;
                }
                sr.Close();
            }
            return words;
        }

        private static float ConfidenceResult()
        {
            CommandsCreature();
            StreamReader sr = new StreamReader(@"C:\VoiceAssistant\\confidenceresult.txt", Encoding.Default);
            string result = sr.ReadLine();
            sr.Close();

            if (result == null)
                return 0.6F;
            else
                return (float)Convert.ToDouble(result);
        }

        private static string VoiceDefault()
        {
            StreamReader sr = new StreamReader(@"C:\VoiceAssistant\\voicedefault.txt", Encoding.Default);
            string result = sr.ReadLine();
            sr.Close();

            if (result == null)
                return synthesizer.GetInstalledVoices(new CultureInfo("ru-RU"))[0].VoiceInfo.Name;
            else
                return Convert.ToString(result);
        }

        private static void CommandsCreature()
        {
            if (File.Exists(@"C:\VoiceAssistant\\commandsclose.txt") && File.Exists(@"C:\VoiceAssistant\\commandsopen.txt") && File.Exists(@"C:\VoiceAssistant\\voicedefault.txt") &&
                File.Exists(@"C:\VoiceAssistant\voicevalue.txt") && File.Exists(@"C:\VoiceAssistant\\search.txt") && File.Exists(@"C:\VoiceAssistant\\confidenceresult.txt"))
                return;

            Directory.CreateDirectory(@"C:\VoiceAssistant");
            File.AppendAllText(@"C:\VoiceAssistant\\confidenceresult.txt", null);
            File.AppendAllText(@"C:\VoiceAssistant\\commandsclose.txt", null);
            File.AppendAllText(@"C:\VoiceAssistant\\commandsopen.txt", null);
            File.AppendAllText(@"C:\VoiceAssistant\\voicedefault.txt", null); 
            File.AppendAllText(@"C:\VoiceAssistant\voicevalue.txt", null);
            File.AppendAllText(@"C:\VoiceAssistant\\search.txt", null);

            if (File.ReadAllText(@"C:\VoiceAssistant\\commandsclose.txt") != "") return;

            StreamWriter sw = new StreamWriter(@"C:\VoiceAssistant\commandsclose.txt", false, Encoding.Default);
            StreamWriter sw1 = new StreamWriter(@"C:\VoiceAssistant\commandsopen.txt", false, Encoding.Default);

            string[] commands = { "редактор реестра", "regedit" ,  "диспетчер задач", "Taskmgr" , "проводник", "explorer", "калькулятор" };

            for (int i = 0; i < commands.Length; i++)
            {
                if (i != 5)
                    sw.WriteLine(commands[i]);
                else
                    sw.WriteLine("-");
                sw1.WriteLine(commands[i]);
            }

            sw.WriteLine("Calculator");
            sw1.WriteLine("calc");

            sw.Close();
            sw1.Close();
        }

        private async void WordResult(byte[] bytes)
        {
            try
            {
                synthesizer.SpeakAsync("Уже ищу");

                var uri = string.Format("https://asr.yandex.net/asr_xml?" + "uuid=01ae13cb744628b58fb536d496daa1e6&key=39fee5e9-2ec9-4a42-8020-53e235ca6d"  +
               "be&topic=queries&lang=ru - RU");

                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "POST";
                request.ContentType = "audio/x-wav";
                request.ContentLength = bytes.Length;


                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                var response = await request.GetResponseAsync();

                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string words = reader.ReadToEnd().Remove(0, 98);
                words = words.Remove(words.IndexOf("</variant>"), words.Length - words.IndexOf("</variant>"));

                recording = true;

                Process.Start(search_def + words);
            }
           catch { }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel4.Top = button2.Top;
            addCommands1.BringToFront();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            panel4.Top = button3.Top;
            deleteCommands1.BringToFront();
            deleteCommands1.DeleteCommands_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Top = button1.Top;
            home1.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Top = button4.Top;
            micro1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Top = button5.Top;
            settings1.BringToFront();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timers <= 1)
            {
                timer1.Stop();
                if (waveIn != null)
                {
                    StopRecording();
                    WordResult(File.ReadAllBytes(@"C:\VoiceAssistant\file.wav"));
                }
            }
            else
                timers--;   
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            mouse_move = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}