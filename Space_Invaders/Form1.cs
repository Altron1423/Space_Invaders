namespace Space_Invaders;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
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
        Console.WriteLine("Hello world!");
    }

    private void player_KeyDown(object sender, KeyEventArgs e)
    {
        player.PlayerKeyDown(e);
    }
    private void player_KeyUp(object sender, KeyEventArgs e)
    {
        player.PlayerKeyUp(e);
    }
}