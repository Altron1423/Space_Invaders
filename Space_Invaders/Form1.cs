namespace Space_Invaders;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        //Фиксируем размер и внешний вид формы
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // Устанавливаем стартовую позицию (будет переопределено при открытии из Form1)
        this.StartPosition = FormStartPosition.Manual;

        button3.FlatAppearance.MouseOverBackColor = button3.BackColor;
        button2.FlatAppearance.MouseOverBackColor = button2.BackColor;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // Устанавливаем фокус на управляемый элемент
        player.Focus();
        KeyPreview = true;

        // Для PictureBox или Panel нужно установить:
        player.TabStop = true; // Разрешить получение фокуса
    }

    private void button1_Click(object sender, EventArgs e)
    {
        button1.Visible = false;
        player.Visible = true;
        button3.Visible = true;
        button2.Visible = true;
        button4.Visible = true;
    }

    private void player_KeyDown(object sender, KeyEventArgs e)
    {
        player.PlayerKeyDown(e);
    }
    private void player_KeyUp(object sender, KeyEventArgs e)
    {
        player.PlayerKeyUp(e);
    }

    private void button4_MouseMove(object sender, MouseEventArgs e)
    {
        Button bt = sender as Button;
        bt.BackColor = Color.DarkGreen;
        bt.ForeColor = Color.Black;
    }

    private void button4_MouseLeave(object sender, EventArgs e)
    {
        Button bt = sender as Button;
        bt.BackColor = Color.FromArgb(255, 0, 64, 0);
        bt.ForeColor = Color.White;
    }

    private void button4_Click(object sender, EventArgs e)
    {
        button4.Visible = false;
        button7.Visible = true;
        button5.Visible = true;
        button6.Visible = true;
    }

    private void button5_Click(object sender, EventArgs e)
    {
        button4.Visible = true;
        button7.Visible = false;
        button5.Visible = false;
        button6.Visible = false;
    }

    private void button6_Click(object sender, EventArgs e)
    {
        var otvet = MessageBox.Show("Вы уверены, что хотите завершить?", "Space Invaders", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (otvet == DialogResult.Yes)
        {
            Form2 form2 = new Form2();

            form2.StartPosition = FormStartPosition.Manual;
            form2.Location = new Point(
                this.Location.X + (this.Width - form2.Width) / 2,
                this.Location.Y + (this.Height - form2.Height) / 2
            );

            this.Hide();
            form2.ShowDialog();
            this.Close();
        }
    }
}