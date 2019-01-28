namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.settings1 = new WindowsFormsApp2.settings();
            this.micro1 = new WindowsFormsApp2.Micro();
            this.home1 = new WindowsFormsApp2.Home();
            this.deleteCommands1 = new WindowsFormsApp2.DeleteCommands();
            this.addCommands1 = new WindowsFormsApp2.AddCommands();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(button5);
            this.panel1.Controls.Add(button4);
            this.panel1.Controls.Add(button3);
            this.panel1.Controls.Add(button2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 501);
            this.panel1.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(-4, 460);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(53, 41);
            this.button6.TabIndex = 8;
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.button6, resources.GetString("button6.ToolTip"));
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button5.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            button5.ForeColor = System.Drawing.Color.White;
            button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button5.Location = new System.Drawing.Point(20, 299);
            button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(320, 62);
            button5.TabIndex = 7;
            button5.Text = "         Настройки";
            button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = true;
            button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button4.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            button4.ForeColor = System.Drawing.Color.White;
            button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button4.Location = new System.Drawing.Point(20, 238);
            button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(323, 62);
            button4.TabIndex = 6;
            button4.Text = "         Калибровка микрофона";
            button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = true;
            button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button3.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            button3.ForeColor = System.Drawing.Color.White;
            button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button3.Location = new System.Drawing.Point(20, 176);
            button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(323, 62);
            button3.TabIndex = 5;
            button3.Text = "         Удалить команду";
            button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            button2.ForeColor = System.Drawing.Color.White;
            button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button2.Location = new System.Drawing.Point(20, 114);
            button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(323, 62);
            button2.TabIndex = 4;
            button2.Text = "         Добавить команду";
            button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel4.Location = new System.Drawing.Point(0, 53);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(13, 62);
            this.panel4.TabIndex = 3;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            button1.ForeColor = System.Drawing.Color.White;
            button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button1.Location = new System.Drawing.Point(20, 53);
            button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(320, 62);
            button1.TabIndex = 0;
            button1.Text = "         Главный экран";
            button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(343, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(668, 10);
            this.panel2.TabIndex = 1;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(368, 5);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(116, 128);
            this.panel3.TabIndex = 2;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.label1.Location = new System.Drawing.Point(35, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "АСЯ";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-33, -15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.settings1);
            this.panel5.Controls.Add(this.micro1);
            this.panel5.Controls.Add(this.home1);
            this.panel5.Controls.Add(this.deleteCommands1);
            this.panel5.Controls.Add(this.addCommands1);
            this.panel5.Location = new System.Drawing.Point(343, 132);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(668, 369);
            this.panel5.TabIndex = 6;
            // 
            // settings1
            // 
            this.settings1.Location = new System.Drawing.Point(0, 0);
            this.settings1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.settings1.Name = "settings1";
            this.settings1.Size = new System.Drawing.Size(668, 369);
            this.settings1.TabIndex = 4;
            // 
            // micro1
            // 
            this.micro1.Location = new System.Drawing.Point(0, 0);
            this.micro1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.micro1.Name = "micro1";
            this.micro1.Size = new System.Drawing.Size(668, 369);
            this.micro1.TabIndex = 3;
            // 
            // home1
            // 
            this.home1.Location = new System.Drawing.Point(0, 4);
            this.home1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.home1.Name = "home1";
            this.home1.Size = new System.Drawing.Size(668, 366);
            this.home1.TabIndex = 2;
            // 
            // deleteCommands1
            // 
            this.deleteCommands1.Location = new System.Drawing.Point(0, 1);
            this.deleteCommands1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.deleteCommands1.Name = "deleteCommands1";
            this.deleteCommands1.Size = new System.Drawing.Size(668, 369);
            this.deleteCommands1.TabIndex = 1;
            // 
            // addCommands1
            // 
            this.addCommands1.Location = new System.Drawing.Point(0, 1);
            this.addCommands1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.addCommands1.Name = "addCommands1";
            this.addCommands1.Size = new System.Drawing.Size(668, 369);
            this.addCommands1.TabIndex = 0;
            // 
            // button9
            // 
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.Location = new System.Drawing.Point(921, 12);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(43, 28);
            this.button9.TabIndex = 5;
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(964, 12);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(43, 28);
            this.button7.TabIndex = 3;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1011, 501);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(693, 441);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ася";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Panel panel5;
        private AddCommands addCommands1;
        private DeleteCommands deleteCommands1;
        private Home home1;
        private Micro micro1;
        private settings settings1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        public static System.Windows.Forms.Button button1;
        public static System.Windows.Forms.Button button5;
        public static System.Windows.Forms.Button button4;
        public static System.Windows.Forms.Button button3;
        public static System.Windows.Forms.Button button2;
    }
}

