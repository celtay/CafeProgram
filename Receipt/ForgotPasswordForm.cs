using System;
using System.IO;
using System.Windows.Forms;

namespace Receipt
{
    public partial class ForgotPasswordForm : Form
    {
        private const string PasswordDirectory = "Files";
        private const string PasswordFilePath = "Files/password.txt";
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void buttonUpdatePassword_Click(object sender, EventArgs e)
        {
            if (textBoxAdminCode.Text == "AdminAdmin")
            {
                string newPassword = textBoxNewPassword.Text;
                SavePassword(newPassword);
                MessageBox.Show("Şifre başarıyla güncellendi.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Geçersiz Admin Kodu.");
            }
        }

        private void SavePassword(string password)
        {
            EnsurePasswordDirectoryExists();
            File.WriteAllText(PasswordFilePath, password);
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
