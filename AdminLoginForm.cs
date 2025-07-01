namespace Receipt
{
    public partial class AdminLoginForm : Form
    {
        public bool IsAuthenticated { get; private set; }

        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Şifre doğrulama işlemi
            string password = textBoxPassword.Text;

            if (password == "admin123") // Şifreyi istediğiniz gibi ayarlayabilirsiniz
            {
                IsAuthenticated = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Yanlış şifre. Lütfen tekrar deneyin.");
                textBoxPassword.Clear();
            }
        }
    }
}