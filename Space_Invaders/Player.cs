using System.ComponentModel;


namespace Space_Invaders
{
    public partial class Player : UserControl
    {
        // int state = 0; // -1 - krest  1 - null
        
        int speed=10;
        private int move_orientetion = 0;
        bool key_A_press = false, key_D_press = false;
        
        public Player()
        {
            InitializeComponent();
        }
    
        public Player(IContainer container)
        {
            container.Add(this);
    
            InitializeComponent();
            
            
        }
        
        
        private void PlayerDraw(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.FillRectangle(Brushes.Green, 0, 0, Width - 1, Height - 1);
        }

        private void PlayerMoving()
        {
            if (move_orientetion == -1)
            {
                if (Left > speed)
                    Left -= speed;
            }
            else if (move_orientetion == 1)
            {
                if (Left < Form.ActiveForm.Width - Width - speed*3)
                    Left += speed;
            }
        }

        private void PlayerKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                move_orientetion++;
                key_A_press = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                move_orientetion--;
                key_D_press = false;
            }
        }
        
        private void PlayerKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && !key_A_press)
            {
                key_A_press = true;
                move_orientetion--;
            }
            else if (e.KeyCode == Keys.D && !key_D_press)
            {
                key_D_press = true;
                move_orientetion++;
            }
            else if (e.KeyCode == Keys.Space)
            {
                Console.WriteLine($"Shoot {Left + Width / 2}");
            }
        }
        
    }
}

