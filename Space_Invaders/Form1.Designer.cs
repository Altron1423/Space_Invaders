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
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(44, 50);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(141, 45);
        button1.TabIndex = 0;
        button1.TabStop = false;
        button1.Text = "Say hello";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // player1
        // 
        player1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        player1.Location = new System.Drawing.Point(0, 0);
        player1.Name = "player1";
        player1.Size = new System.Drawing.Size(148, 148);
        player1.TabIndex = 0;
        // 
        // player
        // 
        player.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        player.Location = new System.Drawing.Point(220, 750);
        player.Name = "player";
        player.Size = new System.Drawing.Size(160, 100);
        player.TabIndex = 1;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        ClientSize = new System.Drawing.Size(858, 840);
        Controls.Add(player);
        Controls.Add(button1);
        KeyPreview = true;
        Text = "Form1";
        Load += Form1_Load;
        KeyDown += player_KeyDown;
        KeyUp += player_KeyUp;
        ResumeLayout(false);
    }

    private Space_Invaders.Player player;

    private Space_Invaders.Player player1;

    private System.Windows.Forms.Button button1;

    #endregion
}