using System.ComponentModel;


namespace Space_Invaders
{
    public partial class Player : UserControl
    {
        // int state = 0; // -1 - krest  1 - null

        private int _speed = 10;
        private int _moveOrientation = 0;
        private bool _keyAPress = false, _keyDPress = false;
        
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

        private void Moving()
        {
            if (_moveOrientation == -1)
            {
                if (Left > _speed)
                    Left -= _speed;
            }
            else if (_moveOrientation == 1)
            {
                if (Left < Form.ActiveForm.Width - Width - _speed*3)
                    Left += _speed;
            }
        }

        public void PlayerKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                _moveOrientation++;
                _keyAPress = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                _moveOrientation--;
                _keyDPress = false;
            }
        }
        
        public void PlayerKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && !_keyAPress)
            {
                _keyAPress = true;
                _moveOrientation--;
            }
            else if (e.KeyCode == Keys.D && !_keyDPress)
            {
                _keyDPress = true;
                _moveOrientation++;
            }
            else if (e.KeyCode == Keys.Space)
            {
                Console.WriteLine($"Shoot {Left + Width / 2}");
            }

            Moving();
        }
        
    }
}

