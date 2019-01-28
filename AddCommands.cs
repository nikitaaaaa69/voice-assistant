using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class AddCommands : UserControl
    {
        private static string process_path;
        private bool url = true;

        public AddCommands()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Выберите нужную программу";
            openFileDialog1.Filter = "exe | *.exe";

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            else
                url = false;

            string name = openFileDialog1.SafeFileName, process_name = null; process_path = openFileDialog1.FileName;

            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == '.')
                    for (int j = 0; j < i; j++)
                    {
                        char z = name[j];
                        process_name += z;
                    }
            }
            textBox2.Text = process_name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
                label3.Text = "Введите ключевую фразу и имя процесса.";
            else if (textBox1.Text.Length < 4)
                label3.Text = "Ключевая фраза слишком короткая.";
            else if (textBox2.Text.Length < 4)
                label3.Text = "Фраза слишком короткая.";
            else if (textBox2.Text == "")
                label3.Text = "Введите имя процесса.";
            else if (textBox1.Text == "")
                label3.Text = "Введите ключевую фразу.";
            else if (!Exist(textBox1.Text))
                label3.Text = "Такая фраза уже существует.";
            else if (textBox2.Text.IndexOf(@"http://") != 0 && textBox2.Text.IndexOf(@"https://") != 0 && textBox2.Text.IndexOf(@"www.") != 0 && url)
                label3.Text = "Некорректная ссылка.";
            else if (textBox2.Text.IndexOf(@".") == -1 && url)
                label3.Text = "Некорректная ссылка.";
            else
            {
                StreamWriter sw = new StreamWriter(@"C:\VoiceAssistant\commandsclose.txt", true, Encoding.Default);
                StreamWriter sw1 = new StreamWriter(@"C:\VoiceAssistant\commandsopen.txt", true, Encoding.Default);

                if (process_path == null)
                    process_path = textBox2.Text;

                sw.WriteLine(textBox1.Text);
                sw.WriteLine(textBox2.Text);
                sw1.WriteLine(textBox1.Text);
                sw1.WriteLine(process_path);

                sw.Close();
                sw1.Close();

                url = true;
                timer1.Stop();
                timer1.Start();
                textBox1.Text = "";
                textBox2.Text = "";
                label4.Text = "Команда успешно добавлена";
                label3.Text = "";

                Form1 form1 = new Form1();

                form1.determinant1.LoadGrammar(form1.Grammar());
                form1.determinant1.LoadGrammar(form1.Grammar1());
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar == (Char)Keys.Space) && (textBox1.Text[textBox1.Text.Length - 1] != (Char)Keys.Space));
                else if ((e.KeyChar < 1040 || e.KeyChar > 1103) && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            }
            catch
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 64 && e.KeyChar < 91) || (e.KeyChar > 96 && e.KeyChar < 123) || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == '-' || e.KeyChar == '.' || e.KeyChar == '_' ||
                e.KeyChar == '~' || e.KeyChar == ':' || e.KeyChar == '/' || e.KeyChar == '?' || e.KeyChar == '#' || e.KeyChar == '[' || e.KeyChar == ']' || e.KeyChar == '@' ||
                e.KeyChar == '!' || e.KeyChar == '$' || e.KeyChar == '&' || e.KeyChar == '\'' || e.KeyChar == '(' || e.KeyChar == ')' || e.KeyChar == '*' || e.KeyChar == '+' ||
                e.KeyChar == ',' || e.KeyChar == ';' || e.KeyChar == '=' || e.KeyChar != (char)Keys.Delete || e.KeyChar != (char)Keys.Back);
            else
                e.Handled = true;
        }

        private bool Exist(string file_name)
        {
            using (StreamReader sr = new StreamReader(@"C:\VoiceAssistant\commandsclose.txt", Encoding.Default))
            {
                while (sr.Peek() != -1)
                {
                    if (file_name == sr.ReadLine())
                    {
                        sr.Close(); return false;
                    }
                    sr.ReadLine();
                }
                sr.Close();
            }
            return true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = "";
            timer1.Stop();
        }

    }
}
