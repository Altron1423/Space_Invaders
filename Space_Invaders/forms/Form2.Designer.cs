namespace Space_Invaders
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.готово;
            pictureBox1.Location = new Point(2, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(914, 558);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 64, 0);
            button1.Font = new Font("Wide Latin", 14.25F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(141, 292);
            button1.Name = "button1";
            button1.Size = new Size(234, 46);
            button1.TabIndex = 1;
            button1.Text = "▶️ НАЧАТЬ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.MouseLeave += button1_MouseLeave;
            button1.MouseMove += button1_MouseMove;
            // 
            // button2
            // 
            button2.BackColor = Color.Maroon;
            button2.Font = new Font("Wide Latin", 14.25F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(141, 475);
            button2.Name = "button2";
            button2.Size = new Size(234, 46);
            button2.TabIndex = 2;
            button2.Text = "✖️ ВЫХОД";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.MouseLeave += button_MouseLeave;
            button2.MouseMove += button_MouseMove;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(0, 64, 0);
            button3.Font = new Font("Wide Latin", 14.25F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(141, 353);
            button3.Name = "button3";
            button3.Size = new Size(234, 46);
            button3.TabIndex = 3;
            button3.Text = "🎮 УПРАВЛЕНИЕ";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            button3.MouseLeave += button1_MouseLeave;
            button3.MouseMove += button1_MouseMove;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(0, 64, 0);
            button4.Font = new Font("Wide Latin", 14.25F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(141, 414);
            button4.Name = "button4";
            button4.Size = new Size(234, 46);
            button4.TabIndex = 4;
            button4.Text = "📜 ОБ ИГРЕ";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            button4.MouseLeave += button1_MouseLeave;
            button4.MouseMove += button1_MouseMove;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 561);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form2";
            Text = "КОСМИЧЕСКИЕ ЗАХВАТЧИКИ";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}