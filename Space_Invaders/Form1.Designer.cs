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
        button1 = new System.Windows.Forms.Button();
        player1 = new Space_Invaders.Player(components);
        player = new Space_Invaders.Player(components);
        button2 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        button4 = new System.Windows.Forms.Button();
        button5 = new System.Windows.Forms.Button();
        button6 = new System.Windows.Forms.Button();
        button7 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)64)), ((int)((byte)0)));
        button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button1.ForeColor = System.Drawing.Color.White;
        button1.Location = new System.Drawing.Point(239, 240);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(434, 76);
        button1.TabIndex = 0;
        button1.TabStop = false;
        button1.Text = "НАЖМИ, ЧТОБЫ НАЧАТЬ";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        button1.MouseLeave += button4_MouseLeave;
        button1.MouseMove += button4_MouseMove;
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
        // button2
        // 
        button2.BackColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        button2.Location = new System.Drawing.Point(-7, -5);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(250, 574);
        button2.TabIndex = 2;
        button2.UseVisualStyleBackColor = false;
        button2.Visible = false;
        // 
        // button3
        // 
        button3.BackColor = System.Drawing.Color.FromArgb(((int)((byte)64)), ((int)((byte)64)), ((int)((byte)64)));
        button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        button3.Location = new System.Drawing.Point(669, -5);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(250, 574);
        button3.TabIndex = 3;
        button3.UseVisualStyleBackColor = false;
        button3.Visible = false;
        // 
        // button4
        // 
        button4.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)64)), ((int)((byte)0)));
        button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button4.ForeColor = System.Drawing.Color.White;
        button4.Location = new System.Drawing.Point(12, 12);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(47, 44);
        button4.TabIndex = 4;
        button4.Text = "||";
        button4.UseVisualStyleBackColor = false;
        button4.Visible = false;
        button4.Click += button4_Click;
        button4.MouseLeave += button4_MouseLeave;
        button4.MouseMove += button4_MouseMove;
        // 
        // button5
        // 
        button5.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)64)), ((int)((byte)0)));
        button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button5.ForeColor = System.Drawing.Color.White;
        button5.Location = new System.Drawing.Point(339, 195);
        button5.Name = "button5";
        button5.Size = new System.Drawing.Size(237, 70);
        button5.TabIndex = 5;
        button5.Text = "ПРОДОЛЖИТЬ";
        button5.UseVisualStyleBackColor = false;
        button5.Visible = false;
        button5.Click += button5_Click;
        button5.MouseLeave += button4_MouseLeave;
        button5.MouseMove += button4_MouseMove;
        // 
        // button6
        // 
        button6.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)64)), ((int)((byte)0)));
        button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button6.ForeColor = System.Drawing.Color.White;
        button6.Location = new System.Drawing.Point(339, 280);
        button6.Name = "button6";
        button6.Size = new System.Drawing.Size(237, 70);
        button6.TabIndex = 6;
        button6.Text = "ВЫХОД";
        button6.UseVisualStyleBackColor = false;
        button6.Visible = false;
        button6.Click += button6_Click;
        button6.MouseLeave += button4_MouseLeave;
        button6.MouseMove += button4_MouseMove;
        // 
        // button7
        // 
        button7.BackColor = System.Drawing.Color.Maroon;
        button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        button7.ForeColor = System.Drawing.Color.White;
        button7.Location = new System.Drawing.Point(12, 12);
        button7.Name = "button7";
        button7.Size = new System.Drawing.Size(47, 44);
        button7.TabIndex = 7;
        button7.Text = "||";
        button7.UseVisualStyleBackColor = false;
        button7.Visible = false;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        BackColor = System.Drawing.Color.Black;
        ClientSize = new System.Drawing.Size(914, 561);
        Controls.Add(button7);
        Controls.Add(button4);
        Controls.Add(button1);
        Controls.Add(button6);
        Controls.Add(button5);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(player);
        Text = "КОСМИЧЕСКИЕ ЗАХВАТЧИКИ";
        Load += Form1_Load;
        KeyDown += player_KeyDown;
        KeyUp += player_KeyUp;
        ResumeLayout(false);
    }

    private Space_Invaders.Player player;

    private Space_Invaders.Player player1;

    private System.Windows.Forms.Button button1;

    #endregion

    private Button button2;
    private System.Windows.Forms.Button button3;
    private Button button4;
    private Button button5;
    private Button button6;
    private Button button7;
}