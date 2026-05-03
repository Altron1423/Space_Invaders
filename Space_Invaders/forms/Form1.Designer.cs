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
        start_button = new System.Windows.Forms.Button();
        player1 = new Space_Invaders.Player(components);
        player = new Space_Invaders.Player(components);
        left_fon = new System.Windows.Forms.Button();
        right_fon = new System.Windows.Forms.Button();
        pause_button = new System.Windows.Forms.Button();
        continue_button = new System.Windows.Forms.Button();
        exit_button = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // start_button
        // 
        start_button.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)64)), ((int)((byte)0)));
        start_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        start_button.ForeColor = System.Drawing.Color.White;
        start_button.Location = new System.Drawing.Point(239, 240);
        start_button.Name = "start_button";
        start_button.Size = new System.Drawing.Size(434, 76);
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
        player1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        player1.Location = new System.Drawing.Point(0, 0);
        player1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        player1.Name = "player1";
        player1.Size = new System.Drawing.Size(148, 148);
        player1.TabIndex = 0;
        // 
        // player
        // 
        player.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        player.Location = new System.Drawing.Point(397, 491);
        player.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        player.Name = "player";
        player.Size = new System.Drawing.Size(119, 69);
        player.TabIndex = 1;
        player.Visible = false;
        // 
        // left_fon
        // 
        left_fon.BackColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        left_fon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        left_fon.Location = new System.Drawing.Point(0, -5);
        left_fon.Name = "left_fon";
        left_fon.Size = new System.Drawing.Size(250, 574);
        left_fon.TabIndex = 2;
        left_fon.UseVisualStyleBackColor = false;
        left_fon.Visible = false;
        // 
        // right_fon
        // 
        right_fon.BackColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        right_fon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        right_fon.Location = new System.Drawing.Point(664, -5);
        right_fon.Name = "right_fon";
        right_fon.Size = new System.Drawing.Size(250, 574);
        right_fon.TabIndex = 3;
        right_fon.UseVisualStyleBackColor = false;
        right_fon.Visible = false;
        // 
        // pause_button
        // 
        pause_button.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)64)), ((int)((byte)0)));
        pause_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        pause_button.ForeColor = System.Drawing.Color.White;
        pause_button.Location = new System.Drawing.Point(12, 12);
        pause_button.Name = "pause_button";
        pause_button.Size = new System.Drawing.Size(47, 44);
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
        continue_button.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)64)), ((int)((byte)0)));
        continue_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        continue_button.ForeColor = System.Drawing.Color.White;
        continue_button.Location = new System.Drawing.Point(339, 195);
        continue_button.Name = "continue_button";
        continue_button.Size = new System.Drawing.Size(237, 70);
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
        exit_button.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)64)), ((int)((byte)0)));
        exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        exit_button.ForeColor = System.Drawing.Color.White;
        exit_button.Location = new System.Drawing.Point(339, 280);
        exit_button.Name = "exit_button";
        exit_button.Size = new System.Drawing.Size(237, 70);
        exit_button.TabIndex = 6;
        exit_button.Text = "ВЫХОД";
        exit_button.UseVisualStyleBackColor = false;
        exit_button.Visible = false;
        exit_button.Click += ButtonExit;
        exit_button.MouseLeave += button_MouseLeave;
        exit_button.MouseMove += button_MouseMove;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        BackColor = System.Drawing.Color.Black;
        ClientSize = new System.Drawing.Size(914, 561);
        Controls.Add(pause_button);
        Controls.Add(start_button);
        Controls.Add(exit_button);
        Controls.Add(continue_button);
        Controls.Add(right_fon);
        Controls.Add(left_fon);
        Controls.Add(player);
        Text = "КОСМИЧЕСКИЕ ЗАХВАТЧИКИ";
        Load += Form1_Load;
        KeyDown += player_KeyDown;
        KeyUp += player_KeyUp;
        ResumeLayout(false);
    }

    private Space_Invaders.Player player;

    private Space_Invaders.Player player1;

    private System.Windows.Forms.Button start_button;

    #endregion

    private System.Windows.Forms.Button left_fon;
    private System.Windows.Forms.Button right_fon;
    private Button pause_button;
    private Button continue_button;
    private Button exit_button;
}