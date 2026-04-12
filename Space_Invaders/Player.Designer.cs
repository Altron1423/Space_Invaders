using System.ComponentModel;
using System.Runtime.InteropServices.Swift;

namespace Space_Invaders
{
    partial class Player
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;
    
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
    
        #region Component Designer generated code
    
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            
            
            SuspendLayout();
            // 
            // Player
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Name = "Player";
            Size = new Size(148, 148);
            Paint += PlayerDraw;
            // MouseClick += Krestik_MouseClick;
            KeyDown += PlayerKeyDown;
            KeyUp += PlayerKeyUp;
            ResumeLayout(false);

        }
    
        #endregion
    }
}

