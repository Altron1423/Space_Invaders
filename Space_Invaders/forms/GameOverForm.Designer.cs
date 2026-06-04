namespace Space_Invaders.forms
{
    partial class GameOverForm
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
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)64)), ((int)((byte)0)));
            button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            button1.ForeColor = System.Drawing.Color.White;
            button1.Location = new System.Drawing.Point(242, 424);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(111, 49);
            button1.TabIndex = 0;
            button1.Text = "Да";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.MouseLeave += button1_MouseLeave;
            button1.MouseMove += button1_MouseMove;
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.Maroon;
            button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            button2.ForeColor = System.Drawing.Color.White;
            button2.Location = new System.Drawing.Point(530, 424);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(111, 49);
            button2.TabIndex = 1;
            button2.Text = "Нет";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            button2.MouseLeave += button_MouseLeave;
            button2.MouseMove += button_MouseMove;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)204));
            label1.ForeColor = System.Drawing.Color.Red;
            label1.Location = new System.Drawing.Point(227, 207);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(452, 55);
            label1.TabIndex = 2;
            label1.Text = "💀 Игра окончена!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(362, 376);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(171, 29);
            label2.TabIndex = 3;
            label2.Text = "Продолжить?";
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Segoe UI", 30F);
            label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            label3.Location = new System.Drawing.Point(307, 283);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(287, 56);
            label3.TabIndex = 4;
            label3.Text = "Счёт: 0";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameOverForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(914, 561);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label label3;

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
    }
}