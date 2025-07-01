using System.Windows.Forms;

namespace Receipt.MenuScreenDatas
{
    public partial class menuproduct : UserControl
    {
        public string ProductNameM
        {
            get { return productnamemenu.Text; }
            set { productnamemenu.Text = value; }
        }

        public decimal ProductPriceM
        {
            get { return decimal.Parse(labelpricemenu.Controls[0].Text); }
            set { labelpricemenu.Text = value.ToString("C"); }
        }

        public string ImagePathM
        {
            get { return imagebutton.Image == null ? string.Empty : imagebutton.Image.Tag.ToString(); }
            set
            {
                imagebutton.Image = System.Drawing.Image.FromFile(value);
                imagebutton.Image.Tag = value; // Image path'i saklamak için Tag özelliğini kullanıyoruz
                imagebutton.ImageSize = new System.Drawing.Size(imagebutton.Width - 10, imagebutton.Height - 1); // Resmi buton boyutuna göre ayarla
                imagebutton.ImageAlign = HorizontalAlignment.Center; // Resmi butonun ortasına hizala
            }
        }
        public menuproduct()
        {
            InitializeComponent();
        }
    }
}
