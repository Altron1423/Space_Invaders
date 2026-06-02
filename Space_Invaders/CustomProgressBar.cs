using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Space_Invaders
{
    public class CustomProgressBar : ProgressBar
    {
        private Color _progressColor = Color.Gray;
        private int _currentValue = 0;

        [Category("Appearance")]
        [Description("Цвет заполнения прогресс-бара")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Gray")]
        public Color ProgressColor
        {
            get { return _progressColor; }
            set
            {
                _progressColor = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int Value
        {
            get { return _currentValue; }
            set
            {
                int newValue = Math.Max(0, Math.Min(value, Maximum));
                if (newValue != _currentValue)
                {
                    _currentValue = newValue;
                    Invalidate();
                    base.Value = _currentValue;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int Maximum
        {
            get { return base.Maximum; }
            set
            {
                base.Maximum = value;
                if (_currentValue > value)
                {
                    Value = value;
                }
                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int Minimum
        {
            get { return base.Minimum; }
            set
            {
                base.Minimum = value;
                Invalidate();
            }
        }

        public CustomProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(240, 240, 240);

            _progressColor = Color.Gray;
            _currentValue = 0;
            base.Value = 0;
            base.Maximum = 100;
            base.Minimum = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                g.FillRectangle(brush, rect);
            }

            if (_currentValue > 0 && this.Maximum > 0)
            {
                int width = (int)(rect.Width * ((double)_currentValue / this.Maximum));
                if (width > 0)
                {
                    Rectangle progressRect = new Rectangle(rect.X, rect.Y, width, rect.Height);
                    using (SolidBrush brush = new SolidBrush(_progressColor))
                    {
                        g.FillRectangle(brush, progressRect);
                    }
                }
            }

            //using (Pen pen = new Pen(Color.Gray, 1))
            //{
            //    g.DrawRectangle(pen, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
            //}
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            Invalidate();
        }
    }
}