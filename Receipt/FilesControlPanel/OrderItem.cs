using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Receipt
{
    public partial class OrderItem : UserControl
    {
        public string ProductName
        {
            get => lblProductName.Text;
            set => lblProductName.Text = value;
        }

        private decimal _price; // Özel alan

        public decimal Price
        {
            get => _price; // Değeri özel alandan al
            set
            {
                _price = value; // Değeri özel alana ata
                lblPrice.Text = _price.ToString("C", new System.Globalization.CultureInfo("tr-TR")); // Formatlı metin göster
            }
        }

        private decimal id_of_product;
        public decimal ID
        {
            get => id_of_product;

            set => id_of_product = value;
        }

        public event EventHandler RemoveClicked;

        public OrderItem()
        {
            InitializeComponent();
            this.Paint += OrderItem_Paint;
            btnRemove.Click += (s, e) => RemoveClicked?.Invoke(this, EventArgs.Empty);
        }

        private void OrderItem_Paint(object sender, PaintEventArgs e)
        {

            // Yuvarlak köşeler için dikdörtgenin radyusunu belirleyin
            int cornerRadius = 20;

            // Gradient renklerini tanımlayın
            // Color color1 = Color.FromArgb(249, 130, 68); // Açık yeşil
            // Color color2 = Color.FromArgb(247, 72, 115);  // Koyu yeşil

            // Yuvarlak köşe yolu oluştur
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); // Sol üst köşe
            path.AddArc(this.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Sağ üst köşe
            path.AddArc(this.Width - cornerRadius, this.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Sağ alt köşe
            path.AddArc(0, this.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Sol alt köşe
            path.CloseFigure();

            // Arka planı gradient ile doldur
            // using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, color1, color2, LinearGradientMode.Vertical))
            //{
            //    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //    e.Graphics.FillPath(brush, path);
            //}

            // Yuvarlak köşe bölgesini ayarla
            this.Region = new Region(path);
        }
    }
}
