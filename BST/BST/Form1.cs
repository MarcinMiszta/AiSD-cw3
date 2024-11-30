namespace BST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BST BST = new BST();
        private void button1_Click(object sender, EventArgs e)
        {
            BST.Add(liczba);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BST.Remove(liczbaRemove);
        }
        int liczba;
        int liczbaRemove;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                liczba = int.Parse(textBox1.Text);
            }
            catch
            {
                liczba = 0;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                liczbaRemove = int.Parse(textBox2.Text);
            }
            catch
            {
                liczbaRemove = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = BST.WypiszDrzewo();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}