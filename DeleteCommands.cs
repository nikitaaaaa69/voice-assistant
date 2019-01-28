using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class DeleteCommands : UserControl
    {
        private static string path_open = @"C:\VoiceAssistant\\commandsopen.txt";
        private static string path_close = @"C:\VoiceAssistant\\commandsclose.txt";
        private int index;

        public DeleteCommands()
        {
            InitializeComponent();
        }

        public void DeleteCommands_Load(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                using (StreamReader sr = new StreamReader(path_close, Encoding.Default))
                {
                    while (sr.Peek() != -1)
                    {
                        this.listBox1.Items.Add(sr.ReadLine());
                        sr.ReadLine();
                    }
                    sr.Close();
                }
                listBox1.Text = listBox1.Items[0].ToString();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index == -1)
            {
                timer1.Start();
                label2.Text = "Выберите команду";
                return;
            }

            if (listBox1.Items.Count == 1)
            {
                timer1.Start();
                label2.Text = "Нельзя удалить все команды!";
                return;
            }

            File.WriteAllLines(path_close, deletecommand(path_close, listBox1.SelectedItem.ToString()), Encoding.Default);
            File.WriteAllLines(path_open, deletecommand(path_open, listBox1.SelectedItem.ToString()), Encoding.Default);

            listBox1.Items.Remove(listBox1.Items[index]);

            Form1 form1 = new Form1();

            form1.determinant1.LoadGrammar(form1.Grammar());
            form1.determinant1.LoadGrammar(form1.Grammar1());
        }

        private string[] deletecommand(string path, string word)
        {
            string[] file = new string[File.ReadAllLines(path).Length - 2];

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                int i = 0;
                while (sr.Peek() > -1)
                {
                    string command = sr.ReadLine();
                    if (command == word)
                        sr.ReadLine();
                    else
                    {
                        file[i] += command;
                        i++;
                    }
                }
            }
            return file;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "";
            timer1.Stop();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            index = listBox.SelectedIndex;
        }
    }
}
