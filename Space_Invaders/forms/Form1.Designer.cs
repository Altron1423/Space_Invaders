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
        progressBar1 = new ProgressBar();
        progressBar2 = new ProgressBar();
        progressBar3 = new ProgressBar();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        SuspendLayout();
        // 
        // start_button
        // 
        start_button.BackColor = Color.FromArgb(0, 64, 0);
        start_button.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        start_button.ForeColor = Color.White;
        start_button.Location = new Point(341, 400);
        start_button.Margin = new Padding(4, 5, 4, 5);
        start_button.Name = "start_button";
        start_button.Size = new Size(620, 127);
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
        player.Location = new Point(567, 818);
        player.Margin = new Padding(6, 8, 6, 8);
        player.Name = "player";
        player.Size = new Size(169, 114);
        player.TabIndex = 1;
        player.Visible = false;
        // 
        // left_fon
        // 
        left_fon.BackColor = Color.FromArgb(64, 64, 64);
        left_fon.FlatStyle = FlatStyle.Flat;
        left_fon.Location = new Point(0, -8);
        left_fon.Margin = new Padding(4, 5, 4, 5);
        left_fon.Name = "left_fon";
        left_fon.Size = new Size(357, 957);
        left_fon.TabIndex = 2;
        left_fon.UseVisualStyleBackColor = false;
        left_fon.Visible = false;
        // 
        // right_fon
        // 
        right_fon.BackColor = Color.FromArgb(64, 64, 64);
        right_fon.FlatStyle = FlatStyle.Flat;
        right_fon.Location = new Point(949, -8);
        right_fon.Margin = new Padding(4, 5, 4, 5);
        right_fon.Name = "right_fon";
        right_fon.Size = new Size(357, 957);
        right_fon.TabIndex = 3;
        right_fon.UseVisualStyleBackColor = false;
        right_fon.Visible = false;
        // 
        // pause_button
        // 
        pause_button.BackColor = Color.FromArgb(0, 64, 0);
        pause_button.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        pause_button.ForeColor = Color.White;
        pause_button.Location = new Point(17, 20);
        pause_button.Margin = new Padding(4, 5, 4, 5);
        pause_button.Name = "pause_button";
        pause_button.Size = new Size(67, 73);
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
        continue_button.Location = new Point(484, 325);
        continue_button.Margin = new Padding(4, 5, 4, 5);
        continue_button.Name = "continue_button";
        continue_button.Size = new Size(339, 117);
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
        exit_button.BackColor = Color.FromArgb(0, 64, 0);
        exit_button.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        exit_button.ForeColor = Color.White;
        exit_button.Location = new Point(484, 467);
        exit_button.Margin = new Padding(4, 5, 4, 5);
        exit_button.Name = "exit_button";
        exit_button.Size = new Size(339, 117);
        exit_button.TabIndex = 6;
        exit_button.Text = "ВЫХОД";
        exit_button.UseVisualStyleBackColor = false;
        exit_button.Visible = false;
        exit_button.Click += ButtonExit;
        exit_button.MouseLeave += button_MouseLeave;
        exit_button.MouseMove += button_MouseMove;
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
        label1.Font = new Font("Showcard Gothic", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.ForeColor = Color.FromArgb(192, 0, 0);
        label1.Location = new Point(983, 43);
        label1.Name = "label1";
        label1.Size = new Size(166, 50);
        label1.TabIndex = 7;
        label1.Text = "❤️❤️❤️";
        label1.Visible = false;
        // 
        // progressBar1
        // 
        progressBar1.BackColor = SystemColors.Highlight;
        progressBar1.Location = new Point(1066, 127);
        progressBar1.Name = "progressBar1";
        progressBar1.Size = new Size(150, 34);
        progressBar1.Style = ProgressBarStyle.Continuous;
        progressBar1.TabIndex = 8;
        progressBar1.Visible = false;
        // 
        // progressBar2
        // 
        progressBar2.BackColor = Color.FromArgb(255, 192, 128);
        progressBar2.ForeColor = Color.FromArgb(255, 192, 128);
        progressBar2.Location = new Point(1066, 186);
        progressBar2.Name = "progressBar2";
        progressBar2.Size = new Size(150, 34);
        progressBar2.TabIndex = 9;
        progressBar2.Visible = false;
        // 
        // progressBar3
        // 
        progressBar3.BackColor = Color.FromArgb(128, 255, 128);
        progressBar3.ForeColor = Color.FromArgb(128, 255, 128);
        progressBar3.Location = new Point(1066, 248);
        progressBar3.Name = "progressBar3";
        progressBar3.Size = new Size(150, 34);
        progressBar3.TabIndex = 10;
        progressBar3.Visible = false;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.BackColor = Color.FromArgb(64, 64, 64);
        label2.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
        label2.ForeColor = Color.FromArgb(0, 0, 192);
        label2.Location = new Point(972, 112);
        label2.Name = "label2";
        label2.Size = new Size(78, 54);
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
        label3.Location = new Point(983, 166);
        label3.Name = "label3";
        label3.Size = new Size(67, 65);
        label3.TabIndex = 12;
        label3.Text = "✧";
        label3.Visible = false;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.BackColor = Color.FromArgb(64, 64, 64);
        label4.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
        label4.ForeColor = Color.FromArgb(0, 192, 0);
        label4.Location = new Point(982, 231);
        label4.Name = "label4";
        label4.Size = new Size(78, 54);
        label4.TabIndex = 13;
        label4.Text = "🛡️";
        label4.Visible = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        BackColor = Color.Black;
        ClientSize = new Size(1306, 935);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(progressBar3);
        Controls.Add(progressBar2);
        Controls.Add(progressBar1);
        Controls.Add(label1);
        Controls.Add(pause_button);
        Controls.Add(start_button);
        Controls.Add(exit_button);
        Controls.Add(continue_button);
        Controls.Add(right_fon);
        Controls.Add(left_fon);
        Controls.Add(player);
        Margin = new Padding(4, 5, 4, 5);
        Name = "Form1";
        Text = "КОСМИЧЕСКИЕ ЗАХВАТЧИКИ";
        Load += Form1_Load;
        KeyDown += player_KeyDown;
        KeyUp += player_KeyUp;
        ResumeLayout(false);
        PerformLayout();
    }

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
    private ProgressBar progressBar1;
    private ProgressBar progressBar2;
    private ProgressBar progressBar3;
    private Label label2;
    private Label label3;
    private Label label4;
}