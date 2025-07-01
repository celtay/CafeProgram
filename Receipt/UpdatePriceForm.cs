using System;
using System.Windows.Forms;
using static Receipt.Form1;

namespace Receipt
{
    public partial class UpdatePriceForm : Form
    {
        public string ProductName { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }

        public UpdatePriceForm(Product product)
        {
            InitializeComponent();
            ProductName = product.Name;
            OldPrice = product.Price;
            labelProductName.Text = ProductName;
            textBoxOldPrice.Text = OldPrice.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // Kullanıcı girdisindeki noktayı virgüle dönüştür
            string input = textBoxPrice.Text.Replace('.', ',');

            if (decimal.TryParse(input, out decimal newPrice))
            {
                NewPrice = newPrice;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Geçerli bir fiyat girin.");
            }
        }
    }
}
