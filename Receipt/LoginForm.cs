using System;
using System.IO;
using System.Windows.Forms;

namespace Receipt
{
    public partial class LoginForm : Form
    {
        private const string PasswordDirectory = "Files";
        private const string PasswordFilePath = "Files/password.txt";
        public bool IsAuthenticated { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            ForgotPasswordForm forgotPasswordForm = new ForgotPasswordForm();
            forgotPasswordForm.ShowDialog();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Şifre doğrulama işlemi
            string password = textBoxPassword.Text;
            string savedPassword = LoadPassword();

            if (password == savedPassword)
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

        private void SavePassword(string password)
        {
            EnsurePasswordDirectoryExists();
            File.WriteAllText(PasswordFilePath, password);
        }

        private string LoadPassword()
        {
            EnsurePasswordDirectoryExists();
            if (File.Exists(PasswordFilePath))
            {
                return File.ReadAllText(PasswordFilePath);
            }
            else
            {
                return "AdminAdmin"; // Varsayılan şifre
            }
        }

        private void EnsurePasswordDirectoryExists()
        {
            if (!Directory.Exists(PasswordDirectory))
            {
                Directory.CreateDirectory(PasswordDirectory);
            }
        }
    }
}
