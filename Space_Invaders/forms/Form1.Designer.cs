namespace Space_Invaders;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        components = new System.ComponentModel.Container();
        start_button = new Button();
        player1 = new Player(components);
        player = new Player(components);
        left_fon = new Button();
        right_fon = new Button();
        pause_button = new Button();
        continue_button = new Button();
        exit_button = new Button();
        timer1 = new System.Windows.Forms.Timer(components);
        label1 = new Label();
        progressBar1 = new CustomProgressBar();
        progressBar2 = new CustomProgressBar();
        progressBar3 = new CustomProgressBar();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        button1 = new Button();
        button2 = new Button();
        label5 = new Label();
        label6 = new Label();
        labelLevel = new Label();
        labelDificalty = new Label();
        SuspendLayout();
        // 
        // start_button
        // 
        start_button.BackColor = Color.FromArgb(0, 64, 0);
        start_button.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        start_button.ForeColor = Color.White;
        start_button.Location = new Point(239, 240);
        start_button.Name = "start_button";
        start_button.Size = new Size(434, 76);
        start_button.TabIndex = 0;
        start_button.TabStop = false;
        start_button.Text = "НАЖМИ, ЧТОБЫ НАЧАТЬ";
        start_button.UseVisualStyleBackColor = false;
        start_button.Click += RunGame;
        start_button.MouseLeave += button_MouseLeave;
        start_button.MouseMove += button_MouseMove;
        // 
        // player1
        // 
        player1.BorderStyle = BorderStyle.FixedSingle;
        player1.Location = new Point(0, 0);
        player1.Margin = new Padding(4, 5, 4, 5);
        player1.Name = "player1";
        player1.Size = new Size(148, 148);
        player1.TabIndex = 0;
        // 
        // player
        // 
        player.BorderStyle = BorderStyle.FixedSingle;
        player.Location = new Point(397, 491);
        player.Margin = new Padding(4, 5, 4, 5);
        player.Name = "player";
        player.Size = new Size(119, 69);
        player.TabIndex = 1;
        player.Visible = false;
        // 
        // left_fon
        // 
        left_fon.BackColor = Color.FromArgb(64, 64, 64);
        left_fon.FlatStyle = FlatStyle.Flat;
        left_fon.Location = new Point(-3, -5);
        left_fon.Name = "left_fon";
        left_fon.Size = new Size(250, 574);
        left_fon.TabIndex = 2;
        left_fon.UseVisualStyleBackColor = false;
        left_fon.Visible = false;
        // 
        // right_fon
        // 
        right_fon.BackColor = Color.FromArgb(64, 64, 64);
        right_fon.FlatStyle = FlatStyle.Flat;
        right_fon.Location = new Point(664, -5);
        right_fon.Name = "right_fon";
        right_fon.Size = new Size(250, 574);
        right_fon.TabIndex = 3;
        right_fon.UseVisualStyleBackColor = false;
        right_fon.Visible = false;
        // 
        // pause_button
        // 
        pause_button.BackColor = Color.FromArgb(0, 64, 0);
        pause_button.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        pause_button.ForeColor = Color.White;
        pause_button.Location = new Point(12, 12);
        pause_button.Name = "pause_button";
        pause_button.Size = new Size(47, 44);
        pause_button.TabIndex = 4;
        pause_button.Text = "||";
        pause_button.UseVisualStyleBackColor = false;
        pause_button.Visible = false;
        pause_button.Click += PauseClick;
        pause_button.MouseLeave += button_MouseLeave;
        pause_button.MouseMove += button_MouseMove;
        // 
        // continue_button
        // 
        continue_button.BackColor = Color.FromArgb(0, 64, 0);
        continue_button.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        continue_button.ForeColor = Color.White;
        continue_button.Location = new Point(339, 140);
        continue_button.Name = "continue_button";
        continue_button.Size = new Size(237, 70);
        continue_button.TabIndex = 5;
        continue_button.Text = "ПРОДОЛЖИТЬ";
        continue_button.UseVisualStyleBackColor = false;
        continue_button.Visible = false;
        continue_button.Click += ContinueClick;
        continue_button.MouseLeave += button_MouseLeave;
        continue_button.MouseMove += button_MouseMove;
        // 
        // exit_button
        // 
        exit_button.BackColor = Color.Maroon;
        exit_button.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        exit_button.ForeColor = Color.White;
        exit_button.Location = new Point(339, 368);
        exit_button.Name = "exit_button";
        exit_button.Size = new Size(237, 70);
        exit_button.TabIndex = 6;
        exit_button.Text = "ВЫХОД";
        exit_button.UseVisualStyleBackColor = false;
        exit_button.Visible = false;
        exit_button.Click += ButtonExit;
        exit_button.MouseLeave += exit_button_MouseLeave;
        exit_button.MouseMove += exit_button_MouseMove;
        // 
        // timer1
        // 
        timer1.Enabled = true;
        timer1.Interval = 20;
        timer1.Tick += timer1_Tick;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.BackColor = Color.FromArgb(64, 64, 64);
        label1.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.ForeColor = Color.FromArgb(192, 0, 0);
        label1.Location = new Point(688, 26);
        label1.Margin = new Padding(2, 0, 2, 0);
        label1.Name = "label1";
        label1.Size = new Size(174, 31);
        label1.TabIndex = 7;
        label1.Text = "❤️❤️❤️❤️❤️";
        label1.Visible = false;
        // 
        // progressBar1
        // 
        progressBar1.BackColor = Color.FromArgb(240, 240, 240);
        progressBar1.ForeColor = Color.Gray;
        progressBar1.Location = new Point(746, 76);
        progressBar1.Margin = new Padding(2);
        progressBar1.Name = "progressBar1";
        progressBar1.Size = new Size(105, 20);
        progressBar1.TabIndex = 8;
        progressBar1.Visible = false;
        // 
        // progressBar2
        // 
        progressBar2.BackColor = Color.FromArgb(240, 240, 240);
        progressBar2.ForeColor = Color.Gray;
        progressBar2.Location = new Point(746, 112);
        progressBar2.Margin = new Padding(2);
        progressBar2.Name = "progressBar2";
        progressBar2.Size = new Size(105, 20);
        progressBar2.TabIndex = 9;
        progressBar2.Visible = false;
        // 
        // progressBar3
        // 
        progressBar3.BackColor = Color.FromArgb(240, 240, 240);
        progressBar3.ForeColor = Color.Gray;
        progressBar3.Location = new Point(746, 149);
        progressBar3.Margin = new Padding(2);
        progressBar3.Name = "progressBar3";
        progressBar3.Size = new Size(105, 20);
        progressBar3.TabIndex = 10;
        progressBar3.Visible = false;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.BackColor = Color.FromArgb(64, 64, 64);
        label2.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
        label2.ForeColor = Color.FromArgb(0, 0, 192);
        label2.Location = new Point(680, 67);
        label2.Margin = new Padding(2, 0, 2, 0);
        label2.Name = "label2";
        label2.Size = new Size(54, 37);
        label2.TabIndex = 11;
        label2.Text = "⚡";
        label2.Visible = false;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.BackColor = Color.FromArgb(64, 64, 64);
        label3.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 204);
        label3.ForeColor = Color.FromArgb(192, 64, 0);
        label3.Location = new Point(687, 100);
        label3.Margin = new Padding(2, 0, 2, 0);
        label3.Name = "label3";
        label3.Size = new Size(46, 45);
        label3.TabIndex = 12;
        label3.Text = "✧";
        label3.Visible = false;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.BackColor = Color.FromArgb(64, 64, 64);
        label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        label4.ForeColor = Color.FromArgb(0, 192, 0);
        label4.Location = new Point(688, 145);
        label4.Margin = new Padding(2, 0, 2, 0);
        label4.Name = "label4";
        label4.Size = new Size(42, 30);
        label4.TabIndex = 13;
        label4.Text = "🛡️";
        label4.Visible = false;
        // 
        // button1
        // 
        button1.BackColor = Color.FromArgb(0, 64, 0);
        button1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button1.ForeColor = Color.White;
        button1.Location = new Point(339, 216);
        button1.Name = "button1";
        button1.Size = new Size(237, 70);
        button1.TabIndex = 14;
        button1.Text = "УПРАВЛЕНИЕ";
        button1.UseVisualStyleBackColor = false;
        button1.Visible = false;
        button1.Click += button1_Click;
        button1.MouseLeave += button_MouseLeave;
        button1.MouseMove += button_MouseMove;
        // 
        // button2
        // 
        button2.BackColor = Color.FromArgb(0, 64, 0);
        button2.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button2.ForeColor = Color.White;
        button2.Location = new Point(339, 292);
        button2.Name = "button2";
        button2.Size = new Size(237, 70);
        button2.TabIndex = 15;
        button2.Text = "ОБ ИГРЕ";
        button2.UseVisualStyleBackColor = false;
        button2.Visible = false;
        button2.Click += button2_Click;
        button2.MouseLeave += button_MouseLeave;
        button2.MouseMove += button_MouseMove;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.BackColor = Color.FromArgb(64, 64, 64);
        label5.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
        label5.ForeColor = Color.FromArgb(0, 192, 192);
        label5.Location = new Point(12, 149);
        label5.Name = "label5";
        label5.Size = new Size(130, 30);
        label5.TabIndex = 16;
        label5.Text = "🎯 СЧЁТ: 0 ";
        label5.Visible = false;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.BackColor = Color.FromArgb(64, 64, 64);
        label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
        label6.ForeColor = Color.FromArgb(192, 192, 0);
        label6.Location = new Point(12, 189);
        label6.Name = "label6";
        label6.Size = new Size(160, 30);
        label6.TabIndex = 17;
        label6.Text = "👑 РЕКОРД: 0 ";
        label6.Visible = false;
        // 
        // labelLevel
        // 
        labelLevel.AutoSize = true;
        labelLevel.BackColor = Color.FromArgb(64, 64, 64);
        labelLevel.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold);
        labelLevel.ForeColor = Color.White;
        labelLevel.Location = new Point(12, 77);
        labelLevel.Name = "labelLevel";
        labelLevel.Size = new Size(107, 23);
        labelLevel.TabIndex = 18;
        labelLevel.Text = "УРОВЕНЬ: 1";
        labelLevel.Visible = false;
        // 
        // labelDificalty
        // 
        labelDificalty.AutoSize = true;
        labelDificalty.BackColor = Color.FromArgb(64, 64, 64);
        labelDificalty.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold);
        labelDificalty.ForeColor = Color.LawnGreen;
        labelDificalty.Location = new Point(12, 112);
        labelDificalty.Name = "labelDificalty";
        labelDificalty.Size = new Size(172, 23);
        labelDificalty.TabIndex = 19;
        labelDificalty.Text = "СЛОЖНОТЬ: ЛЕГКО";
        labelDificalty.Visible = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        BackColor = Color.Black;
        ClientSize = new Size(914, 561);
        Controls.Add(labelDificalty);
        Controls.Add(labelLevel);
        Controls.Add(label5);
        Controls.Add(label6);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(exit_button);
        Controls.Add(continue_button);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(progressBar3);
        Controls.Add(progressBar2);
        Controls.Add(progressBar1);
        Controls.Add(label1);
        Controls.Add(pause_button);
        Controls.Add(start_button);
        Controls.Add(right_fon);
        Controls.Add(left_fon);
        Controls.Add(player);
        Name = "Form1";
        Text = "КОСМИЧЕСКИЕ ЗАХВАТЧИКИ";
        Load += Form1_Load;
        KeyDown += player_KeyDown;
        KeyUp += player_KeyUp;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label labelDificalty;

    private System.Windows.Forms.Label labelLevel;

    private System.Windows.Forms.Timer timer1;
    private Space_Invaders.Player player;
    private Space_Invaders.Player player1;
    private System.Windows.Forms.Button start_button;

    #endregion

    private System.Windows.Forms.Button left_fon;
    private System.Windows.Forms.Button right_fon;
    private Button pause_button;
    private Button continue_button;
    private Button exit_button;
    private Label label1;
    private CustomProgressBar progressBar1;
    private CustomProgressBar progressBar2;
    private CustomProgressBar progressBar3;
    private Label label2;
    private Label label3;
    private Label label4;
    private Button button1;
    private Button button2;
    private Label label5;
    private Label label6;
}